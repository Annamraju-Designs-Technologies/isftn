using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hrithvika.Models
{
    public class Custom_GalleryEvents
    {
        public int id { get; set; }
        public int eventid { get; set; }
        public string image_url { get; set; }
        public string eventtype { get; set; }
        public Nullable<System.DateTime> Createdon { get; set; }
        public string createdby { get; set; }
        public HttpPostedFileBase[] files { get; set; }
    }
}