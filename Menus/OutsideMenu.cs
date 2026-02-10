using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAnalysis.Interfaces;
using WeatherAnalysis.Models;

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
            List<Reading> readings = Data.GetAllReadings().Where(r => r.IsInside == false).ToList();
            
            bool isActive = true;
            if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out int num))
            {
                Console.Clear();
                switch ((Enums.Enum.OutsideMenu)num)
                {
                    case Enums.Enum.OutsideMenu.Averages:
                        DateTime startDate = Helpers.GetDate(true);
                        DateTime endDate = Helpers.GetDate(false);
                        Console.Clear();
                        Helpers.AverageTemperatureDateRange(readings, startDate, endDate);

                        Console.WriteLine("Any key to continue...");
                        Console.ReadKey(true);
                        break;

                    case Enums.Enum.OutsideMenu.Warm_To_Cold:
                        Helpers.PrintByOrder(readings, Enums.Enum.OrderBy.AVG_Temp_HighToLow);
                        Console.WriteLine("Any key to continue...");
                        Console.ReadKey(true);
                        
                        break;

                    case Enums.Enum.OutsideMenu.Humidity_Dry_To_Wet:
                        Helpers.PrintByOrder(readings, Enums.Enum.OrderBy.AVG_Humidity_LowToHigh);
                        Console.WriteLine("Any key to continue...");
                        Console.ReadKey(true);
                        break;

                    case Enums.Enum.OutsideMenu.Moldrisk_Low_To_High:
                        Helpers.PrintByOrder(readings, Enums.Enum.OrderBy.AVG_MoldRisk_LowToHigh);
                        Console.WriteLine("Any key to continue...");
                        Console.ReadKey(true);
                        break;

                    case Enums.Enum.OutsideMenu.Meteorological_Autumn:
                        DateOnly metroDateAutumn = Helpers.GetMetro(Data.GetAllReadings().Where(r => r.IsInside == false).ToList(), 10, new DateOnly(2016, 8, 1), new DateOnly(2017, 2, 14));

                        Console.WriteLine("Autumn Metrological Date");
                        Console.WriteLine(metroDateAutumn);
                        Console.ReadKey(true);
                        break;

                    case Enums.Enum.OutsideMenu.Meteorological_Winter:
                        DateOnly metroDateWinter = Helpers.GetMetro(Data.GetAllReadings().Where(r => r.IsInside == false).ToList(), 1, new DateOnly(2016, 1, 1), new DateOnly(2016, 12, 31));

                        Console.WriteLine("Winter Metrological Date");
                        Console.WriteLine(metroDateWinter);
                        Console.ReadKey(true);
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
