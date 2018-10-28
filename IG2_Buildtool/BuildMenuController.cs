using System;

namespace IG2_Buildtool
{
    class BuildMenuController
    {
        readonly Menu BuildMenu1 = new Menu(new string[] { "All", "Italy", "Germany", "Chille", "Back", "Exit" });
        readonly Menu BuildMenu2 = new Menu(new string[] { "Debug", "Release", "Back", "Exit" });
        readonly Menu BuildMenu3 = new Menu(new string[] { "Build", "Rebuild", "Back", "Exit" });

        public void StartBuildMenu1()
        {
            BuildMenu1.PrintMenu();
            switch (BuildMenu1.Selection)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    StartBuildMenu2();
                    break;
                case 5:
                    break;
                case 6:
                    BuildToolMain.ShouldRun = false;
                    break;
            }
        }

        private void StartBuildMenu2()
        {
            BuildMenu2.PrintMenu();
            switch (BuildMenu2.Selection)
            {
                case 1:
                case 2:
                    StartBuildMenu3();
                    break;
                case 3:
                    StartBuildMenu1();
                    break;
                case 4:
                    BuildToolMain.ShouldRun = false;
                    break;
            }
        }

        private void StartBuildMenu3()
        {
            BuildMenu3.PrintMenu();
            switch (BuildMenu3.Selection)
            {
                case 1:
                case 2:
                    string client = BuildMenu1.SelectionDictionary[BuildMenu1.Selection.ToString()];
                    string configuration = BuildMenu2.SelectionDictionary[BuildMenu2.Selection.ToString()];
                    string action = BuildMenu3.SelectionDictionary[BuildMenu3.Selection.ToString()];
                    ProjectBuilder compiler = new ProjectBuilder();
                    compiler.BuildAll();
                    break;
                case 3:
                    StartBuildMenu2();
                    break;
                case 4:
                    BuildToolMain.ShouldRun = false;
                    break;
            }
        }    
    }
}
