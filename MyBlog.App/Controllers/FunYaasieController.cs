using System;
using System.Collections.Generic;
using System.Linq;
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
            
            return View();
        }

        // GET: FunYaasie/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FunYaasie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FunYaasie/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FunYaasie/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FunYaasie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FunYaasie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FunYaasie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
