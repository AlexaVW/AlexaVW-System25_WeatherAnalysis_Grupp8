using System.ComponentModel.Design;
using WeatherAnalysis.Interfaces;
using WeatherAnalysis.Models;

namespace WeatherAnalysis
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine(Helpers.GetFileText("WeatherData.txt")[0]);

            string[] dataRows = Reader.GetFileLines("WeatherData.txt");
            List<Reading> readings = Helpers.GetReadingsFromDataRow(dataRows);

            //Skicka in Reading i WeatherApp
            WeatherApp weatherApp = new WeatherApp(readings);
            //weatherApp.Start();
        }
    }
}
