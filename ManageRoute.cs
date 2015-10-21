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
 
        public ManageRoute(Form parent)
        {
            InitializeComponent();
            this.formParent = parent;
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
            // TODO: This line of code loads data into the 'teste_OnibusDataSet1.ROUTEs' table. You can move, or remove it, as needed.
            //this.rOUTEsTableAdapter.Fill(this.teste_OnibusDataSet1.ROUTEs);
            // TODO: This line of code loads data into the 'teste_OnibusDataSet1.BUSES' table. You can move, or remove it, as needed.
            //this.bUSESTableAdapter.Fill(this.teste_OnibusDataSet1.BUSES);
            //this.bUSESTableAdapter.Fill(this.teste_OnibusDataSet.BUSES);

            DBRoute db = new DBRoute(new Teste_OnibusContext());

            var a = db.SelectRouteBus();

            foreach (var item in a)
            {
                var b = 1;
            }

            DataSet st = new DataSet();
            //st = a;
            //set.Load();
            
            //dataGridView1.DataSource = db.SelectRouteBus();

            
        }

    }
}
