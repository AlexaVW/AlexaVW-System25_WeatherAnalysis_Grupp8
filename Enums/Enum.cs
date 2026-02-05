using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAnalysis.Enums
{
    internal class Enum
    {
        public enum InsideOutsideMenu
        {
            Outside = 1,
            Inside
        }

        public enum OutsideMenu
        {
            Averages = 1,
            Warm_To_Cold,
            Humidity_Dry_To_Wet,
            Moldrisk_Low_To_High,
            Meteorological_Autumn,
            Meteorological_Winter

        }

        public enum InsdieMenu
        {
            Avereges = 1,
            Warm_To_Cold,
            Humidity_Dry_To_Wet,
            Moldrisk_Low_To_High
        }
    }
}
