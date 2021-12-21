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
    public class BlogController : Controller
    {
        private readonly MarizonaDbContext db;

        public BlogController(MarizonaDbContext db )
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            BlogListViewModel vm = new BlogListViewModel();
            vm.BlogTags = db.BlogTags.ToList();
            vm.Blogs = db.Blogs
                .Include(x => x.BlogTag)
                .ToList();

            return View(vm);
        }
        public IActionResult Details()
        {
            return View();
        }

    }
}
