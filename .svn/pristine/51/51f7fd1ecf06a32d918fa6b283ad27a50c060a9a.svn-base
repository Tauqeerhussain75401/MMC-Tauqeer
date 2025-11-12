using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace ERP
{
    public partial class frmTest : Form
    {

        public frmTest()
        {
            InitializeComponent();
            FillControls.FillcmbTestCatagory(cmbFilterCatagory);
            FillControls.FillcmbTestCatagory(cmbCatagory);
            FillControls.FillcmbDepartmentIndex(cmbDepartment);

        }
        bool FLogIn = true;
        DataTable dtQuery;
        void FillQuery()
        {
            dgvQuery.Rows.Clear();
            dtQuery = Query.TestIndex((string)cmbFilterCatagory.SelectedValue, cmbStatus.Text);
            for (int i = 0; i < dtQuery.Rows.Count; i++)
            {
                dgvQuery.Rows.Add(dtQuery.Rows[i]["ID"].ToString(), dtQuery.Rows[i]["TiTle"].ToString(),
                    dtQuery.Rows[i]["hospitalrate"].ToString(),
                    dtQuery.Rows[i]["IsDeactivated"].ToString() == "0" ? true : false,
                    dtQuery.Rows[i]["CreatedBy"].ToString() + " | " + ((DateTime)dtQuery.Rows[i]["CreatedTime"]).ToString("dd-MMM-yyyy hh:mm:ss tt"),
                    dtQuery.Rows[i]["EditBy"].ToString() != "" ? dtQuery.Rows[i]["EditBy"].ToString() + " | " + ((DateTime)dtQuery.Rows[i]["EditTime"]).ToString("dd-MMM-yyyy hh:mm:ss tt") : null);
            }



        }
        internal void FillDetail(string ID)
        {
            DataTable dt;
            dt = Query.TestDetail(ID);
            /////////////////////
            txtID.Text = ID;
            if (dt.Rows.Count > 0)
            {
                cmbCatagory.SelectedValue = dt.Rows[0]["TesttypeId"].ToString();
                cmbLocation.SelectedValue = dt.Rows[0]["location"].ToString() == null ? "-1" : dt.Rows[0]["location"].ToString();
                chkIsActive.Checked = dt.Rows[0]["IsDeactivated"].ToString() == "0" ? true : false;
                txtTitle.Text = dt.Rows[0]["Title"].ToString();
                ntxtCharges.Value = (Decimal)dt.Rows[0]["HospitalRate"];
                ntxtHospShare.Value = (Decimal)dt.Rows[0]["hospitalshare"];
                ntxtConsShare.Value = (Decimal)dt.Rows[0]["consultantshare"];
                cmbDepartment.SelectedValue = dt.Rows[0]["testHeadId"].ToString();
                txtCreatedBy.Text = dt.Rows[0]["CreatedBy"].ToString() + " | " + ((DateTime)dt.Rows[0]["CreatedTime"]).ToString("dd-MMM-yyyy hh:mm:ss tt");
                txtEditBy.Text = dt.Rows[0]["EditBy"].ToString() != "" ? dt.Rows[0]["EditBy"].ToString() + " | " + ((DateTime)dt.Rows[0]["EditTime"]).ToString("dd-MMM-yyyy hh:mm:ss tt") : null;

            }
        }
        DataTable dtDepartment = Query.DepartmentIndexAll();
        private void frmReceipt_Load(object sender, EventArgs e)
        {

            FillQuery();
            FillControls.FillcmBLocation(cmbLocation);
            //FillLocation
            FLogIn = false;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to save this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (UserInfo.UserLevel != "Admin" && txtID.Text != "")
                {
                    frmAuthentication frm = new frmAuthentication();
                    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        return;
                    }
                }
                if (cmbLocation.Text == "")
                {
                    MessageBox.Show("Plz Select Location");
                    return;
                }
                else if (cmbFilterCatagory.Text == "Laboratory")
                {
                    if (cmbDepartment.Text == "")
                    {
                        MessageBox.Show("Plz Select Department");
                        return;
                    }
                }
                //        if (row.Cells[clnAccount.Index].Value != null &&
                //            row.Cells[clnAccount.Index].Value != null)
                //        {
                DML.Test_add_Edit(txtID.Text, txtTitle.Text, ntxtCharges.Value.ToString(), (string)cmbCatagory.SelectedValue, ntxtConsShare.Value.ToString(), ntxtHospShare.Value.ToString(), (string)cmbDepartment.SelectedValue, cmbLocation.SelectedValue.ToString(), chkIsActive.Checked ? "0" : "1");
                //        }
                //    }
                //FillDetail(voucher);
                MessageBox.Show("Record Successfully Saved..!");
                FillQuery();
                btnNew.Focus();
                //}
            }
        }
        private void dgvQuery_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!FLogIn && e.RowIndex != -1)
            {
                string voucherNo = dgvQuery.Rows[e.RowIndex].Cells[clnid.Index].Value.ToString();
                tabDetailQuery.SelectedTab = tabpgDetail;
                FillDetail(voucherNo);
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {


            FillQuery();
        }
        private void dgvQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvQuery.CurrentRow != null)
                {
                    string voucherNo = dgvQuery.CurrentRow.Cells[clnid.Index].Value.ToString();
                    tabDetailQuery.SelectedTab = tabpgDetail;
                    FillDetail(voucherNo);
                    e.Handled = true;
                }
            }
        }
        int VoucherIndex = 0;


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Validation.Clear(grpInvoiceDetail);

        }

        private void frmPayments_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }



        private void btnPrint_Click(object sender, EventArgs e)
        {
            Reports.CrpTest rpt = new Reports.CrpTest();
            DataTable dt = Query.TestIndex((string)cmbFilterCatagory.SelectedValue, cmbStatus.Text);
            rpt.SetDataSource(dtQuery);
            rpt.SetParameterValue("@TestType", cmbFilterCatagory.Text);
            frmReportView frm = new frmReportView();
            frm.rptViewer.ReportSource = rpt;
            frm.Show();
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDepartment.Enabled = false;
            if (cmbCatagory.Text == "Laboratory")
            {
                cmbDepartment.Enabled = true;
            }
        }





    }
}
