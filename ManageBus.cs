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
        Teste_OnibusContext context;

        public ManageBus(Form parent)
        {
            InitializeComponent();
            this.parentForm = parent;

            using (context = new Teste_OnibusContext())
            {
                loadGridViewData(context);
            }
        }

        #region BasicEvents

        private void dgvBus_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            lblMessage.Text = string.Empty;
            if (MessageBox.Show("When performing this operation, the route of this bus will also be deleted. Are you sure you want to continue?", "Confirmation", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    using (context = new Teste_OnibusContext())
                    {
                        var id = int.Parse(e.Row.Cells["ID"].Value.ToString());

                        BUS bus = context.BUS.FirstOrDefault(x => x.Bus_ID == id);

                        ROUTE route = context.ROUTEs.FirstOrDefault(x => x.Bus_ID == id);

                        List<STATION_BUSES> station_bus = context.STATION_BUSES.Where(x => x.Buses_FK == id).ToList();

                        foreach (var item in station_bus)
                        {
                            context.STATION_BUSES.Remove(item);
                        }

                        context.ROUTEs.Remove(route);
                        context.BUS.Remove(bus);

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

                if (dgvBus["Bus_Provider", e.RowIndex].Value == null)
                {
                    txtProvider.Text = "";
                }
                else
                {
                    txtProvider.Text = dgvBus["Bus_Provider", e.RowIndex].Value.ToString();
                }

                if (dgvBus["Bus_Color", e.RowIndex].Value == null)
                {
                    txtColor.Text = "";
                }
                else
                {
                    txtColor.Text = dgvBus["Bus_Color", e.RowIndex].Value.ToString();
                }

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
            //txtDescription.Enabled = enable;
            //txtColor.Enabled = enable;
            //txtProvider.Enabled = enable;
            //btnAdd.Enabled = enable;

            txtDescription.Text = "";
            txtColor.Text = "";
            txtProvider.Text = "";
            txtID.Text = "";
        }

        #endregion

        private void ManageBus_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            dgvBus.Columns[6].Visible = false;
            dgvBus.Columns[5].Visible = false;

            enableFields(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (validFields())
            {
                if (txtID.Text.Length > 0) //Alter
                {
                    try
                    {
                        using (context = new Teste_OnibusContext())
                        {
                            var id = int.Parse(txtID.Text);
                            BUS bus = context.BUS.FirstOrDefault(x => x.Bus_ID == id);

                            bus.Bus_Description = txtDescription.Text;
                            bus.Bus_Provider = txtProvider.Text;
                            bus.Bus_Color = txtColor.Text;

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
                else // Add
                {
                    BUS bus = new BUS();

                    bus.Bus_Description = txtDescription.Text;
                    bus.Bus_Provider = txtProvider.Text;
                    bus.Bus_Color = txtColor.Text;

                    using (context = new Teste_OnibusContext())
                    {
                        context.BUS.Add(bus);

                        context.SaveChanges();

                        if (loadGridViewData(context))
                        {
                            lblMessage.Text = "Add successfully!";
                            lblMessage.ForeColor = Color.Green;
                            enableFields(false);
                        }
                    }
                }
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
                var list = new BindingList<BUS>(context.BUS.ToList());
                var source = new BindingSource(list, null);
                dgvBus.DataSource = source;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
