﻿using ConsoleTableExt;
using EasyConsole;
using HierarchyExamples.Contracts;
using HierarchyExamples.Helpers.Helpers;
using HierarchyExamples.Helpers.Menu.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HierarchyExamples.Helpers.Menu.Actions
{

    public class OpenCategoryPage : ActionMenuPage
    {
        public OpenCategoryPage(IDataService dataService, Program program)
            : base(dataService, "Open category", program)
        {

        }

        public override void Display()
        {
            var topLevel = DataService.Get(CurrentParentID);
            DisplayHelpers.Display(topLevel, "Choose category to open");

            var selectedId = Input.ReadInt();

            var possibleIds = topLevel.Childs.Select(x => x.Id);

            if (possibleIds.Contains(selectedId))
            {
                CurrentParentID = selectedId; 
            }
            else
            {
                Output.DisplayPrompt("Item cannot be open");
            }

            //Input.ReadString("Press [Enter] to navigate home");

            Program.NavigateTo<DisplayCategory>();

            ///Program.NavigateBack();
            //Program.NavigateHome();
        }

    }
}
