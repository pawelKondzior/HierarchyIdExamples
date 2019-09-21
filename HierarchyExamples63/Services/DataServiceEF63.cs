using HierarchyExamples.Contracts;
using HierarchyExamples.Shared;
using HierarchyExamples63.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Hierarchy;
using System.Linq;
using System.Text;

namespace HierarchyExamples63.Services
{
    public class DataServiceEF63 : IDataService
    {
        private EFContext Context { get; set; }

        public DataServiceEF63()
        {
            ReferenceUtil.EnsureStaticReference<System.Data.Entity.SqlServer.SqlProviderServices>();

            Context = new EFContext();
        }

        public void Dispose()
        {
            Context.Dispose();
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
                .FirstOrDefault();
              ///  .Include(x => x.Childs)
                ///.FirstOrDefault(x => x.Id == id);

            ///result.Name = category.Name;
            // result.Childs = GetDtoList(category.Childs);

            return result;
        }

        public void Add(ProductCategoryDto add, int? parentId)
        {
            var entity = Context.ProductCategory.Create();
            entity.Name = add.Name;
            entity.Level = HierarchyId.Parse("/1/");

            HierarchyId.GetRoot()
            
            Context.ProductCategory.Add(entity);
            Context.SaveChanges();
        }

       

        

        public List<ProductCategoryDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<ProductCategoryDto> GetChilds(int? categoryId)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategoryDto> GetTopLevel()
        {
            return new List<ProductCategoryDto>();

            //throw new NotImplementedException();
        }

        public List<ProductCategoryDto> GetTree()
        {
            throw new NotImplementedException();
        }

        public void Remove(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
