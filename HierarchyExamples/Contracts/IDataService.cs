using System;
using System.Collections.Generic;

namespace HierarchyExamples.Contracts
{
    public interface IDataService : IDisposable
    {
        List<ProductCategoryDto> GetTopLevel();

        List<ProductCategoryDto> GetChilds(int? categoryId);

        void Add(ProductCategoryDto add, int? parentId);

        void Remove(int categoryId);

        List<ProductCategoryDto> GetAll();

        List<ProductCategoryDto> GetTree();

        ProductCategoryExtendedDto Get(int? id);

        void AddProducts(int? id);
    }
}