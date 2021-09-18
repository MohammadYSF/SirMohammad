using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataLayer
{
  public  interface IPostRepository
    {
        bool Add(Post post);
        bool update(Post post);
        bool Delete(Post post);
        bool Delete(object id);
        Post FindByID(object id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> Get(Expression<Func<Post, bool>> where = null, Func<IQueryable<Post>, IOrderedQueryable<Post>> orderby = null, string includes = null);
        
    }
}
