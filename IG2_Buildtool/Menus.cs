using System;
using System.Collections.Generic;
using System.Text;

namespace IG2_Buildtool
{
    public enum MainMenuOptions
    {
        Build = 1,
        Clean = 2,
        Exit = 0
    }

    public enum BuildMenuClientOptions
    {
        All = 1,
        Italy = 2,
        Germany = 3,
        Back = 9,
        Exit = 0
    }

    public enum BuildMenuActionOptions
    {
        Build = 1,
        Rebuild = 2,
        Back = 9,
        Exit = 0
    }

    public enum BuildMenuConfigOptions
    {
        Debug = 1,
        Release = 2,
        Back = 9,
        Exit = 0
    }

    public static class Menus
    {
        public static MainMenuOptions DisplyMainMenu()
        {
            List<string> options = new List<string>(new string[] { "1", "2", "0" });
            Console.WriteLine("####Welcome to IG2 Build Tool####\n");
            Console.WriteLine("Select an option from the list:");
            Console.WriteLine("1. Build");
            Console.WriteLine("2. Clean");
            Console.WriteLine("0. Exit");
            Console.Write("Action: ");
            string sel = Console.ReadLine();
            if (ValidateSelection(sel, options))
            {
                int.TryParse(sel, out int selection);
                return Enum.Parse<MainMenuOptions>(selection.ToString());
            }
            else
            {
                return DisplyMainMenu();
            }
            
        }

        public static BuildMenuClientOptions DisplayBuildClientMenu()
        {
            List<string> options = new List<string>(new string[] { "1", "2", "3", "9", "0" });
            Console.WriteLine();
            Console.WriteLine("Select client from the list:");
            Console.WriteLine("1. All");
            Console.WriteLine("2. Italy");
            Console.WriteLine("3. Germany");
            Console.WriteLine("9. Back");
            Console.WriteLine("0. Exit");
            Console.Write("Action: ");
            string sel = Console.ReadLine();
            if (ValidateSelection(sel, options))
            {
                int.TryParse(sel, out int selection);
                return Enum.Parse<BuildMenuClientOptions>(selection.ToString());
            }
            else
            {
                return DisplayBuildClientMenu();
            }
        }

        public static BuildMenuActionOptions DisplayBuildActionMenu()
        {
            List<string> options = new List<string>(new string[] { "1", "2", "9", "0" });
            Console.WriteLine();
            Console.WriteLine("Select build action from the list:");
            Console.WriteLine("1. Build");
            Console.WriteLine("2. Rebuild");
            Console.WriteLine("9. Back");
            Console.WriteLine("0. Exit");
            Console.Write("Action: ");
            string sel = Console.ReadLine();
            if (ValidateSelection(sel, options))
            {
                int.TryParse(sel, out int selection);
                return Enum.Parse<BuildMenuActionOptions>(selection.ToString());
            }
            else
            {
                return DisplayBuildActionMenu();
            }
                
        }

        public static BuildMenuConfigOptions DisplayBuildConfigMenu()
        {
            List<string> options = new List<string>(new string[] { "1", "2", "9", "0" });
            Console.WriteLine();
            Console.WriteLine("Select build configuration from the list:");
            Console.WriteLine("1. Debug");
            Console.WriteLine("2. Release");
            Console.WriteLine("9. Back");
            Console.WriteLine("0. Exit");
            Console.Write("Action: ");
            string sel = Console.ReadLine();
            if (ValidateSelection(sel, options))
            {
                int.TryParse(sel, out int selection);
                return Enum.Parse<BuildMenuConfigOptions>(selection.ToString());
            }
            else
            {
                return DisplayBuildConfigMenu();
            }
        }

        static bool ValidateSelection(string selection, List<string> options)
        {
            if (!int.TryParse(selection, out int result))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Action must be a number!\n");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            else if (!options.Contains(selection))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid option!\n");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            return true;
        }
    }
}
