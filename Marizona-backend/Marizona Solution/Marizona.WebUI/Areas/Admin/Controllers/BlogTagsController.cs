using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Marizona.WebUI.Models.DataContexts;
using Marizona.WebUI.Models.Entities;

namespace Marizona.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogTagsController : Controller
    {
        private readonly MarizonaDbContext db;

        public BlogTagsController(MarizonaDbContext db)
        {
            this.db = db;
        }

        // GET: Admin/BlogTags
        public async Task<IActionResult> Index()
        {
            return View(await db.BlogTags.ToListAsync());
        }

        // GET: Admin/BlogTags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogTag = await db.BlogTags
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogTag == null)
            {
                return NotFound();
            }

            return View(blogTag);
        }

        // GET: Admin/BlogTags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/BlogTags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id,CreatedDate,DeletedDate,UpdateDate,CreatedByUserId")] BlogTag blogTag)
        {
            if (ModelState.IsValid)
            {
                db.Add(blogTag);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blogTag);
        }

        // GET: Admin/BlogTags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogTag = await db.BlogTags.FindAsync(id);
            if (blogTag == null)
            {
                return NotFound();
            }
            return View(blogTag);
        }

        // POST: Admin/BlogTags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id,CreatedDate,DeletedDate,UpdateDate,CreatedByUserId")] BlogTag blogTag)
        {
            if (id != blogTag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(blogTag);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogTagExists(blogTag.Id))
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
            return View(blogTag);
        }

        // GET: Admin/BlogTags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogTag = await db.BlogTags
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogTag == null)
            {
                return NotFound();
            }

            return View(blogTag);
        }

        // POST: Admin/BlogTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogTag = await db.BlogTags.FindAsync(id);
            db.BlogTags.Remove(blogTag);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogTagExists(int id)
        {
            return db.BlogTags.Any(e => e.Id == id);
        }
    }
}
