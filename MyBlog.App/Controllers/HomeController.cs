using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.DataLayer;
namespace MyBlog.App.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                ViewBag.WebsitePersianName = db.WebsiteDetailsRepository.getDetails().WebsitePersianName;
                ViewBag.WebsiteEnglishName = db.WebsiteDetailsRepository.getDetails().WebsiteEnglishName;
                return View();
            }
            
        }

        public ActionResult About()
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                return View(db.WebsiteDetailsRepository.getDetails());
            }
        }

        public ActionResult Contact()
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                return View(db.WebsiteDetailsRepository.getDetails());
            }
        }
        public ActionResult ShowPost()
        {
            ViewBag.Title = "پست";
            return View("Post");
        }
        public ActionResult GetPosts(int id = 10)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                List<Post> data;
                if (db.PostRepository.Get().ToList().Count >= id)
                {
                    data = db.PostRepository.Get().OrderByDescending(a => a.PostDate).Take(id).ToList();
                }
                else
                {
                    data = db.PostRepository.Get().OrderByDescending(a => a.PostDate).ToList();
                }
                return PartialView(data);

            }
        }
        public ActionResult GetPost(int id = 0)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                Post post = db.PostRepository.FindByID(id);
                if (post == null || id == 0)
                {
                    return HttpNotFound();
                }
                ViewBag.CategoryName = db.CategoryRepository.FindByID(post.CategoryID).CategoryName;
                return View(post);
            }
        }
        [Route("search")]
        public ActionResult SearchByQ(string q = "")
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                IEnumerable<Post> data = db.PostRepository.Get(a => a.PostTitle.Contains(q));
                ViewBag.Q = q;
                return View(data);
            }
        }
        public ActionResult SearchByCategory(int catID = 0)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                if (catID == 0)
                {
                    return HttpNotFound();
                }
                Category category = db.CategoryRepository.FindByID(catID);
                if (category == null)
                {
                    return HttpNotFound();
                }
                ViewBag.CategoryName = category.CategoryName;
                ViewBag.isGettingAll = false;
                return View(db.PostRepository.Get(a=> a.Category.CategoryName == category.CategoryName));
            }
        }
        public ActionResult GetCategories()
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                return PartialView(db.CategoryRepository.GetAll().ToList());
            }
        }
        public ActionResult GetAllPosts()
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                ViewBag.isGettingAll = true;
                return View("SearchByCategory" , db.PostRepository.GetAll().ToList());
            }
        }

    }
}