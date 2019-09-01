using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGershman.PhotoLib
{
    /// <summary>
    /// Camera statuses possible
    /// </summary>
    public enum CameraStatus
    {
        /// <summary>
        /// The camera is not connected to the computer
        /// </summary>
        Disconnected,

        /// <summary>
        /// Camera connection opening is in progress
        /// </summary>
        Connecting,

        /// <summary>
        /// Camera is connected and free to receive commands
        /// </summary>
        Idle,

        /// <summary>
        /// Camera is busy - shooting in progress
        /// </summary>
        Shooting,

        /// <summary>
        /// Camera is connected, but not ready to receive commands for unidentified reason
        /// </summary>
        NotReady
    }
}
