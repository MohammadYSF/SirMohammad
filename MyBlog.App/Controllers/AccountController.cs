using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.DataLayer;
using MyBlog.ViewModels;
using System.Web.Security;

namespace MyBlog.App.Controllers
{
    public class AccountController : Controller
    {
        private UnitOfWork db = new UnitOfWork();
        // GET: Account
        [HttpGet]
        [Route("login")]
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("login")]

        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                string hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password, "MD5");

                Users user = db.UserRepository.GetByHPasswordAndEmail(hashedPassword , model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("Email","کاربری با اطلاعات وارد شده یافت نشد");
                }
                else
                {
                    if (db.UserRepository.isAdmin(user))
                    {
                        FormsAuthentication.SetAuthCookie(user.Username, model.RememberMe);
                        return RedirectToAction("Index", "Posts" , new {area ="Admin" });
                    }
                    else
                    {
                        // we have to login the normal user. currently , we do not need this part
                        return View(model);

                    }
                }
            }
            return View(model);
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}