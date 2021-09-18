using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.DataLayer;
namespace MyBlog.App.Controllers
{
    public class CommentsController : Controller
    {
        // GET: Comments
        public ActionResult GetCommentsByPostID(int id = 0)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            using (UnitOfWork db = new UnitOfWork())
            {
                Post post = db.PostRepository.FindByID(id);
                if (post == null)
                {
                    return HttpNotFound();
                }
                return PartialView(db.CommentRepository.GetByPostID(post.PostID).ToList());
            }

        }
        [HttpGet]
        public ActionResult AddComment(int id = 0)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            using (UnitOfWork db = new UnitOfWork())
            {
                Post post = db.PostRepository.FindByID(id);
                if (post == null)
                {
                    return HttpNotFound();
                }
                Comment comment = new Comment();
                comment.PostID = post.PostID;
                return PartialView("AddComment", comment);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment([Bind(Include = "PostID,ParentID,CommentName,CommentEmail,CommentText")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                {
                    using (UnitOfWork db = new UnitOfWork())
                    {
                        comment.CommentDate = DateTime.Now;
                        comment.IsCommentOk = true;
                        db.CommentRepository.Add(comment);
                        db.Save();
                        return PartialView("GetCommentsByPostID" , db.CommentRepository.GetByPostID(comment.PostID).ToList());
                    }

                }

            }
            return null;



        }

        public ActionResult DeleteComment(int commentID = 0)
        {
            if (commentID == 0)
            {
                return HttpNotFound();
            }
            else
            {
                using (UnitOfWork db = new UnitOfWork())
                {
                    Comment comment = db.CommentRepository.FindByID(commentID);
                    if (comment == null)
                    {
                        return HttpNotFound();

                    }
                    else
                    {
                        db.CommentRepository.Delete(comment);
                        db.Save();
                        return PartialView("GetCommentsByPostID", db.CommentRepository.GetByPostID(comment.PostID).ToList());
                    }
                }
            }

        }
        public ActionResult ReplyToComment(int commentID = 0)
        {
            if (commentID == 0)
            {
                return HttpNotFound();
            }
            using (UnitOfWork db = new UnitOfWork())
            {
                Comment comment = db.CommentRepository.FindByID(commentID);
                if (comment == null)
                {
                    return HttpNotFound();
                }
                Comment rComment = new Comment();
                rComment.ParentID = comment.CommentID;
                rComment.PostID = comment.PostID;
                return PartialView("AddComment", rComment);
            }
        }

    }
}