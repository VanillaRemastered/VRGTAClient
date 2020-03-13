using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaUpdater
{
    class VanillaOverlay
    {
        static int overlayTextFps = -1;
        static bool isActive = false;

        /// <summary>
        /// Does the main logic loop, fetching current FPS and updatign the label.
        /// </summary>
        static void LogicLoop()
        {
            while(ProcessWatcher.IsGameRunning() && isActive)
            {
                int fps = DX9OverlayAPI.Overlay.GetFrameRate();
                DX9OverlayAPI.Overlay.TextSetString(overlayTextFps, fps.ToString());
            }
        }

        /// <summary>
        /// Creates required elements using the directx wrapper
        /// </summary>
        public static void Init()
        {
            if (!ProcessWatcher.IsGameRunning())
                return;

            DX9OverlayAPI.Overlay.SetParam("process", "gta_sa.exe");

            overlayTextFps = DX9OverlayAPI.Overlay.TextCreate("Arial", 12, true, false, 200, 200, 0xFF00FFFF, "FPS", false, true);
            isActive = true;
            LogicLoop();
        }

        /// <summary>
        /// Stops the main loop and destroys the overlay.
        /// </summary>
        public static void Stop()
        {
            isActive = false;

            DX9OverlayAPI.Overlay.TextDestroy(overlayTextFps);
        }
    }
}
