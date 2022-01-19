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

            [Authorize(Policy = "account.index")]
            public IActionResult Index()
            {
                return View();
            }

            [Authorize(Policy = "account.signin")]
            [Route("signin.html")]
            public IActionResult SignIn()
            {
                return View();
            }

        [Authorize(Policy = "account.register")]
        [Route("register.html")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("signin.html")]
        [Authorize(Policy = "account.signin")]
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



        [Authorize(Policy = "account.register")]
        [HttpPost]
        [Route("register.html")]
        public async Task<IActionResult> Register(RegisterFormModel user)
        {
            if (ModelState.IsValid)
            {
                db.Database.BeginTransaction();
                var username = await userManager.FindByNameAsync(user.UserName);
                var email = await userManager.FindByEmailAsync(user.Email);

                if (username != null) {
                    ViewBag.Message = "Your username is already used!";
                    return View(user);                
                }



                //return Json(new
                //    {
                //        error = true,
                //        message = "Your username is already used!"
                //    });

                if (email != null)
                {
                    ViewBag.Message = "Your email is already registered!";
                    return View(user);
                }



                    //return Json(new
                    //{
                    //    error = true,
                    //    message = "Your email is already registered!"
                    //});

                MarizonaRole MarizonaRole = new MarizonaRole
                {
                    Name = "User"
                };



                if (!roleManager.RoleExistsAsync(MarizonaRole.Name).Result)
                {
                    var createRole = roleManager.CreateAsync(MarizonaRole).Result;
                    if (!createRole.Succeeded)
                    {

                        ViewBag.Message = "Error, please try again!";
                        return View(user);
                        //return Json(new
                        //{
                        //    error = true,
                        //    message = "Error, please try again!"
                        //});
                    }
                }
                else
                {
                    //todo
                    //var role = roleManager.FindByNameAsync(MarizonaRole.Name).Result;

                }

                string password = user.Password;
                var MarizonaUser = new MarizonaUser()
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    EmailConfirmed = false
                };
                //password 3den yxuari olmaliid
                var createdUser = userManager.CreateAsync(MarizonaUser, password).Result;

                if (createdUser.Succeeded)
                {
                    userManager.AddToRoleAsync(MarizonaUser, MarizonaRole.Name).Wait();

                    //string token = $"emailconfirmtoken-{MarizonaUser.Id}-{DateTime.Now:yyyyMMddHHmmss}";
                    //token = token.Encrypt();
                    string token = userManager.GenerateEmailConfirmationTokenAsync(MarizonaUser).Result;
                    string path = $"{Request.Scheme}://{Request.Host}/email-confirm?email={MarizonaUser.Email}&token={token}";
                    var sendMail = configuration.SendEmail(user.Email, "Marizona email confirming", $"Please, use <a href={path}>this link</a> for confirming");

                    if (sendMail == false)
                    {
                        db.Database.RollbackTransaction();

                        ViewBag.Message = "Please, try again";
                        return View(user);


                        //return Json(new
                        //{
                        //    error = true,
                        //    message = "Please, try again"
                        //});
                    }

                    db.Database.CommitTransaction();


                    ViewBag.Message = "Successfully, please check your email!";
                    return View(user);

                    //return Json(new
                    //{
                    //    error = false,
                    //    message = "Successfully, please check your email!"
                    //});
                }
                else
                {

                    ViewBag.Message = "Error, please try again!";
                    return View(user);
                    //return Json(new
                    //{
                    //    error = true,
                    //    message = "Error, please try again!"
                    //});
                }

            }


            ViewBag.Message = "Incomplete data";
            return View(user);

            //return Json(new
            //{
            //    error = true,
            //    message = "Incomplete data"
            //});
        }

        [Route("email-confirm")]
        [Authorize(Policy = "account.emailconfirm")]
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

        [Authorize(Policy = "account.wishlist")]
            public IActionResult Wishlist()
            {
                return View();
            }

            [Authorize(Policy = "account.profile")]
            public IActionResult Profile()
            {
                return View();
            }

            [Authorize(Policy = "account.logout")]
            [Route("logout.html")]
            public async Task<IActionResult> Logout()
            {
                await signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }

            [Route("accessdenied.html")]
            public IActionResult AccessDeny()
            {
                return View();
            }


        }
    }


