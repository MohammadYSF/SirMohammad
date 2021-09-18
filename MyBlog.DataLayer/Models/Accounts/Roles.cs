using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.DataLayer
{
   public class Roles
    {
        [Key]
        public int RoleID { get; set; }
        [Display(Name = "نام نقش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string RoleName { get; set; }

        //navigation properties
        public Roles()
        {

        }
        public List<Users> Users { get; set; }
    }
}
