﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ph16787236639_Entities : DbContext
    {
        public ph16787236639_Entities()
            : base("name=ph16787236639_Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<admin> admins { get; set; }
        public virtual DbSet<HRTVIK_events> HRTVIK_events { get; set; }
        public virtual DbSet<HRTVIK_gallery> HRTVIK_gallery { get; set; }
        public virtual DbSet<Person> People { get; set; }
    }
}
