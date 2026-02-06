using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAnalysis.Graphics
{
    public class UI
    {
        public static void PrintMenu(Enum menuEnum)
        {
            //Get what type of enum was inserted
            Type myEnum = menuEnum.GetType();
            //Print all menu rows
            foreach (int i in Enum.GetValues(myEnum))
            {
                //Print row value
                Console.WriteLine("[" + i + "] " + Enum.GetName(myEnum, i).Replace('_', ' '));
            }
        }
    }
}
