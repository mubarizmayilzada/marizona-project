using Marizona.WebUI.Models.DataContexts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;



namespace Marizona.WebUI.Core.Provider
{
    public class AppClaimProvider : IClaimsTransformation
    {
        readonly MarizonaDbContext db;
        public AppClaimProvider(MarizonaDbContext db)
        {
            this.db = db;
        }

        //bir user/admin ve s.'de claimlerini deyisende gerek sistemden cixsin yeniden daxil olsun ki
        //deyisiklikler tetbiq olunsun. Bunun qarsisini bele aliriq: Her requestde artiq deyisiklikler
        //yoxlanilir
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            if (principal.Identity.IsAuthenticated //eger login olunubsa
                && principal.Identity is ClaimsIdentity cIdentity)
            //cast prosesi

            {
                //claimleri silmek
                while (cIdentity.Claims.Any(c => !c.Type.StartsWith("http") && !c.Type.StartsWith("Asp"))) //icindeki butun claimler bosalana qeder
                {
                    var claims = cIdentity.Claims.First(c => !c.Type.StartsWith("http") && !c.Type.StartsWith("Asp"));
                    cIdentity.RemoveClaim(claims);  //her defe birincini goturub silir

                }

                //userin idsini gotururuk (claimlerini ve rolun veridyi claimleri tapmaq ucun)
                var userId = Convert.ToInt32(cIdentity.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value);
                var claimNames = new List<string>();  //db'deki yeni claimlerin yigildigi yer

                //oz yeni claimlerini goturmek
                string[] lst = db.UserClaims.Where(c => c.UserId == userId && c.ClaimValue.Equals("1")).Select(c => c.ClaimType).ToArray();
                claimNames.AddRange(lst);

                //rolun verdiyi yeni claimleri goturmek
                string[] rClaims = (from ur in db.UserRoles
                                    join rc in db.RoleClaims on ur.RoleId equals rc.RoleId
                                    where ur.UserId == userId && rc.ClaimValue.Equals("1")
                                    select rc.ClaimType).ToArray();
                claimNames.AddRange(rClaims);


                //yeni claimleri doldurmaq
                foreach (var item in claimNames)
                {
                    cIdentity.AddClaim(new Claim(item, "1"));
                }

            }

            return principal;
        }
    }
}
