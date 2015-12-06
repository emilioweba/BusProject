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
        Teste_OnibusContext context;

        public ManageStations(Form parent)
        {
            InitializeComponent();
            this.parentForm = parent;

            using (context = new Teste_OnibusContext())
            {
                loadGridViewData(context);
            }
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
            if (MessageBox.Show("When performing this operation, the route of the buses that pass through this station will be changed. Are you sure you want to continue?", "Confirmation", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    using (context = new Teste_OnibusContext())
                    {
                        var id = int.Parse(e.Row.Cells["ID"].Value.ToString());

                        STATION station = context.STATIONS.FirstOrDefault(x => x.Station_ID == id);

                        List<STATION_BUSES> station_bus = context.STATION_BUSES.Where(x => x.Stations_Fk == id).ToList();

                        foreach (var item in station_bus)
                        {
                            context.STATION_BUSES.Remove(item);
                        }

                        context.STATIONS.Remove(station);

                        context.SaveChanges();
                    }

                    Methods.DisplayMessage(lblMessage, "Deleted successfully!", Color.Green);
                }
                catch (Exception ex)
                {
                    Methods.DisplayMessage(lblMessage, "Error while deleting", Color.Red);
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
            lblMessage.Text = "";

            dgvStations.Columns[1].Visible = false;
            dgvStations.Columns[3].Visible = false;
            dgvStations.Columns[4].Visible = false;

            enableFields(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(validFields())
            {
                if (txtID.Text.Length > 0) //Alter
                {
                    try
                    {
                        using (context = new Teste_OnibusContext())
                        {
                            var id = int.Parse(txtID.Text);

                            STATION station = context.STATIONS.FirstOrDefault(x => x.Station_ID == id);

                            station.Station_Description = txtDescription.Text;

                            context.SaveChanges();

                            if (loadGridViewData(context))
                            {
                                lblMessage.Text = "Updated successfully!";
                                lblMessage.ForeColor = Color.Green;
                                enableFields(false);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Methods.DisplayMessage(lblMessage, "It was not possible to update the data", Color.Red);
                    }
                }
                //else // Add
                //{
                //    STATION station = new STATION();

                //    station = txtDescription.Text;

                //    using (context = new Teste_OnibusContext())
                //    {
                //        context.STATION.Add(station);

                //        context.SaveChanges();

                //        if (loadGridViewData(context))
                //        {
                //            lblMessage.Text = "Add successfully!";
                //            lblMessage.ForeColor = Color.Green;
                //            enableFields(false);
                //        }
                //    }
                //}
            }
            else
            {
                Methods.DisplayMessage(lblMessage, "Check the input data", Color.Red);
            }
            resetFields();
        }

        private bool loadGridViewData(Teste_OnibusContext context)
        {
            try
            {
                var list = new BindingList<STATION>(context.STATIONS.ToList());
                var source = new BindingSource(list, null);
                dgvStations.DataSource = source;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
