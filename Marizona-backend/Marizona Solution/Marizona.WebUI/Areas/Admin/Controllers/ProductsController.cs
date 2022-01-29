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
    public class ProductsController : Controller
    {
        private readonly MarizonaDbContext db;
        readonly IWebHostEnvironment env;
        public ProductsController(MarizonaDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            var marizonaDbContext = db.Products.Include(p => p.Category).Include(p => p.Size);
            return View(await marizonaDbContext.ToListAsync());
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await db.Products
                .Include(p => p.Category)
                .Include(p => p.Size)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Id");
            ViewData["SizeId"] = new SelectList(db.Sizes, "Id", "Id");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductFormModel product)
        {
            if (ModelState.IsValid)
            {
                string extension = Path.GetExtension(product.file.FileName);
                product.ImagePath = $"{Guid.NewGuid()}{extension}";

                string physicalFileName = Path.Combine(env.ContentRootPath,
                                                       "wwwroot",
                                                       "uploads",
                                                       "images",
                                                       product.ImagePath);

                using (var stream = new FileStream(physicalFileName, FileMode.Create, FileAccess.Write))
                {
                    await product.file.CopyToAsync(stream);
                }

                var product1 = new Product();
                
                product1.ImagePath = product.ImagePath;
                product1.Title = product.Title;
                product1.ShortDescription = product.ShortDescription;
                product1.Description = product.Description;
                product1.Price = product.Price;
                product1.IsSalePrice = product.IsSalePrice;
                product1.CategoryId = product.CategoryId;
                product1.SizeId = product.SizeId;

                db.Add(product1);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Id", product.CategoryId);
            ViewData["SizeId"] = new SelectList(db.Sizes, "Id", "Id", product.SizeId);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Id", product.CategoryId);
            ViewData["SizeId"] = new SelectList(db.Sizes, "Id", "Id", product.SizeId);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,ShortDescription,Description,BarCode,ImagePath,SizeId,CategoryId,Price,IsSalePrice,Id,CreatedDate,DeletedDate,UpdateDate,CreatedByUserId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(product);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Id", product.CategoryId);
            ViewData["SizeId"] = new SelectList(db.Sizes, "Id", "Id", product.SizeId);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await db.Products
                .Include(p => p.Category)
                .Include(p => p.Size)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await db.Products.FindAsync(id);
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return db.Products.Any(e => e.Id == id);
        }
    }
}
