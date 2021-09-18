using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataLayer
{
     public interface IPostSubImageRepository
    {
        bool Add(PostSubImage postSubImage);
        bool Delete(PostSubImage postSubImage);
        bool Delete(object id);
        PostSubImage GetByID(object id);
        IEnumerable<PostSubImage> GetByPostID(int postID);
        IEnumerable<PostSubImage> GetAll();

    }
}
