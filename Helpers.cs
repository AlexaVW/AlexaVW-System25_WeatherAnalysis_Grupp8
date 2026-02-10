using System;
using System.Collections.Generic;
using System.Globalization;
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

            foreach (var dataRow in dataRows)
            {
                
                Reading reading = ConvertToReading(dataRow);
                if(reading != null)
                {
                    readings.Add(reading);
                }
            }

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
                    double temperature =    double.Parse(mTemperature.Value.Replace('.',','));
                    double humidity =       double.Parse(mHumidity.Value);

                    return new Reading(dateTime, isInside, temperature, humidity);
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                    //Console.WriteLine($"Could not parse:\t{dataRow}");
                }
            }
            else
            {
               //Console.WriteLine($"Denined by regex:\t{dataRow} |\tDate:{mDateTime.Success} - {mDateTime.Value} | Location:{mIsInside.Success} - {mIsInside.Value} | Temp:{mTemperature.Success} - {mTemperature.Value} | Humidity:{mHumidity.Success} - {mHumidity.Value} |");
            }

            return null;
        }

        public static DateTime GetDate(bool isStartDate)
        {
            bool isValidDate = false;
            DateOnly date = new DateOnly();

            while (!isValidDate)
            {
                Console.WriteLine("Min: " + Data.GetAllReadings().Min(r => DateOnly.FromDateTime(r.Date)));
                Console.WriteLine("Max: " + Data.GetAllReadings().Max(r => DateOnly.FromDateTime(r.Date)));

                if (isStartDate)
                    Console.WriteLine("Choose start date");
                else
                    Console.WriteLine("Choose end date");

                isValidDate = DateOnly.TryParse(Console.ReadLine(), out date);
            }

            if (isStartDate)
            {
                return new DateTime(date, TimeOnly.MinValue);
            }
            else
            {
                return new DateTime(date, TimeOnly.MaxValue);
            }
        }


        public static void AverageTemperatureDateRange(List<Reading> readings, DateTime startDate, DateTime endDate)
        {
            readings = readings.Where(r => r.Date >= startDate).Where(r => r.Date <= endDate).ToList();
            
            var group = readings.GroupBy(r => DateOnly.FromDateTime(r.Date));

            Console.WriteLine("Avg by Date");
            PrintReadingDateOnlyGroup(group);

        }

        

        // Sortering av varmast till kallaste dagen enligt medeltemperatur per dag
        public static void AverageWarmToCold(List<Reading> readings)
        {
            //Group
            var group = readings.GroupBy(r => DateOnly.FromDateTime(r.Date));
            var sortedGroup = group.OrderByDescending(g => g.Average(g => g.Temperature));

            Console.WriteLine("Avg Warm to Cold");
            PrintReadingDateOnlyGroup(sortedGroup);

        }

        public static void AverageMoldRisk(List<Reading> readings)
        {
            //Group
            var group = readings.GroupBy(r => DateOnly.FromDateTime(r.Date));
            var sortedGroup = group.OrderBy(g => g.Average(g => g.MoldRisk));

            Console.WriteLine("AVG Mold Risk Low to High");
            PrintReadingDateOnlyGroup(sortedGroup);

        }



        private static void PrintReadingDateOnlyGroup(IEnumerable<IGrouping<DateOnly,Reading>> readingDateGroup)
        {
            foreach (var group in readingDateGroup)
            {
                string date =       group.Key.ToString();
                string temp =       group.Average(r => r.Temperature).ToString("N2");
                string humidity =   group.Average(r => r.Humidity).ToString("N2");
                string moldRisk =   group.Average(r => r.MoldRisk).ToString("N0");

                Console.WriteLine($"Date: {date.PadRight(16)}Temp: {temp.PadRight(12)}Humidity: {humidity.PadRight(12)}Mold risk: {moldRisk.PadRight(12)}");
            }
        }


        private static void PrintReading(List<Reading> readings)
        {
            foreach(var reading in readings)
            {
                reading.Print();
            }
        }


    }
}
