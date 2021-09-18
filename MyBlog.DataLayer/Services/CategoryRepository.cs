using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel;

namespace MyBlog.DataLayer
{
    public class CategoryRepository : ICategoryRepository
    {
        private MyBlogContext _db;
        public CategoryRepository(MyBlogContext db)
        {
            _db = db;
        }
        public virtual bool Add(Category category)
        {
            try
            {
                _db.Categories.Add(category);
                return true;
            }
            catch 
            {
                return false;
                
            }

        }

        public virtual bool Delete(object id)
        {
            return Delete(FindByID(id));
        }

        public virtual bool Delete(Category category)
        {
            try
            {
                _db.Categories.Remove(category);
                return true;
            }
            catch 
            {

                return false;
            }
        }

        public virtual Category FindByID(object id)
        {
            try
            {
                return _db.Categories.Find(id);
            }
            catch
            {
                return null;
                
            }
        }

        public IEnumerable<Category> GetAll()
        {
            return _db.Categories.Include(z=> z.Posts);
        }

        public virtual bool Update(Category category)
        {
            try
            {
                _db.Entry(category).State = System.Data.Entity.EntityState.Modified;
                return true;
           }
            catch 
            {

                return false;
            }
        }
    }
}
