using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureAreaBL
{
    /// <summary>
    /// Class that represents a circle
    /// </summary>
    public class Circle : IFigure
    {
        /// <summary>
        /// Radius of the circle
        /// </summary>
        public double Radius { get; }

        /// <summary>
        /// Creates a circle with the radius given
        /// </summary>
        /// <param name="radius">Radius of the circle to be created; must be positive</param>
        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException(Resources.CircleNonPositiveRadius);

            Radius = radius;
        }

        /// <summary>
        /// Calculates area of the circle
        /// </summary>
        /// <returns>Area of the circle</returns>
        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        /// <summary>
        /// Check the figure given for congruency with this figure
        /// </summary>
        /// <param name="figure">Any figure given</param>
        /// <returns>true if the figures are consistent; false otherwise</returns>
        public bool IsCongruent(IFigure figure)
        {
            if (!(figure is Circle circle))
                return false;
            else
                return Robuster.Equals(Radius, circle.Radius);
        }
    }
}
