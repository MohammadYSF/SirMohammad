using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataLayer
{
   public interface IFunYaasieRepository
    {
        bool Add(FunYaasie funYaasie);
        bool Update(FunYaasie funYaasie);
        bool Delete(FunYaasie funYaasie);
        bool Delete(object id);
        FunYaasie FindByID(object id);

        IQueryable<FunYaasie> GetAll();
    }
}
