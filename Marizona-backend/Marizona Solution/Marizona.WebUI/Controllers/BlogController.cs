using Marizona.WebUI.Models.DataContexts;
using Marizona.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marizona.WebUI.Controllers
{
    [AllowAnonymous]
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
        //public IActionResult Details()
        //{
        //    var vm = new CategoryBlogPostViewModel();


        //    //vm.comments = db.BlogPostComments.Where(bpc => bpc.DeletedDate == null && bpc.BlogPostId == vm.BlogPost.Id).ToList();
        //    return View(vm);
        //}

        public IActionResult Details([FromRoute] int id)
        {
            var vm = new CategoryBlogPostViewModel();
            vm.Categories = db.Categories.ToList();
            vm.BlogPost = db.Blogs
                .Include(e=>e.BlogTag)
                .FirstOrDefault(e => e.Id == id);
            vm.RecentBlogs = db.Blogs.OrderByDescending(e => e.CreatedDate).Take(3).ToList();
            return View(vm);
        }

    }
}
