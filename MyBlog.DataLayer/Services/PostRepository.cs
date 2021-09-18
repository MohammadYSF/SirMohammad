using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace MyBlog.DataLayer
{
    public class PostRepository : IPostRepository
    {
        private MyBlogContext _db;
        public PostRepository(MyBlogContext db)
        {
            _db = db;
        }
        public IEnumerable<Post> Get(Expression<Func<Post, bool>> where = null, Func<IQueryable<Post>, IOrderedQueryable<Post>> orderby = null, string includes = null)
        {
            IQueryable<Post> query = _db.Posts;
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
            return query.ToList();
        }
        public bool Add(Post post)
        {
            try
            {
                _db.Posts.Add(post);
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

        public bool Delete(Post post)
        {
            try
            {
                _db.Posts.Remove(post);
                return true;
            }
            catch
            {
                return false;

            }
        }

        public virtual Post FindByID(object id)
        {
            int postID = Convert.ToInt32(id);
            return _db.Posts.Include(a=> a.User).First(a=> a.PostID == postID);
        }

        public IEnumerable<Post> GetAll()
        {
            var data = _db.Posts.Include(p => p.Category).Include(p => p.Comments).Include(a => a.User);
            return data;

        }

        public bool update(Post post)
        {
            try
            {
                _db.Entry(post).State = System.Data.Entity.EntityState.Modified;
                return true;
            }
            catch 
            {

                return false;
            }
        }
    }
}
