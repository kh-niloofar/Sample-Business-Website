using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataLayer
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }


        [Display(Name ="نوع صفحه")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        public int PageId { get; set; }


        [Display(Name ="نام مقاله")]
        public int? BlogId { get; set; }

        [Display(Name = "نام پروژه")]
        public int? ProjectId { get; set; }


        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public String UserName { get; set; }


        [Display(Name ="ایمیل")]
        [DataType(DataType.EmailAddress)]
        public String UserEmail { get; set; }

        [Display(Name = "دیدگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public String UserComment { get; set; }

        [Display(Name = "زمان ایجاد")]
        [DisplayFormat(DataFormatString ="{0:yyyy/MM/dd}")]
        public DateTime CreateDate { get; set; }


        public virtual Blog Blogs { get; set; }
        public virtual Project Projects { get; set; }
        public virtual page Pages { get; set; }
        public Comment()
        {

        }


    }
}
