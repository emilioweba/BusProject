namespace Bus_Application
{
    partial class UploadKML
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.rdbStations = new System.Windows.Forms.RadioButton();
            this.rdbReferences = new System.Windows.Forms.RadioButton();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnClearStationReferences = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.chbBus = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(218, 75);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Load";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(73, 77);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(139, 20);
            this.txtPath.TabIndex = 1;
            // 
            // rdbStations
            // 
            this.rdbStations.AutoSize = true;
            this.rdbStations.Location = new System.Drawing.Point(14, 12);
            this.rdbStations.Name = "rdbStations";
            this.rdbStations.Size = new System.Drawing.Size(63, 17);
            this.rdbStations.TabIndex = 2;
            this.rdbStations.Text = "Stations";
            this.rdbStations.UseVisualStyleBackColor = true;
            this.rdbStations.CheckedChanged += new System.EventHandler(this.rdbStations_CheckedChanged);
            // 
            // rdbReferences
            // 
            this.rdbReferences.AutoSize = true;
            this.rdbReferences.Location = new System.Drawing.Point(14, 35);
            this.rdbReferences.Name = "rdbReferences";
            this.rdbReferences.Size = new System.Drawing.Size(107, 17);
            this.rdbReferences.TabIndex = 4;
            this.rdbReferences.Text = "Reference Points";
            this.rdbReferences.UseVisualStyleBackColor = true;
            this.rdbReferences.CheckedChanged += new System.EventHandler(this.rdbReferences_CheckedChanged);
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(70, 218);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(223, 52);
            this.lblMessage.TabIndex = 10;
            // 
            // btnClearStationReferences
            // 
            this.btnClearStationReferences.Location = new System.Drawing.Point(218, 284);
            this.btnClearStationReferences.Name = "btnClearStationReferences";
            this.btnClearStationReferences.Size = new System.Drawing.Size(75, 23);
            this.btnClearStationReferences.TabIndex = 11;
            this.btnClearStationReferences.Text = "Clear";
            this.btnClearStationReferences.UseVisualStyleBackColor = true;
            this.btnClearStationReferences.Click += new System.EventHandler(this.btnClearStationReferences_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Clear Reference Points:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chbBus);
            this.panel1.Controls.Add(this.rdbStations);
            this.panel1.Controls.Add(this.rdbReferences);
            this.panel1.Location = new System.Drawing.Point(144, 117);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(149, 86);
            this.panel1.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 319);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Clear Database:";
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(217, 314);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(75, 23);
            this.btnClearAll.TabIndex = 18;
            this.btnClearAll.Text = "Clear";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // chbBus
            // 
            this.chbBus.AutoSize = true;
            this.chbBus.Location = new System.Drawing.Point(14, 58);
            this.chbBus.Name = "chbBus";
            this.chbBus.Size = new System.Drawing.Size(96, 17);
            this.chbBus.TabIndex = 5;
            this.chbBus.Text = "Bus and Route";
            this.chbBus.UseVisualStyleBackColor = true;
            this.chbBus.CheckedChanged += new System.EventHandler(this.chbBus_CheckedChanged);
            // 
            // UploadKML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 363);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClearStationReferences);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnBrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UploadKML";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Load";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UploadKMLStations_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.RadioButton rdbStations;
        private System.Windows.Forms.RadioButton rdbReferences;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnClearStationReferences;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.RadioButton chbBus;
    }
}