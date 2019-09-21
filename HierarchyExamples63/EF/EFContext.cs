using HierarchyExamples.Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchyExamples63.EF
{
    public class EFContext : DbContext
    {
        public EFContext() : base("name=EFContext")
        {
          
        }

        public virtual DbSet<ProductCategory> ProductCategory { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
