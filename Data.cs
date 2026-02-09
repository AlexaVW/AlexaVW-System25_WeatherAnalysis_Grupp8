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
            string[] dataRows = Reader.GetFileLines("WeatherData.txt");
            Console.WriteLine("Done");

            Console.Write("Parsing data... ");
            _readings = Helpers.GetReadingsFromDataRow(dataRows);
            Console.WriteLine("Done\n");
        }
        public static List<Reading> GetAllReadings()
        {
            return _readings;
        } 
    }
}
