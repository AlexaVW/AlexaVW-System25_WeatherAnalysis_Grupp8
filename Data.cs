using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WeatherAnalysis.Models;

namespace WeatherAnalysis
{
    public static class Data
    {
        private static List<Reading> _readings = new List<Reading>();

        public static void LoadData()
        {
            Console.Write("Reading data... ");
            string[] dataRows = DataReaderWriter.GetFileLines("WeatherData.txt");
            Console.WriteLine("Done");

            Console.Write("Parsing data... ");
            _readings = Helpers.GetReadingsFromDataRow(dataRows) //Filter out months with only a few values
                .Where(r => r.Date >= new DateTime(new DateOnly(2016,6,1),TimeOnly.MinValue))
                .Where(r => r.Date <= new DateTime(new DateOnly(2016, 12, 31), TimeOnly.MaxValue))
                .ToList();
            Console.WriteLine("Done\n");
        }
        public static List<Reading> GetAllReadings()
        {
            return _readings;
        } 
    }
}
