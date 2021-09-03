using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataLayer
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }



        [Display(Name ="عنوان مقاله")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [MaxLength(200)]

        public String BlogSubject { get; set; }

        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int CatId { get; set; }

        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250)]
        public String BlogDesc { get; set; }

        [Display(Name = "متن مقاله")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public String BlogContent { get; set; }

        [Display(Name = "عکس مقاله")]
        public String BlogImageName { get; set; }

        [Display(Name = "تگ مقاله")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public String BlogTag { get; set; }

        [Display(Name = "بازدید مقاله")]
        public int BlogVisit { get; set; }


        [Display(Name = "تاریخ ایجاد مقاله")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime BlogDate { get; set; }




        public virtual BlogCat BlogCats { get; set; }
        public virtual List<Comment> BlogComments { get; set; }

        public Blog()
        {

        }

    }
}
