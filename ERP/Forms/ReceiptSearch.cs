using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERP
{
    public partial class ReceiptSearch : Form
    {
        bool FLogIn;
        public ReceiptSearch()
        {
            InitializeComponent();
            FLogIn = false;
            FillControls.FillcmbTest(cmbTest);
            FillControls.FillcmbTestCatagory(cmbCategory);
            FillControls.FillcmbPatientCatagory(cmbType);
            FillControls.FillcmbMember(cmbMember);
            FillControls.FillcmbCunsultantINPrecieptSearch(cmbConsultant);
            FillControls.FillcmbUser(cmbUser);
            FillControls.FillReferenceIndex(cmbReference);

        }

        DataTable dtQuery;
        void FillDetail(string[] filter)
        {
            dtQuery = Query.OPDReceiptQuery(filter);
            dgvQuery.AutoGenerateColumns = false;
            dgvQuery.DataSource = dtQuery;
            dgvQuery.Columns[clnTokenNo.Index].DataPropertyName = "tokenno";
            dgvQuery.Columns[clnVoucherNum.Index].DataPropertyName = "receiptno";
            dgvQuery.Columns[clnDate.Index].DataPropertyName = "vdate";
            dgvQuery.Columns[clnOPDCatagory.Index].DataPropertyName = "CatagoryTitle";
            dgvQuery.Columns[clnConsultant.Index].DataPropertyName = "ConsultantName";
            dgvQuery.Columns[clnPatientType.Index].DataPropertyName = "patienttype";
            dgvQuery.Columns[clnPatientName.Index].DataPropertyName = "patientname";
            dgvQuery.Columns[clnAmount.Index].DataPropertyName = "grossamount";
            dgvQuery.Columns[ClnCreatedby.Index].DataPropertyName = "createdby";
            dgvQuery.Columns[clnEditby.Index].DataPropertyName = "editby";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string DateRange = !rdbDateall.Checked ? " and trunc(pr.Vdate) between '" + dtpDateFrom.Value.ToDBFormat() + "' and '" + dtpDateTo.Value.ToDBFormat() + "'" : "";
            string OPDCatagory = !rdbCategoryAll.Checked ? " and catagoryid = '" + (string)cmbCategory.SelectedValue + "'" : "";
            string PatientType = !rdbTypeAll.Checked ? " and PatientType = '" + (string)cmbType.SelectedValue + "'" : "";
            string BMJMember = !rdbMemberAll.Checked ? " and memberid = '" + cmbMember.SelectedValue.ToString() + "'" : "";
            string Gender = !rdbGenderAll.Checked ? " and gender = '" + cmbGender.Text + "'" : "";
            string Consultant = !rdbConsultantAll.Checked ? " and consultantid = '" + (string)cmbConsultant.SelectedValue + "'" : "";
            string User = !rdbUserAll.Checked ? " and pr.createdby = '" + cmbUser.Text + "'" : "";
            string Reference = !rdbReferenceAll.Checked ? " and referenceid = '" + (string)cmbReference.SelectedValue + "'" : "";
            string CreateDateRange = !rdbCreadtedByDateAll.Checked ? " and trunc(createdtime) between '" + dtpCreatedByDateFrom.Value.ToDBFormat() + "' and '" + dtpCreatedByDateTo.Value.ToDBFormat() + "'" : "";
            string Token = txtToken.Text != "" ? " and tokenno = '" + txtToken.Text + "'" : "";
            string ReceiptNo = txtReceipt.Text != "" ? " and receiptno = '" + txtReceipt.Text + "'" : "";
            string PatientName = txtPName.Text != "" ? " and lower(patientname) like '%" + txtPName.Text.ToLower() + "%'" : "";
            string ContactNo = txtConNo.Text != "" ? " and contactno LIKE '%" + txtConNo.Text + "%'" : "";

            FillDetail(new string[] { DateRange ,
                OPDCatagory,
                PatientType,BMJMember, Gender,Consultant,User,Reference,CreateDateRange ,Token,ReceiptNo,PatientName,ContactNo
            });
        }

        private void ReceiptSearch_Load(object sender, EventArgs e)
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

        private void rdbTypeAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTypeAll.Checked) cmbType.Enabled = false; else cmbType.Enabled = true;
        }

        private void rdbConsultantAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbConsultantAll.Checked) cmbConsultant.Enabled = false; else cmbConsultant.Enabled = true;
        }

        private void rdbUserAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbUserAll.Checked) cmbUser.Enabled = false; else cmbUser.Enabled = true;
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

        private void rdbReferenceAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbReferenceAll.Checked) cmbReference.Enabled = false; else cmbReference.Enabled = true;
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

        private void rdbMemberAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMemberAll.Checked) cmbMember.Enabled = false; else cmbMember.Enabled = true;
        }

        private void rdbGenderAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbGenderAll.Checked) cmbGender.Enabled = false; else cmbGender.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Reports.PatientReceipt rpt = new Reports.PatientReceipt();
            rpt.SetDataSource(dtQuery);
            rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
            frmReportView frm = new frmReportView();
            frm.rptViewer.ReportSource = rpt;
            frm.Show();
        }

        private bool Print(string voucher)
        {
            // bool IsPrinted = false;
            try
            {
                if (voucher != "")
                {
                    DataTable dt = ReportQuery.OPDReceipt(voucher);
                    if (dt.Rows[0]["ReportType"].ToString() != "CARD")
                    {
                        Reports.OPDReceipt rpt = new Reports.OPDReceipt();

                        DataTable dtTest = ReportQuery.OPDTestReceipt(voucher);
                        rpt.SetDataSource(dtTest);

                        string VoucherNo = "OP-" + voucher;
                        string QRimagePath = Application.StartupPath + "\\QRCode.jpeg";
                        DataTable dtQRcode = Query.GenerateQRCode(VoucherNo, QRimagePath);
                        //rpt.SetDataSource(dtQRcode);

                        rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                        rpt.SetParameterValue("@Contact", CompanyInfo.ContactHead);
                        rpt.SetParameterValue("@Address", CompanyInfo.Address);
                        rpt.SetParameterValue("@Catagory", dt.Rows[0]["CatagoryTitle"].ToString());
                        rpt.SetParameterValue("@ReceiptNo", "OP-" + voucher);
                        rpt.SetParameterValue("@Date", (DateTime)dt.Rows[0]["Vdate"]);
                        rpt.SetParameterValue("@Patient", dt.Rows[0]["patientName"].ToString());
                        rpt.SetParameterValue("@Gender", dt.Rows[0]["Gender"].ToString());
                        rpt.SetParameterValue("@Consultant", dt.Rows[0]["ConsultantName"].ToString());
                        rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                        rpt.SetParameterValue("@User", UserInfo.UserName);
                        rpt.SetParameterValue("@Discount", dt.Rows[0]["Discount"].ToString());
                        rpt.SetParameterValue("@Remarks", dt.Rows[0]["Remarks"].ToString());
                        rpt.SetParameterValue("@GrossAmount", dt.Rows[0]["GrossAmount"].ToString());
                        decimal NetAmouunt = Convert.ToDecimal(dt.Rows[0]["NetAmount"].ToString());
                        decimal kECharges = Convert.ToDecimal(dt.Rows[0]["electricitycharges"].ToString());
                        decimal Total = NetAmouunt + kECharges;
                        rpt.SetParameterValue("@NetAmount", NetAmouunt);
                        rpt.SetParameterValue("@electricitycharges", dt.Rows[0]["electricitycharges"].ToString());
                        rpt.SetParameterValue("@DiscountName", dt.Rows[0]["patientType"].ToString());
                        rpt.SetParameterValue("@ReferenceName", dt.Rows[0]["ReferenceName"].ToString());
                        rpt.SetParameterValue("@MemberId", dt.Rows[0]["memberid"].ToString());
                        rpt.SetParameterValue("@TokenNo", dt.Rows[0]["TokenNo"].ToString());
                        rpt.SetParameterValue("@Age", dt.Rows[0]["Age"].ToString());
                        rpt.SetParameterValue("@CreatedBY", dt.Rows[0]["createdby"].ToString());
                        rpt.SetParameterValue("@partialName", "Partial Payment");
                        rpt.SetParameterValue("@Partial", dt.Rows[0]["netbalance"].ToString());
                        rpt.SetParameterValue("@Createdtime", (DateTime)dt.Rows[0]["createdtime"]);
                        rpt.SetParameterValue("@PrintedBy", UserInfo.UserId);
                        rpt.SetParameterValue("@terminal", SoftwareInfo.Terminal);

                        if (dt.Rows[0]["Discount"].ToString() == "0") rpt.ReportFooterSection3.SectionFormat.EnableSuppress = true;
                        if (dt.Rows[0]["ReferenceName"].ToString() == "") rpt.ReportFooterSection5.SectionFormat.EnableSuppress = true;
                        if (dt.Rows[0]["memberid"].ToString() == "") rpt.ReportFooterSection6.SectionFormat.EnableSuppress = true;
                        if (dt.Rows[0]["tokenNo"].ToString() == "0") rpt.ReportFooterSection7.SectionFormat.EnableSuppress = true;
                        rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                        rpt.PrintOptions.PrinterName = ConfigInfo.PrinterName;
                        rpt.PrintToPrinter(1, true, 1, 9999);
                        //if (UserInfo.UserLevel == "Admin")
                        //{
                        //    frmReportView frm = new frmReportView();
                        //    frm.rptViewer.ReportSource = rpt;
                        //    frm.Show();
                        //}
                        //else
                        //{
                        //    rpt.PrintToPrinter(1, true, 1, 9999);
                        //}



                        //Reports.OPDReceipt rpt = new Reports.OPDReceipt();

                        //DataTable dtTest = ReportQuery.OPDTestReceipt(voucher);
                        //rpt.SetDataSource(dtTest);

                        //rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                        //rpt.SetParameterValue("@Contact", CompanyInfo.ContactHead);
                        //rpt.SetParameterValue("@Address", CompanyInfo.Address);
                        //rpt.SetParameterValue("@Catagory", dt.Rows[0]["CatagoryTitle"].ToString());
                        //rpt.SetParameterValue("@ReceiptNo", "OP-" + voucher);
                        //rpt.SetParameterValue("@Date", (DateTime)dt.Rows[0]["Vdate"]);
                        //rpt.SetParameterValue("@Patient", dt.Rows[0]["patientName"].ToString());
                        //rpt.SetParameterValue("@Gender", dt.Rows[0]["Gender"].ToString());
                        //rpt.SetParameterValue("@Consultant", dt.Rows[0]["ConsultantName"].ToString());
                        //rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                        //rpt.SetParameterValue("@User", UserInfo.UserName);
                        //rpt.SetParameterValue("@Discount", dt.Rows[0]["Discount"].ToString());
                        //rpt.SetParameterValue("@Remarks", dt.Rows[0]["Remarks"].ToString());
                        //rpt.SetParameterValue("@GrossAmount", dt.Rows[0]["GrossAmount"].ToString());
                        //rpt.SetParameterValue("@NetAmount", dt.Rows[0]["NetAmount"].ToString());
                        //rpt.SetParameterValue("@DiscountName", dt.Rows[0]["patientType"].ToString());
                        //rpt.SetParameterValue("@ReferenceName", dt.Rows[0]["ReferenceName"].ToString());
                        //rpt.SetParameterValue("@MemberId", dt.Rows[0]["memberid"].ToString());
                        //rpt.SetParameterValue("@TokenNo", dt.Rows[0]["TokenNo"].ToString());
                        //rpt.SetParameterValue("@Age", dt.Rows[0]["Age"].ToString());
                        //rpt.SetParameterValue("@CreatedBY", dt.Rows[0]["createdby"].ToString());
                        //rpt.SetParameterValue("@Createdtime", (DateTime)dt.Rows[0]["createdtime"]);
                        //rpt.SetParameterValue("@PrintedBy", UserInfo.UserId);
                        //rpt.SetParameterValue("@terminal", SoftwareInfo.Terminal);

                        //if (dt.Rows[0]["Discount"].ToString() == "0") rpt.ReportFooterSection3.SectionFormat.EnableSuppress = true;
                        //if (dt.Rows[0]["ReferenceName"].ToString() == "") rpt.ReportFooterSection5.SectionFormat.EnableSuppress = true;
                        //if (dt.Rows[0]["memberid"].ToString() == "") rpt.ReportFooterSection6.SectionFormat.EnableSuppress = true;
                        //if (dt.Rows[0]["tokenNo"].ToString() == "0") rpt.ReportFooterSection7.SectionFormat.EnableSuppress = true;
                        //rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                        //rpt.PrintOptions.PrinterName = ConfigInfo.PrinterName;
                        //rpt.PrintToPrinter(1, true, 1, 9999);

                    }
                    else
                    {
                        Reports.OPDCard rpt = new Reports.OPDCard();

                        string VoucherNo = "OP-" + voucher;
                        string QRimagePath = Application.StartupPath + "\\QRCode.jpeg";
                        DataTable dtQRcode = Query.GenerateQRCode(VoucherNo, QRimagePath);
                        rpt.SetDataSource(dtQRcode);

                        rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                        rpt.SetParameterValue("@Contact", CompanyInfo.ContactHead);
                        rpt.SetParameterValue("@Address", CompanyInfo.Address);
                        rpt.SetParameterValue("@Catagory", dt.Rows[0]["CatagoryTitle"].ToString());
                        rpt.SetParameterValue("@ReceiptNo", "OP-" + voucher);
                        rpt.SetParameterValue("@Date", (DateTime)dt.Rows[0]["Vdate"]);
                        rpt.SetParameterValue("@Patient", dt.Rows[0]["patientName"].ToString());
                        rpt.SetParameterValue("@Gender", dt.Rows[0]["Gender"].ToString());
                        rpt.SetParameterValue("@Consultant", dt.Rows[0]["ConsultantName"].ToString());
                        rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                        rpt.SetParameterValue("@User", UserInfo.UserName);
                        rpt.SetParameterValue("@Discount", dt.Rows[0]["Discount"].ToString());
                        rpt.SetParameterValue("@Remarks", dt.Rows[0]["Remarks"].ToString());
                        rpt.SetParameterValue("@GrossAmount", dt.Rows[0]["GrossAmount"].ToString());
                        rpt.SetParameterValue("@NetAmount", dt.Rows[0]["NetAmount"].ToString());
                        rpt.SetParameterValue("@DiscountName", dt.Rows[0]["patientType"].ToString() == "PUBLIC" ? "" : dt.Rows[0]["patientType"].ToString());
                        rpt.SetParameterValue("@ReferenceName", dt.Rows[0]["ReferenceName"].ToString());
                        rpt.SetParameterValue("@MemberId", dt.Rows[0]["memberid"].ToString());
                        rpt.SetParameterValue("@TokenNo", dt.Rows[0]["TokenNo"].ToString());
                        rpt.SetParameterValue("@Age", dt.Rows[0]["Age"].ToString());
                        rpt.SetParameterValue("@CreatedBY", dt.Rows[0]["createdby"].ToString());
                        rpt.SetParameterValue("@Createdtime", (DateTime)dt.Rows[0]["createdtime"]);
                        rpt.SetParameterValue("@PrintedBy", UserInfo.UserId);
                        rpt.SetParameterValue("@terminal", SoftwareInfo.Terminal);

                        if (dt.Rows[0]["Discount"].ToString() == "0") rpt.ReportFooterSection3.SectionFormat.EnableSuppress = true;
                        if (dt.Rows[0]["ReferenceName"].ToString() == "") rpt.ReportFooterSection5.SectionFormat.EnableSuppress = true;
                        if (dt.Rows[0]["memberid"].ToString() == "") rpt.ReportFooterSection6.SectionFormat.EnableSuppress = true;
                        if (dt.Rows[0]["tokenNo"].ToString() == "0") rpt.ReportFooterSection7.SectionFormat.EnableSuppress = true;
                        // rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                        rpt.PrintOptions.PrinterName = ConfigInfo.PrinterName;
                        rpt.PrintToPrinter(1, true, 1, 9999);
                        //if (UserInfo.UserLevel == "Admin")
                        //{
                        //    frmReportView frm = new frmReportView();
                        //    frm.rptViewer.ReportSource = rpt;
                        //    frm.Show();
                        //}
                        //else
                        //{
                        //    rpt.PrintToPrinter(1, true, 1, 9999);
                        //}
                    }

                    //frm.rptViewer.ReportSource = rpt;
                    //frm.Show();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void btnAllReceipt_Click(object sender, EventArgs e)
        {
            if (UserInfo.UserLevel == "Admin")
            {
                for (int i = 0; i < dgvQuery.Rows.Count; i++)
                {
                    PrintNew(dgvQuery.Rows[i].Cells[clnVoucherNum.Index].Value.ToString());
                }
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FLogIn == true)
            {
                FillControls.FillcmbTestID(cmbTest, cmbCategory.SelectedValue.ToString());
            }

        }

        private void cmbCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (FLogIn == true)
            //{
            //    FillControls.FillcmbCatagoryTest(cmbTest, cmbCategory.SelectedValue.ToString());
            //}

        }

        private void dgvQuery_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private bool PrintNew(string voucher)
        {
            bool IsPrinted = false;
            try
            {
                if (voucher != "")
                {
                    DataTable dt = ReportQuery.OPDReceipt(voucher);
                    if (dt.Rows[0]["ReportType"].ToString() != "CARD")
                    {
                        
                        string category = dt.Rows[0]["CatagoryTitle"].ToString();
                        if (category == "Laboratory")
                        {
                            PrintHussainiLaboratory(voucher, dt);
                            return true;
                        }

                        Reports.OPDReceipt rpt = new Reports.OPDReceipt();
                        DataTable dtTest = ReportQuery.OPDTestReceipt(voucher);
                        dtTest.Columns.Add("QRcode", typeof(byte[]));


                        //  string VoucherNo = "OP-" + voucher;
                        // string QRimagePath = Application.StartupPath + "\\QRCode.jpeg";
                        //  DataTable dtQRcode = Query.GenerateQRCode(VoucherNo, QRimagePath);
                        // foreach (DataRow dr2 in dtTest.Rows)
                        // {
                        // dr2["QRcode"] = (byte[])dtQRcode.Rows[0]["Qrcode"];
                        //}



                        rpt.SetDataSource(dtTest);
                        rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                        rpt.SetParameterValue("@Contact", CompanyInfo.ContactHead);
                        rpt.SetParameterValue("@Address", CompanyInfo.Address);
                        rpt.SetParameterValue("@Catagory", dt.Rows[0]["CatagoryTitle"].ToString());
                        rpt.SetParameterValue("@ReceiptNo", "OP-" + voucher);
                        rpt.SetParameterValue("@Date", (DateTime)dt.Rows[0]["Vdate"]);
                        rpt.SetParameterValue("@Patient", dt.Rows[0]["patientName"].ToString());
                        rpt.SetParameterValue("@Gender", dt.Rows[0]["Gender"].ToString());
                        rpt.SetParameterValue("@Consultant", dt.Rows[0]["ConsultantName"].ToString());
                        rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                        rpt.SetParameterValue("@User", UserInfo.UserName);
                        rpt.SetParameterValue("@Discount", dt.Rows[0]["Discount"].ToString());
                        rpt.SetParameterValue("@Remarks", dt.Rows[0]["Remarks"].ToString());
                        rpt.SetParameterValue("@GrossAmount", dt.Rows[0]["GrossAmount"].ToString());
                        decimal NetAmouunt = Convert.ToDecimal(dt.Rows[0]["NetAmount"].ToString());
                        decimal kECharges = Convert.ToDecimal(dt.Rows[0]["electricitycharges"].ToString());
                        decimal Total = NetAmouunt + kECharges;
                        rpt.SetParameterValue("@NetAmount", NetAmouunt);
                        rpt.SetParameterValue("@electricitycharges", dt.Rows[0]["electricitycharges"].ToString());
                        rpt.SetParameterValue("@DiscountName", dt.Rows[0]["patientType"].ToString());
                        rpt.SetParameterValue("@ReferenceName", dt.Rows[0]["ReferenceName"].ToString());
                        rpt.SetParameterValue("@MemberId", dt.Rows[0]["memberid"].ToString());
                        rpt.SetParameterValue("@TokenNo", dt.Rows[0]["TokenNo"].ToString());
                        rpt.SetParameterValue("@Age", dt.Rows[0]["Age"].ToString());
                        rpt.SetParameterValue("@CreatedBY", dt.Rows[0]["createdby"].ToString());
                        rpt.SetParameterValue("@partialName", "Partial Payment");
                        rpt.SetParameterValue("@Partial", dt.Rows[0]["netbalance"].ToString());
                        rpt.SetParameterValue("@Createdtime", (DateTime)dt.Rows[0]["createdtime"]);
                        rpt.SetParameterValue("@PrintedBy", UserInfo.UserId);
                        rpt.SetParameterValue("@terminal", SoftwareInfo.Terminal);
                        rpt.SetParameterValue("@urcompanyname", CompanyInfo.UrCompanyName);
                        rpt.SetParameterValue("@phoneNo", dt.Rows[0]["contactno"].ToString());
                        rpt.ReportFooterSection7.SectionFormat.EnableUnderlaySection = true;
                        if (dt.Rows[0]["Discount"].ToString() == "0") rpt.ReportFooterSection3.SectionFormat.EnableSuppress = true;
                        if (dt.Rows[0]["electricitycharges"].ToString() == "0") rpt.ReportFooterSection20.SectionFormat.EnableSuppress = true;
                        if (dt.Rows[0]["ispartial"].ToString() == "0") rpt.ReportFooterSection12.SectionFormat.EnableSuppress = true;
                        if (dt.Rows[0]["ReferenceName"].ToString() == "") rpt.ReportFooterSection5.SectionFormat.EnableSuppress = true;
                        if (dt.Rows[0]["memberid"].ToString() == "")
                        {
                            rpt.ReportFooterSection6.SectionFormat.EnableSuppress = true;
                            rpt.ReportFooterSection7.SectionFormat.EnableUnderlaySection = false;
                        }
                        if (dt.Rows[0]["tokenNo"].ToString() == "0") rpt.ReportFooterSection7.SectionFormat.EnableSuppress = true;
                        rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                        rpt.PrintToPrinter(1, true, 1, 9999);
                        //if (UserInfo.UserLevel == "Admin")
                        //{
                        //    frmReportView frm = new frmReportView();
                        //    frm.rptViewer.ReportSource = rpt;
                        //    frm.Show();
                        //}
                        //else
                        //{
                        //    rpt.PrintToPrinter(1, true, 1, 9999);
                        //    Query.Execute("update opdreceipt set noofprint = nvl(noofprint,0) + 1 where receiptno = '" + voucher + "'");
                        //}
                    }
                    else
                    {
                        Reports.OPDCard rpt = new Reports.OPDCard();
                        rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                        rpt.SetParameterValue("@Contact", CompanyInfo.ContactHead);
                        rpt.SetParameterValue("@Address", CompanyInfo.Address);
                        rpt.SetParameterValue("@Catagory", dt.Rows[0]["CatagoryTitle"].ToString());
                        rpt.SetParameterValue("@ReceiptNo", "OP-" + voucher);
                        rpt.SetParameterValue("@Date", (DateTime)dt.Rows[0]["Vdate"]);
                        rpt.SetParameterValue("@Patient", dt.Rows[0]["patientName"].ToString());
                        rpt.SetParameterValue("@Gender", dt.Rows[0]["Gender"].ToString());
                        rpt.SetParameterValue("@Consultant", dt.Rows[0]["ConsultantName"].ToString());
                        rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                        rpt.SetParameterValue("@User", dt.Rows[0]["createdby"].ToString());
                        rpt.SetParameterValue("@Discount", dt.Rows[0]["Discount"].ToString());
                        rpt.SetParameterValue("@Remarks", dt.Rows[0]["Remarks"].ToString());
                        rpt.SetParameterValue("@GrossAmount", dt.Rows[0]["GrossAmount"].ToString());
                        rpt.SetParameterValue("@NetAmount", dt.Rows[0]["NetAmount"].ToString());
                        rpt.SetParameterValue("@DiscountName", dt.Rows[0]["patientType"].ToString() == "PUBLIC" ? "" : dt.Rows[0]["patientType"].ToString());
                        rpt.SetParameterValue("@ReferenceName", dt.Rows[0]["ReferenceName"].ToString());
                        rpt.SetParameterValue("@MemberId", dt.Rows[0]["memberid"].ToString());
                        rpt.SetParameterValue("@TokenNo", dt.Rows[0]["TokenNo"].ToString());
                        rpt.SetParameterValue("@Age", dt.Rows[0]["Age"].ToString());
                        rpt.SetParameterValue("@CreatedBY", dt.Rows[0]["createdby"].ToString());
                        rpt.SetParameterValue("@Createdtime", (DateTime)dt.Rows[0]["createdtime"]);
                        rpt.SetParameterValue("@PrintedBy", UserInfo.UserId);
                        rpt.SetParameterValue("@terminal", SoftwareInfo.Terminal);
                        rpt.SetParameterValue("@urcompanyname", CompanyInfo.UrCompanyName);
                        rpt.SetParameterValue("@phoneNo", dt.Rows[0]["contactno"].ToString());
                        if (dt.Rows[0]["Discount"].ToString() == "0") rpt.ReportFooterSection3.SectionFormat.EnableSuppress = true;
                        if (dt.Rows[0]["ReferenceName"].ToString() == "") rpt.ReportFooterSection5.SectionFormat.EnableSuppress = true;
                        if (dt.Rows[0]["memberid"].ToString() == "")
                        {
                            rpt.ReportFooterSection6.SectionFormat.EnableSuppress = true;
                        }
                        else
                        {
                            rpt.ReportFooterSection1.SectionFormat.EnableUnderlaySection = true;
                        }
                        if (dt.Rows[0]["tokenNo"].ToString() == "0") rpt.ReportFooterSection7.SectionFormat.EnableSuppress = true;
                        rpt.PrintToPrinter(1, true, 1, 9999);
                        //if (UserInfo.UserLevel == "Admin")
                        //{
                        //    frmReportView frm = new frmReportView();
                        //    frm.rptViewer.ReportSource = rpt;
                        //    frm.Show();
                        //}
                        //else
                        //{
                        //    rpt.PrintToPrinter(1, true, 1, 9999);
                        //    Query.Execute("update opdreceipt set noofprint = nvl(noofprint,0) + 1 where receiptno = '" + voucher + "'");
                        //}

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

        void PrintHussainiLaboratory(string voucher, DataTable dt)
        {
            Reports.OPDReceipt_Laboratory rpt = new Reports.OPDReceipt_Laboratory();
            DataTable dtTest = ReportQuery.OPDTestReceipt(voucher);
            dtTest.Columns.Add("QRcode", typeof(byte[]));


            // string VoucherNo = "OP-" + voucher;
            // string QRimagePath = Application.StartupPath + "\\QRCode.jpeg";
            //  DataTable dtQRcode = Query.GenerateQRCode(VoucherNo, QRimagePath);

            rpt.SetDataSource(dtTest);
            rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
            rpt.SetParameterValue("@Contact", CompanyInfo.ContactHead);
            rpt.SetParameterValue("@Address", CompanyInfo.Address);
            rpt.SetParameterValue("@Catagory", dt.Rows[0]["CatagoryTitle"].ToString());
            rpt.SetParameterValue("@ReceiptNo", "OP-" + voucher);
            rpt.SetParameterValue("@Date", (DateTime)dt.Rows[0]["Vdate"]);
            rpt.SetParameterValue("@Patient", dt.Rows[0]["patientName"].ToString());
            rpt.SetParameterValue("@Gender", dt.Rows[0]["Gender"].ToString());
            rpt.SetParameterValue("@Consultant", dt.Rows[0]["laboratoryConsultantName"].ToString());
            rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
            rpt.SetParameterValue("@User", UserInfo.UserName);
            rpt.SetParameterValue("@Discount", dt.Rows[0]["Discount"].ToString());
            rpt.SetParameterValue("@Remarks", dt.Rows[0]["Remarks"].ToString());
            rpt.SetParameterValue("@GrossAmount", dt.Rows[0]["GrossAmount"].ToString());
            decimal NetAmouunt = Convert.ToDecimal(dt.Rows[0]["NetAmount"].ToString());
            decimal kECharges = Convert.ToDecimal(dt.Rows[0]["electricitycharges"].ToString());
            decimal Total = NetAmouunt + kECharges;
            rpt.SetParameterValue("@NetAmount", NetAmouunt);
            rpt.SetParameterValue("@electricitycharges", dt.Rows[0]["electricitycharges"].ToString());
            rpt.SetParameterValue("@DiscountName", dt.Rows[0]["patientType"].ToString());
            rpt.SetParameterValue("@ReferenceName", dt.Rows[0]["ReferenceName"].ToString());
            rpt.SetParameterValue("@MemberId", dt.Rows[0]["memberid"].ToString());
            rpt.SetParameterValue("@TokenNo", dt.Rows[0]["TokenNo"].ToString());
            rpt.SetParameterValue("@Age", dt.Rows[0]["Age"].ToString());
            rpt.SetParameterValue("@CreatedBY", dt.Rows[0]["createdby"].ToString());
            rpt.SetParameterValue("@phoneNo", dt.Rows[0]["contactno"].ToString());
            rpt.SetParameterValue("@partialName", "Partial Payment");
            rpt.SetParameterValue("@Partial", dt.Rows[0]["netbalance"].ToString());
            rpt.SetParameterValue("@Createdtime", (DateTime)dt.Rows[0]["createdtime"]);
            rpt.SetParameterValue("@PrintedBy", UserInfo.UserId);
            rpt.SetParameterValue("@terminal", SoftwareInfo.Terminal);
            rpt.SetParameterValue("@urcompanyname", CompanyInfo.UrCompanyName);
            rpt.ReportFooterSection7.SectionFormat.EnableUnderlaySection = true;
            if (dt.Rows[0]["Discount"].ToString() == "0") rpt.ReportFooterSection3.SectionFormat.EnableSuppress = true;
            if (dt.Rows[0]["electricitycharges"].ToString() == "0") rpt.ReportFooterSection20.SectionFormat.EnableSuppress = true;
            if (dt.Rows[0]["ispartial"].ToString() == "0") rpt.ReportFooterSection12.SectionFormat.EnableSuppress = true;
            if (dt.Rows[0]["ReferenceName"].ToString() == "") rpt.ReportFooterSection5.SectionFormat.EnableSuppress = true;
            if (dt.Rows[0]["memberid"].ToString() == "")
            {
                rpt.ReportFooterSection6.SectionFormat.EnableSuppress = true;
                rpt.ReportFooterSection7.SectionFormat.EnableUnderlaySection = false;
            }
            if (dt.Rows[0]["tokenNo"].ToString() == "0") rpt.ReportFooterSection7.SectionFormat.EnableSuppress = true;
            rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rpt.PrintToPrinter(1, true, 1, 9999);
            //if (UserInfo.UserLevel == "Admin")
            //{
            //    frmReportView frm = new frmReportView();
            //    frm.rptViewer.ReportSource = rpt;
            //    frm.Show();
            //}
            //else
            //{
            //    rpt.PrintToPrinter(1, true, 1, 9999);
            //    Query.Execute("update opdreceipt set noofprint = nvl(noofprint,0) + 1 where receiptno = '" + voucher + "'");
            //}
        }
    }
}

