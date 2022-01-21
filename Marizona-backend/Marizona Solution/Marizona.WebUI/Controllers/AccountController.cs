using Marizona.WebUI.Core.Extensions;
using Marizona.WebUI.Models.DataContexts;
using Marizona.WebUI.Models.Entities.Membership;
using Marizona.WebUI.Models.FormModels;
using Marizona.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marizona.WebUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        readonly UserManager<MarizonaUser> userManager;
        readonly SignInManager<MarizonaUser> signInManager;
        readonly RoleManager<MarizonaRole> roleManager;
        readonly IConfiguration configuration;
        readonly MarizonaDbContext db;
        public AccountController(UserManager<MarizonaUser> userManager,
                                 SignInManager<MarizonaUser> signInManager,
                                 RoleManager<MarizonaRole> roleManager,
                                 IConfiguration configuration,
                                 MarizonaDbContext db)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
            this.db = db;
        }

       // [Authorize(Policy = "account.index")]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult SignIn()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {

            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index));

        }


        [HttpPost]
        public async Task<IActionResult> SignIn(LoginFormModel user)
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

                if (foundedUser == null || !await userManager.IsInRoleAsync(foundedUser, "User"))
                {
                    ViewBag.Message = "Your username or password is incorrect!";
                    return View(user);
                }

                //if(!await userManager.IsInRoleAsync(foundedUser, "User"))
                //{
                //    ViewBag.Message = "Your username or password is incorrect!";
                //    return View(user);
                //}

                if (!await userManager.IsEmailConfirmedAsync(foundedUser))
                {
                    ViewBag.Message = "Please,confirm your email!";
                    return View(user);
                }

                var sResult = await signInManager.PasswordSignInAsync(foundedUser, user.Password, true, true);

                if (sResult.Succeeded != true)
                {
                    ViewBag.Message = "Your username or password is incorrect!";
                    return View(user);
                }

                var redirectUrl = Request.Query["ReturnUrl"];
                if (!string.IsNullOrWhiteSpace(redirectUrl))
                {
                    return Redirect(redirectUrl);
                }

                return RedirectToAction("Index", "Home");
            }
            ViewBag.Message = "Your username or password is incorrect!";
            return View();
        }



        //[Authorize(Policy = "account.register")]
        //[Route("register.html")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel register)
        {

            //Eger giris edibse routda myaccount/sing yazanda o seyfe acilmasin homa tulaasin
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "Home");

            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            //Yeni user yaradiriq.
            MarizonaUser user = new MarizonaUser
            {

                UserName = register.UserName,
                Email = register.Email,
                EmailConfirmed=true
            };



            string token = $"subscribetoken-{register.UserName}-{DateTime.Now:yyyyMMddHHmmss}"; // token yeni id goturuk

            token = token.Encrypt("");

            string path = $"{Request.Scheme}://{Request.Host}/subscribe-confirmm?token={token}"; // path duzeldirik



            var mailSended = configuration.SendEmail(user.Email, "BeluqaTahir", $"Zehmet olmasa <a href={path}>Link</a> vasitesile abuneliyi tamamlayin");


            var person = await userManager.FindByNameAsync(user.UserName);


            if (person == null)
            {
                //Burda biz userManager vasitesile user ve RegistirVM passwword yoxluyuruq.(yaradiriq)
                var identityRuselt = await userManager.CreateAsync(user, register.Password);


                //Startupda yazdigimiz qanunlara uymursa Configure<IdentityOptions> onda error qaytariq summary ile.;
                if (!identityRuselt.Succeeded)
                {
                    foreach (var error in identityRuselt.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

                //Yratdigimiz user ilk yarananda user rolu verik.

                await userManager.AddToRoleAsync(user, "User");

                return RedirectToAction("SignIn", "Account");

            }


            if (person.UserName != null)
            {
                ViewBag.ms = "Bu username evvelceden qeydiyyatdan kecib";

                return View(register);
            }
            return null;

        }




        //[Route("email-confirm")]
        //[Authorize(Policy = "account.emailconfirm")]
        public async Task<IActionResult> EmailConfirm(string email, string token)
        {
            var user = userManager.FindByEmailAsync(email).Result;
            if (user == null)
            {
                ViewBag.Message = "Token error!";
                return View();
            }

            token = token.Replace(" ", "+");

            if (user.EmailConfirmed == true)
            {
                ViewBag.Message = "You have already confirmed.";
                return View();
            }

            IdentityResult result = await userManager.
                        ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                ViewBag.Message = "We're excited to have you get started. Your account is confirmed successfully.";
                return View();
            }
            else
            {
                ViewBag.Message = "Error while confirming your email!";
                return View();
            }

            //    token = token.Decrypt();

            //    Match match =Regex.Match(token, @"emailconfirmtoken-(?<id>\d+)-(?<executeTimeStamp>\d{14})");

            //    if (match.Success)
            //    {
            //        long id = Convert.ToInt64(match.Groups["id"].Value);
            //        string executeTimeStamp = match.Groups["executeTimeStamp"].Value;

            //        var user = db.Users.FirstOrDefault(u => u.Id == id);

            //        if (user == null)
            //        {
            //            ViewBag.Message = "Token error!";
            //            goto end;
            //        }
            //        if (user.EmailConfirmed == true)
            //        {
            //            ViewBag.Message = "You have already confirmed.";
            //            goto end;
            //        }
            //        user.EmailConfirmed = true;
            //        db.SaveChanges();
            //        ViewBag.Message = "We're excited to have you get started. Your account is confirmed successfully.";

            //    }
            //    else
            //    {
            //        ViewBag.Message = "Wrong Application!";
            //    }
            //end:
            //    return View();
        }

        [Authorize(Policy = "account.signout")]
        public async Task<IActionResult> Signout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(SignIn));
        }

       // [Authorize(Policy = "account.wishlist")]
        public IActionResult Wishlist()
        {
            return View();
        }

        //[Authorize(Policy = "account.profile")]
        public IActionResult Profile()
        {
            return View();
        }



        //  [Route("accessdenied.html")]
        public IActionResult Accessdenied()
        {
            return View();
        }

    }
}


