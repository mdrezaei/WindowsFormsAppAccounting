﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp2_Accounting_DataLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Accounting_DBEntities : DbContext
    {
        public Accounting_DBEntities()
            : base("name=Accounting_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customers_info> Customers_info { get; set; }
        public virtual DbSet<Accounting> Accounting { get; set; }
        public virtual DbSet<Accounting_Type> Accounting_Type { get; set; }
        public virtual DbSet<Login> Login { get; set; }
    }
}
