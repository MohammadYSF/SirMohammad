using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataLayer
{
    public class CommentRepository:ICommentRepository
    {
        private MyBlogContext _db;
        public CommentRepository(MyBlogContext db)
        {
            _db = db;
        }

        public bool Add(Comment comment)
        {
            try
            {
                _db.Comments.Add(comment);
                return true;
            }
            catch 
            {

                return false;
            }
        }

        public bool Delete(object id)
        {
            return Delete(FindByID(id));
        }

        public bool Delete(Comment comment)
        {
            try
            {
                _db.Comments.Remove(comment);
                return true;
            }
            catch 
            {

                return false;
            }
        }

        public bool Edit(Comment comment)
        {
            try
            {
                _db.Entry(comment).State = System.Data.Entity.EntityState.Modified;
                return true;
            }
            catch 
            {

                return false;
            }
        }

        public Comment FindByID(object id)
        {
            return _db.Comments.Find(id);
        }

        public IEnumerable<Comment> Get(Expression<Func<Comment, bool>> where = null, Func<IQueryable<Comment>, IOrderedQueryable<Comment>> orderby = null, string includes = null)
        {
            IQueryable<Comment> query = _db.Comments;
            if (where != null)
            {
                query = query.Where(where);
            }
            if (orderby != null)
            {
                query = orderby(query);
            }
            if (includes != null)
            {
                foreach (var item in includes.Split(','))
                {
                    query = query.Include(includes);
                }
            }
            return query;
        }

        public List<Comment> GetByPostID(int postID)
        {
            return _db.Comments.Include(mbox=> mbox.Comment2).Where(a => a.PostID == postID).ToList();
        }
    }
}
