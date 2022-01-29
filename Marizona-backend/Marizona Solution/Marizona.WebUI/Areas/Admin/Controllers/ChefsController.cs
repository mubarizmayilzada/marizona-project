using Marizona.WebUI.Models.DataContexts;
using Marizona.WebUI.Models.Entities;
using Marizona.WebUI.Models.FormModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Marizona.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChefsController : Controller
    {
        private readonly MarizonaDbContext db;
        readonly IWebHostEnvironment env;

        public ChefsController(MarizonaDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;

        }

        // GET: Admin/Chefs
        public async Task<IActionResult> Index()
        {
            var marizonaDbContext = db.Chefs.Include(c => c.PositionChef).Include(c => c.SocialMedia);
            return View(await marizonaDbContext.ToListAsync());
        }

        // GET: Admin/Chefs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chef = await db.Chefs
                .Include(c => c.PositionChef)
                .Include(c => c.SocialMedia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chef == null)
            {
                return NotFound();
            }

            return View(chef);
        }

        // GET: Admin/Chefs/Create
        public IActionResult Create()
        {
            ViewData["PositionChefId"] = new SelectList(db.PositionChefs, "Id", "Id");
            ViewData["SocialMediaId"] = new SelectList(db.SocialMedias, "Id", "Id");
            return View();
        }

        // POST: Admin/Chefs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ChefFormModel chef)
        {
            if (ModelState.IsValid)
            {

                string extension = Path.GetExtension(chef.file.FileName);
                chef.ImagePath = $"{Guid.NewGuid()}{extension}";

                string physicalFileName = Path.Combine(env.ContentRootPath,
                                                       "wwwroot",
                                                       "uploads",
                                                       "images",
                                                       chef.ImagePath);

                using (var stream = new FileStream(physicalFileName, FileMode.Create, FileAccess.Write))
                {
                    await chef.file.CopyToAsync(stream);
                }

                var chef1 = new Chef();
                chef1.ImagePath = chef.ImagePath;
                chef1.Name = chef.Name;
                chef1.PositionChefId = chef.PositionChefId;
                chef1.aboutChef = chef.aboutChef;
                chef1.SocialMediaId = chef.SocialMediaId;

                db.Add(chef1);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PositionChefId"] = new SelectList(db.PositionChefs, "Id", "Id", chef.PositionChefId);
            ViewData["SocialMediaId"] = new SelectList(db.SocialMedias, "Id", "Id", chef.SocialMediaId);
            return View(chef);
        }

        // GET: Admin/Chefs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chef = await db.Chefs.FindAsync(id);
            if (chef == null)
            {
                return NotFound();
            }
            ViewData["PositionChefId"] = new SelectList(db.PositionChefs, "Id", "Id", chef.PositionChefId);
            ViewData["SocialMediaId"] = new SelectList(db.SocialMedias, "Id", "Id", chef.SocialMediaId);
            return View(chef);
        }

        // POST: Admin/Chefs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImagePath,Name,PositionChefId,aboutChef,SocialMediaId,Id,CreatedDate,DeletedDate,UpdateDate,CreatedByUserId")] Chef chef)
        {
            if (id != chef.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(chef);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChefExists(chef.Id))
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
            ViewData["PositionChefId"] = new SelectList(db.PositionChefs, "Id", "Id", chef.PositionChefId);
            ViewData["SocialMediaId"] = new SelectList(db.SocialMedias, "Id", "Id", chef.SocialMediaId);
            return View(chef);
        }

        // GET: Admin/Chefs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chef = await db.Chefs
                .Include(c => c.PositionChef)
                .Include(c => c.SocialMedia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chef == null)
            {
                return NotFound();
            }

            return View(chef);
        }

        // POST: Admin/Chefs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chef = await db.Chefs.FindAsync(id);
            db.Chefs.Remove(chef);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChefExists(int id)
        {
            return db.Chefs.Any(e => e.Id == id);
        }
    }
}
