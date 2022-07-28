using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyBlog.DataLayer;
using MyBlog.Utilities;
using MyBlog.ViewModels;

namespace MyBlog.App.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class PostsController : Controller
    {

        private UnitOfWork db = new UnitOfWork();

        // GET: Admin/Posts
        public ActionResult Index()
        {
            var posts = db.PostRepository.GetAll().ToList();
            return View(posts);
        }

        // GET: Admin/Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.PostRepository.FindByID(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Admin/Posts/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.CategoryRepository.GetAll(), "CategoryID", "CategoryName");
            var userData = db.UserRepository.Get(a => a.isAuthor == true).ToList();
            ViewBag.UserID = new SelectList(userData , "UserID", "Username");
            return View();
        }

        // POST: Admin/Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "PostID,PostTitle,CategoryID,PostDescription,PostText,UserID,ImageAlt")] Post post, HttpPostedFileBase image_upload, string[] Keywords)
        {
            if (ModelState.IsValid && image_upload != null && AdminTools.IsImage(image_upload))
            {
                string imageName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(image_upload.FileName);
                image_upload.SaveAs(Server.MapPath("/Images/Posts/MainImages/OriginalSize/") + imageName);
                ImageResizer imgResizer = new ImageResizer()
                {
                    MaxX = 400,
                    MaxY = 200
                };
                imgResizer.Resize(Server.MapPath("/Images/Posts/MainImages/OriginalSize/") + imageName, Server.MapPath("/Images/Posts/MainImages/100x100/") + imageName);
                post.ImageName = imageName;
                post.PostDate = DateTime.Now;
                post.PostKeywords = string.Join(",", Keywords);
                db.PostRepository.Add(post);
                db.Save();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.CategoryRepository.GetAll(), "CategoryID", "CategoryName", post.CategoryID);
            ViewBag.UserID = new SelectList(db.UserRepository.Get(a => a.isAuthor == true).ToList(), "UserID", "Username");

            return View(post);
        }

        // GET: Admin/Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.PostRepository.FindByID(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            var usercombo = db.UserRepository.Get(a => a.isAuthor).ToList();
            ViewBag.UserID = new SelectList(db.UserRepository.Get(a => a.isAuthor == true).ToList(), "UserID", "Username");
            ViewBag.CategoryID = new SelectList(db.CategoryRepository.GetAll(), "CategoryID", "CategoryName", post.CategoryID);
            return View(post);
        }

        // POST: Admin/Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostID,CategoryID,PostTitle,PostDescription,PostText,PostDate,ImageName,ImageAlt,UserID")] Post post, HttpPostedFileBase img_upload, string[] Keywords)
        {
            post.PostKeywords = "default";
            if (ModelState.IsValid)
            {
                if (img_upload != null)
                {
                    if (img_upload.IsImage())
                    {
                        var x = Server.MapPath("/Images/Posts/MainImages/100x100/") + post.ImageName;
                        System.IO.File.Delete(Server.MapPath("/Images/Posts/MainImages/OriginalSize/" + post.ImageName));
                        System.IO.File.Delete(Server.MapPath("/Images/Posts/MainImages/100x100/" + post.ImageName));
                        string imageName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(img_upload.FileName);
                        img_upload.SaveAs(Server.MapPath("/Images/Posts/MainImages/OriginalSize/") + imageName);
                        ImageResizer imgResizer = new ImageResizer()
                        {
                            MaxX = 400,
                            MaxY = 200
                        };
                        imgResizer.Resize(Server.MapPath("/Images/Posts/MainImages/OriginalSize/") + imageName, Server.MapPath("/Images/Posts/MainImages/100x100/") + imageName);
                        post.ImageName = imageName;
                    }
                    else
                    {
                        ViewBag.CategoryID = new SelectList(db.CategoryRepository.GetAll(), "CategoryID", "CategoryName", post.CategoryID);
                        return View(post);
                    }
                }
                post.PostKeywords = string.Join(",", Keywords);
                db.PostRepository.update(post);
                db.Save();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.UserRepository.Get(a => a.isAuthor == true).ToList(), "UserID", "Username");
            ViewBag.CategoryID = new SelectList(db.CategoryRepository.GetAll(), "CategoryID", "CategoryName", post.CategoryID);
            return View(post);
        }

        // GET: Admin/Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.PostRepository.FindByID(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Admin/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.PostRepository.FindByID(id);
            System.IO.File.Delete(Server.MapPath("/Images/Posts/MainImages/OriginalSize/" + post.ImageName));
            System.IO.File.Delete(Server.MapPath("/Images/Posts/MainImages/100x100/" + post.ImageName));
            db.PostRepository.Delete(post);
            List<Comment> postComments = db.CommentRepository.GetByPostID(post.PostID);
            foreach (var comment in postComments)
            {
                db.CommentRepository.Delete(comment);
            }
            db.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //CKEDITOR



        public void UploadImageCKEdtior(HttpPostedFileWrapper upload)
        {
            if (upload != null)
            {
                string imageName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(upload.FileName);
                string path = Server.MapPath("/Images/Posts/CKEditor/") + imageName;
                upload.SaveAs(path);

            }
        }

        public ActionResult ListOutCKeditorUploads()
        {
            List<ImageViewModel> images = System.IO.Directory.GetFiles(Server.MapPath("/Images/Posts/CKEditor"))
                .Select(a => new ImageViewModel()
                {
                    ImageUrl = Url.Content("/Images/Posts/CKEditor/" + System.IO.Path.GetFileName(a)),
                    ImageName = System.IO.Path.GetFileName(a)
                }).ToList();
            return View(images);
        }
        //id is the imageName

        public ActionResult DeleteCKImage(string imageName)
        {
            System.IO.File.Delete(Server.MapPath("/Images/Posts/CKEditor/" + imageName));


            List<ImageViewModel> images = System.IO.Directory.GetFiles(Server.MapPath("/Images/Posts/CKEditor"))
                .Select(a => new ImageViewModel()
                {
                    ImageUrl = Url.Content("/Images/Posts/CKEditor/" + System.IO.Path.GetFileName(a)),
                    ImageName = System.IO.Path.GetFileName(a)
                }).ToList();

            return PartialView(images);
        }
    }
}
