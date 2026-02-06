using System.ComponentModel.Design;
using WeatherAnalysis.Interfaces;

namespace WeatherAnalysis
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine(Helpers.GetFileText("WeatherData.txt")[0]);
            Menus.MainMenu mainMenu = new Menus.MainMenu();

            mainMenu.Run();
        }
    }
}
