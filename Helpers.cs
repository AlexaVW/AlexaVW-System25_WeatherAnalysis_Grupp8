using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAnalysis
{
    public class Helpers
    {
        public static string[] GetFileText(string fileNameWithExtension)
        {
            string projectPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\Data"));
            string filePath = Path.Combine(projectPath, fileNameWithExtension);

            return File.ReadAllLines(filePath);
        }

    }
}
