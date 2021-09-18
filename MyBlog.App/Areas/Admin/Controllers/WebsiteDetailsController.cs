using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.DataLayer;

namespace MyBlog.App.Areas.Admin.Controllers
{
    public class WebsiteDetailsController : Controller
    {
        // GET: Admin/WebsiteDetails
        public ActionResult Index()
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                return View(db.WebsiteDetailsRepository.getDetails());
            }
            
        }
        public ActionResult Edit()
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                return View(db.WebsiteDetailsRepository.getDetails());
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "")] WebsiteDetails details)
        {
            if (ModelState.IsValid)
            {
                using (UnitOfWork db = new UnitOfWork())
                {
                    db.WebsiteDetailsRepository.Edit(details);
                    db.Save();
                    return RedirectToAction("Index", "WebsiteDetails");
                }
            }
            return View(details);
        }
    }
}