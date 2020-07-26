using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hrithvika.Models
{
    public class Custom_Donation
    {
        public int id { get; set; }
        [Required (ErrorMessage ="Name feild is required")]
        public string NAME { get; set; }
        [Required (ErrorMessage = "Email feild is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string email { get; set; }
        [Required(ErrorMessage = "You must provide a Phone Number")]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string phone { get; set; }
        [Required]
        public Nullable<float> amount { get; set; }
        public string address { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string STATUS { get; set; }
        public Nullable<System.DateTime> createdon { get; set; }
    }
}