using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hrithvika.Models
{
    public class custom_Gallery
    {
        public int id { get; set; }
        public string path { get; set; }
        public Nullable<System.DateTime> createdon { get; set; }
        public bool isimportant { get; set; }
        public string TYPE { get; set; }
        public Nullable<int> rank { get; set; }
        public HttpPostedFileBase[] files { get; set; }
        public string title { get; set; }
        public string category { get; set; }
    }
}