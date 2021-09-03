using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class page
    {
        [Key]

        public int PageID { get; set; }
        [Display(Name ="نوع صفحه")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [MaxLength(150)]

        public String PageType { get; set; }



        public virtual List<Comment> Comments { get; set; }

        public page()
        {

        }

    }
}
