using System;

namespace IG2_Buildtool
{
    class BuildToolMain
    {
        static private Menus Menu = new Menus();
        public static bool ShouldRun = true;

        static void Main(string[] args)
        {
            bool tests = false;
            if (tests) { Tests(); }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("####Welcome to IG2 Build Tool####\n");
            Menu MainMenu = new Menu(new string[] { "Build", "Clean", "Exit" });

            while (ShouldRun)
            {
                MainMenu.PrintMenu();
                switch (MainMenu.Selection)
                {
                    case 1:
                        BuildMenuController controller = new BuildMenuController();
                        controller.StartBuildMenu1();
                        break;
                    case 2:
                        Console.WriteLine("Starting cleaning process...");
                        break;
                    case 999:
                        break;
                    case 3:
                        ShouldRun = false;
                        break;
                }
            }

            Console.WriteLine("End of program...");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            Environment.Exit(0);
        }

        private static void Tests()
        {
            Console.WriteLine("End of program...");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}