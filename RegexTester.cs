using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WeatherAnalysis
{
    public class RegexTester
    {

        public static Match TestDateTime(string text)
        {
            Regex regex = new Regex(@"^(?<date>\d{4}-\d{2}-\d{2}).(?<time>\d{2}:\d{2}:\d{2})$");
            Match match = regex.Match(text);
            
            return match;
        }

        public static Match TestIsInside(string text)
        {
            Regex regex = new Regex(@"^(Inne|Ute)$");
            Match match = regex.Match(text);

            return match;
        }

        public static Match TestTemperature(string text)
        {
            Regex regex = new Regex(@"-?\d+\.\d+");
            Match match = regex.Match(text);

            return match;
        }

        public static Match TestHumidity(string text)
        {
            Regex regex = new Regex(@"^\d{2}$");
            Match match = regex.Match(text);

            return match;
        }
    }
}
