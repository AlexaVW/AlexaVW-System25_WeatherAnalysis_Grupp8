using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAnalysis.Interfaces
{
    public interface IMenu
    {
        Enum MenuEnum { get;}

        bool HandleInput();
        void DrawMenu();
        void Run()
        {

        }
    }
}
