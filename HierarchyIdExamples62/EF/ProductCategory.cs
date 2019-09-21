namespace HierarchyIdExamples62.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductCategory")]
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Product = new HashSet<Product>();
            Childs = new HashSet<ProductCategory>();
        }

        

        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public int? ParentId { get; set; }

        public virtual ICollection<Product> Product { get; set; }

        public virtual ICollection<ProductCategory> Childs { get; set; }

        public virtual ProductCategory Parent { get; set; }
    }
}
