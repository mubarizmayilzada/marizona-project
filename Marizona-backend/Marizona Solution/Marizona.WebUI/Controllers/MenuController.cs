using Marizona.WebUI.Models.DataContexts;
using Marizona.WebUI.Models.Entities;
using Marizona.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Marizona.WebUI.Controllers
{
    public class MenuController : Controller
    {

        private readonly MarizonaDbContext db;

        public MenuController(MarizonaDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var products = db.Products.Count();
            Random rnd = new ();
            ShopFilterCategoriesViewModel vm = new ();
            vm.Products = db.Products
                .Include(x => x.Category)
                .Include(x => x.Size)
                .Take(rnd.Next(4, products))
                .ToList();
            vm.RecentProducts = db.Products.OrderByDescending(x => x.CreatedDate).Take(4).ToList();
            return View(vm);
        }
    }
}
