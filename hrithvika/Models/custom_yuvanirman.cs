using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hrithvika.Models
{
    public class custom_yuvanirman
    {
        public int id { get; set; }
        [Required]
        public string firstname { get; set; }
        [Required]
        public string lastname { get; set; }
        public System.DateTime createdon { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string organization { get; set; }
        [Required(ErrorMessage = "About is required.")]
        [MaxLength(2000, ErrorMessage = "Text cannot be longer than 2000 characters.")]
        public string about { get; set; }
        [Required]
        public string address { get; set; }
        public string awards { get; set; }
       
        public string email { get; set; }
       
        public string orglogo { get; set; }
        public string category { get; set; }
        public string video1 { get; set; }
        
        public string projectimages { get; set; }
     
        public string projectimages1 { get; set; }
      
        public string projectimages2 { get; set; }
        public string newsarticle1 { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public int isactive { get; set; }

    }
}