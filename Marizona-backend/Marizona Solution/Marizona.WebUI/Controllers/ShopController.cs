using Marizona.WebUI.Models.DataContexts;
using Marizona.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marizona.WebUI.Controllers
{
    [AllowAnonymous]
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
                .Include(x => x.Size)
                .ToList();
            vm.RecentBlogs = db.Blogs.OrderByDescending(e => e.CreatedDate).Take(3).ToList();
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

        public async Task<IActionResult> ShoppingCard()
        {
            if (Request.Cookies.TryGetValue("basket", out string basketJson))
            {
                //var basket = JsonSerializer.DeserializeObject<List<BasketItem>>(basketJson);
                var basket = JsonConvert.DeserializeObject<List<BasketItem>>(basketJson);

                foreach (var basketElement in basket)
                {
                    var product = await db.Products
                        .Include(pi => pi.ImagePath)
                        .FirstOrDefaultAsync(p => p.Id == basketElement.ProductId);

                    //basketElement.ImagePath = product.ImagePath
                    //    ?.FirstOrDefault(i => i.IsMain == true)?.ImagePath;

                    basketElement.Name = product.Title;
                    basketElement.Price = (decimal)product.Price;
                    basketElement.IsSalePrice = (decimal)product.IsSalePrice;

                }

                return View(basket);
            }
            return View();
        }
    }
}
