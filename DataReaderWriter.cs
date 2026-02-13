using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAnalysis
{
    internal class DataReaderWriter
    {
        public static string path = "../../../Data/";

        public static string[] GetFileLines(string fileName)
        {
            string[] lines = null;

            try
            {
                lines = File.ReadAllLines(path + fileName);
            }
            catch (Exception e) 
            {
                Console.WriteLine("Could not find file");
            }

            return lines;
        }

        public static void WriteListToFile(List<string> textRows, string fileName)
        {
            try
            {
                File.WriteAllLines(path + fileName, textRows);
            }
            catch (Exception e) 
            {
            
            }
        }
    }
}
