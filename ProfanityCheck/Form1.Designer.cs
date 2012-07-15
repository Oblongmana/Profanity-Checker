namespace ProfanityCheck
{
    partial class Form1
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCheckFile = new System.Windows.Forms.Button();
            this.lblAlphaDB = new System.Windows.Forms.Label();
            this.tbCheckFile = new System.Windows.Forms.TextBox();
            this.btnProfanityList = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbProfanityList = new System.Windows.Forms.TextBox();
            this.ofdCheckFile = new System.Windows.Forms.OpenFileDialog();
            this.ofdProfanityList = new System.Windows.Forms.OpenFileDialog();
            this.btnRun = new System.Windows.Forms.Button();
            this.pbMyProgressBar = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCheckFile
            // 
            this.btnCheckFile.Location = new System.Drawing.Point(665, 24);
            this.btnCheckFile.Name = "btnCheckFile";
            this.btnCheckFile.Size = new System.Drawing.Size(91, 20);
            this.btnCheckFile.TabIndex = 80;
            this.btnCheckFile.Text = "Browse";
            this.btnCheckFile.UseVisualStyleBackColor = true;
            this.btnCheckFile.Click += new System.EventHandler(this.btnCheckFile_Click);
            // 
            // lblAlphaDB
            // 
            this.lblAlphaDB.AutoSize = true;
            this.lblAlphaDB.Location = new System.Drawing.Point(12, 9);
            this.lblAlphaDB.Name = "lblAlphaDB";
            this.lblAlphaDB.Size = new System.Drawing.Size(217, 13);
            this.lblAlphaDB.TabIndex = 79;
            this.lblAlphaDB.Text = "1) Choose your csv file to check for profanity";
            // 
            // tbCheckFile
            // 
            this.tbCheckFile.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbCheckFile.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbCheckFile.Location = new System.Drawing.Point(47, 25);
            this.tbCheckFile.Name = "tbCheckFile";
            this.tbCheckFile.ReadOnly = true;
            this.tbCheckFile.Size = new System.Drawing.Size(612, 20);
            this.tbCheckFile.TabIndex = 78;
            // 
            // btnProfanityList
            // 
            this.btnProfanityList.Location = new System.Drawing.Point(665, 75);
            this.btnProfanityList.Name = "btnProfanityList";
            this.btnProfanityList.Size = new System.Drawing.Size(91, 20);
            this.btnProfanityList.TabIndex = 83;
            this.btnProfanityList.Text = "Browse";
            this.btnProfanityList.UseVisualStyleBackColor = true;
            this.btnProfanityList.Click += new System.EventHandler(this.btnProfanityList_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 13);
            this.label1.TabIndex = 82;
            this.label1.Text = "2) Choose your profanity filter csv list";
            // 
            // tbProfanityList
            // 
            this.tbProfanityList.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbProfanityList.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbProfanityList.Location = new System.Drawing.Point(47, 76);
            this.tbProfanityList.Name = "tbProfanityList";
            this.tbProfanityList.ReadOnly = true;
            this.tbProfanityList.Size = new System.Drawing.Size(612, 20);
            this.tbProfanityList.TabIndex = 81;
            // 
            // ofdCheckFile
            // 
            this.ofdCheckFile.FileName = "openFileDialog1";
            // 
            // ofdProfanityList
            // 
            this.ofdProfanityList.FileName = "openFileDialog1";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(665, 120);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(90, 46);
            this.btnRun.TabIndex = 84;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // pbMyProgressBar
            // 
            this.pbMyProgressBar.Location = new System.Drawing.Point(47, 120);
            this.pbMyProgressBar.Name = "pbMyProgressBar";
            this.pbMyProgressBar.Size = new System.Drawing.Size(612, 46);
            this.pbMyProgressBar.TabIndex = 85;
            this.pbMyProgressBar.Tag = "";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(322, 137);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(68, 13);
            this.lblProgress.TabIndex = 86;
            this.lblProgress.Text = "Progress: 0%";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 180);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.pbMyProgressBar);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnProfanityList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbProfanityList);
            this.Controls.Add(this.btnCheckFile);
            this.Controls.Add(this.lblAlphaDB);
            this.Controls.Add(this.tbCheckFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCheckFile;
        private System.Windows.Forms.Label lblAlphaDB;
        private System.Windows.Forms.TextBox tbCheckFile;
        private System.Windows.Forms.Button btnProfanityList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbProfanityList;
        private System.Windows.Forms.OpenFileDialog ofdCheckFile;
        private System.Windows.Forms.OpenFileDialog ofdProfanityList;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.ProgressBar pbMyProgressBar;
        private System.Windows.Forms.Label lblProgress;
    }
}

