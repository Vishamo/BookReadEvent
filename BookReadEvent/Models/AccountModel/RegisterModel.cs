using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadEvent.Models.AccountModel
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress(ErrorMessage ="Please Enter a Valid Email Address")]
        
        public string Email { get; set; }
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [Required]
        [MinLength(5)]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword",ErrorMessage ="Password DoesNot Match")]
        public string password { get; set; }
        [Required]
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
