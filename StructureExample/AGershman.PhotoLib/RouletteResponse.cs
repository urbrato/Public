using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGershman.PhotoLib
{
    /// <summary>
    /// Roulette responses possible.
    /// </summary>
    public enum RouletteResponse
    {
        /// <summary>
        /// Device reports command is performed properly
        /// </summary>
        OK,

        /// <summary>
        /// Device reports there was an error in the request from the computer
        /// </summary>
        RequestError,

        /// <summary>
        /// Device reports there was some hardware issue when attempting to perform the command
        /// </summary>
        DeviceError,

        /// <summary>
        /// Device report was missing, invalid or corrupted
        /// </summary>
        ResponseError,

        /// <summary>
        /// Unexpected error that can be translated
        /// </summary>
        OtherError
    }
}
