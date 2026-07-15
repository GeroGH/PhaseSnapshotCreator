using System.Drawing;
using System.Windows.Forms;

namespace PhaseSnapshotCreator
{
    partial class CreateSnapShot
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PhaseOrderLabel = new System.Windows.Forms.Label();
            this.PhaseOrder = new System.Windows.Forms.TextBox();
            this.ButtonStartPhasing = new System.Windows.Forms.Button();
            this.ButtonOpenFolder = new System.Windows.Forms.Button();
            this.VisiblePhasesLabel = new System.Windows.Forms.Label();
            this.Resolution = new System.Windows.Forms.TextBox();
            this.VisiblePhases = new System.Windows.Forms.TextBox();
            this.ResolutionLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SuspendLayout();
            // 
            // PhaseOrderLabel
            // 
            this.PhaseOrderLabel.AutoSize = true;
            this.PhaseOrderLabel.Location = new System.Drawing.Point(10, 8);
            this.PhaseOrderLabel.Name = "PhaseOrderLabel";
            this.PhaseOrderLabel.Size = new System.Drawing.Size(69, 13);
            this.PhaseOrderLabel.TabIndex = 0;
            this.PhaseOrderLabel.Text = "Phase Order:";
            // 
            // PhaseOrder
            // 
            this.PhaseOrder.Location = new System.Drawing.Point(10, 23);
            this.PhaseOrder.Multiline = true;
            this.PhaseOrder.Name = "PhaseOrder";
            this.PhaseOrder.Size = new System.Drawing.Size(109, 152);
            this.PhaseOrder.TabIndex = 1;
            this.PhaseOrder.TextChanged += new System.EventHandler(this.TextBoxFileName_TextChanged);
            // 
            // ButtonStartPhasing
            // 
            this.ButtonStartPhasing.Location = new System.Drawing.Point(251, 49);
            this.ButtonStartPhasing.Name = "ButtonStartPhasing";
            this.ButtonStartPhasing.Size = new System.Drawing.Size(152, 59);
            this.ButtonStartPhasing.TabIndex = 2;
            this.ButtonStartPhasing.Text = "Start Phasing";
            this.ButtonStartPhasing.UseVisualStyleBackColor = true;
            this.ButtonStartPhasing.Click += new System.EventHandler(this.ButtonStartPhasing_Click);
            // 
            // ButtonOpenFolder
            // 
            this.ButtonOpenFolder.Location = new System.Drawing.Point(251, 114);
            this.ButtonOpenFolder.Name = "ButtonOpenFolder";
            this.ButtonOpenFolder.Size = new System.Drawing.Size(152, 61);
            this.ButtonOpenFolder.TabIndex = 2;
            this.ButtonOpenFolder.Text = "Open Folder";
            this.ButtonOpenFolder.UseVisualStyleBackColor = true;
            this.ButtonOpenFolder.Click += new System.EventHandler(this.ButtonOpenFolder_Click);
            // 
            // VisiblePhasesLabel
            // 
            this.VisiblePhasesLabel.AutoSize = true;
            this.VisiblePhasesLabel.Location = new System.Drawing.Point(125, 9);
            this.VisiblePhasesLabel.Name = "VisiblePhasesLabel";
            this.VisiblePhasesLabel.Size = new System.Drawing.Size(83, 13);
            this.VisiblePhasesLabel.TabIndex = 0;
            this.VisiblePhasesLabel.Text = "Vissible Phases:";
            // 
            // Resolution
            // 
            this.Resolution.Location = new System.Drawing.Point(251, 23);
            this.Resolution.Name = "Resolution";
            this.Resolution.Size = new System.Drawing.Size(152, 20);
            this.Resolution.TabIndex = 1;
            this.Resolution.TextChanged += new System.EventHandler(this.TextBoxResolution_TextChanged);
            // 
            // VisiblePhases
            // 
            this.VisiblePhases.Location = new System.Drawing.Point(128, 23);
            this.VisiblePhases.Multiline = true;
            this.VisiblePhases.Name = "VisiblePhases";
            this.VisiblePhases.Size = new System.Drawing.Size(109, 152);
            this.VisiblePhases.TabIndex = 3;
            this.VisiblePhases.TextChanged += new System.EventHandler(this.VisiblePhases_TextChanged);
            // 
            // ResolutionLabel
            // 
            this.ResolutionLabel.AutoSize = true;
            this.ResolutionLabel.Location = new System.Drawing.Point(248, 8);
            this.ResolutionLabel.Name = "ResolutionLabel";
            this.ResolutionLabel.Size = new System.Drawing.Size(60, 13);
            this.ResolutionLabel.TabIndex = 4;
            this.ResolutionLabel.Text = "Resolution:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 182);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(411, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // CreateSnapShot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 204);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ResolutionLabel);
            this.Controls.Add(this.VisiblePhases);
            this.Controls.Add(this.ButtonOpenFolder);
            this.Controls.Add(this.ButtonStartPhasing);
            this.Controls.Add(this.Resolution);
            this.Controls.Add(this.PhaseOrder);
            this.Controls.Add(this.VisiblePhasesLabel);
            this.Controls.Add(this.PhaseOrderLabel);
            this.Name = "CreateSnapShot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phase Snapshot Creator v10.07.2026a";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateSnapShot_FormClosing);
            this.Load += new System.EventHandler(this.PhaseSnapshotCreator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label PhaseOrderLabel;
        private TextBox PhaseOrder;
        private Button ButtonStartPhasing;
        private Button ButtonOpenFolder;
        private Label VisiblePhasesLabel;
        private TextBox Resolution;
        private TextBox VisiblePhases;
        private Label ResolutionLabel;
        private StatusStrip statusStrip1;
    }
}

