using System;
using System.Collections.Generic;
using System.Linq;
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

        public Reading(DateTime date, bool isInside, double temperature, double humidity)
        {
            Date = date;
            IsInside = isInside;
            Temperature = temperature;
            Humidity = humidity;
        }
    }
}
