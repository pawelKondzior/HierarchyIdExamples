using HierarchyExamples.Contracts;
using HierarchyIdExamples62.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HierarchyExamples.Shared;
using System.Data.Entity;

namespace HierarchyExamples62.Services
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
            entity.ParentId = parentId;

            Context.ProductCategory.Add(entity);
            Context.SaveChanges();
        }

        public ProductCategoryExtendedDto Get(int? id)
        {
            var result = new ProductCategoryExtendedDto();

            if (!id.HasValue || id == 0)
            {
                result.Childs = GetTopLevel();
                return result;
            }

            var category = Context.ProductCategory
                .AsQueryable()
                .Include(x => x.Childs)
                .FirstOrDefault(x => x.Id == id);

            result.Name = category.Name;
            result.Childs = GetDtoList(category.Childs);

            return result;
        }




        public List<ProductCategoryDto> GetAll()
        {
            var categoryList = Context.ProductCategory.ToList();

            var result = GetDtoList(categoryList);

            return result;
        }

        private static List<ProductCategoryDto> GetDtoList(IEnumerable<ProductCategory> categoryList)
        {
            var result = new List<ProductCategoryDto>();

            EntitiesToListDto(categoryList, result);

            return result;
        }

        private static void EntitiesToListDto(IEnumerable<ProductCategory> categoryList, List<ProductCategoryDto> result)
        {
            foreach(var entity in categoryList)
            {
                var dto = new ProductCategoryDto();
                dto.Id = entity.Id;
                dto.Name = entity.Name;

                result.Add(dto);
            }
        }

        public List<ProductCategoryDto> GetChilds(int? categoryId)
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
            var entity = Context.ProductCategory
             .FirstOrDefault(x => x.Id == categoryId);

            Context.ProductCategory.Remove(entity);
            Context.SaveChanges();
        }

        
        
    }
}
