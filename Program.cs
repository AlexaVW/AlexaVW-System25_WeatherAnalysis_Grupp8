using System.ComponentModel.Design;
using System.Globalization;
using WeatherAnalysis.Interfaces;
using WeatherAnalysis.Models;

namespace WeatherAnalysis
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("sv-SE");
            Data.LoadData();

            Helpers.GetMetro(Data.GetAllReadings().Where(r => r.IsInside == false).ToList(), 10, new DateOnly(2016, 8, 1), new DateOnly(2017, 2, 14));
            Console.ReadKey();
            //Start MainMenu
            Menus.MainMenu mainMenu = new Menus.MainMenu();
            mainMenu.Run();
        }
    }
}
