using HierarchyExamples.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HierarchyExamples63.Services
{
    public class DataService : IDataService
    {
        public DataService()
        {

        }


        public void Add(ProductCategoryDto add, int? parentId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<ProductCategoryDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<ProductCategoryDto> GetChilds(int categoryId)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategoryDto> GetTopLevel()
        {
            throw new NotImplementedException();
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
