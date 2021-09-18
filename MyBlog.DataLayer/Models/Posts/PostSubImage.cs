using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.DataLayer
{
    public class PostSubImage
    {
        [Key]
        public int SubID { get; set; }
        [Required]
        public int PostID { get; set; }
        [Required]
        public string SubImageName { get; set; }

        //navigation properties
        public PostSubImage()
        {

        }
        public virtual Post Post { get; set; }
    }
}
