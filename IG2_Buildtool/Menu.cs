using System;
using System.Collections.Generic;

namespace IG2_Buildtool
{
    class Menu
    {
        public string[] MenuOptions;
        public int Selection;
        public Dictionary<string, string> SelectionDictionary; 

        public Menu(string[] menuOptions)
        {
            SelectionDictionary = new Dictionary<string, string>();
            MenuOptions = menuOptions;
        }

        private List<string> CreateMenu()
        {
            List<string> NewMenu = new List<string>();
            int index = 1;

            foreach (string option in MenuOptions)
            {
                NewMenu.Add($"{index} - {option}");
                SelectionDictionary.TryAdd($"{index}", $"{option}");
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
            Console.Write("\nAction: ");
            string selection = Console.ReadLine();
            if (!int.TryParse(selection, out int result))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nAction must be a number!\n");
                Console.ForegroundColor = ConsoleColor.White;
                Selection = 999;
            }
            else if (!SelectionDictionary.ContainsKey(selection))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid option!\n");
                Console.ForegroundColor = ConsoleColor.White;
                Selection = 999;
            }
            else
            {
                Selection = int.Parse(selection);
            }
        }

        public void PrintSelection()
        {
            Console.WriteLine("You choosed: " + SelectionDictionary[Selection.ToString()]);
        }
    }
}
