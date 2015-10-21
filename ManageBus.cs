using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpKml.Base;

namespace Bus_Application
{
    public partial class ManageBus : Form
    {
        Form parentForm;
        DBBus dbBus;
        public ManageBus(Form parent)
        {
            InitializeComponent();
            this.parentForm = parent;
            
            Teste_OnibusContext context = new Teste_OnibusContext();
            dbBus = new DBBus(context);
        }

        #region BasicEvents

        private void dgvBus_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            lblMessage.Text = string.Empty;
            if (MessageBox.Show("Ao realizar essa operação, a rota desse ônibus também será deletada. Tem certeza que deseja continuar?", "Confirmação", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    dbBus.Delete(int.Parse(e.Row.Cells["ID"].Value.ToString()));
                    Methods.DisplayMessage(lblMessage, "Removido com sucesso!", Color.Green);
                }
                catch (Exception ex)
                {
                    Methods.DisplayMessage(lblMessage, "Erro ao remover registro", Color.Red);
                }
                enableFields(false);
            }
            else
                e.Cancel = true;
        }

        private void dgvBus_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
                Cursor = Cursors.Hand;
            else
                Cursor = Cursors.Default;
        }

        private void dgvBus_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                enableFields(true);
                
                txtDescription.Text = dgvBus["Bus_Description", e.RowIndex].Value.ToString();
                txtProvider.Text = dgvBus["Bus_Provider", e.RowIndex].Value.ToString();
                txtColor.Text = dgvBus["Bus_Color", e.RowIndex].Value.ToString();
                txtID.Text = dgvBus["ID", e.RowIndex].Value.ToString();

                lblMessage.Text = "";
            }
        }

        private void dgvBus_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void ManageBus_FormClosed(object sender, FormClosedEventArgs e)
        {
            parentForm.Enabled = true;
            parentForm.Activate();
        }

        private void txtColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnAdd_Click(this, new EventArgs());
        }

        #endregion

        #region BasicMethods
        private bool validFields()
        {
            bool valid = true;

            if (txtDescription.Text.Trim().Equals(string.Empty))
                valid = false;

            return valid;
        }

        private void resetFields()
        {
            txtDescription.Text = "";
            txtProvider.Text = "";
            txtColor.Text = "";
            txtID.Text = "";
        }

        private void enableFields(bool enable)
        {
            txtDescription.Enabled = enable;
            txtColor.Enabled = enable;
            txtProvider.Enabled = enable;
            btnAdd.Enabled = enable;

            txtDescription.Text = "";
            txtColor.Text = "";
            txtProvider.Text = "";
            txtID.Text = "";
        }

        #endregion

        private void ManageBus_Load(object sender, EventArgs e)
        {
            //this.bUSESTableAdapter.Fill(this.teste_OnibusDataSet.BUSES);
            lblMessage.Text = "";

            enableFields(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(validFields())
            {
                if (txtID.Text.Length > 0) //Alterar
                {
                    try
                    {
                        BUS bus = new BUS();

                        bus.Bus_ID = int.Parse(txtID.Text);
                        bus.Bus_Description = txtDescription.Text;
                        bus.Bus_Provider = txtProvider.Text;
                        bus.Bus_Color = txtColor.Text;

                        dbBus.Edit(bus);
                        //this.bUSESTableAdapter.Fill(this.teste_OnibusDataSet.BUSES);

                        lblMessage.Text = "Alterado com sucesso!";
                        lblMessage.ForeColor = Color.Green;
                        enableFields(false);
                    }
                    catch(Exception ex)
                    {
                        Methods.DisplayMessage(lblMessage, "Não foi possível alterar os campos", Color.Red);
                    }
                }
                //else // Adicionar
                //{
                //    BUS bus = new BUS();

                //    bus.Bus_Description = txtDescription.Text;
                //    bus.Bus_Provider = txtProvider.Text;
                //    bus.Bus_Color = txtColor.Text;

                //    dbBus.Add(bus);
                //    this.bUSESTableAdapter.Fill(this.teste_OnibusDataSet.BUSES);

                //    lblMessage.Text = "Adicionado com sucesso!";
                //    lblMessage.ForeColor = Color.Green;
                //}
            }
            else
            {
                Methods.DisplayMessage(lblMessage, "Verifique os campos informados", Color.Red);
            }
            resetFields();
        }

    }
}
