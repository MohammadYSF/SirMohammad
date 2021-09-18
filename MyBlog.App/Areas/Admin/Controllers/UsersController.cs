using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.DataLayer;
using MyBlog.ViewModels;
using MyBlog.Utilities;
using System.Web.Security;


namespace MyBlog.App.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class UsersController : Controller
    {
        UnitOfWork db = new UnitOfWork();

        // GET: Admin/Users
        public ActionResult Index()
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                return View(db.UserRepository.Get(null, null, "Role").ToList());
            }

        }

        public ActionResult Add()
        {
            using (UnitOfWork db = new UnitOfWork())
            {

                return View(new Users());
            }
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Add([Bind(Include = "Email,Username,PhoneNumber,ShortDescription,Password,IsAuthor")] Users user, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                using (UnitOfWork db = new UnitOfWork())
                {
                    //role id 2 is normal user
                    user.RoleID = 2;
                    user.RegisterDate = DateTime.Now;
                    user.IsActivated = true;
                    string imageName = Guid.NewGuid() + System.IO.Path.GetExtension(fileUpload.FileName);
                    user.ImageName = imageName;
                    fileUpload.SaveAs(Server.MapPath("/Images/Profiles/OriginalSize/" + imageName));
                    ImageResizer imgResizer = new ImageResizer()
                    {
                        MaxX = 400,
                        MaxY = 200
                    };
                    imgResizer.Resize(Server.MapPath("/Images/Profiles/OriginalSize/" + imageName), Server.MapPath("/Images/Profiles/100x100/" + imageName));
                    //hashing the password
                    string hashedPass = FormsAuthentication.HashPasswordForStoringInConfigFile(user.Password, "MD5");
                    user.Password = hashedPass;
                    db.UserRepository.Add(user);
                    db.Save();
                    return RedirectToAction("Index", "Users");

                }
            }
            return View(user);
        }
        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            Users user = db.UserRepository.Find(id);

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,RoleID,RegisterDate,Password,ImageName,Username,Email,PhoneNumber,ShortDescription")] Users user, HttpPostedFileBase image_upload)
        {
            if (ModelState.IsValid)
            {
                if (image_upload != null)
                {
                    if (image_upload.IsImage())
                    {

                        System.IO.File.Delete(Server.MapPath("/Images/Profiles/OriginalSize/" + user.ImageName));
                        System.IO.File.Delete(Server.MapPath("/Images/Profiles/100x100/" + user.ImageName));
                        string imageName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(image_upload.FileName);
                        image_upload.SaveAs(Server.MapPath("/Images/Profiles/OriginalSize/") + imageName);
                        ImageResizer imgResizer = new ImageResizer()
                        {
                            MaxX = 400,
                            MaxY = 200
                        };
                        imgResizer.Resize(Server.MapPath("/Images/Profiles/OriginalSize/") + imageName, Server.MapPath("/Images/Profiles/100x100/") + imageName);
                        user.ImageName = imageName;
                    }
                    else
                    {
                        return View(user);
                    }
                }
                db.UserRepository.Edit(user);
                db.Save();
                return RedirectToAction("Index", "Users");
            }
            return View(user);
        }

        public ActionResult ChangePassword(int id = 0)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            Users user = db.UserRepository.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ChangePasswordViewModel model = new ChangePasswordViewModel()
            {
                UsrID = user.UserID,

            };
            return PartialView(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword([Bind(Include = "UsrID,OldPassword,NewPassword")]ChangePasswordViewModel model)
        {
            Users user = db.UserRepository.Find(model.UsrID);

            if (ModelState.IsValid)
            {



                string hashedPass = FormsAuthentication.HashPasswordForStoringInConfigFile(model.OldPassword, "MD5");
                if (user.Password.ToLower() == hashedPass.ToLower())
                {
                    //ok
                    string newHashedPass = FormsAuthentication.HashPasswordForStoringInConfigFile(model.NewPassword, "MD5");
                    user.Password = newHashedPass.ToLower();
                    db.UserRepository.Edit(user);
                    db.Save();
                    return Redirect($"/Admin/Users/Edit/{user.UserID}?changingPassword=true");
                }




            }
            return Redirect($"/Admin/Users/Edit/{user.UserID}?changingPassword=false");


        }
        public ActionResult Delete(int id = 0)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            using (UnitOfWork db = new UnitOfWork())
            {
                Users user = db.UserRepository.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Users user = db.UserRepository.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            System.IO.File.Delete(Server.MapPath("/Images/Profiles/OriginalSize/" + user.ImageName));
            System.IO.File.Delete(Server.MapPath("/Images/Profiles/100x100/" + user.ImageName));
            db.UserRepository.Delete(user);
            db.Save();
            return RedirectToAction("Index");
        }

    }
}