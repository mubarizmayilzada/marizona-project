using Marizona.WebUI.Models.DataContexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marizona.WebUI.Controllers
{
    [AllowAnonymous]
    public class FAQsController : Controller
    {
        private readonly MarizonaDbContext db;

        public FAQsController(MarizonaDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.Faqs);
        }
    }
}
