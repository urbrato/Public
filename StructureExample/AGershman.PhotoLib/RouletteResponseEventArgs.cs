using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGershman.PhotoLib
{
    /// <summary>
    /// Provides data for IRoulette events.
    /// </summary>
    public class RouletteResponseEventArgs : EventArgs
    {
        /// <summary>
        /// Device response to the computer command.
        /// </summary>
        public RouletteResponse Response { get; }

        /// <summary>
        /// Data class constructor
        /// </summary>
        /// <param name="response">Device response to the command</param>
        public RouletteResponseEventArgs(RouletteResponse response)
        {
            Response = response;
        }
    }
}
