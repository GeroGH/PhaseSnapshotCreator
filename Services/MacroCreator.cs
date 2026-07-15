using System.IO;
using System.Text;

namespace PhaseSnapshotCreator.Services
{
    public static class MacroCreator
    {
        public static void CreateSnapshotMacro(string macroPath, string exportFolder, string resolution, string fileName)
        {
            var fileNameFullPath = Path.Combine(exportFolder, fileName);

            var sb = new StringBuilder();

            sb.AppendLine($"namespace Tekla.Technology.Akit.UserScript");
            sb.AppendLine($"{{");
            sb.AppendLine($"    public class Script");
            sb.AppendLine($"    {{");
            sb.AppendLine($"        public static void Run(IScript akit)");
            sb.AppendLine($"        {{");
            sb.AppendLine($"            akit.Callback(\"diaDisplaySnapshotDialog\", \"\", \"main_frame\");");
            sb.AppendLine($"            akit.PushButton(\"options\", \"snapshot_dialog\");");
            sb.AppendLine($"            akit.ValueChange(\"snapshot_option_dialog\", \"width\", \"{resolution}\");");
            sb.AppendLine($"            akit.ValueChange(\"snapshot_option_dialog\", \"dpi\", \"150\");");
            sb.AppendLine($"            akit.ValueChange(\"snapshot_option_dialog\", \"white_bg_enabled\", \"1\");");
            sb.AppendLine($"            akit.ValueChange(\"snapshot_dialog\", \"target_selection\", \"1\");");
            sb.AppendLine($"            akit.ValueChange(\"snapshot_dialog\", \"filename\", @\"{fileNameFullPath}\" + \".png\");");
            sb.AppendLine($"            akit.ValueChange(\"snapshot_dialog\", \"show_with_viewer_enabled\", \"0\");");
            sb.AppendLine($"            akit.PushButton(\"take_snapshot\", \"snapshot_dialog\"); ");
            sb.AppendLine($"            akit.PushButton(\"option_ok\", \"snapshot_option_dialog\");");
            sb.AppendLine($"            akit.PushButton(\"cancel\", \"snapshot_dialog\"); ");
            sb.AppendLine($"        }}");
            sb.AppendLine($"    }}");
            sb.AppendLine($"}}");

            File.WriteAllText(macroPath, sb.ToString());
        }
    }
}