using Marizona.WebUI.Models.DataContexts;
using Marizona.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marizona.WebUI.Controllers
{
    public class ShopController : Controller
    {
        private readonly MarizonaDbContext db;

        public ShopController(MarizonaDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            ShopFilterCategoriesViewModel vm = new ShopFilterCategoriesViewModel();
            vm.Categories = db.Categories.ToList();
            vm.Products = db.Products
                .Include(x => x.Category)
                .Include(x => x.Size).ToList();
            
            return View(vm);
        }

        public IActionResult Details([FromRoute]int id)
        {
            var product = db.Products
                .Include(x => x.Category)
                .Include(x => x.Size)
                .FirstOrDefault(x => x.Id == id);


            return View(product);
        }
    }
}
