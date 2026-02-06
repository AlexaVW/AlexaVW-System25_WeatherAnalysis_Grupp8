using System.ComponentModel.Design;
using WeatherAnalysis.Interfaces;

namespace WeatherAnalysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menus.MainMenu mainMenu = new Menus.MainMenu();

            mainMenu.Run();
        }
    }
}
