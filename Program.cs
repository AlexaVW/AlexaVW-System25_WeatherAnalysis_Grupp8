using System.Collections.Generic;
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

            Helpers.WriteManyFiles(Data.GetAllReadings());
            

            //Start MainMenu
            Menus.MainMenu mainMenu = new Menus.MainMenu();
            mainMenu.Run();
        }
    }
}
