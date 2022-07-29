using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataLayer
{
    public class FunYaasieRepository : IFunYaasieRepository
    {
        private readonly MyBlogContext _db;
        public FunYaasieRepository(MyBlogContext db)
        {
            _db = db;
        }
        public bool Add(FunYaasie funYaasie)
        {
            try
            {
                _db.FunYaasies.Add(funYaasie);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool Delete(FunYaasie funYaasie)
        {
            try
            {
                _db.FunYaasies.Remove(funYaasie);
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

        public FunYaasie FindByID(object id)
        {
            return _db.FunYaasies.Find(id);
        }

        public IQueryable<FunYaasie> GetAll()
        {
            return _db.FunYaasies;
        }

        public bool Update(FunYaasie funYaasie)
        {
            try
            {
                _db.Entry<FunYaasie>(funYaasie).State = System.Data.Entity.EntityState.Modified;
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
