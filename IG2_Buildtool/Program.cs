using System;

namespace IG2_Buildtool
{
    class Program
    {
        static void Main(string[] args)
        {
            switch (Menus.DisplyMainMenu())
            {
                case (MainMenuOptions.Build):
                    {
                        BuildMenuClientOptions retValue = Menus.DisplayBuildClientMenu();
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
                    BuildMenuActionOptions retValue2 = Menus.DisplayBuildActionMenu();
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
                    break;
                case BuildMenuActionOptions.Back:
                    BuildMenuClientOptions retValue = Menus.DisplayBuildClientMenu();
                    NextStepClientBuildMenu(retValue);


                    break;
                case BuildMenuActionOptions.Exit:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
