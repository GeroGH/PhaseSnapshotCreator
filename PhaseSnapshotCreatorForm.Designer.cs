using System.Drawing;
using System.Windows.Forms;

namespace SingleSnapShot
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
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxFileName = new System.Windows.Forms.TextBox();
            this.ButtonCreateSnapShot = new System.Windows.Forms.Button();
            this.ButtonOpenFolder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxResolution = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File name:";
            // 
            // TextBoxFileName
            // 
            this.TextBoxFileName.Location = new System.Drawing.Point(10, 23);
            this.TextBoxFileName.Name = "TextBoxFileName";
            this.TextBoxFileName.Size = new System.Drawing.Size(240, 20);
            this.TextBoxFileName.TabIndex = 1;
            this.TextBoxFileName.TextChanged += new System.EventHandler(this.TextBoxFileName_TextChanged);
            // 
            // ButtonCreateSnapShot
            // 
            this.ButtonCreateSnapShot.Location = new System.Drawing.Point(10, 49);
            this.ButtonCreateSnapShot.Name = "ButtonCreateSnapShot";
            this.ButtonCreateSnapShot.Size = new System.Drawing.Size(318, 39);
            this.ButtonCreateSnapShot.TabIndex = 2;
            this.ButtonCreateSnapShot.Text = "Create Snap Shot";
            this.ButtonCreateSnapShot.UseVisualStyleBackColor = true;
            this.ButtonCreateSnapShot.Click += new System.EventHandler(this.ButtonCreateSnapShot_Click);
            // 
            // ButtonOpenFolder
            // 
            this.ButtonOpenFolder.Location = new System.Drawing.Point(10, 93);
            this.ButtonOpenFolder.Name = "ButtonOpenFolder";
            this.ButtonOpenFolder.Size = new System.Drawing.Size(318, 39);
            this.ButtonOpenFolder.TabIndex = 2;
            this.ButtonOpenFolder.Text = "Open Folder";
            this.ButtonOpenFolder.UseVisualStyleBackColor = true;
            this.ButtonOpenFolder.Click += new System.EventHandler(this.ButtonOpenFolder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Resolution:";
            // 
            // TextBoxResolution
            // 
            this.TextBoxResolution.Location = new System.Drawing.Point(256, 23);
            this.TextBoxResolution.Name = "TextBoxResolution";
            this.TextBoxResolution.Size = new System.Drawing.Size(72, 20);
            this.TextBoxResolution.TabIndex = 1;
            this.TextBoxResolution.TextChanged += new System.EventHandler(this.TextBoxResolution_TextChanged);
            // 
            // CreateSnapShot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 140);
            this.Controls.Add(this.ButtonOpenFolder);
            this.Controls.Add(this.ButtonCreateSnapShot);
            this.Controls.Add(this.TextBoxResolution);
            this.Controls.Add(this.TextBoxFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CreateSnapShot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phase Snapshot Creator v10.07.2026a";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CreateSnapShot_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox TextBoxFileName;
        private Button ButtonCreateSnapShot;
        private Button ButtonOpenFolder;
        private Label label2;
        private TextBox TextBoxResolution;
    }
}

