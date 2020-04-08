using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GazaEmgCore2.ViewModels
{
    public class RegisterModel
    {

        [Required]
        [Display(Name = "اسم المشتخدم")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "الايميل")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة السر")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تاكيد كلمة السر ")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "الاسم الاول ")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "الاسم الاخير ")]
        public string lastName { get; set; }

        [Required]
        [Display(Name = "الجوال")]
        public string Mobile { get; set; }

        [Required]
        [Display(Name = "رقم الهوية")]
        public string Id_NO { get; set; }

    }
}
