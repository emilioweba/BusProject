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
    public partial class ManageReference : Form
    {
        Form parentForm;
        Teste_OnibusContext context;

        public ManageReference(Form parent)
        {
            InitializeComponent();
            this.parentForm = parent;
            txtMain.Enabled = false;

            using (context = new Teste_OnibusContext())
            {
                loadGridViewData(context);
            }
        }

        #region BasicEvents

        private void dgvReferences_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                enableFields(true);

                int id = int.Parse(dgvReferences["Known_As_ID", e.RowIndex].Value.ToString());

                using (context = new Teste_OnibusContext())
                {
                    var mainLandmark = context.LANDMARK_KNOWN_AS.FirstOrDefault(x => x.Known_As_ID == id).LANDMARK.LANDMARK_KNOWN_AS.OrderBy(x => x.Known_As_ID).First().Known_As_Description;
                    txtMain.Text = mainLandmark;
                    txtKnown.Text = dgvReferences["Known_As_Description", e.RowIndex].Value.ToString();
                    txtID.Text = id.ToString();
                }

                lblMessage.Text = "";
            }
        }

        private void dgvReferences_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void dgvReferences_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
                Cursor = Cursors.Hand;
            else
                Cursor = Cursors.Default;
        }

        private void dgvReferences_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            lblMessage.Text = string.Empty;
            if (MessageBox.Show("When performing this operation, all related landmarks will also be deleted. Are you sure you want to continue?", "Confirmation", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    using (context = new Teste_OnibusContext())
                    {
                        var id = int.Parse(e.Row.Cells["Known_As_ID"].Value.ToString());

                        LANDMARK_KNOWN_AS landmark = context.LANDMARK_KNOWN_AS.FirstOrDefault(x => x.Known_As_ID == id);

                        var parentLandmark = landmark.LANDMARK;
                        var relatedLandmarks = parentLandmark.LANDMARK_KNOWN_AS.ToList();

                        foreach (var item in relatedLandmarks)
                        {
                            context.LANDMARK_KNOWN_AS.Remove(item);
                        }

                        context.LANDMARK_KNOWN_AS.Remove(landmark);
                        context.LANDMARKs.Remove(parentLandmark);

                        context.SaveChanges();

                        if (loadGridViewData(context))
                        {
                            Methods.DisplayMessage(lblMessage, "Deleted successfully!", Color.Green);
                        }
                    }
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

        private void ManageReference_FormClosed(object sender, FormClosedEventArgs e)
        {
            parentForm.Enabled = true;
            parentForm.Activate();
        }

        #endregion

        #region BasicMethods
        private bool validFields()
        {
            bool valid = true;

            if (txtMain.Text.Trim().Equals(string.Empty))
            {
                valid = false;
            }
            else if (txtKnown.Text.Trim().Equals(string.Empty))
            {
                valid = false;
            }

            return valid;
        }

        private void resetFields()
        {
            txtMain.Text = "";
            txtKnown.Text = "";
            txtID.Text = "";
        }

        private void enableFields(bool enable)
        {
            //txtMain.Enabled = enable;
            txtKnown.Enabled = enable;
            btnAdd.Enabled = enable;

            txtMain.Text = "";
            txtKnown.Text = "";
            txtID.Text = "";
        }

        private void dgvReferencesColumnsVisible(bool visible)
        {
            dgvReferences.Columns[1].Visible = visible;
            dgvReferences.Columns[2].Visible = visible;
            dgvReferences.Columns[4].Visible = visible;
            dgvReferences.Columns[5].Visible = visible;
        }

        #endregion

        private void ManageReference_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            dgvReferencesColumnsVisible(false);

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
                            LANDMARK_KNOWN_AS landmark = context.LANDMARK_KNOWN_AS.FirstOrDefault(x => x.Known_As_ID == id);

                            landmark.Known_As_Description = txtKnown.Text;

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
                dgvReferences.DataSource = null;

                var list = new BindingList<LANDMARK_KNOWN_AS>(context.LANDMARK_KNOWN_AS.ToList());
                var source = new BindingSource(list, null);
                dgvReferences.DataSource = source;

                dgvReferencesColumnsVisible(false);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
