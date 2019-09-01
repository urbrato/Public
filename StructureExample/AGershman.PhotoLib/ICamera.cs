using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGershman.PhotoLib
{
    /// <summary>
    /// Common interface for all cameras
    /// </summary>
    public interface ICamera : IDevice
    {
        /// <summary>
        /// true, if the camera can shoot by command
        /// </summary>
        bool CanShoot { get; }

        /// <summary>
        /// true, if the camera can shoot by command to inner storage
        /// </summary>
        bool CanShootWithoutDownload { get; }

        /// <summary>
        /// true, if the camera can shoot by command and then allow to download the frame
        /// </summary>
        bool CanShootWithDownload { get; }



        /// <summary>
        /// true, if the camera can report shutter speeds available
        /// </summary>
        bool CanGetTvList { get; }

        /// <summary>
        /// true, if the camera can report the current shutter speed
        /// </summary>
        bool CanGetTv { get; }

        /// <summary>
        /// true, if the camera can change the current shutter speed by the computer command
        /// </summary>
        bool CanSetTv { get; }



        /// <summary>
        /// true, if the camera can report diaphragms available
        /// </summary>
        bool CanGetAvList { get; }

        /// <summary>
        /// true, if the camera can report the current diaphragm
        /// </summary>
        bool CanGetAv { get; }

        /// <summary>
        /// true, if the camera can change the current diaphragm by the computer command
        /// </summary>
        bool CanSetAv { get; }



        /// <summary>
        /// true, if the camera can report white balances available
        /// </summary>
        bool CanGetWBList { get; }

        /// <summary>
        /// true, if the camera can report the current white balance
        /// </summary>
        bool CanGetWB { get; }

        /// <summary>
        /// true, if the camera can change the current white balance by the computer command
        /// </summary>
        bool CanSetWB { get; }



        /// <summary>
        /// true, if the camera can report ISO values available
        /// </summary>
        bool CanGetIsoList { get; }

        /// <summary>
        /// true, if the camera can report the current ISO value
        /// </summary>
        bool CanGetIso { get; }

        /// <summary>
        /// true, if the camera can change the current ISO value by the computer command
        /// </summary>
        bool CanSetIso { get; }



        /// <summary>
        /// true, if the camera can report frame sizes and qualities available
        /// </summary>
        bool CanGetQualityList { get; }

        /// <summary>
        /// true, if the camera can report the current frame size and quality
        /// </summary>
        bool CanGetQuality { get; }

        /// <summary>
        /// true, if the camera can change the current frame size and quality by the computer command
        /// </summary>
        bool CanSetQuality { get; }



        /// <summary>
        /// true, if the camera can report the image shooted file formats available
        /// </summary>
        bool GetGetFormatList { get; }

        /// <summary>
        /// true, if the camera can report the current file format for the images to be shooted
        /// </summary>
        bool CanGetFormat { get; }

        /// <summary>
        /// true, if the camera can change the file format for the images to be shooted by the computer command
        /// </summary>
        bool CanSetFormat { get; }



        /// <summary>
        /// true, if the camera supports liveview translation
        /// </summary>
        bool CanLiveView { get; }

        /// <summary>
        /// Gets or sets liveview translation
        /// 
        /// Exceptions:
        /// InvalidOperationException, if trying to set true when liveview is not supported or camera isn't connected
        /// </summary>
        bool LiveViewOn { get; set; }

        /// <summary>
        /// Shutter speeds available, or [] when not supported
        /// </summary>
        Tv[] TvAvailable { get; }

        /// <summary>
        /// The current shutter speed, or Tv.Empty when not supported
        /// </summary>
        Tv TvCurrent { get; }



        /// <summary>
        /// Diaphragm values available, or [] when not supported
        /// </summary>
        Av[] AvAvailable { get; }

        /// <summary>
        /// The current diaphragm value, or 0 when not supported
        /// </summary>
        Av AvCurrent { get; }



        /// <summary>
        /// ISO values available, or [] when not supported
        /// </summary>
        Iso[] IsoAvailable { get; }

        /// <summary>
        /// The current ISO value, or 0 when not supported
        /// </summary>
        Iso IsoCurrent { get; }



        /// <summary>
        /// White balance values available, or [] when not supported
        /// </summary>
        string[] WBAvailable { get; }

        /// <summary>
        /// The current white balance value, or string.Empty when not supported
        /// </summary>
        string WBCurrent { get; }

        /// <summary>
        /// Image file formats available, or [] when not supported
        /// </summary>
        string[] FormatsAvailable { get; }

        /// <summary>
        /// The current image file format, or string.Empty when not supported
        /// </summary>
        string FormatCurrent { get; }



        /// <summary>
        /// The size of the picture to take, in pixels
        /// </summary>
        Size ImageSize { get; }

        /// <summary>
        /// The camera sensor size, in mm
        /// </summary>
        SizeF SensorSize { get; }

        /// <summary>
        /// The size of the central area to analyze, in pixels
        /// </summary>
        Size CentralAreaSize { get; }



        /// <summary>
        /// The camera status
        /// </summary>
        CameraStatus Status { get; }



        /// <summary>
        ///  Occurs when asynchronous shoot command processing is finished
        /// </summary>
        event EventHandler<ShootEventArgs> ShootComplete;

        /// <summary>
        /// Occurs when image is shot and ready to download (if available)
        /// </summary>
        event EventHandler ShootGot;

        /// <summary>
        /// Occurs when the shutter speeds available set is changed
        /// </summary>
        event EventHandler TvAvailableChanged;

        /// <summary>
        /// Occurs when the current shutter speed is changed
        /// </summary>
        event EventHandler TvCurrentChanged;

        /// <summary>
        /// Occurs when the diaphragms available set is changed
        /// </summary>
        event EventHandler AvAvailableChanged;

        /// <summary>
        /// Occurs when the current diaphragm is changed
        /// </summary>
        event EventHandler AvCurrentChanged;

        /// <summary>
        /// Occurs when the current white balance is changed
        /// </summary>
        event EventHandler WBCurrentChanged;

        /// <summary>
        /// Occurs when the ISO values available set is changed
        /// </summary>
        event EventHandler IsoAvailableChanged;

        /// <summary>
        /// Occurs when the current ISO value is changed
        /// </summary>
        event EventHandler IsoCurrentChanged;

        /// <summary>
        /// Occurs when the frame sizes and qualities available set is changed
        /// </summary>
        event EventHandler QualitiesAvailableChanged;

        /// <summary>
        /// Occurs when the current frame size and/or quality is changed
        /// </summary>
        event EventHandler QualityCurrentChanged;

        /// <summary>
        /// Occurs when the camera status is changed
        /// </summary>
        event EventHandler StatusChanged;

        /// <summary>
        /// Occurs when the image file formats available set is changed
        /// </summary>
        event EventHandler FormatsAvailableChanged;

        /// <summary>
        /// Occurs when the current image file format setting is changed
        /// </summary>
        event EventHandler FormatCurrentChanged;

        /// <summary>
        /// Occurs when the size of the picture to take is changed
        /// </summary>
        event EventHandler ImageSizeChanged;

        /// <summary>
        /// Shoots synchronously to inner storage.
        /// Shoots without downloading when inner storage shooting is not supported.
        /// If camera is not ready, waits until camera is ready or timeout is expired.
        /// Does nothing if shooting in progress.
        /// 
        /// Exceptions:
        /// InvalidOperationException, if shooting is not supported or camera disconnected.
        /// </summary>
        /// <param name="timeout">Timeout in msec.</param>
        /// <returns>Name of the file in the camera (string.Empty if not supported)</returns>
        string Shoot(int timeout);

        /// <summary>
        /// Shoots synchronously and downloads the image to the computer file named.
        /// Shoots without downloading when inner storage shooting is only supported.
        /// If camera is not ready, waits until camera is ready or timeout is expired.
        /// Does nothing if shooting in progress.
        /// 
        /// Exceptions:
        /// InvalidOperationException, if shooting is not supported or camera disconnected.
        /// </summary>
        /// <param name="fileName">Name of the result file. If the file is already exists, it will be overwritten.</param>
        /// <param name="timeout">Timeout in msec.</param>
        /// <returns>Name of the file in the camera (string.Empty if not supported)</returns>
        string Shoot(string fileName, int timeout);

        /// <summary>
        /// Shoots asynchronously to inner storage.
        /// Shoots without downloading when inner storage shooting is not supported.
        /// Does nothing if shooting in progress.
        /// 
        /// Exceptions:
        /// InvalidOperationException, if shooting is not supported or camera disconnected.
        /// </summary>
        void ShootAsync();

        /// <summary>
        /// Shoots asynchronously and downloads the image to the computer file named.
        /// Shoots without downloading when inner storage shooting is only supported.
        /// Does nothing if shooting in progress.
        /// 
        /// Exceptions:
        /// 
        /// InvalidOperationException, if shooting is not supported or camera disconnected.
        /// </summary>
        /// <param name="fileName">Name of the result file. If the file is already exists, it will be overwritten.</param>
        void ShootAsync(string fileName);

        /// <summary>
        /// Cancels asynchronous shooting.
        /// Does nothing if no shooting is in progress.
        /// </summary>
        void ShootAsyncCancel();



        /// <summary>
        /// Sets new shutter speed synchronously.
        /// Does nothing if shutter speed getting is supported and the new value is the same as the old one.
        /// Cancels previous shutter speed changing operation if any.
        /// 
        /// Exceptions:
        /// InvalidOperationException, if shutter speed setting is not supported.
        /// ArgumentException, if the new value is not available.
        /// </summary>
        /// <param name="tv">New value of the shutter speed.</param>
        void ChangeTv(Tv tv);

        /// <summary>
        /// Sets new shutter speed asynchronously.
        /// Does nothing if shutter speed getting is supported and the new value is the same as the old one.
        /// Cancels previous shutter speed changing operation if any.
        /// 
        /// Exceptions:
        /// InvalidOperationException, if shutter speed setting is not supported.
        /// ArgumentException, if the new value is not available.
        /// </summary>
        /// <param name="tv">New value of the shutter speed.</param>
        void ChangeTvAsync(Tv tv);

        /// <summary>
        /// Cancels shutter speed change operation.
        /// Does nothing if no such operation is in progress.
        /// </summary>
        void ChangeTvAsyncCancel();

        /// <summary>
        /// Sets new diaphragm synchronously.
        /// Does nothing if diaphragm getting is supported and the new value is the same as the old one.
        /// Cancels previous diaphragm changing operation if any.
        /// 
        /// Exceptions:
        /// InvalidOperationException, if diaphragm setting is not supported.
        /// ArgumentException, if the new value is not available.
        /// </summary>
        /// <param name="av">New value of the diaphragm.</param>
        void ChangeAv(Av av);

        /// <summary>
        /// Sets new diaphragm asynchronously.
        /// Does nothing if diaphragm getting is supported and the new value is the same as the old one.
        /// Cancels previous diaphragm changing operation if any.
        /// 
        /// Exceptions:
        /// InvalidOperationException, if diaphragm setting is not supported.
        /// ArgumentException, if the new value is not available.
        /// </summary>
        /// <param name="av">New value of the diaphragm.</param>
        void ChangeAvAsync(Av av);

        /// <summary>
        /// Cancels diaphragm change operation.
        /// Does nothing if no such operation is in progress.
        /// </summary>
        void ChangeAvAsyncCancel();

        /// <summary>
        /// Sets new white balance synchronously.
        /// Does nothing if white balance getting is supported and the new value is the same as the old one.
        /// Cancels previous white balance changing operation if any.
        /// 
        /// Exceptions:
        /// InvalidOperationException, if white balance setting is not supported.
        /// ArgumentException, if the new value is not available.
        /// </summary>
        /// <param name="wb">New value of the white balance.</param>
        void ChangeWB(string wb);

        /// <summary>
        /// Sets new white balance asynchronously.
        /// Does nothing if white balance getting is supported and the new value is the same as the old one.
        /// Cancels previous white balance changing operation if any.
        /// 
        /// Exceptions:
        /// InvalidOperationException, if white balance setting is not supported.
        /// ArgumentException, if the new value is not available.
        /// </summary>
        /// <param name="wb">New value of the white balance.</param>
        void ChangeWBAsync(string wb);

        /// <summary>
        /// Cancels white balance change operation.
        /// Does nothing if no such operation is in progress.
        /// </summary>
        void ChangeWBAsyncCancel();

        /// <summary>
        /// Sets new ISO synchronously.
        /// Does nothing if ISO getting is supported and the new value is the same as the old one.
        /// Cancels previous ISO changing operation if any.
        /// 
        /// Exceptions:
        /// InvalidOperationException, if ISO setting is not supported.
        /// ArgumentException, if the new value is not available.
        /// </summary>
        /// <param name="iso">New value of the ISO.</param>
        void ChangeIso(Iso iso);

        /// <summary>
        /// Sets new ISO asynchronously.
        /// Does nothing if ISO getting is supported and the new value is the same as the old one.
        /// Cancels previous ISO changing operation if any.
        /// 
        /// Exceptions:
        /// InvalidOperationException, if ISO setting is not supported.
        /// ArgumentException, if the new value is not available.
        /// </summary>
        /// <param name="iso">New value of the ISO.</param>
        void ChangeIsoAsync(Iso iso);

        /// <summary>
        /// Cancels ISO change operation.
        /// Does nothing if no such operation is in progress.
        /// </summary>
        void ChangeIsoAsyncCancel();


        /// <summary>
        /// Cancels frame size and quality settings change operation.
        /// Does nothing if no such operation is in progress.
        /// </summary>
        void ChangeQualityAsyncCancel();



        /// <summary>
        /// Sets new image file format synchronously.
        /// Does nothing if image file format getting is supported and the new value is the same as the old one.
        /// Cancels previous image file format changing operation if any.
        /// 
        /// Exceptions:
        /// InvalidOperationException, if image file format setting is not supported.
        /// ArgumentException, if the new value is not available.
        /// </summary>
        /// <param name="format">New value of the image file format.</param>
        void ChangeFormat(string format);

        /// <summary>
        /// Sets new image file format asynchronously.
        /// Does nothing if image file format getting is supported and the new value is the same as the old one.
        /// Cancels previous image file format changing operation if any.
        /// 
        /// Exceptions:
        /// InvalidOperationException, if image file format setting is not supported.
        /// ArgumentException, if the new value is not available.
        /// </summary>
        /// <param name="format">New value of the image file format.</param>
        void ChangeFormatAsync(string format);

        /// <summary>
        /// Cancels image file format change operation.
        /// Does nothing if no such operation is in progress.
        /// </summary>
        void ChangeFormatAsyncCancel();
    }
}
