using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGershman.PhotoLib
{
    /// <summary>
    /// Common interface for all roulettes.
    /// </summary>
    public interface IRoulette : IDevice
    {
        /// <summary>
        /// Maximum frames horisontal amount supported.
        /// </summary>
        int NxMax { get; }

        /// <summary>
        /// Maximum frames vertical amount supported.
        /// </summary>
        int NyMax { get; }



        /// <summary>
        /// Minimum horisontal coordinate supported, mm.
        /// </summary>
        float Xmin { get; }

        /// <summary>
        /// Maximum horisontal coordinate supported, mm.
        /// </summary>
        float Xmax { get; }

        /// <summary>
        /// Minimum vertical coordinate supported, mm.
        /// </summary>
        float Ymin { get; }

        /// <summary>
        /// Maximum vertical coordinate supported, mm.
        /// </summary>
        float Ymax { get; }



        /// <summary>
        /// true, if the roulette can be calibrated by command
        /// </summary>
        bool CanCalibrate { get; }

        /// <summary>
        /// true, if the roulette allows to change frames overlay
        /// </summary>
        bool CanVaryOverlay { get; }

        /// <summary>
        /// true, if the roulette can report its coordinates
        /// </summary>
        bool CanGetCoords { get; }

        /// <summary>
        /// true, if the roulette can move by command
        /// </summary>
        bool CanMove { get; }



        /// <summary>
        /// Move technique - lens only, sensor only or as object
        /// </summary>
        MoveTechnique MoveTechnique { get; }



        /// <summary>
        /// Gets current device status.
        /// </summary>
        RouletteStatus Status { get; }



        /// <summary>
        /// Occurs when roulette status is changed.
        /// </summary>
        event EventHandler StatusChanged;

        /// <summary>
        /// Occurs when async calibration is complete.
        /// </summary>
        event EventHandler<RouletteResponseEventArgs> CalibrateComplete;

        /// <summary>
        /// Occurs when async movement is complete.
        /// </summary>
        event EventHandler<RouletteResponseEventArgs> MoveComplete;



        /// <summary>
        /// Gets minimum horisontal coordinate with the vertical coordinate and frames set given.
        /// Coordinates are in mm.
        /// </summary>
        /// <param name="y">vertical coordinate</param>
        /// <param name="nx">frames horisontal amount</param>
        /// <param name="ny">frames vertical amount</param>
        /// <returns>minimum horisontal coordinate with the vertical coordinate and frames set given</returns>
        float GetXMin(float y, int nx, int ny);

        /// <summary>
        /// Gets maximum horisontal coordinate with the vertical coordinate and frames set given.
        /// </summary>
        /// <param name="y">vertical coordinate</param>
        /// <param name="nx">frames horisontal amount</param>
        /// <param name="ny">frames vertical amount</param>
        /// <returns>maximum horisontal coordinate with the vertical coordinate and frames set given</returns>
        float GetXMax(float y, int nx, int ny);

        /// <summary>
        /// Gets minimum vertical coordinate with the horisontal coordinate and frames set given.
        /// </summary>
        /// <param name="y">horisontal coordinate</param>
        /// <param name="nx">frames horisontal amount</param>
        /// <param name="ny">frames vertical amount</param>
        /// <returns>minimum vertical coordinate with the horisontal coordinate and frames set given</returns>
        float GetYMin(float x, int nx, int ny);

        /// <summary>
        /// Gets maximum coordinate with the vertical coordinate and frames set given.
        /// </summary>
        /// <param name="y">vertical coordinate</param>
        /// <param name="nx">frames horisontal amount</param>
        /// <param name="ny">frames vertical amount</param>
        /// <returns>maximum coordinate with the vertical coordinate and frames set given</returns>
        float GetYMax(float x, int nx, int ny);



        /// <summary>
        /// Advices automatic frame order for the frames set given.
        /// </summary>
        /// <param name="nx">frames horisontal amount</param>
        /// <param name="ny">frames vertical amount</param>
        /// <param name="xMin">minimum horisontal coordinate of the set</param>
        /// <param name="xMax">maximum horisontal coordinate of the set</param>
        /// <param name="yMin">minimum vertical coordinate of the set</param>
        /// <param name="yMax">maximum vertical coordinate of the set</param>
        /// <returns>automatic frame order for the frames set given</returns>
        int[] AdviceOrder(int nx, int ny, float xMin, float xMax, float yMin, float yMax);



        /// <summary>
        /// Calibrates the roulette synchronously.
        /// Does nothing if calibration or movement is in progress.
        /// 
        /// Exceptions:
        /// InvalidOperationException, when calibration is not supported.
        /// </summary>
        /// <returns>Operation result</returns>
        RouletteResponse Calibrate();

        /// <summary>
        /// Calibrates the roulette asynchronously.
        /// Does nothing if calibration or movement is in progress.
        /// Operation result can be obtained when handling the CalibrateComplete event.
        /// 
        /// Exceptions:
        /// InvalidOperationException, when calibration is not supported.
        /// </summary>
        void CalibrateAsync();

        /// <summary>
        /// Cancels the calibrate operation.
        /// Does nothing if no calibration is in progress.
        /// </summary>
        void CalibrateAsyncCancel();

        /// <summary>
        /// Gets the current roulette coordinates in mm.
        /// This operation is synchronous only.
        /// 
        /// Exceptions:
        /// InvalidOperationException, when coordinates getting is not supported.
        /// </summary>
        /// <returns>Roulette coordinates in mm.</returns>
        PointF GetCoords();

        /// <summary>
        /// Moves the roulette to the coordinates given synchronously.
        /// Does nothing if calibration or movement is in progress.
        /// 
        /// Exceptions:
        /// InvalidOperationException, when moving is not supported
        /// </summary>
        /// <param name="location">Coordinates to move to, in mm.</param>
        /// <returns>Operation result.</returns>
        RouletteResponse Move(PointF location);

        /// <summary>
        /// Moves the roulette to the coordinates given asynchronously.
        /// Does nothing if calibration or movement is in progress.
        /// Operation result can be obtained when handling the MoveComplete event.
        /// 
        /// Exceptions:
        /// InvalidOperationException, when moving is not supported.
        /// </summary>
        /// <param name="location">Coordinates to move to, in mm.</param>
        void MoveAsync(PointF location);

        /// <summary>
        /// Cancels the movement operation.
        /// Does nothing if no movement is in progress.
        /// </summary>
        void MoveAsyncCancel();
    }
}
