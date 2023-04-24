using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoProject.Models
{
    public class User
    {
        public int UserId { get; set; }
        [DisplayName(displayName: "First Name")]
        [Required(ErrorMessage = "First Name is Mandatory")]
        public string FirstName { get; set; }
        [DisplayName(displayName: "Last Name")]
        [Required(ErrorMessage = "Last Name is Mandatory")]
        public string LastName { get; set; }
        [DisplayName(displayName: "Mobile No")]
        [Required(ErrorMessage = "Mobile No is Mandatory")]
        [MinLength(10, ErrorMessage = "Please enter Valid Mobile No")]
        [MaxLength(10, ErrorMessage = "Please enter Valid Mobile No")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Please enter a valid number")]
        public string MobileNo { get; set; }
        [DisplayName(displayName: "Email Id")]
        [Required(ErrorMessage = "Email Id is Mandatory")]
        [EmailAddress]
        public string EmailId { get; set; }


    }
}