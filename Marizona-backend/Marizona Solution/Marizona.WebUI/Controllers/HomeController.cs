using Marizona.WebUI.Models.DataContexts;
using Marizona.WebUI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

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

        public HomeController(MarizonaDbContext db)
        {
            this.db = db;
        }
        public IActionResult AboutUs()
        {
            var chefs = db.Chefs
                .Include(e => e.PositionChef)
                .Include(e => e.SocialMedia).ToList();

            return View(chefs);
        }
    }
}
