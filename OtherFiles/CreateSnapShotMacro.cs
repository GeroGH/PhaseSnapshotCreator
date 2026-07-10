using System;
using Tekla.Structures.Model;

namespace Tekla.Technology.Akit.UserScript
{
    public class Script
    {
        public static void Run(IScript akit)
        {
            var model = new Model();
            var modelInfo = model.GetInfo();
            var directory = modelInfo.ModelPath + @"\SnapShotsGG";
            var fileName = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            var res = "640";

            akit.Callback("diaDisplaySnapshotDialog", "", "main_frame");
            akit.PushButton("options", "snapshot_dialog");
            akit.ValueChange("snapshot_option_dialog", "width", res);
            akit.ValueChange("snapshot_option_dialog", "dpi", "150");
            akit.ValueChange("snapshot_option_dialog", "white_bg_enabled", "1");
            akit.ValueChange("snapshot_dialog", "target_selection", "1");
            akit.ValueChange("snapshot_dialog", "filename", directory + "\\"  + fileName + ".bmp");
            akit.ValueChange("snapshot_dialog", "show_with_viewer_enabled", "0");
            akit.PushButton("take_snapshot", "snapshot_dialog");
            akit.PushButton("option_ok", "snapshot_option_dialog");
            akit.PushButton("cancel", "snapshot_dialog");
        }
    }
}