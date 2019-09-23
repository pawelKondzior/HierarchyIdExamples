namespace HierarchyIdExamples62.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EFContext : DbContext
    {
        public EFContext()
            : base("name=EFContext")
        {
        }

       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
               .HasMany(e => e.Childs)
               .WithOptional(e => e.Parent)
               .HasForeignKey(e => e.ParentId);
        }
    }
}
