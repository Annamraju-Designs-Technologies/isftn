//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace hrithvika.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class publicvoice
    {
        public int id { get; set; }
        public string NAME { get; set; }
        public string phone { get; set; }
        public string description { get; set; }
        public string photo { get; set; }
        public string video { get; set; }
        public Nullable<System.DateTime> createdon { get; set; }
        public Nullable<int> isactive { get; set; }
        public Nullable<int> isdeleted { get; set; }
    }
}
