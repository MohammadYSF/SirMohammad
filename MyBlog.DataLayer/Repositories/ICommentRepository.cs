using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataLayer
{
    public interface ICommentRepository
    {
        bool Add(Comment comment);
        bool Delete(Comment comment);
        Comment FindByID(object id);
        bool Delete(object id);
        bool Edit(Comment comment);
        IEnumerable<Comment> Get(Expression<Func<Comment, bool>> where = null, Func<IQueryable<Comment>, IOrderedQueryable<Comment>> orderby = null, string includes = null);
        List<Comment> GetByPostID(int postID);
    }
}
