using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Tekla.Structures.Model;

namespace SingleSnapShot
{
    public partial class CreateSnapShot : Form
    {
        public string ExportFolder { get; set; }
        public string MacroFileName { get; set; }
        public CreateSnapShot()
        {
            this.InitializeComponent();
        }

        private void ButtonCreateSnapShot_Click(object sender, EventArgs e)
        {
            var dateTimeNow = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            var fileName = this.ExportFolder + @"\" + this.TextBoxFileName.Text + " " + dateTimeNow;

            this.CreateSnapShotMacro(this.TextBoxResolution.Text, fileName);
            Tekla.Structures.Model.Operations.Operation.RunMacro(this.MacroFileName);
        }
        private void CreateSnapShotMacro(string resolution, string fileName)
        {
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
            sb.AppendLine($"            akit.ValueChange(\"snapshot_dialog\", \"filename\", @\"{fileName}\" + \".png\");");
            sb.AppendLine($"            akit.ValueChange(\"snapshot_dialog\", \"show_with_viewer_enabled\", \"0\");");
            sb.AppendLine($"            akit.PushButton(\"take_snapshot\", \"snapshot_dialog\"); ");
            sb.AppendLine($"            akit.PushButton(\"option_ok\", \"snapshot_option_dialog\");");
            sb.AppendLine($"            akit.PushButton(\"cancel\", \"snapshot_dialog\"); ");
            sb.AppendLine($"        }}");
            sb.AppendLine($"    }}");
            sb.AppendLine($"}}");

            File.WriteAllText(this.MacroFileName, sb.ToString());
        }
        private void ButtonOpenFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", @"/open, " + this.ExportFolder);
        }

        private void CreateSnapShot_Load(object sender, EventArgs e)
        {
            this.TextBoxResolution.Text = "320";
            this.TextBoxFileName.Text = "Snapshot";

            var macroName = "CreateSnapShotMacro.cs";
            this.MacroFileName = @"C:\ProgramData\Trimble\Tekla Structures\2023.0\Environments\UK\General\user-macros\modeling\" + macroName;

            var model = new Model();
            var modelInfo = model.GetInfo();
            var folderName = "SnapShotsGG";
            this.ExportFolder = modelInfo.ModelPath + @"\" + folderName;

            if (!Directory.Exists(this.ExportFolder))
            {
                Directory.CreateDirectory(this.ExportFolder);
            }
        }

        private void TextBoxResolution_TextChanged(object sender, EventArgs e)
        {
            this.TextBoxResolution.Text = this.TextBoxResolution.Text;
        }

        private void TextBoxFileName_TextChanged(object sender, EventArgs e)
        {
            this.TextBoxFileName.Text = this.TextBoxFileName.Text;
        }
    }
}
