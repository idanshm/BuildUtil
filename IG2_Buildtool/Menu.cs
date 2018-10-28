using System;
using System.Collections.Generic;
using System.Text;

namespace IG2_Buildtool
{
    class Menu
    {
        public string[] MenuOptions;
        private int Selection;

        public Menu(string[] menuOptions)
        {
            this.MenuOptions = menuOptions;
        }

        private List<string> CreateMenu()
        {
            List<string> NewMenu = new List<string>();
            int index = 1;

            foreach (string option in this.MenuOptions)
            {
                NewMenu.Add($"{index.ToString()} - {option}");
                index++;
            }
            return NewMenu;
        }

        public void PrintMenu()
        {
            List<string> menu = CreateMenu();
            foreach(string option in menu)
            {
                Console.WriteLine(option);
            }
            SetSelection();
        }

        private void SetSelection()
        {
            Console.Write("Action: ");
            int.TryParse(Console.ReadLine(), out int selection);
            this.Selection = selection;
        }

        public void PrintSelection()
        {
            Console.WriteLine("You choosed: " + this.Selection.ToString());
        }
    }
}
