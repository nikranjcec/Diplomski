﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApartmaniService
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ApartmaniEntities : DbContext
    {
        public ApartmaniEntities()
            : base("name=ApartmaniEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Apartman> Apartman { get; set; }
        public virtual DbSet<Gost> Gost { get; set; }
        public virtual DbSet<Rezervacija> Rezervacija { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
