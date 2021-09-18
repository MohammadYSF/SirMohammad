using MyBlog.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataLayer
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        [Display(Name = "نقش کاربر")]
        [Required(ErrorMessage = "لطفا {0} را تعیین کنید")]
        public int RoleID { get; set; }
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]

        public string Username { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(20)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Display(Name = "وضعیت فعالیت کاربر")]
        public bool IsActivated { get; set; }
        [Display(Name = "تاریخ ثبت نام")]
        [DataType(DataType.DateTime)]
        public DateTime RegisterDate { get; set; }
        [Display(Name = "عکس پروفایل")]
        [MaxLength(300)]
        public string ImageName { get; set; }
        [Display(Name = "درباره من")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500)]
        
        public string ShortDescription { get; set; }

        [Display(Name = "نویسنده؟")]
        public bool isAuthor { get; set; }

        //navigation properties
        public virtual List<Post> Posts { get; set; }
        public virtual Roles Role { get; set; }
        public Users()
        {

        }
        

    }
}
