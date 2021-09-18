using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.DataLayer
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Display(Name = "نام دسته بندی")]
        [MaxLength(100 , ErrorMessage = "تعداد کاراکتر نباید بیشتر از 100 باشد")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "لطفا نام دسته بندی را وارد کنید")]
        
        public string CategoryName { get; set; }

        public virtual List<Post> Posts { get; set; }

        public Category()
        {

        }
    }
}
