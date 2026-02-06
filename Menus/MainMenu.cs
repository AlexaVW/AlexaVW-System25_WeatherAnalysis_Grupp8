using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAnalysis.Interfaces;

namespace WeatherAnalysis.Menus
{
    public class MainMenu : IMenu
    {
        public Enum MenuEnum { get;}

        //menu
        public MainMenu()
        {
            MenuEnum = new Enums.Enum.MainMenu();
        }


        public void DrawMenu()
        {
            Graphics.UI.PrintMenu(MenuEnum);
        }

        public void HandleInput()
        {
            
        }
    }
}
