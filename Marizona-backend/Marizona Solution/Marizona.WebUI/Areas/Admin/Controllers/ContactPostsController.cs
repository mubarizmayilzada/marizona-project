using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Marizona.WebUI.Models.DataContexts;
using Marizona.WebUI.Models.Entities;
using Marizona.WebUI.Models.FormModels;
using Microsoft.Extensions.Configuration;
using Marizona.WebUI.Core.Extensions;

namespace Marizona.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactPostsController : Controller
    {

        private readonly MarizonaDbContext db;
        readonly IConfiguration configuration;

        public ContactPostsController(MarizonaDbContext db, IConfiguration configuration)
        {
            this.db = db;
            this.configuration = configuration;
        }

        // GET: Admin/ContactPosts
        public async Task<IActionResult> Index()
        {
            return View(await db.ContactPosts.ToListAsync());
        }

        // GET: Admin/ContactPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactPost = await db.ContactPosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactPost == null)
            {
                return NotFound();
            }

            return View(contactPost);
        }

        // GET: Admin/ContactPosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ContactPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Email,Comment,Subject,Answer,AnsweredDate,AnswerByUserİd,Id,CreatedDate,DeletedDate,UpdateDate,CreatedByUserId")] ContactPost contactPost)
        {
            if (ModelState.IsValid)
            {
                db.Add(contactPost);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactPost);
        }

        // GET: Admin/ContactPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactPost = await db.ContactPosts.FindAsync(id);
            if (contactPost == null)
            {
                return NotFound();
            }
            return View(contactPost);
        }

        // POST: Admin/ContactPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ContactPostFormModel contactPost)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Database.BeginTransaction();
                    var contact1 = db.ContactPosts.Where(e => e.DeletedDate == null).FirstOrDefault(e => e.Id == contactPost.Id);
                    contact1.Answer = contactPost.Answer;
                    if (contact1.AnsweredDate == null)
                    {
                        contact1.AnsweredDate = DateTime.Now;
                    }
                    await db.SaveChangesAsync();

                    var mailSend = configuration.SendEmail(contact1.Email, "Marizona Answer", $"{contact1.Answer}");

                    if (mailSend == false)
                    {
                        db.Database.RollbackTransaction();
                        return View("Details", contact1);
                    }

                    db.Database.CommitTransaction();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactPostExists(contactPost.Id))
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
            return View(contactPost);
        }

        // GET: Admin/ContactPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactPost = await db.ContactPosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactPost == null)
            {
                return NotFound();
            }

            return View(contactPost);
        }

        // POST: Admin/ContactPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactPost = await db.ContactPosts.FindAsync(id);
            db.ContactPosts.Remove(contactPost);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactPostExists(int id)
        {
            return db.ContactPosts.Any(e => e.Id == id);
        }
    }
}
