﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NumberSearch.DATA
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ICN_NumberSearchEntities : DbContext
    {
        public ICN_NumberSearchEntities()
            : base("name=ICN_NumberSearchEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<CodePoint> CodePoints { get; set; }
        public DbSet<Number> Numbers { get; set; }
        public DbSet<NumberOperator> NumberOperators { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<tb_Setting> tb_Setting { get; set; }
        public DbSet<UploadedFile> UploadedFiles { get; set; }
        public DbSet<vw_NumbersAndOperators> vw_NumbersAndOperators { get; set; }
    }
}