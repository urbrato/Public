using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGershman.PhotoLib
{
    /// <summary>
    /// Common interface for all connectable devices.
    /// </summary>
    public interface IDevice
    {
        /// <summary>
        /// true, if the device is connected
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Gets or sets device parameters, including connection properties.
        /// The device wrap implementation itself is responsible to the ConnectionString value meaning.
        /// </summary>
        string ConnectionString { get; set; }

        /// <summary>
        /// Gets exception throwed during the last operation, if any.
        /// </summary>
        Exception LastException { get; }



        /// <summary>
        /// Occurs when device becomes connected.
        /// </summary>
        event EventHandler ConnectComplete;

        /// <summary>
        /// Occurs when device becomes disconnected.
        /// </summary>
        event EventHandler DisconnectComplete;



        /// <summary>
        /// Connects the device synchronously.
        /// Does nothing if the device is already connected or connecting is in progress.
        /// </summary>
        void Connect();

        /// <summary>
        /// Connects the device asynchronously.
        /// Does nothing if the device is already connected or connecting is in progress.
        /// </summary>
        void ConnectAsync();

        /// <summary>
        /// Cancels asynchronous connecting process, if any.
        /// </summary>
        void ConnectAsyncCancel();

        /// <summary>
        /// Disconnects the device synchronously.
        /// Does nothing if the device is not connected or connection/disconnection is in progress.
        /// </summary>
        void Disconnect();

        /// <summary>
        /// Disconnects the device asynchronously.
        /// Does nothing if the device is not connected or connection/disconnection is in progress.
        /// </summary>
        void DisconnectAsync();

        /// <summary>
        /// Cancels asynchronous disconnecting process, if any.
        /// </summary>
        void DisconnectAsyncCancel();

        /// <summary>
        /// Shows setup dialog. ConnectionString can be changed after that.
        /// </summary>
        void SetupConnectionDlg();

        /// <summary>
        /// Shows view configuration and manipulation dialog (maybe or maybe not the same as in <seealso cref="SetupConnectionDlg"/> but readonly).
        /// </summary>
        void ViewConfigDlg();
    }
}
