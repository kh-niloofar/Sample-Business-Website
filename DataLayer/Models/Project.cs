using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataLayer
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Display(Name = "عنوان پروژه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public String ProjectSubject { get; set; }

        [Display(Name = "نام سرویس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int ServiceId { get; set; }

        [Display(Name = "توضیح مختصر ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300)]
        public String ProjectDesc { get; set; }

        [Display(Name = "توضیح پروژه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public String ProjectContent { get; set; }

        [Display(Name = "بازدید از پروژه")]
        public int ProjectVisit { get; set; }

        [Display(Name = "عکس پروژه")]
        public String ProjectImage { get; set; }

        [Display(Name = "تاریخ شروع پروژه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Date)]
        public DateTime ProjectStartDate { get; set; }

        [Display(Name = "تاریخ پایان پروژه ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Date)]
        public DateTime ProjectEndDate { get; set; }



        public virtual Services Services { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public Project()
        {
                
        }


    }
}
