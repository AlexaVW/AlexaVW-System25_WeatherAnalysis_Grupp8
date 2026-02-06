using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAnalysis.Enums
{
    internal class Enum
    {
        public enum MainMenu
        {
            Outside = 1,
            Inside,
            Write_Report_To_File,
            Exit = 9
        }

        public enum OutsideMenu
        {
            Averages = 1,
            Warm_To_Cold,
            Humidity_Dry_To_Wet,
            Moldrisk_Low_To_High,
            Meteorological_Autumn,
            Meteorological_Winter,
            Go_Back = 9

        }

        public enum InsdieMenu
        {
            Avereges = 1,
            Warm_To_Cold,
            Humidity_Dry_To_Wet,
            Moldrisk_Low_To_High,
            Go_Back = 9
        }
    }
}
