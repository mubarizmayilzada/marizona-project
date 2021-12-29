using Marizona.WebUI.AppCode.Extensions;
using Marizona.WebUI.Models.DataContexts;
using Marizona.WebUI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Marizona.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Contact()
        {
            ViewBag.CurretDate = DateTime.Now.ToString("dd.MM.yyyy.HH:mm:ss ffffff");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(ContactPost model)
        {
            ViewBag.CurretDate = DateTime.Now.ToString("dd.MM.yyyy.HH:mm:ss ffffff");
            if (ModelState.IsValid)
            {
                db.ContactPosts.Add(model);
                db.SaveChanges();

                //ModelState.Clear();
                //ViewBag.Message = ;

                //return View();

                return Json(new {
                    error = false,
                    message = "Sizin müraciətiniz qeydə alındı. Tezliklə sizə geri dönüş edəcəyik!"
                });
            }
            //return View(model);

            return Json(new
            {
                error = true,
                message = "Biraz sonra yenidən yoxlayın."
            });
        }

        private readonly MarizonaDbContext db;
        private readonly IConfiguration configuration;

        public HomeController(MarizonaDbContext db,IConfiguration configuration)
        {
            this.db = db;
            this.configuration = configuration;
        }
        public IActionResult AboutUs()
        {
            var chefs = db.Chefs
                .Include(e => e.PositionChef)
                .Include(e => e.SocialMedia).ToList();

            return View(chefs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Subscribe([Bind("Email")]Subscribe model)
        {
            if (ModelState.IsValid)
            {
                var current = db.Subscribes.FirstOrDefault(s => s.Email.Equals(model.Email));

                if (current != null && current.EmailConfirmed == true)
                {
                    return Json(new
                    {
                        error = true,
                        message = "Bu e-poctla daha öncə abunəçi qeydiyyatı edilib."
                    });
                }
                else if (current != null && (current.EmailConfirmed ?? false == false))
                {
                    return Json(new
                    {
                        error = true,
                        message = "E-pocta gonderilmis linkle qeydiyyat tamamlanmayib."
                    });
                }
                db.Subscribes.Add(model);
                db.SaveChanges();

                string token = $"subscribetoken-{model.Id}-{DateTime.Now:yyyyMMddHHmmss}";

                string path = $"{Request.Scheme}://{Request.Host}/subscribe-confirm?token={token}";

                var mailSended = configuration.SendEmail(model.Email, "Marizona Newsletter subscribe", $"Zehmet olmasa <a href={path}>Link</a> vasitesi ile abuneliyi tamamlayin");

                if (mailSended == false)
                {
                    db.Database.RollbackTransaction();

                    return Json(new
                    {
                        error = false,
                        message = "E-mail gonderilen zaman xeta bash verdi. biraz sonra yeniden yoxlayin."
                    });
                }
                return Json(new
                {
                    error = false,
                    message = "Sorğunuz uğurla qeydə alındı. Zəhmət olmasa E-poçtunuza göndərilmiş linkdən abunəliyi tamamlayın."
                });
            }

            return Json(new { 
                error = "true",
                message= "sorğunun icrası zamanı problem yarandı. bir az sonra yeniden yoxlayın."
            });
        }

        [HttpGet]
        [Route("subscribe-confirm")]
        public IActionResult SubscribeConfirm(string token)
        {
            Match match = Regex.Match(token, @"subscribetoken-(?<id>\d)+-(?<executeTimeStamp>\d{14})");

            if (match.Success)
            {
                int id = Convert.ToInt32(match.Groups["id"].Value);
                string executeTimeStamp = match.Groups["executeTimeStamp"].Value;

                var subscribe = db.Subscribes.FirstOrDefault(s => s.Id == id);

                if (subscribe == null)
                {
                    ViewBag.Message = Tuple.Create(true, "Token xətası!");
                    goto end;
                }

                if ((subscribe.EmailConfirmed ?? false) == true)
                {
                    ViewBag.Message = Tuple.Create(true, "Abunəliyiniz artıq təsdiq edilmişdir!");
                    goto end;
                }
                subscribe.EmailConfirmed = true;
                subscribe.EmailConfirmedDate = DateTime.Now;
                db.SaveChanges();

                ViewBag.Message = Tuple.Create(false, "Abunəliyiniz təsdiq edildi!");


            }

        end:
            return View();
        }
    }
}
