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
    public partial class frmUserSession : Form
    {
        public frmUserSession()
        {
            InitializeComponent();
        }

        void FillQuery(string UserId)
        {
            dgvSession .Rows.Clear();
            string q = "SELECT * from vu_usersession where userid = '" + UserId + "'  order by fromdate desc";
            DataTable dt = Query.getData(q);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgvSession.Rows.Add(dt.Rows[i]["sessionid"].ToString() ,
                      dt.Rows[i]["fromdate"].ToString() != "" ? ((DateTime )dt.Rows[i]["fromdate"]).ToString("dd-MMM-yyyy hh:mm:ss tt")  : null,
                      dt.Rows[i]["todate"].ToString() != "" ? ((DateTime)dt.Rows[i]["todate"]).ToString("dd-MMM-yyyy hh:mm:ss tt") : null,
                      dt.Rows[i]["status"].ToString() == "0" ? true  : false,
                      dt.Rows[i]["sessiondate"].ToString() != "" ? ((DateTime)dt.Rows[i]["sessiondate"]).ToString("dd-MMM-yyyy") : null,
                      dt.Rows[i]["shiftname"].ToString()
                      );
            }
            dgvSession_SelectionChanged(null, null);
        }
        private void frmUserSession_Load(object sender, EventArgs e)
        {
            if (UserInfo.UserLevel == "Admin")
            {
                FillControls.FillcmbUser(cmbUser);
            }
            else
            {
                FillQuery(UserInfo.UserId);
            }
        }

        private void dgvSession_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSession.CurrentRow!= null && (bool)dgvSession.CurrentRow.Cells[clnClosed.Index].Value == false)
            {
                btnClosed.Enabled = true;
                btnPrint.Enabled = true;
            }
            else
            {
                btnClosed.Enabled = false;
                btnPrint.Enabled = true ;
            }
        }

        private void btnClosed_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to closed this session...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DML.UserSession_Closed((string)dgvSession.CurrentRow.Cells[clnSessionId.Index].Value);
                MessageBox.Show("Session Successfully Closed...!");
                DataTable dt = Query.getData("SELECT * from usersession where sessionid = '" + (string)dgvSession.CurrentRow.Cells[clnSessionId.Index].Value + "'");
                dgvSession.CurrentRow.Cells[clnFrom.Index].Value = dt.Rows[0]["fromdate"].ToString() != "" ? ((DateTime)dt.Rows[0]["fromdate"]).ToString("dd-MMM-yyyy hh:mm:ss tt") : null;
                dgvSession.CurrentRow.Cells[clnTo.Index].Value = dt.Rows[0]["todate"].ToString() != "" ? ((DateTime)dt.Rows[0]["todate"]).ToString("dd-MMM-yyyy hh:mm:ss tt") : null;
                dgvSession.CurrentRow.Cells[clnClosed.Index].Value = dt.Rows[0]["status"].ToString() == "0" ? true : false;
            }
        }

        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
              DataRowView dr = (DataRowView)cmbUser.SelectedItem;
            dgvSession.Rows.Clear();
            if (dr != null)
            {
                FillQuery(dr["UserId"].ToString());
            }
              

            }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvSession.CurrentRow.Index  != -1)
            {
                if (UserInfo.UserLevel == "In-Patient"|| UserInfo.UserLevel == "Receptionist|In-Patient" || UserInfo.UserLevel == "Admin")
                {
                    Reports.dailyCashStatement daily = new Reports.dailyCashStatement();
                    DataTable DTBMJ = ReportQuery.rep_dailycashstatament_userwise((string)dgvSession.CurrentRow.Cells[clnSessionId.Index].Value);
                    daily.SetDataSource(DTBMJ);
                    daily.SetParameterValue("@User", UserInfo.UserId);
                    daily.SetParameterValue("@FDate", (string)dgvSession.CurrentRow.Cells[clnFrom.Index].Value);
                    daily.SetParameterValue("@ToDate",(string)dgvSession.CurrentRow.Cells[clnTo.Index].Value);

                    daily.SetParameterValue("@sessionfrom", (string)dgvSession.CurrentRow.Cells[clnFrom.Index].Value);
                    daily.SetParameterValue("@sessionto", (string)dgvSession.CurrentRow.Cells[clnTo.Index].Value);
                    daily.SetParameterValue("@SessionID", (string)dgvSession.CurrentRow.Cells[clnSessionId.Index].Value);
                    daily.SetParameterValue("@CompanyName", CompanyInfo.CompanyName);
                    frmReportView rptview = new frmReportView();
                    rptview.rptViewer.ReportSource = daily;
                    rptview.Show();
                    if (UserInfo.UserLevel == "Receptionist|In-Patient" || UserInfo.UserLevel == "Admin")
                    {
                        frmReportView frm = new frmReportView();
                        Reports.OPDClosingSummary rpt = new Reports.OPDClosingSummary();
                        DataTable dt = ReportQuery.ClosingSummarySessionWise((string)dgvSession.CurrentRow.Cells[clnSessionId.Index].Value);
                        DataTable dtSub = ReportQuery.SubAddLessDetail((string)dgvSession.CurrentRow.Cells[clnSessionId.Index].Value);
                        DataTable dtSubCancel = ReportQuery.SubCancelDetail((string)dgvSession.CurrentRow.Cells[clnSessionId.Index].Value);
                        DataTable dtSupicios = ReportQuery.SubSupicios((string)dgvSession.CurrentRow.Cells[clnSessionId.Index].Value);
                        rpt.SetDataSource(dt);
                        rpt.Subreports["SubUnpaidLessDetail"].SetDataSource(dtSub);
                        rpt.Subreports["SubCancelOpdReceipt"].SetDataSource(dtSubCancel);
                        rpt.Subreports["SupiciosTrans"].SetDataSource(dtSupicios);
                        rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                        rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                        rpt.SetParameterValue("@User", UserInfo.UserName);
                        rpt.SetParameterValue("@SessionUser", UserInfo.UserLevel == "Admin" ? cmbUser.SelectedValue.ToString() : UserInfo.UserId);
                        rpt.SetParameterValue("@SessionStart", (string)dgvSession.CurrentRow.Cells[clnFrom.Index].Value);
                        rpt.SetParameterValue("@SessionEnd", (string)dgvSession.CurrentRow.Cells[clnTo.Index].Value);
                        rpt.SetParameterValue("@SessionID", (string)dgvSession.CurrentRow.Cells[clnSessionId.Index].Value);
                        frm.rptViewer.ReportSource = rpt;
                        frm.Show();
                    }
                }
                else
                {
                    frmReportView frm = new frmReportView();
                    Reports.OPDClosingSummary rpt = new Reports.OPDClosingSummary();
                    DataTable dt = ReportQuery.ClosingSummarySessionWise((string)dgvSession.CurrentRow.Cells[clnSessionId.Index].Value);
                    DataTable dtSub = ReportQuery.SubAddLessDetail((string)dgvSession.CurrentRow.Cells[clnSessionId.Index].Value);
                    DataTable dtSubCancel = ReportQuery.SubCancelDetail((string)dgvSession.CurrentRow.Cells[clnSessionId.Index].Value);
                    DataTable dtSupicios = ReportQuery.SubSupicios((string)dgvSession.CurrentRow.Cells[clnSessionId.Index].Value);
                    rpt.SetDataSource(dt);
                    rpt.Subreports["SubUnpaidLessDetail"].SetDataSource(dtSub);
                    rpt.Subreports["SubCancelOpdReceipt"].SetDataSource(dtSubCancel);
                    rpt.Subreports["SupiciosTrans"].SetDataSource(dtSupicios);
                    rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                    rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                    rpt.SetParameterValue("@User", UserInfo.UserName);
                    rpt.SetParameterValue("@SessionUser", UserInfo.UserLevel == "Admin" ? cmbUser.SelectedValue.ToString() : UserInfo.UserId);
                    rpt.SetParameterValue("@SessionStart", (string)dgvSession.CurrentRow.Cells[clnFrom.Index].Value);
                    rpt.SetParameterValue("@SessionEnd", (string)dgvSession.CurrentRow.Cells[clnTo.Index].Value);
                    rpt.SetParameterValue("@SessionID", (string)dgvSession.CurrentRow.Cells[clnSessionId.Index].Value);
                    frm.rptViewer.ReportSource = rpt;
                    frm.Show();
                }
            }
        }
    }
}
