using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hrithvika.Models
{
    public class custom_Team
    {
        public int id { get; set; }
        public string img_url { get; set; }
        public string link { get; set; }
        public string title { get; set; }
        public System.DateTime createdon { get; set; }

        public string type { get; set; }
    }
   
}