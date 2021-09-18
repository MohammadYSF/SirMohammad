using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.DataLayer
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }

        public int PostID { get; set; }

        //if it is null (or zero) , it is a father comment
        //if it is not null , it is a boy comment
        public int ParentID { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا نام خود را وارد کنید")]
        [DataType(DataType.Text)]
        [MaxLength(200)]

        public string CommentName { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا ایمیل خود را وارد کنید")]
        [DataType(DataType.Text)]
        [MaxLength(200)]

        public string CommentEmail { get; set; }
        [Display(Name = "متن نظر")]
        [Required(ErrorMessage = "لطفا نظر خودرا بنویسید")]
        [DataType(DataType.MultilineText)]
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public bool IsCommentOk { get; set; }

        public virtual Post Post { get; set; }
        public virtual Comment Comment1 { get; set; }
        public virtual List<Comment> Comment2 { get; set; }
        public Comment()
        {

        }
    }
}
