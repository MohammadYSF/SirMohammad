using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.App.Controllers
{
    public class PickingController : Controller
    {
        // GET: Picking
        [Route("lp")]
        public ActionResult Index()
        {
            return View();
        }
    }
}