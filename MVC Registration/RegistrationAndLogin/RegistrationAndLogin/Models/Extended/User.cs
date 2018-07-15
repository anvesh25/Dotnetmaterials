using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Net;

namespace RegistrationAndLogin.Models
{
    [MetadataType(typeof(userMetadata))]
    public partial class User
    {
        public string ConfirmPassword { get; set; }
    }
    public class userMetadata
    {
        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name required")]
        public string Lastname { get; set; }

        [Display(Name = "Email Id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Id is required")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:MM/dd/yyyy}")]
        public string DateOfBirth { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="Password is required")]
        [MinLength(6, ErrorMessage ="Minimum 6 characters required")]
        [DataType(DataType.Password)]
        public string Password { get; set;}

        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Confirm Password and password did not matched")]
        public string ConfirmPassword { get; set; }
    }
}