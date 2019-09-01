using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGershman.PhotoLib
{
    public interface ICameraWithLiveView: ICamera
    {
        /// <summary>
        /// Occurs when a new liveview frame is available.
        /// Camera implementation is responsible itself for the image disposing after the event handling.
        /// </summary>
        event EventHandler<LiveViewEventArgs> LiveViewFetched;
    }
}
