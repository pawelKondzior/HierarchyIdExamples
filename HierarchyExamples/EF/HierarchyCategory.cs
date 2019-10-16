namespace HierarchyExamples.EF
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Hierarchy;

    [Table("Category", Schema = "Hierarchy")]
    public partial class HierarchyCategory
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public HierarchyId Level { get; set; }
    }
}