using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataLayer
{
    public class FunYaasie
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "سوژه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100 , ErrorMessage = "چه خبرته ! ")]
        [MinLength(3 , ErrorMessage = "حداقل سه کاراکتر باید باشه")]
        public string Subject { get; set; }
        [Display(Name = "گزارش دهنده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "چه خبرته ! ")]
        [MinLength(3, ErrorMessage = "حداقل سه کاراکتر باید باشه")]
        public string Reporter { get; set; }
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(1000 , ErrorMessage = "چه خبرته !")]
        public string Description { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }
    }
}
