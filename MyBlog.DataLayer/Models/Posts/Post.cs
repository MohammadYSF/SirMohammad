using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyBlog.DataLayer
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }
        [Display(Name = "دسته بندی")]

        [Required(ErrorMessage = "لطفا دسته بندی را انتخاب کنید")]
        public int CategoryID { get; set; }
        [Display(Name = "عنوان پست")]
        [MaxLength(65, ErrorMessage = "تعداد کاراکتر باید کمتر از 65 باشد")]
        [Required(ErrorMessage = "لطفا عنوان مقاله را وارد کنید")]
        [DataType(DataType.Text)]
        public string PostTitle { get; set; }
        [Display(Name = "توضیح مختصر پست")]
        [MaxLength(160, ErrorMessage = "تعداد کاراکتر باید کمتر از 160 باشد")]
        [Required(ErrorMessage = "لطفا توضیح مختصر مقاله را وارد کنید")]
        [DataType(DataType.Text)]
        public string PostDescription { get; set; }
        [Display(Name = "متن مقاله")]
        [Required(ErrorMessage = "لطفامتن مقاله را وارد کنید")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string PostText { get; set; }
        [Display(Name = " کلمات کلیدی پست")]
        [DataType(DataType.Text)]
        public string PostKeywords { get; set; }
        [Display(Name = "تاریخ ایجاد پست")]

        [DataType(DataType.DateTime)]
        public DateTime PostDate { get; set; }

        [Display(Name = "تصویر")]
        [DataType(DataType.Text)]
        public string ImageName { get; set; }
        [Display(Name = "جانشین تصویر")]
        [Required(ErrorMessage = "لطفا جانشین تصویر مقاله را وارد کنید")]
        [DataType(DataType.Text)]
        [MaxLength(300, ErrorMessage = "تعداد کاراکتر باید کمتر از 300 باشد")]

        public string ImageAlt { get; set; }

        [Display(Name = "نویسنده؟")]
        public int? UserID { get; set; }

        //navigation properties
        public virtual Users User { get; set; }
        public virtual Category Category { get; set; }

        public virtual List<Comment> Comments { get; set; }

        public virtual List<PostSubImage> PostSubImages { get; set; }
        
        public Post()
        {

        }
    }
}
