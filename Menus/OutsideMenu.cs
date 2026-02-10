using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAnalysis.Interfaces;

namespace WeatherAnalysis.Menus
{
    public class OutsideMenu : IMenu
    {
        public Enum MenuEnum { get;}

        public OutsideMenu()
        {
            MenuEnum = new Enums.Enum.OutsideMenu();
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
                switch ((Enums.Enum.OutsideMenu)num)
                {
                    case Enums.Enum.OutsideMenu.Averages:
                        Helpers.AverageTemperature(Data.GetAllReadings().Where(r => r.IsInside == false).ToList());
                        Console.WriteLine("Any key to continue...");
                        Console.ReadKey(true);
                        break;

                    case Enums.Enum.OutsideMenu.Warm_To_Cold:
                        Helpers.AverageWarmToCold(Data.GetAllReadings().Where(r => r.IsInside == false).ToList());
                        Console.WriteLine("Any key to continue...");
                        Console.ReadKey(true);
                        
                        break;

                    case Enums.Enum.OutsideMenu.Humidity_Dry_To_Wet:
                        break;

                    case Enums.Enum.OutsideMenu.Moldrisk_Low_To_High:
                        break;

                    case Enums.Enum.OutsideMenu.Meteorological_Autumn:
                        break;

                    case Enums.Enum.OutsideMenu.Meteorological_Winter:
                        break;


                    case Enums.Enum.OutsideMenu.Go_Back:
                        isActive = false;
                        break;
                }
            }

            Console.Clear();
            return isActive;
        }

    }
}
