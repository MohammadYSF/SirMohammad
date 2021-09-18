using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.DataLayer
{
    public class WebsiteDetails
    {
        [Key]
        //there is just one row in this table
        public int ID { get; set; }
        [Display(Name = "نام فارسی وب سایت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string WebsitePersianName { get; set; }
        [Display(Name = "نام انگلیسی وب سایت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string WebsiteEnglishName { get; set; }
        [Display(Name = "نام  وب سایت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string WebsiteOwner { get; set; }
        [Display(Name = "درباره ما")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public string AboutText { get; set; }
        [Display(Name = "ارتباط با ما")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public string ContactText { get; set; }
        [Display(Name = "ارتباط با ما")]
        [DataType(DataType.PhoneNumber)]

        public string PhoneNumber { get; set; }
        [Display(Name = "آی دی تلگرام")]
        public string TelegramID { get; set; }
        [Display(Name = "آی دی اینستاگرام")]
        public string InstagramID { get; set; }
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
        [Display(Name = "متن صفحه ورودی سایت")]
        public string LandingText { get; set; }
    }
}
