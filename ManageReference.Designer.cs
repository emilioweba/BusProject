namespace Bus_Application
{
    partial class ManageReference
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
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtProvider = new System.Windows.Forms.TextBox();
            this.lblProvider = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvReferences = new System.Windows.Forms.DataGridView();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bUSESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.lblColor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReferences)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bUSESBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(109, 71);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(58, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Descrição:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(173, 68);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(150, 20);
            this.txtDescription.TabIndex = 1;
            // 
            // txtProvider
            // 
            this.txtProvider.Location = new System.Drawing.Point(173, 103);
            this.txtProvider.Name = "txtProvider";
            this.txtProvider.Size = new System.Drawing.Size(150, 20);
            this.txtProvider.TabIndex = 2;
            // 
            // lblProvider
            // 
            this.lblProvider.AutoSize = true;
            this.lblProvider.Location = new System.Drawing.Point(103, 106);
            this.lblProvider.Name = "lblProvider";
            this.lblProvider.Size = new System.Drawing.Size(64, 13);
            this.lblProvider.TabIndex = 4;
            this.lblProvider.Text = "Fornecedor:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(337, 182);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Salvar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvReferences
            // 
            this.dgvReferences.AllowUserToAddRows = false;
            this.dgvReferences.AllowUserToResizeRows = false;
            this.dgvReferences.AutoGenerateColumns = false;
            this.dgvReferences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReferences.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edit,
            this.ID});
            this.dgvReferences.DataSource = this.bUSESBindingSource;
            this.dgvReferences.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvReferences.Location = new System.Drawing.Point(33, 235);
            this.dgvReferences.MultiSelect = false;
            this.dgvReferences.Name = "dgvReferences";
            this.dgvReferences.ReadOnly = true;
            this.dgvReferences.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReferences.Size = new System.Drawing.Size(435, 180);
            this.dgvReferences.TabIndex = 8;
            this.dgvReferences.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvReferences_CellMouseClick);
            this.dgvReferences.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReferences_CellMouseLeave);
            this.dgvReferences.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvReferences_CellMouseMove);
            this.dgvReferences.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvReferences_UserDeletingRow);
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
            this.ID.DataPropertyName = "Bus_ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 60;
            // 
            // bUSESBindingSource
            // 
            this.bUSESBindingSource.DataMember = "BUSES";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(173, 191);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 9;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(355, 68);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 10;
            this.txtID.Visible = false;
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(173, 139);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(150, 20);
            this.txtColor.TabIndex = 3;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(141, 142);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(26, 13);
            this.lblColor.TabIndex = 11;
            this.lblColor.Text = "Cor:";
            // 
            // ManageReference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 471);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.dgvReferences);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtProvider);
            this.Controls.Add(this.lblProvider);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ManageReference";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Landmarks";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ManageReference_FormClosed);
            this.Load += new System.EventHandler(this.ManageReference_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReferences)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bUSESBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtProvider;
        private System.Windows.Forms.Label lblProvider;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvReferences;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.BindingSource bUSESBindingSource;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bus_Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bus_Provider;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bus_Color;
    }
}