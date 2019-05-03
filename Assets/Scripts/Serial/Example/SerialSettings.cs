using System;
using UnityEngine;

namespace CRI.HitBoxTemplate.Example
{
    [Serializable]
    public struct SerialSettings
    {
        /// <summary>
        /// Name of the the touch surface serial port. (ex: COM4)
        /// </summary>
        [Tooltip("Name of the the touch surface serial port. (ex: COM4)")]
        public string touchControlSerialPortName;
        /// <summary>
        /// Name of the the led controller serial port. (ex: COM5)
        /// </summary>
        [Tooltip("Name of the the led controller serial port. (ex: COM5)")]
        public string ledControlSerialPortName;
        /// <summary>
        /// Camera used to display the screen on the bag.
        /// </summary>
        [Tooltip("Camera used to display the screen on the bg.")]
        public Camera playerCamera;
        /// <summary>
        /// Min value to detect impact
        /// </summary>
        [Tooltip("Min value to detect impact.")]
        public int impactThreshold;
        /// <summary>
        /// Minimum time (in ms) between 2 impacts to be validated (minimum 50ms <=> maximum 50 hits/s)
        /// </summary>
        [Tooltip("Minimum time (in ms) between 2 impacts to be validated (minimum 50ms <=> maximum 50 hits/s)")]
        public int delayOffHit;

        public SerialSettings(string touchSurfacePort,
            string ledControlPort,
            int impactThreshold,
            int delayOffHit,
            Camera playerCamera)
        {
            this.touchControlSerialPortName = touchSurfacePort;
            this.ledControlSerialPortName = ledControlPort;
            this.impactThreshold = impactThreshold;
            this.delayOffHit = delayOffHit;
            this.playerCamera = playerCamera;
        }
    }
} 