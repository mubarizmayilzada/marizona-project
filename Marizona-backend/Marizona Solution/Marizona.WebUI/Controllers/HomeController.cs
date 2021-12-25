using Marizona.WebUI.Models.DataContexts;
using Marizona.WebUI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(Contact model)
        {
            return View();
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
