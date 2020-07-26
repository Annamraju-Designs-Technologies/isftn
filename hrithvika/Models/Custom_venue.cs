using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hrithvika.Models
{
    public class Custom_venue
    {
        public int id { get; set; }
        [Required]
        public string NAME { get; set; }
        [Required(ErrorMessage = "NGO Email feild is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string email { get; set; }
        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = " Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string phone { get; set; }
        public string state { get; set; }
        public string district { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string venue_area { get; set; }
        public int isdeletd { get; set; }
        public Nullable<int> isactive { get; set; }
        public Nullable<System.DateTime> createdon { get; set; }
        public Nullable<System.DateTime> modifiedon { get; set; }
        public string fblink { get; set; }
    }
}