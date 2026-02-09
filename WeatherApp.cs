using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAnalysis.Models;

namespace WeatherAnalysis
{
    public class WeatherApp
    {
        public List<Reading> Readings { get; set; }

        public WeatherApp(List<Reading> readings)
        {
            Readings = readings;
        }

        public void Start()
        {
            Menus.MainMenu mainMenu = new Menus.MainMenu();
            mainMenu.Run();
        }
    }
}
