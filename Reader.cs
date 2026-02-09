using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAnalysis
{
    internal class Reader
    {
        public static string path = "../../../Data/";

        public static string[] GetFileLines(string fileNameWithExtension)
        {
            string projectPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\Data"));
            string filePath = Path.Combine(projectPath, fileNameWithExtension);

            return File.ReadAllLines(filePath);
        }
    }
}
