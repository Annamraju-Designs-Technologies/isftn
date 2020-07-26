using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hrithvika.Models
{
    public class Custom_preyuva
    {
        public int id { get; set; }
        [Required]
        public string NAME { get; set; }
        [Required]
        public string Father_name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string phone { get; set; }
        public string category { get; set; }
        public string institution_name { get; set; }
        public string institution_address { get; set; }
        [Required]
        public string project_title { get; set; }
        [Required]
        public string project_description { get; set; }
        public Nullable<int> group_mumbers { get; set; }
        public string class_or_course { get; set; }
        public Nullable<System.DateTime> createdon { get; set; }
        public string Date_of_birth { get; set; }
    }
}