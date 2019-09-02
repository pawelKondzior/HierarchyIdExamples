using HierarchyExamples.Contracts;
using HierarchyIdExamples62.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HierarchyExamples.Shared;

namespace HierarchyExamples63.Services
{
    public class DataServiceEF62 : IDataService
    {
        private EFContext Context { get; set; } 


        public DataServiceEF62()
        {
            ReferenceUtil.EnsureStaticReference<System.Data.Entity.SqlServer.SqlProviderServices>();

            Context = new EFContext();
        }


        public void Dispose()
        {
            Context.Dispose();
        }

        public void Add(ProductCategoryDto add, int? parentId)
        {
            var entity = Context.ProductCategory.Create();
            entity.Name = add.Name;

            Context.ProductCategory.Add(entity);
            Context.SaveChanges();
        }


        public List<ProductCategoryDto> GetAll()
        {
            var categoryList = Context.ProductCategory.ToList();
           
            var result = GetDtoList(categoryList);

            return result;
        }

        private static List<ProductCategoryDto> GetDtoList(List<ProductCategory> categoryList)
        {
            var result = new List<ProductCategoryDto>();

            categoryList.ForEach(entity =>
            {
                var dto = new ProductCategoryDto();
                dto.Id = entity.Id;
                dto.Name = entity.Name;

                result.Add(dto);
            });

            return result;
        }


        public List<ProductCategoryDto> GetChilds(int categoryId)
        {
            var categoryList = Context.ProductCategory
                .Where(x => x.ParentId == categoryId)
                .ToList();

            var result = GetDtoList(categoryList);

            return result;

        }

        public List<ProductCategoryDto> GetTopLevel()
        {
            var categoryList = Context.ProductCategory
                .Where(x => !x.ParentId.HasValue)
                .ToList();

            var result = GetDtoList(categoryList);

            return result;
        }

        public List<ProductCategoryDto> GetTree()
        {
            /// Ohoho bedzie smieszne

            throw new NotImplementedException();
        }

        public void Remove(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
