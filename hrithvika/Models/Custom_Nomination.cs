using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hrithvika.Models
{
    public class Custom_Nomination
    {
        public int id { get; set; }
        public string NAME { get; set; }
        [Required]
        public string title { get; set; }
        public string Description { get; set; }
        public string display_image { get; set; }
        [Required]
        public string video { get; set; }
       
        [Required]
        public string email { get; set; }
        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Home Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string phone { get; set; }
        public System.DateTime createdon { get; set; }
        public int isdeleted { get; set; }
        public int isactive { get; set; }
        public string category { get; set; }
    }
}