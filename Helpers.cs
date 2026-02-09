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
            string[] columns = dataRow.Split(",");
            string sDateTime =      columns[0];
            string sIsInside =      columns[1];
            string sTemperature =   columns[2];
            string sHumidity =      columns[3];

            //Validate with Regex
            Match mDateTime =       RegexTester.TestDateTime(sDateTime);
            Match mIsInside =       RegexTester.TestIsInside(sIsInside);
            Match mTemperature =    RegexTester.TestTemperature(sTemperature);
            Match mHumidity =       RegexTester.TestHumidity(sHumidity);

            //If all valid try parse
            if (mDateTime.Success && mIsInside.Success && mTemperature.Success && mHumidity.Success)
            {
                try //Parse values
                {
                    DateTime dateTime =     DateTime.Parse(mDateTime.Value);
                    bool isInside =         mIsInside.Value == "Inne" ? true : false;
                    double temperature =    double.Parse(mTemperature.Value.Replace(',','.'));
                    double humidity =       double.Parse(mHumidity.Value);

                    return new Reading(dateTime, isInside, temperature, humidity);
                }
                catch (Exception ex)
                {
                    //Console.WriteLine($"Could not parse:\t{dataRow}");
                }
            }
            else
            {
               //Console.WriteLine($"Denined by regex:\t{dataRow} |\tDate:{mDateTime.Success} - {mDateTime.Value} | Location:{mIsInside.Success} - {mIsInside.Value} | Temp:{mTemperature.Success} - {mTemperature.Value} | Humidity:{mHumidity.Success} - {mHumidity.Value} |");
            }

            return null;
        }

    }
}
