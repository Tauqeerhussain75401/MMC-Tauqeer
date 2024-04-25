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
    public partial class frmCurrentCashStatus : Form
    {
        public frmCurrentCashStatus()
        {
            InitializeComponent();
        }

        private void frmCurrentCashStatus_Load(object sender, EventArgs e)
        {
            UserCurrentCashStatus();
        }

        private void UserCurrentCashStatus()
        {
            DataTable dtUserSession = DML.Load_CurrentCashStatus(UserInfo.UserId);
            if (dtUserSession.Rows.Count > 0)
            {
                ntxtAdvAmount.Text = dtUserSession.Rows[0]["advamount"].ToString();
                ntxtRefundAmount.Text = dtUserSession.Rows[0]["refundamount"].ToString();
                ntxtTotalIPD.Text = dtUserSession.Rows[0]["totalipd"].ToString();
                ntxtOPD.Text = dtUserSession.Rows[0]["opd"].ToString();
                ntxtCurrentCash.Text = dtUserSession.Rows[0]["currentcash"].ToString();
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UserCurrentCashStatus();
        }

    }
}
