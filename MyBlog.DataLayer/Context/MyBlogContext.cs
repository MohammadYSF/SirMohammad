using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace MyBlog.DataLayer
{
   public class MyBlogContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<PostSubImage> PostSubImages { get; set; }
        public DbSet<WebsiteDetails> WebsiteDetails { get; set; }
        public DbSet<FunYaasie> FunYaasies { get; set; }

    }
}
