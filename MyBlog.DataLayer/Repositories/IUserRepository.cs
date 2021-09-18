using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace MyBlog.DataLayer
{
   public interface IUserRepository
    {
        IEnumerable<Users> Get(Expression<Func<Users, bool>> where = null, Func<IQueryable<Users>, IOrderedQueryable<Users>> orderby = null, string includes = null);
        bool Add(Users user);
        bool Delete(Users user);
        bool Delete(object id);
        Users GetByHPasswordAndEmail(string hashedPassword , string email);
        bool isAdmin(Users user);
        Users Find(object id);
        bool Edit(Users id);
        IEnumerable<string> GetRolesByUsername(string username);
    }
}
