namespace Bus_Application
{
    partial class ManageRoute
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
            this.components = new System.ComponentModel.Container();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.lblBus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddBus = new System.Windows.Forms.Button();
            this.btnAddReferencia = new System.Windows.Forms.Button();
            this.dgvRoutes = new System.Windows.Forms.DataGridView();
            this.testeOnibusDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testeOnibusDataSet1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(134, 101);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(218, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(134, 63);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(218, 21);
            this.comboBox2.TabIndex = 2;
            // 
            // lblBus
            // 
            this.lblBus.AutoSize = true;
            this.lblBus.Location = new System.Drawing.Point(85, 66);
            this.lblBus.Name = "lblBus";
            this.lblBus.Size = new System.Drawing.Size(28, 13);
            this.lblBus.TabIndex = 3;
            this.lblBus.Text = "Bus:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Landmark:";
            // 
            // btnAddBus
            // 
            this.btnAddBus.Location = new System.Drawing.Point(370, 61);
            this.btnAddBus.Name = "btnAddBus";
            this.btnAddBus.Size = new System.Drawing.Size(75, 23);
            this.btnAddBus.TabIndex = 6;
            this.btnAddBus.Text = "Manage";
            this.btnAddBus.UseVisualStyleBackColor = true;
            this.btnAddBus.Click += new System.EventHandler(this.btnAddBus_Click);
            // 
            // btnAddReferencia
            // 
            this.btnAddReferencia.Location = new System.Drawing.Point(370, 99);
            this.btnAddReferencia.Name = "btnAddReferencia";
            this.btnAddReferencia.Size = new System.Drawing.Size(75, 23);
            this.btnAddReferencia.TabIndex = 7;
            this.btnAddReferencia.Text = "Manage";
            this.btnAddReferencia.UseVisualStyleBackColor = true;
            this.btnAddReferencia.Click += new System.EventHandler(this.btnAddReferencia_Click);
            // 
            // dgvRoutes
            // 
            this.dgvRoutes.AutoGenerateColumns = false;
            this.dgvRoutes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoutes.DataSource = this.testeOnibusDataSet1BindingSource;
            this.dgvRoutes.Location = new System.Drawing.Point(123, 181);
            this.dgvRoutes.Name = "dgvRoutes";
            this.dgvRoutes.Size = new System.Drawing.Size(240, 150);
            this.dgvRoutes.TabIndex = 8;
            // 
            // testeOnibusDataSet1BindingSource
            // 
            this.testeOnibusDataSet1BindingSource.AllowNew = true;
            this.testeOnibusDataSet1BindingSource.DataMember = "ROUTEs";
            // 
            // ManageRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 366);
            this.Controls.Add(this.dgvRoutes);
            this.Controls.Add(this.btnAddReferencia);
            this.Controls.Add(this.btnAddBus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblBus);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ManageRoute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Route";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ManageRoute_FormClosed);
            this.Load += new System.EventHandler(this.ManageRoute_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testeOnibusDataSet1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label lblBus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddBus;
        private System.Windows.Forms.Button btnAddReferencia;
        private System.Windows.Forms.DataGridView dgvRoutes;
        private System.Windows.Forms.BindingSource testeOnibusDataSet1BindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn busIDDataGridViewTextBoxColumn;
    }
}