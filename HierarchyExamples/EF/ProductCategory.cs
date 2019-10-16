namespace HierarchyExamples.EF
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Category")]
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
            Childs = new HashSet<Category>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public int? ParentId { get; set; }

        public virtual ICollection<Product> Product { get; set; }

        public virtual ICollection<Category> Childs { get; set; }

        public virtual Category Parent { get; set; }
    }
}