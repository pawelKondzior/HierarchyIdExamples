using HierarchyExamples.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.Entity;
using HierarchyExamples.Services;
using HierarchyExamples.Misc;
using HierarchyExamples.EF;

namespace HierarchyExamples.Services
{
    public class ParentChildDataService : BaseDataService, IDataService
    {
        private EFContext Context { get; set; }


        public ParentChildDataService()
        {
            ReferenceUtil.EnsureStaticReference<System.Data.Entity.SqlServer.SqlProviderServices>();

            Context = new EFContext();
        }


        public void Dispose()
        {
            Context.Dispose();
        }

        public void AddProducts(int? id)
        {

            var category = Context.ProductCategory
                .AsQueryable()
                .FirstOrDefault(x => x.Id == id);

            foreach( var i in Enumerable.Range(1, 10))
            {
                var product = new Product
                {
                    Name = string.Format("Product name {0}", i)
                };

                category.Product.Add(product);
            }

            Context.SaveChanges();
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

        private static List<ProductCategoryDto> GetDtoList(IEnumerable<Category> categoryList)
        {
            var result = new List<ProductCategoryDto>();

            EntitiesToListDto(categoryList, result);

            return result;
        }

        private static void EntitiesToListDto(IEnumerable<Category> categoryList, List<ProductCategoryDto> result)
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
