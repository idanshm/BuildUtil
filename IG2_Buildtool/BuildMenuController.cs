using System;

namespace IG2_Buildtool
{
    class BuildMenuController
    {
        readonly Menu BuildMenu1 = new Menu(new string[] { "All", "Italy", "Germany", "Chille", "Back", "Exit" });
        readonly Menu BuildMenu2 = new Menu(new string[] { "Debug", "Release", "Back", "Exit" });
        readonly Menu BuildMenu3 = new Menu(new string[] { "Build", "Rebuild", "Clean", "Back", "Exit" });

        public void StartBuildMenu1()
        {
            bool shouldrunagain = true;
            while (shouldrunagain)
            {
                Console.WriteLine("\nSelect Client: ");
                BuildMenu1.PrintMenu();
                switch (BuildMenu1.Selection)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        BuildMenu1.PrintSelection();
                        shouldrunagain = false;
                        StartBuildMenu2();
                        break;
                    case 5:
                        shouldrunagain = false;
                        break;
                    case 6:
                        shouldrunagain = false;
                        BuildToolMain.ShouldRun = false;
                        break;
                }
            }
        }

        private void StartBuildMenu2()
        {
            bool shouldrunagain = true;
            while (shouldrunagain)
            {
                Console.WriteLine("\nSelect Configuration: ");
                BuildMenu2.PrintMenu();
                switch (BuildMenu2.Selection)
                {
                    case 1:
                    case 2:
                        BuildMenu2.PrintSelection();
                        shouldrunagain = false;
                        StartBuildMenu3();
                        break;
                    case 3:
                        shouldrunagain = false;
                        StartBuildMenu1();
                        break;
                    case 4:
                        shouldrunagain = false;
                        BuildToolMain.ShouldRun = false;
                        break;
                }
            }
            
        }

        private void StartBuildMenu3()
        {
            bool shouldrunagain = true;
            while (shouldrunagain)
            {
                Console.WriteLine("\nSelect Action: ");
                BuildMenu3.PrintMenu();
                switch (BuildMenu3.Selection)
                {
                    case 1:
                    case 2:
                    case 3:
                        BuildMenu3.PrintSelection();
                        shouldrunagain = false;
                        string client = BuildMenu1.SelectionDictionary[BuildMenu1.Selection.ToString()];
                        string configuration = BuildMenu2.SelectionDictionary[BuildMenu2.Selection.ToString()];
                        string action = BuildMenu3.SelectionDictionary[BuildMenu3.Selection.ToString()];
                        ProjectBuilder compiler = new ProjectBuilder();
                        compiler.BuildAll(client, configuration, action);
                        break;
                    case 4:
                        shouldrunagain = false;
                        StartBuildMenu2();
                        break;
                    case 5:
                        shouldrunagain = false;
                        BuildToolMain.ShouldRun = false;
                        break;
                }
            }
        }    
    }
}
