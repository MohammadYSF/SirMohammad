using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.DataLayer;

namespace MyBlog.App.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult GetOtherPosts(int count = 2 , int postID = 0)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                if (db.PostRepository.GetAll().ToList().Count < 2)
                {
                    return null;
                }
                Post post = db.PostRepository.FindByID(postID);
                if (postID ==0 || post == null)
                {
                    return HttpNotFound();
                }
                List<Post> data;
                data = db.PostRepository.Get(a => a.Category.CategoryID == post.Category.CategoryID).Take(2).ToList();
                return PartialView(data);
            }
        }
    }
}