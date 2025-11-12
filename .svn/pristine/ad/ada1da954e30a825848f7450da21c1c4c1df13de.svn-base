using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace ERP.Forms
{
    public partial class frmESSARegister : Form
    {
        public frmESSARegister()
        {
            InitializeComponent();
        }
        void FillForm()
        {
            string IsDateAll = rdbAll.Checked ? "1" : "0";
            string Status = cmbStatus.SelectedIndex == 0 ? "nvl(sentstatus,'0')" : cmbStatus.SelectedIndex == 1 ? "1" : "0";
            string sql = @"SELECT case when sentstatus = '1' then 'Sent' else 'Not Sent' end   status , reg.receiptno, io, reg.receiptdate vdate, patientname, age, wm_concat(reg.testname) tests,contactNo FROM  labmasterreg reg 
                            WHERE fktestid IN (SELECT id FROM test WHERE location = 'ESSA')
                            AND  (trunc(receiptdate) between '" + dtpFDate.Value.ToString("dd-MMM-yyyy") + "' and '" + dtpTDate.Value.ToString("dd-MMM-yyyy") + "' or 1 = " + IsDateAll + ") and nvl(sentstatus,'0') = " + Status +
                            " GROUP BY sentstatus, receiptno, io, receiptdate, patientname, age,contactNo order by to_number(receiptno) desc";
            DataTable dt = Query.getData(sql);
            dgvExpenses.Rows.Clear();   
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgvExpenses.Rows.Add(false, dt.Rows[i]["status"].ToString(), dt.Rows[i]["receiptno"].ToString(), dt.Rows[i]["io"].ToString(), dt.Rows[i]["vdate"].ToString(), dt.Rows[i]["patientname"].ToString(), dt.Rows[i]["age"].ToString()
                    , dt.Rows[i]["tests"].ToString(), dt.Rows[i]["ContactNo"].ToString());
            }           
        }
        void FillForm1()
        {
            string IsDateAll = rdbAll.Checked ? "1" : "0";
            string Status = cmbStatus.SelectedIndex == 0 ? "nvl(sentstatus,'0')" : cmbStatus.SelectedIndex == 1 ? "1" : "0";
            string sql = "SELECT case when sentstatus = '1' then 'Sent' else 'Not Sent' end   status , receiptno, io, vdate, patientname,age, wm_concat(title) tests,contactno FROM  vu_MasterReg where fktestid IN (SELECT id FROM test WHERE location = 'ESSA') and  (trunc(vdate) between '" + dtpFDate.Value.ToString("dd-MMM-yyyy") + "' and '" + dtpTDate.Value.ToString("dd-MMM-yyyy") + "' or 1 = " + IsDateAll + ") and nvl(sentstatus,0) = " + Status + " and io='"+cmbIOstatus.Text+"'GROUP BY sentstatus, receiptno, io, vdate, patientname, age,contactno order by to_number(receiptno) desc";
            DataTable dt = Query.getData(sql);
            dgvExpenses.Rows.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgvExpenses.Rows.Add(false, dt.Rows[i]["status"].ToString(), dt.Rows[i]["receiptno"].ToString(), dt.Rows[i]["io"].ToString(), dt.Rows[i]["vdate"].ToString(), dt.Rows[i]["patientname"].ToString(), dt.Rows[i]["age"].ToString()
                    , dt.Rows[i]["tests"].ToString(), dt.Rows[i]["ContactNo"].ToString());
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            FillForm1();
        }

        private void frmMasterRegister_Load(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = 0;
            cmbIOstatus.SelectedIndex = 0;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            string Receipt = "";
            string[] a = (from DataGridViewRow dr in dgvExpenses.Rows
                          where (bool)dr.Cells[clnSelect.Index].Value == true
                          select "'" + dr.Cells[clnReceiptNo.Index].Value.ToString() + "'").ToArray();
            Receipt = string.Join(",", a);
            if (Receipt != "")
            {
                frmReportView frm = new frmReportView();
                ReportDocument rpt = new ReportDocument();
                DataTable dt = Query.getData("SELECT receiptno slipnumber,vdate reportdate,io IpdOpd,patientname,age,title testname,contactNo FROM vu_masterreg WHERE fktestid IN (SELECT id FROM test WHERE location = 'ESSA')  and  receiptno IN (" + Receipt + ") order by to_number(receiptno ) ");
                rpt = (ReportDocument)new Reports.CrpHdRgstrLocation();
                rpt.SetDataSource(dt);
                frm.rptViewer.ReportSource = rpt;
                frm.Show();
                //Query.Execute("update  labmasterreg set sentstatus = '1' WHERE fktestid IN (SELECT id FROM test WHERE location = 'ESSA') and  receiptno IN (" + Receipt + ") ");

                foreach (DataGridViewRow item in dgvExpenses.Rows)
                {
                    if ((bool)item.Cells[clnSelect.Index].Value == true)
                    {
                        DML.LabMasterReg_SentStatusChanged(item.Cells[clnReceiptNo.Index].Value.ToString(), "1");
                    }
                }
            }
        }
    }
}
