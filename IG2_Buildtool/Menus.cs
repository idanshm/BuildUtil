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
            Console.WriteLine("####Welcome to IG2 Build Tool####\n");
            Console.WriteLine("Select an option from the list:");
            Console.WriteLine("1. Build");
            Console.WriteLine("2. Clean");
            Console.WriteLine("0. Exit");
            Console.Write("Action: ");
            int.TryParse(Console.ReadLine(), out int selection);
            return Enum.Parse<MainMenuOptions>(selection.ToString());
        }

        public static BuildMenuClientOptions DisplayBuildClientMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Select client from the list:");
            Console.WriteLine("1. All");
            Console.WriteLine("2. Italy");
            Console.WriteLine("2. Germany");
            Console.WriteLine("9. Back");
            Console.WriteLine("0. Exit");
            Console.Write("Action: ");
            int.TryParse(Console.ReadLine(), out int selection);
            return Enum.Parse<BuildMenuClientOptions>(selection.ToString());
        }

        public static BuildMenuActionOptions DisplayBuildActionMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Select build action from the list:");
            Console.WriteLine("1. Build");
            Console.WriteLine("2. Rebuild");
            Console.WriteLine("9. Back");
            Console.WriteLine("0. Exit");
            Console.Write("Action: ");
            int.TryParse(Console.ReadLine(), out int selection);
            return Enum.Parse<BuildMenuActionOptions>(selection.ToString());
        }

        public static BuildMenuConfigOptions DisplayBuildConfigMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Select build configuration from the list:");
            Console.WriteLine("1. Debug");
            Console.WriteLine("2. Release");
            Console.WriteLine("9. Back");
            Console.WriteLine("0. Exit");
            Console.Write("Action: ");
            int.TryParse(Console.ReadLine(), out int selection);
            return Enum.Parse<BuildMenuConfigOptions>(selection.ToString());
        }
    }
}
