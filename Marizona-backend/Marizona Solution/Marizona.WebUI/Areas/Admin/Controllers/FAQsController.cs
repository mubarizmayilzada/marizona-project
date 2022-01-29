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
    public class FAQsController : Controller
    {
        private readonly MarizonaDbContext db;

        public FAQsController(MarizonaDbContext db)
        {
            this.db = db;
        }

        // GET: Admin/FAQs
        public async Task<IActionResult> Index()
        {
            return View(await db.Faqs.ToListAsync());
        }

        // GET: Admin/FAQs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fAQ = await db.Faqs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fAQ == null)
            {
                return NotFound();
            }

            return View(fAQ);
        }

        // GET: Admin/FAQs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/FAQs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Question,Answer,Id,CreatedDate,DeletedDate,UpdateDate,CreatedByUserId")] FAQ fAQ)
        {
            if (ModelState.IsValid)
            {
                db.Add(fAQ);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fAQ);
        }

        // GET: Admin/FAQs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fAQ = await db.Faqs.FindAsync(id);
            if (fAQ == null)
            {
                return NotFound();
            }
            return View(fAQ);
        }

        // POST: Admin/FAQs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Question,Answer,Id")] FAQ fAQ)
        {
            if (id != fAQ.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(fAQ);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FAQExists(fAQ.Id))
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
            return View(fAQ);
        }

        // GET: Admin/FAQs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fAQ = await db.Faqs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fAQ == null)
            {
                return NotFound();
            }

            return View(fAQ);
        }

        // POST: Admin/FAQs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fAQ = await db.Faqs.FindAsync(id);
            db.Faqs.Remove(fAQ);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FAQExists(int id)
        {
            return db.Faqs.Any(e => e.Id == id);
        }
    }
}
