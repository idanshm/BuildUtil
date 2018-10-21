using System;

namespace IG2_Buildtool
{
    class Program
    {
        static private Menus Menu = new Menus();
        static void Main(string[] args)
        {
            bool tests = false;
            if (tests) { Tests(); }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("####Welcome to IG2 Build Tool####\n");
            switch (Menu.DisplyMainMenu())
            {
                case (MainMenuOptions.Build):
                    {   
                        BuildMenuClientOptions retValue = Menu.DisplayBuildClientMenu();
                        NextStepClientBuildMenu(retValue);
                        break;
                    }
                case (MainMenuOptions.Clean):
                    {
                        break;
                    }
                case (MainMenuOptions.Exit):
                    {
                        Environment.Exit(0);
                        break;
                    }
            }
            Console.WriteLine($"Selected options: {Menu.Client}, {Menu.Action}, {Menu.Config}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void NextStepClientBuildMenu(BuildMenuClientOptions retValue)
        {
            switch (retValue)
            {
                case BuildMenuClientOptions.All:
                case BuildMenuClientOptions.Italy:
                case BuildMenuClientOptions.Germany:
                    BuildMenuActionOptions retValue2 = Menu.DisplayBuildActionMenu();
                    NextStepActionBuildMenu(retValue2);
                    break;
                case BuildMenuClientOptions.Back:
                    Main(null);
                    break;
                case BuildMenuClientOptions.Exit:
                    Environment.Exit(0);
                    break;
            }
        }

        private static void NextStepActionBuildMenu(BuildMenuActionOptions retValue2)
        {
            switch (retValue2)
            {
                case BuildMenuActionOptions.Build:
                case BuildMenuActionOptions.Rebuild:
                    BuildMenuConfigOptions retValue3 = Menu.DisplayBuildConfigMenu();
                    NextStepConfigBuildMenu(retValue3);
                    break;
                case BuildMenuActionOptions.Back:
                    BuildMenuClientOptions retValue = Menu.DisplayBuildClientMenu();
                    NextStepClientBuildMenu(retValue);
                    break;
                case BuildMenuActionOptions.Exit:
                    Environment.Exit(0);
                    break;
            }
        }

        private static void NextStepConfigBuildMenu(BuildMenuConfigOptions retValue3)
        {
            switch (retValue3)
            {   
                case BuildMenuConfigOptions.Debug:
                case BuildMenuConfigOptions.Release:
                    break;
                case BuildMenuConfigOptions.Back:
                    BuildMenuActionOptions retValue = Menu.DisplayBuildActionMenu();
                    NextStepActionBuildMenu(retValue);
                    break;
                case BuildMenuConfigOptions.Exit:
                    Environment.Exit(0);
                    break;
            }
        }

        private static void Tests()
        {
            var test = new ProjectBuilder();
            test.BuildAll();
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
