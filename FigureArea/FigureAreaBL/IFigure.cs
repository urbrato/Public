using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureAreaBL
{
    /// <summary>
    /// Public interface for figures that can calculate their area
    /// </summary>
    public interface IFigure
    {
        /// <summary>
        /// Method calculating the figure area
        /// </summary>
        /// <returns>Area of the figure</returns>
        double GetArea();

        /// <summary>
        /// Method for checking figures congruency
        /// </summary>
        /// <param name="figure">Figure to check whether it is congruent</param>
        /// <returns>true if the figures are congruent; false otherwise</returns>
        bool IsCongruent(IFigure figure);
    }
}
