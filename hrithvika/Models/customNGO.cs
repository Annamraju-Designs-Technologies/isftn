using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hrithvika.Models
{
    public class customNGO
    {
        public int id { get; set; }
        [Required(ErrorMessage = "NGO Name feild is required")]
        public string orgname { get; set; }
        [Required(ErrorMessage = "NGO Email feild is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string orgemail { get; set; }
        public System.DateTime createdon { get; set; }
        [Required(ErrorMessage = "You must provide a Phone Number")]
        [Display(Name = "NGO Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string orgphone { get; set; }
        public string orglogo { get; set; }
        public string orgdocuments { get; set; }
        public string State { get; set; }
        [Required(ErrorMessage = "NGO Address feild is required")]
        public string orgaddress { get; set; }
        public string presidentname { get; set; }
        public string presedentphone { get; set; }
        public string secretaryname { get; set; }
        public string secretaryphone { get; set; }
        public string presidentemail { get; set; }
        public string secretaryemail { get; set; }
    }
}