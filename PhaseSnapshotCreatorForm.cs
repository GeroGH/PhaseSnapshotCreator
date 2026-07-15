using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
            this.UpdateStatus("Add phases, then click Start Phasing.");

            var currentScreen = Screen.FromPoint(Cursor.Position);
            var workingArea = currentScreen.WorkingArea;
            this.Location = new Point(workingArea.Right - this.Width - 50, workingArea.Top + 150);

            try
            {
                this.Resolution.Text = Properties.Settings.Default.Resolution;

                if (Properties.Settings.Default.PhaseOrder != null)
                {
                    this.PhasesInOrder.Lines = Properties.Settings.Default.PhaseOrder.Cast<string>().ToArray();
                }

                if (Properties.Settings.Default.VisiblePhases != null)
                {
                    this.VisiblePhases.Lines = Properties.Settings.Default.VisiblePhases.Cast<string>().ToArray();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateStatus(string message)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => this.UpdateStatus(message)));
                return;
            }

            this.StatusLabel.Text = message;
        }

        private void ButtonStartPhasing_Click(object sender, EventArgs e)
        {
            this.UpdateStatus("Preparing snapshot export...");

            TeklaService.CreateNewSnapshotSession();
            Directory.CreateDirectory(TeklaService.ExportFolderPath);

            var phasesInOrder = PhasesInOrderManager.GetPhases(this.PhasesInOrder.Text);
            var alwaysVisiblePhases = PhasesInOrderManager.GetPhases(this.VisiblePhases.Text);

            var visibleProgressPhases = new List<int>();
            var frameCounter = 1;

            foreach (var currentPhase in phasesInOrder)
            {
                this.UpdateStatus($"Processing Phase {currentPhase} (Frame {frameCounter})...");
                visibleProgressPhases.Add(currentPhase);

                var phasesToShow = new List<int>();
                phasesToShow.AddRange(visibleProgressPhases);
                phasesToShow.AddRange(alwaysVisiblePhases);
                phasesToShow = phasesToShow.Distinct().ToList();

                this.UpdateStatus($"Creating filter for Phase {currentPhase}...");
                FilterBuilder.CreateFilter(TeklaService.FilterName, phasesToShow);

                this.UpdateStatus($"Updating Tekla representation...");
                this.ApplyRepresentation(TeklaService.FilterName);

                this.UpdateStatus($"Creating snapshot Frame {frameCounter}...");
                var snapshotName = $"Frame {frameCounter:00}";
                MacroCreator.CreateSnapshotMacro(TeklaService.MacroPath, TeklaService.ExportFolderPath, this.Resolution.Text, snapshotName);
                Tekla.Structures.Model.Operations.Operation.RunMacro(TeklaService.MacroPath);
                frameCounter++;
            }

            this.UpdateStatus("Snapshot export completed. Click Open Folder to view the results.");
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
            var folderPath = TeklaService.ExportFolderPath;

            if (!Directory.Exists(folderPath))
            {
                folderPath = Path.GetDirectoryName(folderPath);
            }

            if (!string.IsNullOrEmpty(folderPath) && Directory.Exists(folderPath))
            {
                Process.Start("explorer.exe", folderPath);
            }
            else
            {
                MessageBox.Show("Snapshot folder does not exist.");
            }
        }

        private void TextBoxResolution_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Resolution = this.Resolution.Text;
        }

        private void TextBoxFileName_TextChanged(object sender, EventArgs e)
        {
            var phases = new StringCollection();

            foreach (var phase in this.PhasesInOrder.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
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

        public static class PhasesInOrderManager
        {
            public static List<int> GetPhases(string text)
            {
                var phases = new List<int>();
                var seen = new HashSet<int>();

                foreach (Match match in Regex.Matches(text, @"\d+"))
                {
                    var phase = int.Parse(match.Value);

                    if (seen.Add(phase))
                    {
                        phases.Add(phase);
                    }
                }

                return phases;
            }
        }

        private void CreateSnapShot_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}