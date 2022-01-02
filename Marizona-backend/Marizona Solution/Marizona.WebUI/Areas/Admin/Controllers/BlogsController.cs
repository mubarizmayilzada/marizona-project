using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Marizona.WebUI.Models.DataContexts;
using Marizona.WebUI.Models.Entities;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Marizona.WebUI.Models.FormModels;

namespace Marizona.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogsController : Controller
    {
        private readonly MarizonaDbContext db;
        readonly IWebHostEnvironment env;
        public BlogsController(MarizonaDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }

        // GET: Admin/Blogs
        public async Task<IActionResult> Index()
        {
            var marizonaDbContext = db.Blogs.Include(b => b.BlogTag);
            return View(await marizonaDbContext.ToListAsync());
        }

        // GET: Admin/Blogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await db.Blogs
                .Include(b => b.BlogTag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // GET: Admin/Blogs/Create
        public IActionResult Create()
        {
            ViewData["BlogTagId"] = new SelectList(db.BlogTags, "Id", "Id");
            return View();
        }

        // POST: Admin/Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogFormModel blog)
        {
            if (ModelState.IsValid)
            {
                string extension = Path.GetExtension(blog.file.FileName);
                blog.ImagePath = $"{Guid.NewGuid()}{extension}";

                string physicalFileName = Path.Combine(env.ContentRootPath,
                                                       "wwwroot",
                                                       "uploads",
                                                       "images",
                                                       blog.ImagePath);

                using (var stream = new FileStream(physicalFileName, FileMode.Create, FileAccess.Write))
                {
                    await blog.file.CopyToAsync(stream);
                }

                var blog1 = new Blog();
                blog1.Title = blog.Title;
                blog1.ShortDescription = blog.ShortDescription;
                blog1.Description = blog.Description;
                blog1.BlogTagId = blog.BlogTagId;
                blog1.ImagePath = blog.ImagePath;

                db.Add(blog1);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BlogTagId"] = new SelectList(db.BlogTags, "Id", "Id", blog.BlogTagId);
            return View(blog);
        }

        // GET: Admin/Blogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await db.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            ViewData["BlogTagId"] = new SelectList(db.BlogTags, "Id", "Id", blog.BlogTagId);
            return View(blog);
        }

        // POST: Admin/Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Description,ShortDescription,ImagePath,PublishedDate,BlogTagId,Id,CreatedDate,DeletedDate,UpdateDate,CreatedByUserId")] Blog blog)
        {
            if (id != blog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(blog);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(blog.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BlogTagId"] = new SelectList(db.BlogTags, "Id", "Id", blog.BlogTagId);
            return View(blog);
        }

        // GET: Admin/Blogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await db.Blogs
                .Include(b => b.BlogTag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // POST: Admin/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await db.Blogs.FindAsync(id);
            db.Blogs.Remove(blog);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogExists(int id)
        {
            return db.Blogs.Any(e => e.Id == id);
        }
    }
}
