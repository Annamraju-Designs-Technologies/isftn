using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hrithvika.Models
{
    public class Custom_Events
    {
        public int id { get; set; }
        public string title { get; set; }
        public string image_url { get; set; }
        public Nullable<System.DateTime> Createdon { get; set; }
        public string createdby { get; set; }
        public string description { get; set; }
    }
}