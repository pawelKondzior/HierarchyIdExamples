using System.Collections.Generic;

namespace HierarchyExamples.Contracts
{
    public class ProductCategoryExtendedDto : ProductCategoryDto
    {
        public List<ProductCategoryDto> Childs { get; set; }
    }

}
