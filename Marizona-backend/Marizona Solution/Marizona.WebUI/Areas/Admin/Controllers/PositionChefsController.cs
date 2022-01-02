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
    public class PositionChefsController : Controller
    {
        private readonly MarizonaDbContext db;

        public PositionChefsController(MarizonaDbContext db)
        {
            this.db = db;
        }

        // GET: Admin/PositionChefs
        public async Task<IActionResult> Index()
        {
            return View(await db.PositionChefs.ToListAsync());
        }

        // GET: Admin/PositionChefs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var positionChef = await db.PositionChefs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (positionChef == null)
            {
                return NotFound();
            }

            return View(positionChef);
        }

        // GET: Admin/PositionChefs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/PositionChefs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id,CreatedDate,DeletedDate,UpdateDate,CreatedByUserId")] PositionChef positionChef)
        {
            if (ModelState.IsValid)
            {
                db.Add(positionChef);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(positionChef);
        }

        // GET: Admin/PositionChefs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var positionChef = await db.PositionChefs.FindAsync(id);
            if (positionChef == null)
            {
                return NotFound();
            }
            return View(positionChef);
        }

        // POST: Admin/PositionChefs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id,CreatedDate,DeletedDate,UpdateDate,CreatedByUserId")] PositionChef positionChef)
        {
            if (id != positionChef.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(positionChef);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PositionChefExists(positionChef.Id))
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
            return View(positionChef);
        }

        // GET: Admin/PositionChefs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var positionChef = await db.PositionChefs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (positionChef == null)
            {
                return NotFound();
            }

            return View(positionChef);
        }

        // POST: Admin/PositionChefs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var positionChef = await db.PositionChefs.FindAsync(id);
            db.PositionChefs.Remove(positionChef);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PositionChefExists(int id)
        {
            return db.PositionChefs.Any(e => e.Id == id);
        }
    }
}
