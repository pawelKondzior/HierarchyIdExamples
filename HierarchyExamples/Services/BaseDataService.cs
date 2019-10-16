using HierarchyExamples.Contracts;
using HierarchyExamples.EF;
using System.Collections.Generic;

namespace HierarchyExamples.Services
{
    public abstract class BaseDataService
    {
        protected static List<ProductCategoryDto> GetDtoList(IEnumerable<Category> categoryList)
        {
            var result = new List<ProductCategoryDto>();

            foreach (var entity in categoryList)
            {
                var dto = new ProductCategoryDto();
                dto.Id = entity.Id;
                dto.Name = entity.Name;

                result.Add(dto);
            }

            return result;
        }

        protected static List<ProductCategoryDto> GetDtoList(IEnumerable<HierarchyCategory> categoryList)
        {
            var result = new List<ProductCategoryDto>();

            foreach (var entity in categoryList)
            {
                var dto = new ProductCategoryDto();
                dto.Id = entity.Id;
                dto.Name = entity.Name;

                result.Add(dto);
            }

            return result;
        }
    }
}