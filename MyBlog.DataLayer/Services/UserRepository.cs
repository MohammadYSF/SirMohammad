using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataLayer
{
    public class UserRepository : IUserRepository
    {
        private MyBlogContext _db;
        public UserRepository(MyBlogContext db)
        {
            _db = db;
        }

        public bool Add(Users user)
        {
            try
            {
                _db.Users.Add(user);
                return true;
            }
            catch 
            {

                return false;
            }
        }

        public bool Delete(object id)
        {
            return Delete(Find(id));
        }

        public bool Delete(Users user)
        {
            try
            {
                _db.Users.Remove(user);
                return true;
            }
            catch 
            {

                return false;
            }
        }

        public bool Edit(Users user)
        {
            try
            {
                _db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                return true;
            }
            catch 
            {

                return false;
            }
        }

        public Users Find(object id)
        {
            return _db.Users.Find(id);
        }

        public IEnumerable<Users> Get(Expression<Func<Users, bool>> where = null, Func<IQueryable<Users>, IOrderedQueryable<Users>> orderby = null, string includes = null)
        {
            IQueryable<Users> query = _db.Users;
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


        public Users GetByHPasswordAndEmail(string hashedPassword , string email)
        {
            return _db.Users.SingleOrDefault(z => z.Password == hashedPassword && z.Email == email);
        }

        public IEnumerable<string> GetRolesByUsername(string username)
        {
            return _db.Users.Where(a => a.Username == username).Select(a => a.Role.RoleName).ToArray();
         
        }

        public bool isAdmin(Users user)
        {
            return user.RoleID == 1;

        }
    }
}
