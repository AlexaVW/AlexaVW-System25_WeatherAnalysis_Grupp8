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
            Console.WriteLine(CultureInfo.CurrentCulture.Name);
            //Load / Get data when program starts
            Data.LoadData();

            Helpers.PrintReading(Data.GetAllReadings());
            //Start MainMenu
            Menus.MainMenu mainMenu = new Menus.MainMenu();
            mainMenu.Run();
        }
    }
}
