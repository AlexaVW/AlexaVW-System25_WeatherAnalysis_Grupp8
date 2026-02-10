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
        public double MoldRisk {  get; set; }

        public Reading(DateTime date, bool isInside, double temperature, double humidity)
        {
            Date = date;
            IsInside = isInside;
            Temperature = temperature;
            Humidity = humidity;
        }


        public void Print()
        {
            Console.Write($"{Date.ToString().PadRight(25)}");
            Console.Write($"Inside: {IsInside.ToString().PadRight(12)}");
            Console.Write($"Temp: {Temperature.ToString().PadRight(12)}");
            Console.Write($"Humidity: {Humidity.ToString().PadRight(12)}");
            Console.Write($"Mold risk: {MoldRisk.ToString().PadRight(12)}");
            Console.WriteLine(); //New line

        }
    }
}
