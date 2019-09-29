using ConsoleTableExt;
using EasyConsole;
using HierarchyExamples.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HierarchyExamples.Helpers
{
    public static class DisplayHelpers
    {

        public static void Display(ProductCategoryExtendedDto categoryDto, string tableHeader = "")
            {
            if (!string.IsNullOrEmpty(categoryDto.Name))
            {
                var str = string.Format("Category name: {0}", categoryDto.Name);
                Output.WriteLine(ConsoleColor.Green, str);
            }

            DisplayHelpers.WriteTable(tableHeader, categoryDto.Childs);
        }

        public static void WriteTable(string name, List<ProductCategoryDto> list)
        {
            if (list.Any())
            {
                var listBuilder = ConsoleTableBuilder.From(list);

                listBuilder
                     .WithFormat(ConsoleTableBuilderFormat.Alternative)
                     .ExportAndWriteLine();
            }
            else
            {
                Output.WriteLine("No items in list");
            }
        }
    }
}
