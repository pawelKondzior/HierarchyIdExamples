using HierarchyExamples.Contracts;
using HierarchyExamples.EF;
using HierarchyExamples.Misc;

using System;
using System.Collections.Generic;
using System.Data.Entity.Hierarchy;
using System.Linq;

namespace HierarchyExamples.Services
{
    public class HierarchyIdDataService : BaseDataService, IDataService
    {
        private EFContext Context { get; set; }

        public HierarchyIdDataService()
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

            var childCategoryQuery = Context.HierarchyCategory
                .AsQueryable()
                .Where(x => x.Level.GetAncestor(1) == parentCategory.Level);

            var childList = childCategoryQuery.ToList();

            result.Name = parentCategory.Name;
            result.Childs = GetDtoList(childList);

            return result;
        }

        //public void Add(ProductCategoryDto add, int? parentId)
        //{
        //    var entity = Context.HierarchyCategory.Create();
        //    entity.Name = add.Name;
        //    Context.HierarchyCategory.Add(entity);
        //    Context.SaveChanges();

        //    if (!parentId.HasValue)
        //    {
        //        entity.Level = HierarchyId.Parse(string.Format("/{0}/", entity.Id));
        //    }
        //    else
        //    {
        //        var parentEntity = Context.HierarchyCategory.FirstOrDefault(x => x.Id == parentId);
        //        entity.Level = HierarchyId.Parse(string.Format("{0}{1}/", parentEntity.Level.ToString(), entity.Id));
        //    }
        //    Context.SaveChanges();
        //}

        public void Add(ProductCategoryDto add, int? parentId)
        {
            var entity = Context.HierarchyCategory.Create();
            entity.Name = add.Name;

            HierarchyId parentItem;
            HierarchyCategory lastItemInCurrentLevel;

            if (!parentId.HasValue)
            {
                parentItem = HierarchyId.GetRoot();
            }
            else
            {
                parentItem = Context.HierarchyCategory.FirstOrDefault(x => x.Id == parentId).Level;
            }

            lastItemInCurrentLevel = Context.HierarchyCategory
                  .Where(x => x.Level.GetAncestor(1) == parentItem)
                  .OrderByDescending(x => x.Level)
                  .FirstOrDefault();

            var child1Level = lastItemInCurrentLevel != null ? lastItemInCurrentLevel.Level : null;

            var newLevel = parentItem.GetDescendant(child1Level, null);
            entity.Level = newLevel;

            Context.HierarchyCategory.Add(entity);
            Context.SaveChanges();
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
            // first version
            var topLevelQuery = Context.HierarchyCategory.Where(x => x.Level.GetLevel() == 1);

            // second version
            //var root = HierarchyId.GetRoot();

            //var topLevelQuery = Context.HierarchyCategory
            //   .Where(x => x.Level.GetAncestor(1) == root);

            var topLevelList = topLevelQuery.ToList();

            return GetDtoList(topLevelList);
        }

        public List<ProductCategoryDto> GetTree()
        {
            var topLevelQuery = Context.HierarchyCategory.Where(x => x.Level.GetLevel() == 1);

            throw new NotImplementedException();
        }

        public void Remove(int categoryId)
        {
            var parentItem = Context.HierarchyCategory.FirstOrDefault(x => x.Id == categoryId);

            var allChildsToDelete = Context.HierarchyCategory
                .Where(x => x.Level.IsDescendantOf(parentItem.Level))
                .ToList();

            allChildsToDelete.ForEach(x => Context.HierarchyCategory.Remove(x));

            Context.HierarchyCategory.Remove(parentItem);

            Context.SaveChanges();
        }
    }
}