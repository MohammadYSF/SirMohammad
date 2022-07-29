using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyBlog.DataLayer;
namespace MyBlog.App.Controllers
{
    public class FunYaasieController : Controller
    {
        // GET: FunYaasie
        public ActionResult Index()
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                var data = db.FunYaasieRepository.GetAll().ToList();
                return View(data);

            }
        }

      
        // GET: FunYaasie/Create
        [HttpGet]
        public ActionResult Create()
        {

            return View(new FunYaasie());
        }

        // POST: FunYaasie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Reporter,Subject,Description")] FunYaasie funYaasie)
        {
            if (ModelState.IsValid)
            {
                using (UnitOfWork db = new UnitOfWork())
                {
                    funYaasie.CreationDate = DateTime.Now;
                    funYaasie.ModificationDate = DateTime.Now;
                    db.FunYaasieRepository.Add(funYaasie);
                    db.Save();
                    return RedirectToAction("Index");
                }

            }
            return View(funYaasie);
        }
        // GET: FunYaasie/Edit/5
        public ActionResult Edit(int? id)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                FunYaasie funYaasie = db.FunYaasieRepository.FindByID(id);
                if (funYaasie == null)
                {
                    return HttpNotFound();
                }
                ViewBag.FormMode = "Edit";
                return View("Create" , funYaasie);
            }

        }

        // POST: FunYaasie/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Reporter,Description,Subject,ModificationDate,CreationDate")] FunYaasie funYaasie)
        {
            if (ModelState.IsValid)
            {
                funYaasie.ModificationDate = DateTime.Now;
                using (UnitOfWork db = new UnitOfWork())
                {
                    db.FunYaasieRepository.Update(funYaasie);
                    db.Save();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View("Create",funYaasie);
            }
        }


        [HttpGet]
        public string Delete(int id)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                FunYaasie funYaasie = db.FunYaasieRepository.FindByID(id);
                if (funYaasie == null)
                {
                    return "Error";
                }
                else
                {
                    db.FunYaasieRepository.Delete(funYaasie);
                    db.Save();
                    return "";
                }
            }
        }
    }
}
