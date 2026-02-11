using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAnalysis.Enums
{
    public class Enum
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
            Averages = 1,
            Warm_To_Cold,
            Humidity_Dry_To_Wet,
            Moldrisk_Low_To_High,
            Go_Back = 9
        }


        public enum Windows
        {
            Avereges = 1,
            Warm_To_Cold,
            Humidity_Dry_To_Wet,
            Moldrisk_Low_To_High,
            Go_Back = 9
        }

        public enum OrderBy
        {
            AVG_Temp_LowToHigh,
            AVG_Temp_HighToLow,

            AVG_Humidity_LowToHigh,
            AVG_Humidity_HighToLow,

            AVG_MoldRisk_LowToHigh,
            AVG_MoldRisk_HighToLow,
        }

        public enum WriteColumn
        {
            Temp,
            Humidity,
            MoldRisk,
        }
    }
}
