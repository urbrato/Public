using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureAreaBL
{
    static class Robuster
    {
        public static double Epsilon { get; set; } = 1e-30;

        public static bool Equals(double x, double y)
        {
            return Math.Abs(x - y) < Epsilon;
        }
    }
}
