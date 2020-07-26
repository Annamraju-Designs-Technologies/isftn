using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hrithvika.Models
{
    public class payment
    {
        public int id { get; set; }
        public string NAME { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public Nullable<float> amount { get; set; }
        public string address { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string STATUS { get; set; }
        public Nullable<System.DateTime> createdon { get; set; }
    }
}