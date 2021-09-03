using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }
        [Display(Name ="نام کاربری")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string UserName { get; set; }
        [Display(Name = "ایمیل")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(250)]
        public string UserEmail { get; set; }
        [Display(Name ="کلمه عبور")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        [MaxLength(200)]
        public string UserPass { get; set; }
    }
}
