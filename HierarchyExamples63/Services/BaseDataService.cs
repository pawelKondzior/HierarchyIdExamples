using HierarchyExamples.Contracts;
using HierarchyExamples63.EF;
using HierarchyIdExamples62.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace HierarchyExamples63.Services
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
