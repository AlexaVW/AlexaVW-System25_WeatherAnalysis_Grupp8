using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAnalysis.Interfaces;

namespace WeatherAnalysis.Menus
{
    public class MainMenu : IMenu
    {
        public Enum MenuEnum { get;}

        //menu
        public MainMenu()
        {
            MenuEnum = new Enums.Enum.MainMenu();
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

        public void DrawMenu()
        {
            Graphics.UI.PrintMenu(MenuEnum);
        }

        public bool HandleInput()
        {
            bool isActive = true;
            if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out int num))
            {
                Console.Clear();
                switch ((Enums.Enum.MainMenu)num)
                {
                    case Enums.Enum.MainMenu.Outside:
                        break;

                    case Enums.Enum.MainMenu.Inside:
                        Menus.InsideMenu insideMenu = new Menus.InsideMenu();
                        insideMenu.Run();
                        break;
                    
                    case Enums.Enum.MainMenu.Write_Report_To_File:
                        break;


                    case Enums.Enum.MainMenu.Exit:
                        isActive = false;
                        break;
                }
            }
            
            Console.Clear();
            return isActive;
        }
    }
}
