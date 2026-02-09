using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WeatherAnalysis.Models;

namespace WeatherAnalysis
{
    public class Helpers
    {
        public static List<Reading> GetReadingsFromDataRow(string[] dataRows)
        {
            List<Reading> readings = new List<Reading>();

            // 2016-05-31 13:58:30
            // Inne
            // 24.8
            // 42

            // 2016-05-31 13:58:30,Inne,24.8,42
            foreach (var dataRow in dataRows)
            {
                
                Reading reading = ConvertToReading(dataRow);
                if(reading != null)
                {
                    readings.Add(reading);
                }
            }

            /*
            foreach(var reading in readings)
            {
                Console.WriteLine($"Date: {reading.Date}\tInside: {reading.IsInside}\tTemp: {reading.Temperature}\tHumidity: {reading.Humidity}");
            }
            */

            return readings;
        }

        private static Reading ConvertToReading(string dataRow)
        {
            Regex regexDateTime = new Regex(@"^(?<date>\d{4}-\d{2}-\d{2}).(?<time>\d{2}:\d{2}:\d{2})$");
            Regex regexisInside = new Regex(@"^(Inne|Ute)$");
            Regex regexTemperature = new Regex(@"-?\d+\.\d+"); //Allow minus and single digit
            Regex regexHumidity = new Regex(@"^\d{2}$");


            string[] columns = dataRow.Split(",");
            bool isValidDateTime =      regexDateTime.IsMatch(columns[0]);
            bool isValidIsInside =      regexisInside.IsMatch(columns[1]);
            bool isValidTemperature =   regexTemperature.IsMatch(columns[2]);
            bool isValidHumidity =      regexHumidity.IsMatch(columns[3]);

            if (isValidDateTime && isValidIsInside && isValidTemperature && isValidHumidity)
            {
                try //Parse values
                {
                    DateTime dateTime = DateTime.Parse(columns[0]);
                    bool isInside = columns[1] == "Inne" ? true : false;
                    double temperature = double.Parse(columns[2]);
                    double humidity = double.Parse(columns[3]);

                    return new Reading(dateTime, isInside, temperature, humidity);

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Could not parse:\t{dataRow}");
                }
            }
            else
            {
                Console.WriteLine($"Denined by regex:\t{dataRow} |\tParseDate:{isValidDateTime} ParseLocation:{isValidIsInside} ParseTemp:{isValidTemperature} ParseHumidity:{isValidHumidity}");
            }

            return null;
        }

    }
}
