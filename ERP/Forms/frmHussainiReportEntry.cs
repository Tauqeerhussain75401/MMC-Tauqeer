using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class frmHussainiReportEntry : Form
    {
        public frmHussainiReportEntry()
        {
            InitializeComponent();
        }
        void LoadPatientInfo()
        {
            //DataTable dt = Query.
            if (cmbIOstatus.Text == "OPD")
            {

            }
        }
        private void frmHussainiReportEntry_Load(object sender, EventArgs e)
        {
            bool status = clsConnection.sqlCon();

            if (!status)
            {
                MessageBox.Show("Error in connection with Hussaini Database","Error In connection",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

    }
}
