using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAnalysis.Interfaces;

namespace WeatherAnalysis.Menus
{
    public class InsideMenu : IMenu
    {
        public Enum MenuEnum { get; }

        public InsideMenu()
        {
            MenuEnum = new Enums.Enum.InsdieMenu();
        }

        public void DrawMenu()
        {
            Graphics.UI.PrintMenu(MenuEnum);
        }

        public bool HandleInput()
        {
            Console.Clear();
            Console.WriteLine("Leave empty to go back");
            string input = Console.ReadLine();

            if (input == "")
                return false;
            else
                return true;

        }

        public void Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                DrawMenu();
                isRunning = HandleInput();
            }
        }
    }
}
