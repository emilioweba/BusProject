using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bus_Application
{
    public partial class ManageRoute : Form
    {
        public Form formParent { get; set; }
        Teste_OnibusContext context;
 
        public ManageRoute(Form parent)
        {
            InitializeComponent();
            this.formParent = parent;

            using (context = new Teste_OnibusContext())
            {
                loadGridViewData(context);
            }
        }

        private void btnAddBus_Click(object sender, EventArgs e)
        {
            ManageBus formBus = new ManageBus(this);
            formBus.Visible = true;
            this.Enabled = false;
        }

        private void btnAddReferencia_Click(object sender, EventArgs e)
        {
            ManageReference formReference = new ManageReference(this);
            formReference.Visible = true;
            this.Enabled = false;
        }
        private void ManageRoute_FormClosed(object sender, FormClosedEventArgs e)
        {
            formParent.Enabled = true;
            formParent.Activate();
        }

        private void ManageRoute_Load(object sender, EventArgs e)
        {
           

           

            
        }

        private bool loadGridViewData(Teste_OnibusContext context)
        {
            try
            {
                var list = new BindingList<ROUTE>(context.ROUTEs.ToList());
                var source = new BindingSource(list, null);
                dgvRoutes.DataSource = source;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
