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
    public partial class frmMasterHead : Form
    {
        public frmMasterHead()
        {
            InitializeComponent();
            FillControls.FillcmbLabDepartment(cmbDepartment);
        }
        void FillForm()
        {
            string IsDateAll = rdbAll.Checked ? "1" : "0";
            string Status = cmbStatus.SelectedIndex == 0 ? "nvl(printstatus,'0')" : cmbStatus.SelectedIndex == 1 ? "1" : "0";

            string statusIO = cmbIOstatus.SelectedIndex == 0 ? "OPD" : "IPD";

            string DepartmentId = (string)cmbDepartment.SelectedValue;
            string sql = @"SELECT d.title,case when printstatus = '1' then 'Printed' else 'Not Printed' end   status , reg.receiptno, io, reg.receiptdate vdate, patientname, age, wm_concat(reg.testname) tests FROM  labmasterreg reg
                            left JOIN test t ON t.id = reg.fktestid 
                            left JOIN departments d ON d.id = t.testheadid  
                            where (trunc(receiptdate) between '" + dtpFDate.Value.ToString("dd-MMM-yyyy") + "' and '" + dtpTDate.Value.ToString("dd-MMM-yyyy") + "' or 1 = " + IsDateAll + ") and nvl(printstatus,'0') = " + Status +
                            " and  d.id = '" + DepartmentId + "' and io = '" + statusIO.ToString() + "' " +
                            " GROUP BY printstatus, receiptno, io, receiptdate, patientname, age,d.title  order by to_number(receiptno) desc";
            DataTable dt = Query.getData(sql);
            dgvExpenses.Rows.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgvExpenses.Rows.Add(false, dt.Rows[i]["status"].ToString(), dt.Rows[i]["receiptno"].ToString(), dt.Rows[i]["io"].ToString(), dt.Rows[i]["vdate"].ToString(), dt.Rows[i]["patientname"].ToString(), dt.Rows[i]["age"].ToString()
                    , dt.Rows[i]["tests"].ToString());
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FillForm();
        }

        private void frmMasterHead_Load(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = 2;
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

                    DataTable dt = Query.getData("SELECT receiptno slipnumber,patientname,age,testname,'' result FROM labmasterreg WHERE get_departmentidbytestid(fktestid) = '" + (string)cmbDepartment.SelectedValue + "' and  receiptno IN (" + Receipt + ")  and io = '" + cmbIOstatus.Text   + "'order by to_number(receiptno ) ");

                    if (true)
                    {
                        rpt = (string)cmbDepartment.SelectedValue == "3" ? (ReportDocument)new Reports.CrpHdRgstrHema() :
                            (string)cmbDepartment.SelectedValue == "6" || (string)cmbDepartment.SelectedValue == "10" ? (ReportDocument)new Reports.CrpHdRgstrUrine() :
                            (ReportDocument)new Reports.CrpHeadRegister1();

                    }

                    rpt.SetDataSource(dt);
                    rpt.SetParameterValue("pHeadName", cmbDepartment.Text);
                    rpt.SetParameterValue("pdateFrom", dtpFDate.Value);
                    rpt.SetParameterValue("pDateTo", dtpTDate.Value);
                    rpt.SetParameterValue("StatusIO", cmbIOstatus .Text );

                    
                    frm.rptViewer.ReportSource = rpt;

                    frm.Show();
                    Query.Execute("update  labmasterreg set printstatus = '1' WHERE get_departmentidbytestid(fktestid) = '" + (string)cmbDepartment.SelectedValue + "' and  receiptno IN (" + Receipt + ") and io = '" + cmbIOstatus .Text  + "' ");
            }
        }
    }
}
