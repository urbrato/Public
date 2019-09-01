using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGershman.PhotoLib
{
    /// <summary>
    /// Provides data for ICamera.ShootComplete event.
    /// </summary>
    public class ShootEventArgs : EventArgs
    {
        /// <summary>
        /// Name of the image file in the camera.
        /// </summary>
        public string FileName { get; }

        /// <summary>
        /// Data class constructor.
        /// </summary>
        /// <param name="fileName">Name of the image file in the camera.</param>
        public ShootEventArgs(string fileName)
        {
            FileName = fileName;
        }
    }
}
