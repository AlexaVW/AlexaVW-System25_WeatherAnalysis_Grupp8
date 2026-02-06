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

            Menus.OutsideMenu outSideMenu = new Menus.OutsideMenu();
            //outSideMenu.DrawMenu();

            Menus.InsideMenu insideMenu = new Menus.InsideMenu();

            List<IMenu> menus = new List<IMenu>();
            menus.Add(mainMenu);
            menus.Add(outSideMenu);
            menus.Add(insideMenu);

            foreach (var menu in menus) 
            {
                menu.DrawMenu();
            }
        }
    }
}
