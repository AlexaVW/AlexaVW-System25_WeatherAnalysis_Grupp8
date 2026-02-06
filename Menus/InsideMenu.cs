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

        public void HandleInput()
        {
            if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out int num))
            {
                Console.Clear();
                switch ((Enums.Enum.InsdieMenu)num)
                {
                    case Enums.Enum.InsdieMenu.Avereges:
                        
                        break;
                    case Enums.Enum.InsdieMenu.Warm_To_Cold:

                        break;
                    case Enums.Enum.InsdieMenu.Humidity_Dry_To_Wet:

                        break;
                    case Enums.Enum.InsdieMenu.Moldrisk_Low_To_High:

                        break;
                    case Enums.Enum.InsdieMenu.Go_Back:
                        
                        break;
                }
            }
            Console.Clear();
        }

        public void Run()
        {
            DrawMenu();
            HandleInput();
        }
    }
}
