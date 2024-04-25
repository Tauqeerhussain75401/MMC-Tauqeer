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
    public partial class InRecieptSearch : Form
    {
        bool FLogIn;
        public InRecieptSearch()
        {
            InitializeComponent();
            FLogIn = false;
         
            FillControls.FillcmbTest(cmbTest);
            FillControls.FillcmbIPDTestCatagory(cmbCategory);
            FillControls.FillcmbPatientCatagory(cmbType);
            FillControls.FillcmbMember(cmbMember);
            FillControls.FillcmbCunsultantINPrecieptSearch(cmbConsultant);
            FillControls.FillcmbUser(cmbUser);
            FillControls.FillReferenceIndex(cmbReference);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string DateRange = !rdbDateall.Checked ? " and trunc(receiptdate) between '" + dtpDateFrom.Value.ToDBFormat() + "' and '" + dtpDateTo.Value.ToDBFormat() + "'" : "";
            string OPDCatagory = !rdbCategoryAll.Checked ? " and testtypeid = '" + (string)cmbCategory.SelectedValue + "'" : "";
            string PatientType = !rdbTypeAll.Checked ? " and PatientType = '" + (string)cmbType.SelectedValue + "'" : "";
            string BMJMember = !rdbMemberAll.Checked ? " and bmjnewno = '" + cmbMember.SelectedValue.ToString() + "'" : "";
            string Gender = !rdbGenderAll.Checked ? " and gender = '" + cmbGender.Text + "'" : "";
            string Consultant = !rdbConsultantAll.Checked ? " and inp.consultantid = '" + (string)cmbConsultant.SelectedValue + "'" : "";
            string User = !rdbUserAll.Checked ? " and inp.createdby = '" + cmbUser.Text + "'" : "";
            string Reference = !rdbReferenceAll.Checked ? " and referenceid = '" + (string)cmbReference.SelectedValue + "'" : "";
            string CreateDateRange = !rdbCreadtedByDateAll.Checked ? " and trunc(inp.createdtime) between '" + dtpCreatedByDateFrom.Value.ToDBFormat() + "' and '" + dtpCreatedByDateTo.Value.ToDBFormat() + "'" : "";
            
            string ReceiptNo = txtReceipt.Text != "" ? " and receiptno = '" + txtReceipt.Text + "'" : "";
            string PatientName = txtPName.Text != "" ? " and lower(patientname) like '%" + txtPName.Text.ToLower() + "%'" : "";
            string ContactNo = txtConNo.Text != "" ? " and emergency LIKE '%" + txtConNo.Text + "%'" : "";

            FillDetail(new string[] { DateRange ,
                OPDCatagory,
                PatientType,BMJMember, Gender,Consultant,User,Reference,CreateDateRange ,ReceiptNo,PatientName,ContactNo
            });
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DataTable dtQuery;
        void FillDetail(string[] filter)
        {
            dtQuery = Query.IPDReceiptQuery(filter);
            dgvQuery.AutoGenerateColumns = false;
            dgvQuery.DataSource = dtQuery;
            
            dgvQuery.Columns[clnVoucherNum.Index].DataPropertyName = "receiptno";
            dgvQuery.Columns[clnDate.Index].DataPropertyName = "receiptdate";
            dgvQuery.Columns[clnOPDCatagory.Index].DataPropertyName = "CatagoryTitle";
            dgvQuery.Columns[clnTest.Index].DataPropertyName = "test";
            dgvQuery.Columns[clnConsultant.Index].DataPropertyName = "ConsultantName";
            dgvQuery.Columns[clnPatientType.Index].DataPropertyName = "patienttype";
            dgvQuery.Columns[clnPatientName.Index].DataPropertyName = "patientname";
            dgvQuery.Columns[clnAmount.Index].DataPropertyName = "charges";
            dgvQuery.Columns[ClnCreatedby.Index].DataPropertyName = "createdby";
            dgvQuery.Columns[clnEditby.Index].DataPropertyName = "editby";
            dgvQuery.Columns[clnserialno.Index].DataPropertyName = "serialno";
        }

        private void InRecieptSearch_Load(object sender, EventArgs e)
        {
            if (UserInfo.UserLevel == "Laboratory")
            {
                cmbCategory.SelectedValue = "2";
                rdbCategoryIndi.Checked = true;
                rdbCategoryAll.Enabled = false;
                cmbCategory.Enabled = false;
                rdbCategoryIndi.Enabled = false;


            }
            else if (UserInfo.UserLevel == "Ultrasound")
            {
                cmbCategory.SelectedValue = "5";
                rdbCategoryIndi.Checked = true;
                rdbCategoryAll.Enabled = false;
                cmbCategory.Enabled = false;
                rdbCategoryIndi.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
                groupBox5.Enabled = false;
            }
            dtpDateFrom.Value = DateTime.Now;
            dtpDateTo.Value = DateTime.Now;
            dtpCreatedByDateFrom.Value = DateTime.Now;
            dtpCreatedByDateTo.Value = DateTime.Now;

        }

        private void rdbDateall_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDateall.Checked)
            {
                dtpDateFrom.Enabled = false;
                dtpDateTo.Enabled = false;
            }
            else
            {
                dtpDateFrom.Enabled = true;
                dtpDateTo.Enabled = true;
            }
        }

        private void rdbCategoryAll_CheckedChanged(object sender, EventArgs e)
        {
            FLogIn = true;
            if (rdbCategoryAll.Checked)
            {
                cmbCategory.Enabled = false;
                cmbCategory.Text = "";
                rdbTestAll.Checked = true;
            }
            else
            { cmbCategory.Enabled = true; }
        }

        private void rdbTypeAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTypeAll.Checked) cmbType.Enabled = false; else cmbType.Enabled = true;
        }

        private void rdbMemberAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMemberAll.Checked) cmbMember.Enabled = false; else cmbMember.Enabled = true;
        }

        private void rdbGenderAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbGenderAll.Checked) cmbGender.Enabled = false; else cmbGender.Enabled = true;
        }

        private void rdbConsultantAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbConsultantAll.Checked) cmbConsultant.Enabled = false; else cmbConsultant.Enabled = true;
        }

        private void rdbTestAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTestAll.Checked)
            {
                cmbTest.Enabled = false;
                cmbTest.Text = "";

            }
            else
            {
                cmbTest.Enabled = true;

                if (rdbCategoryAll.Checked == true)
                {
                    rdbTestAll.Checked = true;
                }

            }
        }

        private void rdbUserAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbUserAll.Checked) cmbUser.Enabled = false; else cmbUser.Enabled = true;
        }

        private void rdbReferenceAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbReferenceAll.Checked) cmbReference.Enabled = false; else cmbReference.Enabled = true;
        }

        private void rdbCreadtedByDateAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCreadtedByDateAll.Checked)
            {
                dtpCreatedByDateFrom.Enabled = false;
                dtpCreatedByDateTo.Enabled = false;
            }
            else
            {
                dtpCreatedByDateFrom.Enabled = true;
                dtpCreatedByDateTo.Enabled = true;
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FLogIn == true)
            {
                FillControls.FillcmbTestID(cmbTest, cmbCategory.SelectedValue.ToString());
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Reports.InPatientSearchReport rpt = new Reports.InPatientSearchReport();
            rpt.SetDataSource(dtQuery);
            rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
            frmReportView frm = new frmReportView();
            frm.rptViewer.ReportSource = rpt;
            frm.Show();
        }

        private void btnAllReceipt_Click(object sender, EventArgs e)
        {
            if (UserInfo.UserLevel == "Admin")
            {
                var distinct = dgvQuery.Rows.Cast<DataGridViewRow>()
                           .Select(x => x.Cells[clnVoucherNum.Index].Value.ToString())
                           .Distinct()
                           .ToList();
                for (int i = 0; i < distinct.Count; i++)
                {
                    Print(distinct[i].ToString(),dgvQuery.Rows.Cast<DataGridViewRow>()
                           .Where(x => x.Cells[clnVoucherNum.Index].Value ==distinct[i].ToString()) //..or or both
                           .Select(x => x.Cells[clnserialno.Index].Value.ToString())
                           .FirstOrDefault()
                         );
                }
            }
        }

        private void dgvQuery_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void InRecieptSearch_Load_1(object sender, EventArgs e)
        {

        }
        private bool Print(string voucher,string serialno)
        {
            // bool IsPrinted = false;
            try
            {
                if (voucher != "")
                {
                    Reports.IPDReceipt rpt = new Reports.IPDReceipt();
                    DataTable dt = Query.getData("Select regnoalpha||'-'||regnonumeric as fileno,ad.* from admissioninfo ad where serialno='" + serialno + "'");

                    DataTable dtTest = Query.getData("Select get_opdcatagory(testtypeid) as catagory,isprinted,charges as amount,get_testtitle(testid) as testname,receiptdate,get_consultantname(consultantid) as consultantid from inptestcharges where serialno='" + serialno + "'  and receiptno = '" + voucher + "' and status = 0 ");
                    rpt.SetDataSource(dtTest);
                    
                    rpt.SetParameterValue("@CompanyName", CompanyInfo.CompanyName);
                    rpt.SetParameterValue("@Contact", CompanyInfo.Cell);
                    rpt.SetParameterValue("@Address", CompanyInfo.Address);
                    rpt.SetParameterValue("@Catagory", dtTest.Rows[0]["catagory"].ToString());
                    rpt.SetParameterValue("@ReceiptNo", voucher);
                    rpt.SetParameterValue("@Date", ((DateTime)dtTest.Rows[0]["receiptdate"]).ToString());
                    rpt.SetParameterValue("@Patient", dt.Rows[0]["patientname"].ToString());
                    rpt.SetParameterValue("@Gender", dt.Rows[0]["gender"].ToString());
                    rpt.SetParameterValue("@Consultant", dtTest.Rows[0]["consultantid"].ToString());
                    rpt.SetParameterValue("@User", UserInfo.UserId);
                    rpt.SetParameterValue("@NetAmount", dtTest.Rows[0]["amount"].ToString());
                    rpt.SetParameterValue("@Age", dt.Rows[0]["age"].ToString());
                    rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                    rpt.SetParameterValue("@SlipNumber", dt.Rows[0]["fileno"].ToString());
                    
                    if (UserInfo.UserLevel != "Admin")
                    {
                        if (dtTest.Rows[0]["isprinted"].ToString() == "1")
                        {
                            MessageBox.Show("Receipt Already Printed...!");
                        }
                        else
                        {
                            //rpt.PrintOptions.PrinterName = ConfigInfo.PrinterName;
                            //rpt.PrintToPrinter(1, true, 0, 0);
                            rpt.PrintToPrinter(1, false, 1, 9999);
                            DataTable dt5 = Query.getData("update inptestcharges set isprinted='1' where serialno='" + serialno + "'");
                        }
                    }
                    else
                    {
                        //frmReportView frm = new frmReportView();
                        //frm.rptViewer.ReportSource = rpt;
                        //frm.Show();
                        rpt.PrintOptions.PrinterName = ConfigInfo.PrinterName;
                        rpt.PrintToPrinter(1, true, 0, 0);
                    }
                    
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

    }
}
