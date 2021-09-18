using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataLayer
{
    public interface IWebsiteDetailsRepository
    {
        WebsiteDetails getDetails();
        bool Edit(WebsiteDetails details);

    }
}
