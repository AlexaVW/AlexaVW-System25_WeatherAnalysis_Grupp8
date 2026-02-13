using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAnalysis.Models
{
    public class Reading
    {
        public DateTime Date { get; set; }
        public bool IsInside { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double MoldRisk { get; set; }

        public Reading(DateTime date, bool isInside, double temperature, double humidity)
        {
            Date = date;
            IsInside = isInside;
            Temperature = temperature;
            Humidity = humidity;
            MoldRisk = SetMoldRisk();
        }

        private double SetMoldRisk()
        {
            double moldRisk = 0;

            if (Temperature < 5 || Temperature > 40)
                moldRisk = 0;
            else if (Humidity >= 80)
                moldRisk = 100;
            else if (Humidity >= 70)
                moldRisk = 50;
            else
                moldRisk = 0;

            return moldRisk;
            
        }

    }
}
