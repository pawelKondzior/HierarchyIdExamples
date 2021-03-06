﻿using System.Data.Entity;

namespace HierarchyExamples.EF
{
    public class EFContext : DbContext
    {
        public EFContext() : base("name=EFContext")
        {
        }

        public virtual DbSet<Category> ProductCategory { get; set; }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<HierarchyCategory> HierarchyCategory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
              .HasMany(e => e.Childs)
              .WithOptional(e => e.Parent)
              .HasForeignKey(e => e.ParentId);
        }
    }
}