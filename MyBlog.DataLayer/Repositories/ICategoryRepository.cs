using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataLayer
{
    public interface ICategoryRepository
    {
        bool Add(Category category);
        bool Update(Category category);
        bool Delete(Category category);
        bool Delete(object id);
        Category FindByID(object id);

        IEnumerable<Category> GetAll();

    }
}
