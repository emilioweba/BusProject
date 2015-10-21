namespace Bus_Application
{
    partial class ManageStations
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvStations = new System.Windows.Forms.DataGridView();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTATIONSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTATIONSBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(58, 59);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(43, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Station:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(122, 56);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(150, 20);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescription_KeyPress);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(272, 90);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Save";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvStations
            // 
            this.dgvStations.AllowUserToAddRows = false;
            this.dgvStations.AllowUserToResizeRows = false;
            this.dgvStations.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edit,
            this.ID});
            this.dgvStations.DataSource = this.sTATIONSBindingSource;
            this.dgvStations.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvStations.Location = new System.Drawing.Point(122, 139);
            this.dgvStations.MultiSelect = false;
            this.dgvStations.Name = "dgvStations";
            this.dgvStations.ReadOnly = true;
            this.dgvStations.RowHeadersVisible = false;
            this.dgvStations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStations.Size = new System.Drawing.Size(225, 208);
            this.dgvStations.TabIndex = 8;
            this.dgvStations.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvStations_CellMouseClick);
            this.dgvStations.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStations_CellMouseLeave);
            this.dgvStations.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvStations_CellMouseMove);
            this.dgvStations.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvStations_UserDeletingRow);
            // 
            // Edit
            // 
            this.Edit.FillWeight = 50F;
            this.Edit.HeaderText = "";
            this.Edit.Image = global::Bus_Application.Properties.Resources.Edit;
            this.Edit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Edit.MinimumWidth = 50;
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Edit.Width = 50;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "Station_ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 60;
            // 
            // sTATIONSBindingSource
            // 
            this.sTATIONSBindingSource.DataMember = "STATIONS";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(122, 100);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 9;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(304, 56);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 10;
            this.txtID.Visible = false;
            // 
            // ManageStations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 405);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.dgvStations);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ManageStations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Stations";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ManageStations_FormClosed);
            this.Load += new System.EventHandler(this.ManageStations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTATIONSBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvStations;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.BindingSource sTATIONSBindingSource;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Station_Description;
    }
}