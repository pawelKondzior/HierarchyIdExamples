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
    public class DataServiceEF63 : BaseDataService, IDataService
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


            var parentCategory = Context.HierarchyCategory
                .AsQueryable()
                .FirstOrDefault(x => x.Id == id);

            var childCategoryQuery =
                Context.HierarchyCategory
                .AsQueryable()
                .Where(x => x.Level.IsDescendantOf(parentCategory.Level) 
                && x.Level.GetLevel() == (parentCategory.Level.GetLevel() + 1));

            var childList = childCategoryQuery.ToList();

            result.Name = parentCategory.Name;
            result.Childs = GetDtoList(childList);

            return result;
        }

        public void Add(ProductCategoryDto add, int? parentId)
        {
            var entity = Context.HierarchyCategory.Create();
            entity.Name = add.Name;
            Context.HierarchyCategory.Add(entity);
            Context.SaveChanges();

            if (!parentId.HasValue)
            {
                entity.Level = HierarchyId.Parse(string.Format("/{0}/", entity.Id));
                Context.SaveChanges();
                return;
            }
            else
            {
                var parentEntity = Context.HierarchyCategory.FirstOrDefault(x => x.Id == parentId);
                entity.Level = HierarchyId.Parse(string.Format("{0}{1}/", parentEntity.Level.ToString(), entity.Id));
                Context.SaveChanges();
            }
        }

        public List<ProductCategoryDto> GetAll()
        {
            var root = HierarchyId.GetRoot();

            var parentEntity = Context.HierarchyCategory.FirstOrDefault(x => x.Level.IsDescendantOf(root));


            return new List<ProductCategoryDto>();
        }

        public List<ProductCategoryDto> GetChilds(int? categoryId)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategoryDto> GetTopLevel()
        {
            //var root = HierarchyId.GetRoot();

            var topLevelsList = Context.HierarchyCategory
               .Where(x => x.Level.GetLevel() == 1)
               .ToList();

            return GetDtoList(topLevelsList);

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

        public void AddProducts(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
