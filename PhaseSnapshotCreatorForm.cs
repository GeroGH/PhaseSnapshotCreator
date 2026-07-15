using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PhaseSnapshotCreator.Filtering;
using PhaseSnapshotCreator.Services;
using Tekla.Structures.Model.UI;


namespace PhaseSnapshotCreator
{
    public partial class CreateSnapShot : Form
    {
        public CreateSnapShot()
        {
            this.InitializeComponent();
        }

        private void PhaseSnapshotCreator_Load(object sender, EventArgs e)
        {
            var currentScreen = Screen.FromPoint(Cursor.Position);
            var workingArea = currentScreen.WorkingArea;
            this.Location = new Point(workingArea.Right - this.Width - 50, workingArea.Top + 150);

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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonStartPhasing_Click(object sender, EventArgs e)
        {
            FilterBuilder.CreateFilter(TeklaService.FilterName, this.PhaseOrder.ToString(), this.VisiblePhases.ToString());
            this.ApplyRepresentation(TeklaService.FilterName);
            MacroCreator.CreateSnapshotMacro(TeklaService.MacroPath, TeklaService.ExportFolderPath, this.Resolution.Text, "Frame 1");
            Tekla.Structures.Model.Operations.Operation.RunMacro(TeklaService.MacroPath);
        }
        public void ApplyRepresentation(string representationName)
        {

            var visibleViews = ViewHandler.GetVisibleViews();

            while (visibleViews.MoveNext())
            {
                var currentView = visibleViews.Current;
                if (currentView == null)
                    continue;

                currentView.ViewFilter = representationName;
                currentView.Modify();
            }
        }
        private void ButtonOpenFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", TeklaService.ExportFolderPath);
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