using System;
using System.Collections.Generic;

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

    public class Menus
    {
        private static Menus _instance;

        public static Menus Instance =>_instance ?? InitMenus();

        private static object _lock = new object();
        private static Menus InitMenus()
        {
            lock(_lock)
            {
                return _instance ?? (_instance = new Menus()); 
            }
        }

        public string Client { get; private set; }
        public string Action { get; private set; }
        public string Config { get; private set; }

        public  MainMenuOptions DisplyMainMenu()
        {
            List<string> options = new List<string>(new string[] { "1", "2", "0" });
            Console.WriteLine("Select an option from the list:");
            Console.WriteLine("1. Build");
            Console.WriteLine("2. Clean");
            Console.WriteLine("0. Exit");
            Console.Write("Action: ");
            string userSelection = Console.ReadLine();
            if (ValidateSelection(userSelection, options))
            {
                var parsedSelection = Enum.Parse<MainMenuOptions>(userSelection);
                Console.WriteLine("You choosed: {0}", Enum.GetName(typeof(MainMenuOptions), parsedSelection));
                return parsedSelection;
            }
            else
            {
                return DisplyMainMenu();
            }
            
        }

        public BuildMenuClientOptions DisplayBuildClientMenu()
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
            string userSelection = Console.ReadLine();
            if (ValidateSelection(userSelection, options))
            {
                var parsedSelection = Enum.Parse<BuildMenuClientOptions>(userSelection);
                Client = Enum.GetName(typeof(BuildMenuClientOptions), parsedSelection);
                Console.WriteLine("You choosed: {0}", Client);
                return parsedSelection;
            }
            else
            {
                return DisplayBuildClientMenu();
            }
        }

        public BuildMenuActionOptions DisplayBuildActionMenu()
        {
            List<string> options = new List<string>(new string[] { "1", "2", "9", "0" });
            Console.WriteLine();
            Console.WriteLine("Select build action from the list:");
            Console.WriteLine("1. Build");
            Console.WriteLine("2. Rebuild");
            Console.WriteLine("9. Back");
            Console.WriteLine("0. Exit");
            Console.Write("Action: ");
            string userSelection = Console.ReadLine();
            if (ValidateSelection(userSelection, options))
            {
                var parsedSelection = Enum.Parse<BuildMenuActionOptions>(userSelection);
                Action = Enum.GetName(typeof(BuildMenuActionOptions), parsedSelection);
                Console.WriteLine("You choosed: {0}", Action);
                return parsedSelection;
            }
            else
            {
                return DisplayBuildActionMenu();
            }
                
        }

        public BuildMenuConfigOptions DisplayBuildConfigMenu()
        {
            List<string> options = new List<string>(new string[] { "1", "2", "9", "0" });
            Console.WriteLine();
            Console.WriteLine("Select build configuration from the list:");
            Console.WriteLine("1. Debug");
            Console.WriteLine("2. Release");
            Console.WriteLine("9. Back");
            Console.WriteLine("0. Exit");
            Console.Write("Action: ");
            string userSelection = Console.ReadLine();
            if (ValidateSelection(userSelection, options))
            {
                var parsedSelection = Enum.Parse<BuildMenuConfigOptions>(userSelection);
                Config = Enum.GetName(typeof(BuildMenuConfigOptions), parsedSelection);
                Console.WriteLine("You choosed: {0}", Config);
                return parsedSelection;
            }
            else
            {
                return DisplayBuildConfigMenu();
            }
        }

        static bool ValidateSelection(string userSelection, List<string> options)
        {
            if (!int.TryParse(userSelection, out int result))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Action must be a number!\n");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            else if (!options.Contains(userSelection))
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
