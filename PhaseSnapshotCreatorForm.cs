using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SingleSnapShot.Services;
using Tekla.Structures.Model.Operations;


namespace SingleSnapShot
{
    public partial class CreateSnapShot : Form
    {
        private readonly TeklaService TeklaService;
        private readonly MacroCreator MacroCreator;
        private readonly SnapshotManager SnapshotManager;

        public string ExportFolderPath { get; set; }

        public string MacroFilePath { get; set; }

        public CreateSnapShot()
        {
            this.InitializeComponent();
            this.TeklaService = new TeklaService();
            this.MacroCreator = new MacroCreator();
            this.SnapshotManager = new SnapshotManager();
        }

        private void PhaseSnapshotCreator_Load(object sender, EventArgs e)
        {
            try
            {
                this.Resolution.Text = Properties.Settings.Default.Resolution;

                if (Properties.Settings.Default.PhaseOrder != null)
                {
                    this.PhaseOrder.Lines =
                        Properties.Settings.Default.PhaseOrder.Cast<string>().ToArray();
                }

                if (Properties.Settings.Default.VisiblePhases != null)
                {
                    this.VisiblePhases.Lines =
                        Properties.Settings.Default.VisiblePhases.Cast<string>().ToArray();
                }

                var modelPath = this.TeklaService.GetModelPath();
                var macroDirectory = this.TeklaService.GetUserMacroDirectory();
                this.MacroFilePath = Path.Combine(macroDirectory, "CreateSnapShotMacro.cs");
                this.ExportFolderPath = this.SnapshotManager.CreateExportFolder(modelPath, this.TeklaService.GetUserInitials());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonStartPhasing_Click(object sender, EventArgs e)
        {
            var snapshotFile = this.SnapshotManager.CreateSnapshotFileName(this.ExportFolderPath, "Frame 1");
            this.MacroCreator.CreateSnapshotMacro(this.MacroFilePath, this.Resolution.Text, snapshotFile);
            Operation.RunMacro(this.MacroFilePath);
        }

        private void ButtonOpenFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", this.ExportFolderPath);
        }

        private void TextBoxResolution_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Resolution = this.Resolution.Text;
        }

        private void TextBoxFileName_TextChanged(object sender, EventArgs e)
        {
            var phases = new StringCollection();

            foreach (var phase in this.PhaseOrder.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                phases.Add(phase);
            }

            Properties.Settings.Default.PhaseOrder = phases;
        }

        private void VisiblePhases_TextChanged(object sender, EventArgs e)
        {
            var phases = new StringCollection();

            foreach (var phase in this.VisiblePhases.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                phases.Add(phase);
            }

            Properties.Settings.Default.VisiblePhases = phases;
        }

        private void CreateSnapShot_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}