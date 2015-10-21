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
    public partial class ManageStations : Form
    {
        Form parentForm;
        DBStation dbStation;

        public ManageStations(Form parent)
        {
            InitializeComponent();
            this.parentForm = parent;
            
            Teste_OnibusContext context = new Teste_OnibusContext();
            dbStation = new DBStation(context);
        }

        #region BasicEvents

        private void dgvStations_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                enableFields(true);

                txtDescription.Text = dgvStations["Station_Description", e.RowIndex].Value.ToString();
                txtID.Text = dgvStations["ID", e.RowIndex].Value.ToString();

                lblMessage.Text = "";
            }
        }

        private void dgvStations_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void dgvStations_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
                Cursor = Cursors.Hand;
            else
                Cursor = Cursors.Default;
        }

        private void dgvStations_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            lblMessage.Text = string.Empty;
            if (MessageBox.Show("Ao realizar essa operação, a rota dos ônibus que passam por essa estação será alterada. Tem certeza que deseja continuar?", "Confirmação", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    dbStation.Delete(int.Parse(e.Row.Cells["ID"].Value.ToString()));
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
        
        private void ManageStations_FormClosed(object sender, FormClosedEventArgs e)
        {
            parentForm.Enabled = true;
            parentForm.Activate();
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
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
            txtID.Text = "";
        }

        private void enableFields(bool enable)
        {
            txtDescription.Enabled = enable;
            btnAdd.Enabled = enable;

            txtDescription.Text = "";
            txtID.Text = "";
        }

        #endregion

        private void ManageStations_Load(object sender, EventArgs e)
        {
            //this.sTATIONSTableAdapter.Fill(this.teste_OnibusDataSet3.STATIONS);
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
                        STATION station = new STATION();

                        station.Station_ID = int.Parse(txtID.Text);
                        station.Station_Description = txtDescription.Text;

                        dbStation.Edit(station);
                        //this.sTATIONSTableAdapter.Fill(this.teste_OnibusDataSet3.STATIONS);
            
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
