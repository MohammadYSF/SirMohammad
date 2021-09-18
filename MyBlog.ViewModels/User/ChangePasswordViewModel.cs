using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.ViewModels
{
  public  class ChangePasswordViewModel
    {
        
        public int UsrID { get; set; }
        [Display(Name = "رمز عبور قبلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500)]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Display(Name = "رمز عبور قبلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }
}
