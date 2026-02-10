using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAnalysis.Interfaces;
using WeatherAnalysis.Models;

namespace WeatherAnalysis.Menus
{
    public class InsideMenu : IMenu
    {
        public Enum MenuEnum { get; }

        public InsideMenu()
        {
            MenuEnum = new Enums.Enum.InsdieMenu();
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
            List<Reading> readings = Data.GetAllReadings().Where(r => r.IsInside == true).ToList();
            bool isActive = true;
            if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out int num))
            {
                Console.Clear();
                switch ((Enums.Enum.InsdieMenu)num)
                {
                    case Enums.Enum.InsdieMenu.Averages:
                        DateTime startDate = Helpers.GetDate(true);
                        DateTime endDate = Helpers.GetDate(false);
                        Console.Clear();
                        Helpers.AverageTemperatureDateRange(readings, startDate, endDate);

                        Console.WriteLine("Any key to continue...");
                        Console.ReadKey(true);
                        break;

                    case Enums.Enum.InsdieMenu.Warm_To_Cold:
                        Helpers.AverageWarmToCold(readings);
                        Console.WriteLine("Any key to continue...");
                        Console.ReadKey(true);
                        break;

                    case Enums.Enum.InsdieMenu.Humidity_Dry_To_Wet:
                        Helpers.AverageHumidityDryToWet(readings);
                        Console.WriteLine("Any key to continue...");
                        Console.ReadKey(true);
                        break;

                    case Enums.Enum.InsdieMenu.Moldrisk_Low_To_High:
                        Helpers.AverageMoldRisk(readings);
                        Console.WriteLine("Any key to continue...");
                        Console.ReadKey(true);
                        break;


                    case Enums.Enum.InsdieMenu.Go_Back:
                        isActive = false;
                        break;
                }
            }

            Console.Clear();
            return isActive;
        }

    }
}
