using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleMenu;

namespace HierarchyExamples.ConsoleItems
{
    public static class MenuHelper
    {
        public static List<MenuItem> GetFirstMenu()
        {
            List<MenuItem> list = new List<MenuItem>();
            list.Add(new MenuItem()
            {
                Caption = "Access to table with Entity Fremwork and foreign key to same table",
                Start = (Action)(() =>
                {
                    Console.ForegroundColor = ConsoleColor.White;
                })
            });
            list.Add(new MenuItem()
            {
                Caption = "Access to table with Entity Fremwork and HierarchyID ",
                Start = (Action)(() =>
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                })
            });

            return list;
        }

        public static void StartMenu()
        {
            var list = GetFirstMenu();

            var actionMenu = new Menu("ActionMenu");
            var act = actionMenu.Render(list);
            act.Start();
        }


        public static void StartTestMenu()
        {
            List<MenuItem> i = new List<MenuItem>();
            i.Add(new MenuItem()
            {
                Caption = "Blue item",
                Start = (Action)(() =>
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("blue chose option");
                })
            });
            i.Add(new MenuItem()
            {
                Caption = "Yellow item",
                Start = (Action)(() =>
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("yellow chose option");
                })
            });

            var actionMenu = new Menu("ActionMenu");
            var act = actionMenu.Render(i);
            act.Start();

            var coloredMenu = new Menu("Colored");
            coloredMenu.Config.SelectedAppearence.ForegroundColor = ConsoleColor.Red;
            coloredMenu.Config.SelectedAppearence.BackgroundColor = ConsoleColor.DarkGray;

            var menuItems = new List<Menu>();
            menuItems.Add(new Menu("Standard"));
            menuItems.Add(coloredMenu);

            var menu = new Menu();
            var choice = menu.Render(menuItems);

            switch (choice.Name)
            {
                case "Standard":
                    var standardItems = new string[] { "Option 1", "Option 2", "Option 3" };
                    choice.Render(standardItems);
                    break;

                case "Colored":
                    var coloredItems = System.Enum.GetNames(typeof(ConsoleColor));
                    Console.WriteLine("Select a color");
                    var secondSelected = choice.Render(coloredItems);
                    Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), secondSelected);
                    Console.Write(secondSelected);
                    Console.ResetColor();
                    Console.WriteLine(" is a beautiful color.");
                    break;
            }
        }
    }
}
