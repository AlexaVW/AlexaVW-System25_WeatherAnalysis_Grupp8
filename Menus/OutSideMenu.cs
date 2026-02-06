using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAnalysis.Interfaces;

namespace WeatherAnalysis.Menus
{
    public class OutsideMenu : IMenu
    {
        public Enum MenuEnum { get;}

        public OutsideMenu()
        {
            MenuEnum = new Enums.Enum.OutsideMenu();
        }


        public void DrawMenu()
        {
            Graphics.UI.PrintMenu(MenuEnum);
        }

        public void HandleInput()
        {
            
        }

        public void Run()
        {
            DrawMenu();
            HandleInput();
        }
    }
}
