using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataLayer
{
   public class WebsiteDetailsRepository : IWebsiteDetailsRepository
    {
        private MyBlogContext _db;
        public WebsiteDetailsRepository(MyBlogContext db)
        {
            _db = db;
        }
        public bool Edit(WebsiteDetails details)
        {
            try
            {
                _db.Entry(details).State = System.Data.Entity.EntityState.Modified;
                return true;
            }
            catch 
            {
                return false;
               
            }
        }

        public WebsiteDetails getDetails()
        {
            WebsiteDetails data = _db.WebsiteDetails.FirstOrDefault();
            return data;
        }
    }
}
