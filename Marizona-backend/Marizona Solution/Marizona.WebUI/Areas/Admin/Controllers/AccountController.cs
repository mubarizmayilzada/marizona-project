using Marizona.WebUI.Models.DataContexts;
using Marizona.WebUI.Models.Entities.Membership;
using Marizona.WebUI.Models.FormModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marizona.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class AccountController : Controller
    {
        readonly UserManager<MarizonaUser> userManager;
        readonly SignInManager<MarizonaUser> signInManager;
        readonly MarizonaDbContext db;
        public AccountController(UserManager<MarizonaUser> userManager,
                                 SignInManager<MarizonaUser> signInManager,
                                 MarizonaDbContext db)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.db = db;
        }

        //[Authorize(Policy = "admin.account.login")]
        [Route("admin/signin.html")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //[Authorize(Policy = "admin.account.login")]
        [Route("admin/signin.html")]
        public async Task<IActionResult> Login(LoginFormModel user)
        {
            if (ModelState.IsValid)
            {
                MarizonaUser foundedUser = null;
                if (user.UserName.IsEmail() == true)
                {
                    foundedUser = await userManager.FindByEmailAsync(user.UserName);
                }
                else
                {
                    foundedUser = await userManager.FindByNameAsync(user.UserName);
                }

                if (foundedUser == null)
                {
                    ViewBag.Message = "Your username or password is incorrect!";
                    return View(user);
                }


                //gelen userin butun rollarini gotur
                var rIds = db.UserRoles.Where(ur => ur.UserId == foundedUser.Id).Select(ur => ur.RoleId).ToArray();

                //User olmayan  rollari tapirig bidene de olsa varsa bize besdi
                var hasAnotherRole = db.Roles.Where(r => !r.NormalizedName.Equals("USER") && rIds.Contains(r.Id)).Any();

                //demeli bu user adiynan admine girmek istiyir
                if (hasAnotherRole == false)
                {
                    ViewBag.Message = "Your username or password is incorrect!";
                    return View(user);
                }

                var sResult = await signInManager.PasswordSignInAsync(foundedUser, user.Password, true, true);

                if (sResult.Succeeded != true)
                {
                    ViewBag.Message = "Your username or password is incorrect!";
                    return View(user);
                }

                return RedirectToAction("Index", "Dashboard");
            }
            ViewBag.Message = "Your username or password is incorrect!";
            return View();
        }

        [Authorize(Policy = "admin.account.register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "admin.account.register")]
        public IActionResult Register(LoginFormModel user)
        {
            return View();
        }

        [Authorize(Policy = "admin.account.logout")]
        [Route("admin/logout.html")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        [Authorize(Policy = "admin.account.forgotpass")]
        public IActionResult ForgotPass()
        {
            return View();
        }
    }
}
