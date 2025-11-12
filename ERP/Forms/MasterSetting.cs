using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class MasterSetting : Form
    {
        public MasterSetting()
        {
            InitializeComponent();
        }

        private void txtEvening_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal.Parse((sender as TextBox).Text);
            }
            catch
            {
                (sender as TextBox).Text = "0";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void MasterSetting_Load(object sender, EventArgs e)
        {
            DataTable dt = Query.getData("select * from MasterAggrement");
            if (dt.Rows.Count > 0)
            {
                txtCustomers.Text = ((decimal )dt.Rows[0]["CustomerMandiCom"]).ToString("N0");
                txtFarmers.Text = ((decimal)dt.Rows[0]["FarmerMandiCom"]).ToString("N0");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to save this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Decimal CustomersAggrement = int.Parse(txtCustomers.Text);
                Decimal FarmerAggrement = int.Parse(txtFarmers.Text);
                Query.Execute("Update MasterAggrement set CustomerMandiCom = " + CustomersAggrement + ", FarmerMandiCom = " + FarmerAggrement + "");
                MessageBox.Show("Record Successfully Saved..!");
            }
        }
    }
}
