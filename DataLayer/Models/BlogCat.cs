using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BlogCat
    {
        [Key]
        public int CatId { get; set; }

        [Display(Name ="عنوان دسته")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [MaxLength(200)]

        public String CatName { get; set; }



        public virtual List<Blog> Blogs { get; set; }

        public BlogCat()
        {
                
        }
    }
}
