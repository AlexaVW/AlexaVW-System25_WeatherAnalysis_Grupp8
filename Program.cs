using System.ComponentModel.Design;
using WeatherAnalysis.Interfaces;

namespace WeatherAnalysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Graphics.UI.PrintMenu(new Enums.Enum.MainMenu());

            Menus.MainMenu mainMenu = new Menus.MainMenu();
           //mainMenu.DrawMenu();

            Console.WriteLine();

            Menus.OutSideMenu outSideMenu = new Menus.OutSideMenu();
            //outSideMenu.DrawMenu();

            List<IMenu> menus = new List<IMenu>();
            menus.Add(mainMenu);
            menus.Add(outSideMenu);

            foreach (var menu in menus) 
            {
                menu.DrawMenu();
            }
        }
    }
}
