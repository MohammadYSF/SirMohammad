using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataLayer
{
    public class PostSubImageRepository : IPostSubImageRepository
    {
        private MyBlogContext _db;
        public PostSubImageRepository(MyBlogContext db)
        {
            _db = db;
        }
        public bool Add(PostSubImage postSubImage)
        {
            try
            {
                _db.PostSubImages.Add(postSubImage);
                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool Delete(object id)
        {

            return Delete(GetByID(id));



        }

        public bool Delete(PostSubImage postSubImage)
        {
            try
            {
                _db.PostSubImages.Remove(postSubImage);
                return true;
            }
            catch
            {

                return false;
            }
        }

       public IEnumerable<PostSubImage> GetAll()
        {
            return _db.PostSubImages.ToList();
        }

        public PostSubImage GetByID(object id)
        {
            return _db.PostSubImages.Find(id);
        }

        public IEnumerable<PostSubImage> GetByPostID(int postID)
        {
            return _db.PostSubImages.Where(a => a.PostID == postID);
        }
    }
}
