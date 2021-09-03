using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataLayer
{
    public class Services
    {
        [Key]
        public int ServiceId { get; set; }

        [Display(Name ="نام سرویس")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [MaxLength(200)]

        public String ServiceName { get; set; }

        [Display(Name = "توضیح سرویس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300)]
        [AllowHtml]
        public String ServiceContent { get; set; }


        public virtual List<Project> Projects { get; set; }
        public Services()
        {
                
        }

    }
}
