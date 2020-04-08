using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GazaEmgCore2.ViewModels
{
    public class LoginViewModel
    {


        [Required]
        //[Display(Name = "Email")]
        //[EmailAddress]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة السر")]
        public string Password { get; set; }

        [Display(Name = " تذكرني ?")]
        public bool RememberMe { get; set; }
    }
}
