using Marizona.WebUI.Models.Entities;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
