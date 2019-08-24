using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureAreaBL
{
    /// <summary>
    /// Class that represents a triangle
    /// </summary>
    public class Triangle : IFigure
    {
        /// <summary>
        /// The shortest side of the triangle
        /// </summary>
        public double MinSide { get; }

        /// <summary>
        /// The medium side of the triangle
        /// </summary>
        public double MidSide { get; }

        /// <summary>
        /// The longest side of the triangle
        /// </summary>
        public double MaxSide { get; }

        /// <summary>
        /// Constructor of the triangle by three sides
        /// </summary>
        /// <param name="a">A side; must be positive</param>
        /// <param name="b">A side; must be positive</param>
        /// <param name="c">A side; must be positive</param>
        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException(Resources.TriangleNonPositiveSide);

            double[] sides = new double[3] { a, b, c };
            Array.Sort(sides);

            MinSide = sides[0];
            MidSide = sides[1];
            MaxSide = sides[2];

            if (MaxSide >= MinSide + MidSide)
                throw new ArgumentException(Resources.TriangleInequatyFailed);
        }

        /// <summary>
        /// Method for checking is the triangle right
        /// </summary>
        /// <returns>true if the triangle is right; false otherwise</returns>
        public bool IsRight()
        {
            return Robuster.Equals(MinSide * MinSide + MidSide * MidSide, MaxSide * MaxSide);
        }

        /// <summary>
        /// Calculates area of the triangle
        /// </summary>
        /// <returns>Area of the triangle</returns>
        public double GetArea()
        {
            if (IsRight())
                return MinSide * MidSide / 2;
            else
            {
                double p = (MinSide + MidSide + MaxSide) / 2;
                return Math.Sqrt(p * (p - MinSide) * (p - MidSide) * (p - MaxSide));
            }
        }

        /// <summary>
        /// Check the figure given for congruency with this figure
        /// </summary>
        /// <param name="figure">Any figure given</param>
        /// <returns>true if the figures are consistent; false otherwise</returns>
        public bool IsCongruent(IFigure figure)
        {
            if (!(figure is Triangle triangle))
                return false;
            else
                return
                    Robuster.Equals(MinSide, triangle.MinSide) &&
                    Robuster.Equals(MidSide, triangle.MidSide) &&
                    Robuster.Equals(MaxSide, triangle.MaxSide);
        }
    }
}
