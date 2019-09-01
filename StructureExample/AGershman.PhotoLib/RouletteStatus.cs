using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGershman.PhotoLib
{
    /// <summary>
    /// Roulette device statuses possible
    /// </summary>
    public enum RouletteStatus
    {
        /// <summary>
        /// No roulette is connected
        /// </summary>
        Disconnected,

        /// <summary>
        /// Trying to connect roulette
        /// </summary>
        Connecting,

        /// <summary>
        /// Roulette is connected and ready to process commands
        /// </summary>
        Idle,

        /// <summary>
        /// Calibration is in progress
        /// </summary>
        Calibrating,

        /// <summary>
        /// Movement is in progress
        /// </summary>
        Moving
    }
}
