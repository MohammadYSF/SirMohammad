using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataLayer
{
    public class UnitOfWork : IDisposable
    {

        private MyBlogContext _db = new MyBlogContext();
        private CategoryRepository _categoryRepository;
        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new DataLayer.CategoryRepository(_db);
                }

                return _categoryRepository;
            }
        }

        private PostRepository _postRepository;

        public IPostRepository PostRepository
        {
            get
            {
                if (_postRepository == null) 
                {
                    _postRepository = new PostRepository(_db);
                    
                }
                return _postRepository;
            }

        }

        private UserRepository _userRepository;

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_db);

                }
                return _userRepository;
            }
        }

        private PostSubImageRepository _postSubImageRepository;

        public IPostSubImageRepository PostSubImageRepository
        {
            get
            {
                if (_postSubImageRepository == null)
                {
                    _postSubImageRepository = new PostSubImageRepository(_db);

                }
                return _postSubImageRepository;
            }
        }
        private CommentRepository _commentRepository;

        public ICommentRepository CommentRepository
        {
            get
            {
                if (_commentRepository == null)
                {
                    _commentRepository = new CommentRepository(_db);

                }
                return _commentRepository;
            }
        }
        private WebsiteDetailsRepository _websiteDetailsRepository;

        public IWebsiteDetailsRepository WebsiteDetailsRepository
        {
            get
            {
                if (_websiteDetailsRepository == null)
                {
                    _websiteDetailsRepository = new DataLayer.WebsiteDetailsRepository(_db);
                }
                return _websiteDetailsRepository;
            }
        }






        public void Dispose()
        {
            _db.Dispose();
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
