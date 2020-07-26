using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hrithvika.Models
{
    public class Custom_public
    {
        public int id { get; set; }
        [Required]
        [MaxLength(120)]
        public string NAME { get; set; }
        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string phone { get; set; }
       
        public string description { get; set; }
        public string photo { get; set; }
        public string video { get; set; }
        public Nullable<System.DateTime> createdon { get; set; }
        public Nullable<int> isactive { get; set; }
        public Nullable<int> isdeleted { get; set; }
    }
}