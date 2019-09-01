using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGershman.PhotoLib
{
    /// <summary>
    /// Provides data for ICamera.LiveViewFetched event.
    /// </summary>
    public class LiveViewEventArgs : EventArgs
    {
        /// <summary>
        /// Frame fetched.
        /// Not for long-time storage - will be disposed after handling.
        /// </summary>
        public Image Frame { get; }

        /// <summary>
        /// Data class constructor.
        /// </summary>
        /// <param name="frame">Frame fetched.</param>
        public LiveViewEventArgs(Image frame)
        {
            Frame = frame;
        }
    }
}
