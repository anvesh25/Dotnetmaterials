﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RegistrationAndLogin.Models
{
    public class UserLogin
    {
        [Display(Name ="Email ID")]
        [Required(AllowEmptyStrings = false, ErrorMessage ="Email Id is required")]
        public string EmailID { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="Password Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}