using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAnalysis
{
    internal class DataReader
    {
        public static string path = "../../../Data/";

        public static string[] GetFileLines(string fileNameWithExtension)
        {
            string[] lines = null;

            try
            {
                lines = File.ReadAllLines(path + fileNameWithExtension);
            }
            catch (Exception e) 
            {
                Console.WriteLine("Could not find file");
            }


            return lines;
        }
    }
}
