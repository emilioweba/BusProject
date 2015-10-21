namespace Bus_Application
{
    partial class Form_Search
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
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadKMLEstaçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onibusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pontoDeReferenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cboBuses = new System.Windows.Forms.ComboBox();
            this.lblRecommendations = new System.Windows.Forms.Label();
            this.lblReferenceSearch = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.cboStation = new System.Windows.Forms.ComboBox();
            this.lblStationWhere = new System.Windows.Forms.Label();
            this.lblDistance = new System.Windows.Forms.Label();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.lblMeters = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(176, 84);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(223, 20);
            this.txtKeyword.TabIndex = 2;
            this.txtKeyword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKeyword_KeyPress);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(299, 139);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.cadastroToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(426, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uploadKMLEstaçõesToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.arquivoToolStripMenuItem.Text = "File";
            // 
            // uploadKMLEstaçõesToolStripMenuItem
            // 
            this.uploadKMLEstaçõesToolStripMenuItem.Name = "uploadKMLEstaçõesToolStripMenuItem";
            this.uploadKMLEstaçõesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.uploadKMLEstaçõesToolStripMenuItem.Text = "Perform Data Load";
            this.uploadKMLEstaçõesToolStripMenuItem.Click += new System.EventHandler(this.uploadKMLEstaçõesToolStripMenuItem_Click);
            // 
            // cadastroToolStripMenuItem
            // 
            this.cadastroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotaToolStripMenuItem,
            this.onibusToolStripMenuItem,
            this.pontoDeReferenciaToolStripMenuItem,
            this.estaçãoToolStripMenuItem});
            this.cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
            this.cadastroToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.cadastroToolStripMenuItem.Text = "Management";
            // 
            // rotaToolStripMenuItem
            // 
            this.rotaToolStripMenuItem.Name = "rotaToolStripMenuItem";
            this.rotaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rotaToolStripMenuItem.Text = "Route";
            this.rotaToolStripMenuItem.Click += new System.EventHandler(this.rotaToolStripMenuItem_Click);
            // 
            // onibusToolStripMenuItem
            // 
            this.onibusToolStripMenuItem.Name = "onibusToolStripMenuItem";
            this.onibusToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.onibusToolStripMenuItem.Text = "Bus";
            this.onibusToolStripMenuItem.Click += new System.EventHandler(this.onibusToolStripMenuItem_Click);
            // 
            // pontoDeReferenciaToolStripMenuItem
            // 
            this.pontoDeReferenciaToolStripMenuItem.Name = "pontoDeReferenciaToolStripMenuItem";
            this.pontoDeReferenciaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pontoDeReferenciaToolStripMenuItem.Text = "Landmark";
            this.pontoDeReferenciaToolStripMenuItem.Click += new System.EventHandler(this.pontoDeReferenciaToolStripMenuItem_Click);
            // 
            // estaçãoToolStripMenuItem
            // 
            this.estaçãoToolStripMenuItem.Name = "estaçãoToolStripMenuItem";
            this.estaçãoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.estaçãoToolStripMenuItem.Text = "Station";
            this.estaçãoToolStripMenuItem.Click += new System.EventHandler(this.estaçãoToolStripMenuItem_Click);
            // 
            // cboBuses
            // 
            this.cboBuses.FormattingEnabled = true;
            this.cboBuses.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cboBuses.Location = new System.Drawing.Point(176, 180);
            this.cboBuses.Name = "cboBuses";
            this.cboBuses.Size = new System.Drawing.Size(198, 21);
            this.cboBuses.TabIndex = 5;
            // 
            // lblRecommendations
            // 
            this.lblRecommendations.AutoSize = true;
            this.lblRecommendations.Location = new System.Drawing.Point(46, 183);
            this.lblRecommendations.Name = "lblRecommendations";
            this.lblRecommendations.Size = new System.Drawing.Size(122, 13);
            this.lblRecommendations.TabIndex = 7;
            this.lblRecommendations.Text = "Bus lines recommended:";
            // 
            // lblReferenceSearch
            // 
            this.lblReferenceSearch.AutoSize = true;
            this.lblReferenceSearch.Location = new System.Drawing.Point(32, 87);
            this.lblReferenceSearch.Name = "lblReferenceSearch";
            this.lblReferenceSearch.Size = new System.Drawing.Size(133, 13);
            this.lblReferenceSearch.TabIndex = 8;
            this.lblReferenceSearch.Text = "Where do you want to go?";
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(49, 231);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(325, 60);
            this.lblMessage.TabIndex = 9;
            // 
            // cboStation
            // 
            this.cboStation.FormattingEnabled = true;
            this.cboStation.Location = new System.Drawing.Point(176, 57);
            this.cboStation.Name = "cboStation";
            this.cboStation.Size = new System.Drawing.Size(144, 21);
            this.cboStation.TabIndex = 1;
            // 
            // lblStationWhere
            // 
            this.lblStationWhere.AutoSize = true;
            this.lblStationWhere.Location = new System.Drawing.Point(37, 60);
            this.lblStationWhere.Name = "lblStationWhere";
            this.lblStationWhere.Size = new System.Drawing.Size(128, 13);
            this.lblStationWhere.TabIndex = 11;
            this.lblStationWhere.Text = "Which station are you at?";
            // 
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.Location = new System.Drawing.Point(12, 113);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(185, 13);
            this.lblDistance.TabIndex = 12;
            this.lblDistance.Text = "Distance from the station to landmark:";
            // 
            // txtDistance
            // 
            this.txtDistance.Location = new System.Drawing.Point(200, 110);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(66, 20);
            this.txtDistance.TabIndex = 3;
            this.txtDistance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDistance_KeyPress);
            // 
            // lblMeters
            // 
            this.lblMeters.AutoSize = true;
            this.lblMeters.Location = new System.Drawing.Point(272, 113);
            this.lblMeters.Name = "lblMeters";
            this.lblMeters.Size = new System.Drawing.Size(38, 13);
            this.lblMeters.TabIndex = 13;
            this.lblMeters.Text = "meters";
            // 
            // Form_Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 316);
            this.Controls.Add(this.lblMeters);
            this.Controls.Add(this.txtDistance);
            this.Controls.Add(this.lblDistance);
            this.Controls.Add(this.lblStationWhere);
            this.Controls.Add(this.cboStation);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblReferenceSearch);
            this.Controls.Add(this.lblRecommendations);
            this.Controls.Add(this.cboBuses);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtKeyword);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form_Search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Form";
            this.Load += new System.EventHandler(this.Form_Search_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onibusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pontoDeReferenciaToolStripMenuItem;
        private System.Windows.Forms.ComboBox cboBuses;
        private System.Windows.Forms.ToolStripMenuItem uploadKMLEstaçõesToolStripMenuItem;
        private System.Windows.Forms.Label lblRecommendations;
        private System.Windows.Forms.Label lblReferenceSearch;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.ComboBox cboStation;
        private System.Windows.Forms.Label lblStationWhere;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.Label lblMeters;
        private System.Windows.Forms.ToolStripMenuItem estaçãoToolStripMenuItem;
    }
}

