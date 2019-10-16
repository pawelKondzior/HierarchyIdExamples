namespace HierarchyExamples63
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Product)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.ProductCategoryId);
        }
    }
}
