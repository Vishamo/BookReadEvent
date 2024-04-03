﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadEvent.Models.AccountModel
{
    public class LoginModel
    {
        [Required][EmailAddress]
        public string Email { get; set; }
        [Required][DataType(DataType.Password)]
        public string password { get; set; }
        [Display(Name ="Remember Me")]
        public bool rememberme { get; set; }
    }
}
