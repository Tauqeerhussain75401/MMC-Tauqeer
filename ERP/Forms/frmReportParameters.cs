using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Windows.Documents;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace ERP
{
    public partial class frmReportParameters : Form
    {
        public frmReportParameters()
        {
            InitializeComponent();
        }
        internal string Reportname = "";
        DataTable dtClients = new DataTable();
        DataTable dtEmployees = new DataTable();
        DataTable dtdirector = new DataTable();
        DataTable dtBanks = new DataTable();
        private DataTable Accounts,banks;

        bool FLogIn = true;
        private void ManageControls(Control[] ctrl)
        {
            int LocX = 12, LocY = 60;
            pnlControl.Location = new Point(235, LocY);
            LocY += 50;
            foreach (Control item in ctrl)
            {
                item.Visible = true;
                item.Location = new Point(LocX, LocY);
                LocY += item.Height + 3;
            }
            this.Size = new Size(430, LocY + 50);

        }
        private void ManageControlsLocation(Control[] ctrl)
        {
            int LocX = 12, LocY = 60;
            pnlControl.Location = new Point(235, LocY);
            LocY += 50;
            foreach (Control item in ctrl)
            {
                item.Location = new Point(LocX, LocY);
                LocY += item.Height + 3;
            }
            this.Size = new Size(430, LocY + 50);
        }
        private void fillmcbAccounts()
        {
            Accounts = new DataTable();
            cmbAccount.DataSource = Accounts;
            Accounts = Query.AccountCodes("0");

            DataRow rw = Accounts.NewRow();
            rw["AccountID"] = "";
            Accounts.Rows.InsertAt(rw, 0);

            cmbAccount.DataSource = Accounts;
            cmbAccount.DisplayMember = "AccountTitle";
            cmbAccount.ValueMember = "AccountID";
            cmbAccount.SelectedValue = "001001002001001";

        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReportView frm = new frmReportView();
           
           /// Reports.test rpt1 = new Reports.test();
           //// frm.crystalReportViewer1.ReportSource = rpt1;


            #region Account Statement
            if (Reportname == "Account Statement")
            {

                DataRowView dr = cmbClients.Visible == true ? (DataRowView)cmbClients.SelectedItem : (DataRowView)mcbBankIndex.SelectedItem;
                if (cmbAccount.SelectedIndex != -1)
                {
                    //frmReportView.ShowBox(Reportno, mcbAccount.SelectedValue.ToString(),//--p1
                    //    String.Format("{0:dd-MMM-yyyy}", dtpFDate.Value),//--p2
                    //    String.Format("{0:dd-MMM-yyyy}", dtpTDate.Value),//--p3
                    //    grpClients.Visible == true ? (cmbClients.SelectedIndex != -1 ? cmbClients.SelectedValue.ToString() : "") : (mcbBankIndex.SelectedIndex != -1 ? mcbBankIndex.SelectedValue.ToString() : ""),
                    //    cmbClients.Visible == true ? dr["clienttitle"].ToString() : (mcbBankIndex.Visible == true ? dr["bankname"].ToString() : mcbAccount.Text));
                    //Reports.AccountStatement repas = new Reports.AccountStatement();
                    DataSet ds = new DataSet();
                    Reports.AccountStatement repas = new Reports.AccountStatement();

                    ds = Query.Rep_AccountStatement(cmbAccount.SelectedValue.ToString(), String.Format("{0:dd-MMM-yyyy}", dtpFDate.Value), String.Format("{0:dd-MMM-yyyy}", dtpTDate.Value), grpClients.Visible == true ? (cmbClients.SelectedIndex != -1 ? cmbClients.SelectedValue.ToString() : "") : (mcbBankIndex.SelectedIndex != -1 ? mcbBankIndex.SelectedValue.ToString() : ""), (cmbBank.SelectedIndex != -1 ? cmbBank.SelectedValue.ToString() : ""));//cmbBank.SelectedValue.ToString());

                    repas.SetDataSource(ds);

                    repas.SetParameterValue("@Company_Name", CompanyInfo.CompanyName);
                    repas.SetParameterValue("@Period_From", String.Format("{0:dd-MMM-yyyy}", dtpFDate.Value));
                    repas.SetParameterValue("@Period_To", String.Format("{0:dd-MMM-yyyy}", dtpTDate.Value));
                    if (cmbAccount.SelectedValue.ToString() == "001001005002001")
                        repas.SetParameterValue("@Title", cmbBank.Text);
                    else
                        repas.SetParameterValue("@Title", cmbAccount.Text);
                    repas.SetParameterValue("@User", UserInfo.UserName);

                    frm.rptViewer.ReportSource = repas;
                }
                else
                    cmbAccount.Text = "";
            }
            #endregion
            #region Daily All User Income
            else if (Reportname == "Daily All User Income")
            {
                Reports.AllUserDailyIncome rpt = new Reports.AllUserDailyIncome();
                DataTable dt = ReportQuery.allUserClosingSummary(dtpFDate.Value, dtpTDate.Value);
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@Fdate", dtpFDate.Value);
                rpt.SetParameterValue("@Tdate", dtpTDate.Value);
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);

                frm.rptViewer.ReportSource = rpt;
            }
            #endregion
            #region Member Invoice Detail
            else if (Reportname == "Member Invoice Detail")
            {
                Reports.MemberInvoiceDetail rpt = new Reports.MemberInvoiceDetail();
                DataTable dt = ReportQuery.MemberInvoiceDetail(dtpFDate.Value, dtpTDate.Value, txtMemberNo.Text, cmbStatus.Text,cmbgender.Text);
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@Fdate", dtpFDate.Value);
                rpt.SetParameterValue("@Tdate", dtpTDate.Value);
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);
                rpt.SetParameterValue("@gender", cmbgender.Text);

                frm.rptViewer.ReportSource = rpt;

            }
            #endregion
            #region Zakat Member Invoice Detail
            else if (Reportname == "Zakat Member Invoice Detail")
            {

                if (chkOnlyZakat.Checked == false)
                {
                    MessageBox.Show("Plz Checked The Zakat Member ");
                    return;
                }

                Reports.ZakatMemberInvoiceDetail rpt = new Reports.ZakatMemberInvoiceDetail();
                DataTable dt = ReportQuery.ZakatMemberInvoiceDetail(dtpFDate.Value, dtpTDate.Value, txtMemberNo.Text, cmbStatus.Text);
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@Fdate", dtpFDate.Value);
                rpt.SetParameterValue("@Tdate", dtpTDate.Value);
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);

                frm.rptViewer.ReportSource = rpt;

            }
            #endregion
            #region OPD Reference Detail
            else if (Reportname == "OPD Reference Detail")
            {
                Reports.ReferenceInoiceDetail rpt = new Reports.ReferenceInoiceDetail();
                DataTable dt = new DataTable();
                //if (dtpFDate.Value == dtpTDate.Value)
                //{
                //    dt = ReportQuery.rep_referenceinvoices1_Same(dtpFDate.Value, dtpTDate.Value, (string)cmbReference.SelectedValue);
                //}
                //else
                //{
                   dt = ReportQuery.ReferenceInvoiceDetail(dtpFDate.Value, dtpTDate.Value, (string)cmbReference.SelectedValue);
               // }
                
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@Fdate", dtpFDate.Value);
                rpt.SetParameterValue("@Tdate", dtpTDate.Value);
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);
                //DataTable dtCancel = ReportQuery.rep_OPDreference_Cancellation(dtpFDate.Value, dtpTDate.Value, (string)cmbReference.SelectedValue);
                //if (dtCancel.Rows.Count > 0)
                //{
                //    rpt.SetParameterValue("@Fdate", dtpFDate.Value, "ReferenceInoiceDetailCancelReprot.rpt");
                //    rpt.SetParameterValue("@Tdate", dtpTDate.Value, "ReferenceInoiceDetailCancelReprot.rpt");
                //}
                frm.rptViewer.ReportSource = rpt;

            }
            else if (Reportname == "OPD Reference Detail")
            {

            }
            #endregion
            #region IPD / OPD Income Summary
            else if (Reportname == "IPD / OPD Income Summary")
            {
                Reports.IPD_OPD_IncomeSummary rpt = new Reports.IPD_OPD_IncomeSummary();
                DataTable dt = ReportQuery.IPD_OPD_IncomeSummary(dtpFDate.Value, dtpTDate.Value);
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@Fdate", dtpFDate.Value);
                rpt.SetParameterValue("@Tdate", dtpTDate.Value);
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);

                frm.rptViewer.ReportSource = rpt;

            }
            #endregion
            #region Net Income Summary
            else if (Reportname == "Net Income Summary")
            {
                Reports.CrIncomeSummaryCatagoryWise rpt = new Reports.CrIncomeSummaryCatagoryWise();
                DataTable dt = ReportQuery.Net_IncomeSummary(dtpFDate.Value, dtpTDate.Value);
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@Fdate", dtpFDate.Value);
                rpt.SetParameterValue("@Tdate", dtpTDate.Value);
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);

                frm.rptViewer.ReportSource = rpt;

            }
            #endregion
            #region Gross Income Summary
            else if (Reportname == "Gross Income Summary")
            {
                Reports.CrGrossIncomeCatagorywise rpt = new Reports.CrGrossIncomeCatagorywise();
                DataTable dt = ReportQuery.Gross_IncomeSummary(dtpFDate.Value, dtpTDate.Value);
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@Fdate", dtpFDate.Value);
                rpt.SetParameterValue("@Tdate", dtpTDate.Value);
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);

                frm.rptViewer.ReportSource = rpt;

            }
            #endregion
            #region OPD Consultant Wise Detail
            else if (Reportname == "OPD Consultant Wise Detail")
            {
                Reports.ConsultantWiseDetail rpt = new Reports.ConsultantWiseDetail();
                DataTable dt = ReportQuery.OPDConsultantWiseDetail(dtpFDate.Value, dtpTDate.Value, (string)cmbConsultant.SelectedValue);
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@Fdate", dtpFDate.Value);
                rpt.SetParameterValue("@Tdate", dtpTDate.Value);
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);

                frm.rptViewer.ReportSource = rpt;

            }
            #endregion
            #region OPD Catagory Wise Detail
            else if (Reportname == "OPD Catagory Wise Detail")
            {
                Reports.CatagoryWiseDetail rpt = new Reports.CatagoryWiseDetail();
                DataTable dt = ReportQuery.OPDCatagoryWiseDetail(dtpFDate.Value, dtpTDate.Value, (string)cmbCatagory.SelectedValue, cmbgender.Text);
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@Fdate", dtpFDate.Value);
                rpt.SetParameterValue("@Tdate", dtpTDate.Value);
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);
                rpt.SetParameterValue("@ReportHeader", cmbCatagory.Text);
                rpt.SetParameterValue("@gender", cmbgender.Text == "All" ? "Both" : cmbgender.Text);

                frm.rptViewer.ReportSource = rpt;

            }
            #endregion
            #region OPD Consultant Summary
            else if (Reportname == "OPD Consultant Summary")
            {
                Reports.OpdConsultantSmry rpt = new Reports.OpdConsultantSmry();
                DataTable dt = ReportQuery.OPD_ConsultantSummary(dtpFDate.Value, dtpTDate.Value);
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@Fdate", dtpFDate.Value);
                rpt.SetParameterValue("@Tdate", dtpTDate.Value);
                //rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                //rpt.SetParameterValue("@User", UserInfo.UserName);

                frm.rptViewer.ReportSource = rpt;

            }
            #endregion
            #region Consultant Ledger
            else if (Reportname == "Consultant Ledger")
            {
                Reports.ConsultantLedger rpt = new Reports.ConsultantLedger();
                DataTable dt = ReportQuery.OPD_ConsultantLedger(dtpFDate.Value, dtpTDate.Value, (string)cmbConsultant.SelectedValue);
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@Fdate", dtpFDate.Value);
                rpt.SetParameterValue("@Tdate", dtpTDate.Value);
                rpt.SetParameterValue("@ConsultantName", cmbConsultant.Text);
                //rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                //rpt.SetParameterValue("@User", UserInfo.UserName);

                frm.rptViewer.ReportSource = rpt;

            }
            #endregion
            #region Member Detail
            else if (Reportname == "Member Detail")
            {
                Reports.CrpBmjVoter rpt = new Reports.CrpBmjVoter();
                if (cmbStatus.Text == "")
                {
                    MessageBox.Show("Please Select Status...,");
                    return;
                }
                DataTable dt = Query.getData("SELECT id, newno bmjnewno, newno1, btmwcoldno, oldno bmjoldno, membershipnumber bmjmembershipnumber, title, name, father, grandfather, husband, caste, maritalstatus, dob, olddob, qualification, work, contact, cnic, address, voternumber, isdeactivate, mobilenumberforsms, lastupdateddatetime, lastupdatedbysessionid FROM member where isdeactivate = " + (cmbStatus.Text == "Active" ? "0" : cmbStatus.Text == "Deactive" ? "1" : "isdeactivate") + "");
                rpt.SetDataSource(dt);
                frm.rptViewer.ReportSource = rpt;
                frm.Show();

            }
            #endregion

            #region DETAIL OF IN-PATIENT BILL
            else if (Reportname == "DETAIL OF IN-PATIENT BILL")
            {
                decimal totalChargesSum = 0;
                ERP.Reports.CrpInpIncome2 rptCrpInpIncome2 = new ERP.Reports.CrpInpIncome2();
                DataTable dt = ReportQuery.InPatientBill(dtpFDate.Value, dtpTDate.Value);
                if (dt != null)
                {
                    DataRow[] filteredRows = dt.Select("bmjnewno IS NOT NULL");
                    if (filteredRows.Length > 0)
                    {
                        DataTable dtBMJ = filteredRows.CopyToDataTable();
                        totalChargesSum = dtBMJ.AsEnumerable()
                            .Sum(row => row.Field<decimal>("balance"));
                    }
                }
                rptCrpInpIncome2.SetDataSource(dt);
                rptCrpInpIncome2.SetParameterValue("pDateFrom", dtpFDate.Value);
                rptCrpInpIncome2.SetParameterValue("pDateTo", dtpTDate.Value);
                rptCrpInpIncome2.SetParameterValue("BMJSum", totalChargesSum.ToString("N0"));

                frm.rptViewer.ReportSource = rptCrpInpIncome2;

            }
            #endregion
            #region Discharged Report
            else if (Reportname == "Discharged Report")
            {

                ERP.Reports.CrpInPDischarge CrpDisCharg = new ERP.Reports.CrpInPDischarge();

                DataTable dt = ReportQuery.DischargedPatient(dtpFDate.Value, dtpTDate.Value);
                CrpDisCharg.SetDataSource(dt);
                CrpDisCharg.SetParameterValue("pDateFrom", dtpFDate.Value);
                CrpDisCharg.SetParameterValue("pDateTo", dtpTDate.Value);
                CrpDisCharg.SetParameterValue("pRptHeading1", "Discharged Report");

                frm.rptViewer.ReportSource = CrpDisCharg;


            }
            #endregion

            #region Due/Pending Amount Report
            else if (Reportname == "Due/Pending Amount Report")
            {
                ERP.Reports.CrpInPMaster2 rptcrpmaster2 = new ERP.Reports.CrpInPMaster2();
                DataTable dt = ReportQuery.patientduescharges(dtpFDate.Value, dtpTDate.Value);
                dt.TableName = "DtInpatient";
                rptcrpmaster2.SetDataSource(dt);
                rptcrpmaster2.SetParameterValue("pDateFrom", dtpFDate.Value);
                rptcrpmaster2.SetParameterValue("pDateTo", dtpTDate.Value);
                rptcrpmaster2.SetParameterValue("pRptHeading1", "Due/Pending Amount Report");

                frm.rptViewer.ReportSource = rptcrpmaster2;



            }
            #endregion

            #region Consultant IPD Summary
            else if (Reportname == "Consultant IPD Summary")
            {
                ERP.Reports.CrpIpCnsSmry rptCiCnSlSmry = new ERP.Reports.CrpIpCnsSmry();
                DataTable dt = ReportQuery.ConsultantIPDSummary(dtpFDate.Value, dtpTDate.Value);
                rptCiCnSlSmry.SetDataSource(dt);
                rptCiCnSlSmry.SetParameterValue("pDateFrom", dtpFDate.Value);
                rptCiCnSlSmry.SetParameterValue("pDateTo", dtpTDate.Value);

                frm.rptViewer.ReportSource = rptCiCnSlSmry;

            }
            #endregion

            #region DisCharge Patient Bill Detail
            else if (Reportname == "DisCharge Patient Bill Detail")
            {
                ERP.Reports.CrpIPDDisChargeBillDetail rptCiCnSlSmry = new ERP.Reports.CrpIPDDisChargeBillDetail();
                DataTable dt = ReportQuery.DetailIPDDischargeSummary(dtpFDate.Value, dtpTDate.Value);
                rptCiCnSlSmry.SetDataSource(dt);
                rptCiCnSlSmry.SetParameterValue("pDateFrom", dtpFDate.Value);
                rptCiCnSlSmry.SetParameterValue("pDateTo", dtpTDate.Value);

                frm.rptViewer.ReportSource = rptCiCnSlSmry;

            }
            #endregion
            #region OPD Test Receipt Detail
            else if (Reportname == "OPD Test Receipt Detail")
            {
                Cursor.Current = Cursors.WaitCursor;
                Reports.CrpOPDReceipt rptcrpOPDreceipt = new Reports.CrpOPDReceipt();
                DataTable dt = ReportQuery.DetailOPDReceipt(dtpFDate.Value, dtpTDate.Value, cmbAllCatagory.SelectedValue.ToString(), cmbTest.SelectedValue.ToString(),cmbgender.Text);
                rptcrpOPDreceipt.SetDataSource(dt);
                rptcrpOPDreceipt.SetParameterValue("@FromDate", dtpFDate.Value);
                rptcrpOPDreceipt.SetParameterValue("@ToDate", dtpTDate.Value);
                rptcrpOPDreceipt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rptcrpOPDreceipt.SetParameterValue("@contacthead", CompanyInfo.ContactHead);
                rptcrpOPDreceipt.SetParameterValue("@address", CompanyInfo.Address);
                rptcrpOPDreceipt.SetParameterValue("@urcompanyname", CompanyInfo.UrCompanyName);
                rptcrpOPDreceipt.SetParameterValue("@gender", cmbgender.Text == "All" ? "Both" : cmbgender.Text);
                Cursor.Current = Cursors.Default;
                frm.rptViewer.ReportSource = rptcrpOPDreceipt;

            }
            #endregion
            #region Laboratory Statement
            else if (Reportname == "Laboratory Statement")
            {
                ERP.Reports.rptLabInComeReport rptLabIncome = new ERP.Reports.rptLabInComeReport();
                DataTable dt = ReportQuery.DetailLabIncomeStatement(dtpFDate.Value, dtpTDate.Value);
                rptLabIncome.SetDataSource(dt);
                rptLabIncome.SetParameterValue("@FDate", dtpFDate.Value);
                rptLabIncome.SetParameterValue("@TDate", dtpTDate.Value);

                frm.rptViewer.ReportSource = rptLabIncome;

            }
            #endregion
            #region Zakat Recipient
            else if (Reportname == "Zakat Recipient")
            {
                Reports.rptZakatRecipient RZR = new Reports.rptZakatRecipient();
                DataTable dtZR = ReportQuery.GetZAkatRecipient(cmbZakatReference.SelectedValue.ToString());

                RZR.SetDataSource(dtZR);
                frm.rptViewer.ReportSource = RZR;
            }
            #endregion
            #region BMG MEMBER
            else if (Reportname == "BMG Member")
            {
                string chkAc_Un = chkWithFamily.Checked == true ? "1" : "0";
                if (chkAc_Un == "1")
                {
                    Reports.rptBMJMember1 RPBMJ = new Reports.rptBMJMember1();
                    DataTable DTBMJ = ReportQuery.GetBMJMember(cmbBMGMember.SelectedValue.ToString(),
                    rdoActive.Checked == true ? "0" : rdoUnActive.Checked == true ? "1" : "0", chkWithFamily.Checked == true ? "1" : "0",cmbgender.Text);

                    RPBMJ.SetDataSource(DTBMJ);

                    RPBMJ.SetParameterValue("@chkFamilymember", chkAc_Un);

                    frm.rptViewer.ReportSource = RPBMJ;
                }
                else
                {
                    Reports.rptBMJMember RPBMJ = new Reports.rptBMJMember();
                    DataTable DTBMJ = ReportQuery.GetBMJMember(cmbBMGMember.SelectedValue.ToString(),
                    rdoActive.Checked == true ? "0" : rdoUnActive.Checked == true ? "1" : "0", chkWithFamily.Checked == true ? "1" : "0", cmbgender.Text);

                    RPBMJ.SetDataSource(DTBMJ);

                    RPBMJ.SetParameterValue("@chkFamilymember", chkAc_Un);

                    frm.rptViewer.ReportSource = RPBMJ;
                }

            }
            #endregion
            #region In-Patient Closing
            else if (Reportname == "In-Patient Closing")
            {


                Reports.dailyCashStatementAllUser daily = new Reports.dailyCashStatementAllUser();
                DataTable DTBMJ = ReportQuery.rep_dailycashstatament(dtpFDate.Value.ToString("dd-MMM-yyyy"), dtpTDate.Value.ToString("dd-MMM-yyyy"), cmbUser.Text);


                daily.SetDataSource(DTBMJ);

                daily.SetParameterValue("@User", UserInfo.UserId);
                daily.SetParameterValue("@FDate", dtpFDate.Value.ToString("dd-MMM-yyyy"));
                daily.SetParameterValue("@ToDate", dtpTDate.Value.ToString("dd-MMM-yyyy"));

                daily.SetParameterValue("@CompanyName", CompanyInfo.CompanyName);



                frm.rptViewer.ReportSource = daily;


            }
            #endregion

            #region IPD reference
            else if (Reportname == "IPD Reference Report")
            {

                Reports.IPDrefReport rpt = new Reports.IPDrefReport();
                DataTable dt = ReportQuery.IPDreference(Convert.ToDateTime(dtpFDate.Text), Convert.ToDateTime(dtpTDate.Text), rdbReferenceAll.Checked == true ? "all" : cmbReference.SelectedValue.ToString());
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@Vfrom", dtpFDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetParameterValue("@Vtodate", dtpTDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);

                frm.rptViewer.ReportSource = rpt;

            }
            #endregion
            #region Room Wise Detail
            else if (Reportname == "Room Wise Detail")
            {

                Reports.RoomWisepateintinfo rpt = new Reports.RoomWisepateintinfo();
                DataTable dt = ReportQuery.RoomWisePatientInfo(dtpTDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@tdate", dtpTDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);

                frm.rptViewer.ReportSource = rpt;

            }

            #endregion
            #region Advance Collection Report
            else if (Reportname == "Advance Collection Report")
            {

                Reports.advanceCollection rpt = new Reports.advanceCollection();
                DataTable dt = ReportQuery.AdvanceCollectionUserWise(dtpFDate.Value.ToString("dd-MMM-yyyy"), dtpTDate.Value.ToString("dd-MMM-yyyy"), cmbUser.SelectedValue.ToString());
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@Vfrom", dtpFDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetParameterValue("@Vtodate", dtpTDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);
                rpt.SetParameterValue("@VUser", cmbUser.Text);

                frm.rptViewer.ReportSource = rpt;

            }

            #endregion
            #region IPD Consultant Detail
            else if (Reportname == "IPD Consultant Detail")
            {

                Reports.Crp_ipd_Con_Detail rpt = new Reports.Crp_ipd_Con_Detail();
                DataTable dt = ReportQuery.rep_ipd_consultant_detail(dtpFDate.Value.ToString("dd-MMM-yyyy"), dtpTDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@Vfrom", dtpFDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetParameterValue("@Vtodate", dtpTDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);
                rpt.SetParameterValue("@VUser", cmbUser.Text);

                frm.rptViewer.ReportSource = rpt;

            }

            #endregion
            #region BMJ Report Discharged
            else if (Reportname == "BMJ Report Discharged")
            {

                Reports.Crp_IPD_BMJ rpt = new Reports.Crp_IPD_BMJ();
                DataTable dt = ReportQuery.rep_ipd_bmj_discharged(dtpFDate.Value.ToString("dd-MMM-yyyy"), dtpTDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@Vfrom", dtpFDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetParameterValue("@Vtodate", dtpTDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);
                rpt.SetParameterValue("@VUser", cmbUser.Text);

                frm.rptViewer.ReportSource = rpt;

            }

            #endregion

            #region IPD test summary report
            else if (Reportname == "IPD Test Summary")
            {

                Reports.IPDTestSummary rpt = new Reports.IPDTestSummary();
                DataTable dt = ReportQuery.rep_ipd_testSummary(dtpFDate.Value.ToString("dd-MMM-yyyy"), dtpTDate.Value.ToString("dd-MMM-yyyy"),
                    cmbAllCatagory.SelectedValue.ToString(), cmbTest.SelectedValue.ToString(),cmbgender.Text);
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@Vfrom", dtpFDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetParameterValue("@Vtodate", dtpTDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);
                rpt.SetParameterValue("@gender", cmbgender.Text == "All" ? "Both" : cmbgender.Text);
                //   rpt.SetParameterValue("@VUser", cmbUser.Text);

                frm.rptViewer.ReportSource = rpt;

            }
            #endregion

            #region IPD reference summary
            else if (Reportname == "IPD Reference Summary")
            {

                Reports.IPDrefReport rpt = new Reports.IPDrefReport();
                DataTable dt = ReportQuery.rep_ipd_refundSummary(dtpFDate.Value.ToString("dd-MMM-yyyy"), dtpTDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@Vfrom", dtpFDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetParameterValue("@Vtodate", dtpTDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);
                rpt.SetParameterValue("@VUser", cmbUser.Text);

                frm.rptViewer.ReportSource = rpt;

            }
            #endregion

            #region package detail
            else if (Reportname == "Package Detail")
            {

                Reports.Crp_IPD_Package rpt = new Reports.Crp_IPD_Package();
                DataTable dt = ReportQuery.rep_ipd_packageDetail(dtpFDate.Value.ToString("dd-MMM-yyyy"), dtpTDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@From", dtpFDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetParameterValue("@To", dtpTDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);
                //     rpt.SetParameterValue("@VUser", cmbUser.Text);

                frm.rptViewer.ReportSource = rpt;

            }
            #endregion
            #region ipd refund report
            else if (Reportname == "IPD refund summary")
            {

                Reports.IPDrefundsummaryt rpt = new Reports.IPDrefundsummaryt();
                DataTable dt = ReportQuery.rep_ipd_refundSummary(dtpFDate.Value.ToString("dd-MMM-yyyy"), dtpTDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("From", dtpFDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetParameterValue("To", dtpTDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);
                //           rpt.SetParameterValue("@VUser", cmbUser.Text);

                frm.rptViewer.ReportSource = rpt;

            }
            #endregion
            #region admitted patient Report
            else if (Reportname == "Admitted Patient Report")
            {

                Reports.admPatient rpt = new Reports.admPatient();
                DataTable dt = ReportQuery.rep_ipd_admittedPatient(dtpFDate.Value.ToString("dd-MMM-yyyy"), dtpTDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@From", dtpFDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetParameterValue("@To", dtpTDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);
                //           rpt.SetParameterValue("@VUser", cmbUser.Text);

                frm.rptViewer.ReportSource = rpt;

            }


            #endregion
            #region Trial Balance
            else if (Reportname == "Trial Balance")
            {
                //Reports.TrialBalance rpt = new Reports.TrialBalance();
                //DataSet ds = new DataSet();
                ////DataTable dt = Query.Rep_TrialBalanceERP(dtpFDate.Value.ToString("dd-MMM-yyyy"), dtpTDate.Value.ToString("dd-MMM-yyyy"));
                ////rpt.SetDataSource(dt);
                //DataTable dt = ReportQuery.getTrailBalance(Convert.ToString(dtpFDate.Value), Convert.ToString(dtpTDate.Value));
                //rpt.SetDataSource(dt);
                //rpt.SetParameterValue("@From", dtpFDate.Value.ToString("dd-MMM-yyyy"));
                //rpt.SetParameterValue("@To", dtpTDate.Value.ToString("dd-MMM-yyyy"));
                //rpt.SetParameterValue("@Company_Name", CompanyInfo.CompanyName);
                //frm.rptViewer.ReportSource = rpt;

            }
            #endregion

            #region consultant visit
            else if (Reportname == "In-Patient Consultant visit details")
            {

                Reports.ConsultantVisits rpt = new Reports.ConsultantVisits();
                DataTable dt = ReportQuery.rep_ipd_ConsultantVisits(dtpFDate.Value, dtpTDate.Value, (string)cmbConsultant.SelectedValue);
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@Fdate", dtpFDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetParameterValue("@Tdate", dtpTDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);
                //  rpt.SetParameterValue("@Consultant", (string)cmbConsultant.SelectedValue == "All" ? "All" : (string)cmbConsultant.Text);

                frm.rptViewer.ReportSource = rpt;

            }
            else if (Reportname == "SPD / ZF Report")
            {
                Reports.SPD_ZF rpt = new Reports.SPD_ZF();
                DataTable dt = ReportQuery.GetSPD_ZF(Convert.ToString(dtpFDate.Value),Convert.ToString(dtpTDate.Value));
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@Fdate", dtpFDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetParameterValue("@Tdate", dtpTDate.Value.ToString("dd-MMM-yyyy"));
                frm.rptViewer.ReportSource = rpt;
            }
            else if (Reportname == "Session Patient Report")
            {
                Reports.SessionPatient rpt = new Reports.SessionPatient();
                radioButton6_CheckedChanged(this, EventArgs.Empty);
                DataTable dt = ReportQuery.rep_sessionpatient(Fdate, Tdate, txtregno.Text);
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@Fdate", Fdate);
                rpt.SetParameterValue("@Tdate", Tdate);
                rpt.SetParameterValue("@Regno", txtregno.Text);
                 frm.rptViewer.ReportSource = rpt;
            }
            else if (Reportname == "Partially Payment Pending Report")
            {
                Reports.PartiallyPaymentPendingReport rpt = new Reports.PartiallyPaymentPendingReport();
                //DataTable dt = ReportQuery.rep_PartialyPayment(dtpFDate.Value, dtpTDate.Value, txtregno.Text);
                DataTable dt = Query.GetPartialltPaymentReport(dtpFDate.Value.ToString("dd-MMM-yyyy"), dtpTDate.Value.ToString("dd-MMM-yyyy"), txtregno.Text);
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@Fdate", dtpFDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetParameterValue("@Tdate", dtpTDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetParameterValue("@Regno", txtregno.Text);
                frm.rptViewer.ReportSource = rpt;
            }

            #endregion
            #region
            #region Consultant share details
            else if (Reportname == "Consultant share details")
            {
                Reports.consultantcharges rpt = new Reports.consultantcharges();
                DataTable dt = ReportQuery.rep_consultantShareDetail(dtpFDate.Value, dtpTDate.Value);
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@From", dtpFDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetParameterValue("@To", dtpTDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);
                frm.rptViewer.ReportSource = rpt;
            }
            #endregion
            #region Surgery Wise Details Report
            else if (Reportname == "Surgery Wise Details Report")
            {
                Reports.SurgeryWisereport_ rpt = new Reports.SurgeryWisereport_();
                DataTable dt = ReportQuery.pr_doctorWise_sugeryreport(dtpFDate.Value, dtpTDate.Value, (string)cmbPackage.SelectedValue);
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@Fdate", dtpFDate.Value);
                rpt.SetParameterValue("@Tdate", dtpTDate.Value);
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);
                rpt.SetParameterValue("@ReportHeader", Reportname);
                frm.rptViewer.ReportSource = rpt;
            }
            #endregion
            #region Doctor Wise Report
            else if (Reportname == "Doctor Wise Report")
            {
                Reports.DoctorwiseSurgeryreport rpt = new Reports.DoctorwiseSurgeryreport();
                DataTable dt = ReportQuery.pr_doctorWise_sugeryreport(dtpFDate.Value, dtpTDate.Value, (string)cmbPackage.SelectedValue);
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@Fdate", dtpFDate.Value);
                rpt.SetParameterValue("@Tdate", dtpTDate.Value);
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);
                rpt.SetParameterValue("@ReportHeader", Reportname);
                frm.rptViewer.ReportSource = rpt;
            }
            #endregion
            #region Total Surgeries Report
            else if (Reportname == "Total Surgeries Report")
            {
                Reports.TotalSurgeries rpt = new Reports.TotalSurgeries();
                DataTable dt = ReportQuery.pr_surgerygroup_report(dtpFDate.Value, dtpTDate.Value);
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@Fdate", dtpFDate.Value);
                rpt.SetParameterValue("@Tdate", dtpTDate.Value);
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);
                rpt.SetParameterValue("@ReportHeader", Reportname);
                frm.rptViewer.ReportSource = rpt;
            }
            #endregion



            #region ipd consultant surgery detail
            else if (Reportname == "ipd consultant surgery detail")
            {
                Reports.consultantsurgey rpt = new Reports.consultantsurgey();
                DataTable dt = ReportQuery.consultantsurgerydetail(dtpFDate.Value, dtpTDate.Value, (string)cmbConsultant.SelectedValue, (string)cmbPackage.SelectedValue);
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@Fdate", dtpFDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetParameterValue("@Tdate", dtpTDate.Value.ToString("dd-MMM-yyyy"));
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);
                rpt.SetParameterValue("@Consultant", (string)cmbConsultant.SelectedValue == "All" ? "All" : (string)cmbConsultant.Text);

                frm.rptViewer.ReportSource = rpt;

            }
            #endregion

            else if (Reportname == "OPD Fund Utilization Report")
            {
                DataTable dt = new DataTable();
                string fundType = cmbFundType.Text;
                Reports.OPD_FundUtilization rpt = new Reports.OPD_FundUtilization();
                dt = ReportQuery.OPD_FundUtilization(dtpFDate.Value, dtpTDate.Value, cmbgender.Text);

                DataTable filteredDt = dt.Clone();
                foreach (DataRow row in dt.Rows)
                {
                    DataRow newRow = filteredDt.NewRow();
                    newRow["catagory"] = row["catagory"];
                    newRow["receiptno"] = row["receiptno"];
                    newRow["vdate"] = row["vdate"];
                    newRow["patientname"] = row["patientname"];
                    newRow["gender"] = row["gender"];
                    newRow["TotalAmount"] = row["TotalAmount"];
                    newRow["ZF"] = row["ZF"];
                    newRow["SPD"] = row["SPD"];
                    newRow["Bmj"] = row["Bmj"];
                    newRow["contactno"] = row["contactno"];

                    if (fundType == "All")
                    {
                        filteredDt.Rows.Add(newRow);
                    }
                    else if (fundType == "Full")
                    {
                        decimal totalAmount = Convert.ToDecimal(newRow["TotalAmount"]);
                        decimal Sum = Convert.ToDecimal(row["SPD"]) + Convert.ToDecimal(row["ZF"]) + Convert.ToDecimal(row["Bmj"]);
                        if(totalAmount == Sum)
                        {
                            filteredDt.Rows.Add(newRow);
                        }
                    }
                    else if (fundType == "Partial")
                    {
                        decimal totalAmount = Convert.ToDecimal(newRow["TotalAmount"]);
                        decimal Sum = Convert.ToDecimal(row["SPD"]) + Convert.ToDecimal(row["ZF"]) + Convert.ToDecimal(row["Bmj"]);
                        if (totalAmount != Sum)
                        {
                            filteredDt.Rows.Add(newRow);
                        }
                    }
                }

                rpt.SetDataSource(filteredDt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@Fdate", dtpFDate.Value);
                rpt.SetParameterValue("@Tdate", dtpTDate.Value);
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);
                rpt.SetParameterValue("@ReportHeader", Reportname);
                rpt.SetParameterValue("@Type", fundType);
                rpt.SetParameterValue("@Gender", cmbgender.Text);
                frm.rptViewer.ReportSource = rpt;
            }
            else if (Reportname == "IPD Fund Utilization Report")
            {
                DataTable dt = new DataTable();
                string fundType = cmbFundType.Text;
                Reports.IPD_FundUtilization rpt = new Reports.IPD_FundUtilization();
                dt = ReportQuery.IPD_FundUtilization(dtpFDate.Value, dtpTDate.Value, cmbgender.Text);

                DataTable filteredDt = dt.Clone();
                foreach (DataRow row in dt.Rows)
                {
                    DataRow newRow = filteredDt.NewRow();
                    newRow["fileno"] = row["fileno"];
                    newRow["admdate"] = row["admdate"];
                    newRow["dischargedate"] = row["dischargedate"];
                    newRow["patientname"] = row["patientname"];
                    newRow["gender"] = row["gender"];
                    newRow["totalcharges"] = row["totalcharges"];
                    newRow["ZF"] = row["ZF"];
                    newRow["SPD"] = row["SPD"];
                    newRow["Bmj"] = row["Bmj"];
                    newRow["contactno"] = row["contactno"];

                    if (fundType == "All")
                    {
                        filteredDt.Rows.Add(newRow);
                    }
                    else if (fundType == "Full")
                    {
                        decimal totalAmount = Convert.ToDecimal(newRow["totalcharges"]);
                        decimal Sum = Convert.ToDecimal(row["SPD"]) + Convert.ToDecimal(row["ZF"]) + Convert.ToDecimal(row["Bmj"]);
                        if (totalAmount == Sum)
                        {
                            filteredDt.Rows.Add(newRow);
                        }
                    }
                    else if (fundType == "Partial")
                    {
                        decimal totalAmount = Convert.ToDecimal(newRow["totalcharges"]);
                        decimal Sum = Convert.ToDecimal(row["SPD"]) + Convert.ToDecimal(row["ZF"]) + Convert.ToDecimal(row["Bmj"]);
                        if (totalAmount != Sum)
                        {
                            filteredDt.Rows.Add(newRow);
                        }
                    }
                }

                rpt.SetDataSource(filteredDt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@Fdate", dtpFDate.Value);
                rpt.SetParameterValue("@Tdate", dtpTDate.Value);
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);
                rpt.SetParameterValue("@ReportHeader", Reportname);
                rpt.SetParameterValue("@Type", fundType);
                rpt.SetParameterValue("@Gender", fundType);
                frm.rptViewer.ReportSource = rpt;
            }
            else if(Reportname == "OPD Cash In Hand")
            {
                Reports.OPD_CashInHand rpt = new Reports.OPD_CashInHand();
                DataTable dt = ReportQuery.OPD_CashInHand(dtpFDate.Value, dtpTDate.Value);
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@Fdate", dtpFDate.Value);
                rpt.SetParameterValue("@Tdate", dtpTDate.Value);
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);
                rpt.SetParameterValue("@ReportHeader", Reportname);
                frm.rptViewer.ReportSource = rpt;
            }
            else if (Reportname == "IPD Cash In Hand")
            {
                Reports.IPD_CashInHand rpt = new Reports.IPD_CashInHand();
                DataTable dt = ReportQuery.IPD_CashInHand(dtpFDate.Value, dtpTDate.Value);
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@Fdate", dtpFDate.Value);
                rpt.SetParameterValue("@Tdate", dtpTDate.Value);
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);
                rpt.SetParameterValue("@ReportHeader", Reportname);
                frm.rptViewer.ReportSource = rpt;
            }
            else if (Reportname == "Discrepancies in vouchers")
            {
                Reports.Discrepancies_Voucher rpt = new Reports.Discrepancies_Voucher();
                DataTable dt = ReportQuery.Discrepancies_Voucher();
                rpt.SetDataSource(dt);
                rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                rpt.SetParameterValue("@User", UserInfo.UserName);
                rpt.SetParameterValue("@ReportHeader", Reportname);
                frm.rptViewer.ReportSource = rpt;
            }
            else if (Reportname == "IPD / OPD Closing Summary")
            {
                Reports.Ipd_Opd_ClosingSummary rpt = new Reports.Ipd_Opd_ClosingSummary();
                DataTable dtCategory = ReportQuery.Ipd_Opd_ClosingSummary(dtpFDate.Value, dtpTDate.Value);
                //DataTable dtSummary = ReportQuery.IPD_OPD_IncomeSummary(dtpFDate.Value, dtpTDate.Value);
               DataTable dtLessUnPaid = ReportQuery.Ipd_opd_LessUnPaidsummary(dtpFDate.Value, dtpTDate.Value);
                rpt.SetDataSource(dtCategory);
                //rpt.Subreports["IncomeSummary"].SetDataSource(dtSummary);
                rpt.Subreports["Less_UnPaid_Summary"].SetDataSource(dtLessUnPaid);
                //rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                //rpt.SetParameterValue("@Fdate", dtpFDate.Value);
                //rpt.SetParameterValue("@Tdate", dtpTDate.Value);
                //rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                //rpt.SetParameterValue("@User", UserInfo.UserName);
                frm.rptViewer.ReportSource = rpt;
            }
            #region
            else if (Reportname == "All Patient Detail")
            {
                #region commented code
                /*  string checkedItems = "";
                if (!chkSelectAll.Checked)
                {
                    
                    //CheckedListBox.CheckedItemCollection coll = chkBoxFilter.CheckedItems;
                    //string[] s = new string[coll.Count];
                    //coll.CopyTo(s, 0);
                    //var item = "";
                    //for (var i = 0; i < s.Length; i++)
                    //{
                    //      item = s[i];

                    //    // work with item here
                    //}
                    //string sql = "select * from " + item + " ";
                     
                   DataRowView[] chkColumns = chkBoxFilter.CheckedItems.OfType<DataRowView>().ToArray();
                     checkedItems = string.Join(",", chkColumns.Select(x => x[0].ToString()));
                     string sql = "select  "+checkedItems+" from ipdbilling";

                     Reports.All_Patient rpt = new Reports.All_Patient();
                     DataTable dt = ReportQuery.rep_allpatientDetial(checkedItems);
                     rpt.SetDataSource(dt);
                     rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                     rpt.SetParameterValue("@Fdate", dtpFDate.Value.ToString("dd-MMM-yyyy"));
                     rpt.SetParameterValue("@Tdate", dtpTDate.Value.ToString("dd-MMM-yyyy"));
                     rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                     rpt.SetParameterValue("@User", UserInfo.UserName);
                     rpt.SetParameterValue("@Consultant", (string)cmbConsultant.SelectedValue == "All" ? "All" : (string)cmbConsultant.Text);

                     frm.rptViewer.ReportSource = rpt;

                     string query = "SELECT TOP 5 ";
                     bool isSelected = chkColumns.Cast<ListItem>().Count(i => i.Selected == true) > 0;
                     if (!isSelected)
                     {
                         chkColumns[0].Selected = true;
                     }
                     foreach (ListItem item in chkColumns.Items)
                     {
                         if (item.Selected)
                         {
                             query += item.Value + ",";
                             isSelected = true;
                         }
                     }
                     query = query.Substring(0, query.Length - 1);
                     query += " FROM Customers";
                 }*/
                #endregion
                //       CreateSelectQueryAndParameters();
                //  frmReportView.ShowBox("All patient Detail", chkLab.Checked == true ? "0" : "1", chkXray.Checked == true ? "0":"1",chkPharma.Checked== true ? "0":"1");
                Reports.dynamicRep drp;

                ReportDocument reportDocument;
                ParameterFields paramFields;

                ParameterField paramField;
                ParameterDiscreteValue paramDiscreteValue;



                reportDocument = new ReportDocument();
                paramFields = new ParameterFields();

                paramField = new ParameterField();
                paramField.Name = "@consultant";
                paramDiscreteValue = new ParameterDiscreteValue();
                paramDiscreteValue.Value = (string)cmbConsultant.SelectedValue == "All" ? "All" : (string)cmbConsultant.Text;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                string query = "";
                int columnNo = 0;

                if (chkLab.Checked == true)
                {
                    columnNo++;
                    query = query.Insert(query.Length, "laboratory AS Column" +
                    columnNo.ToString());

                    paramField = new ParameterField();
                    paramField.Name = "col" + columnNo.ToString();
                    paramDiscreteValue = new ParameterDiscreteValue();
                    paramDiscreteValue.Value = "laboratory";
                    paramField.CurrentValues.Add(paramDiscreteValue);
                    paramFields.Add(paramField);
                }
                if (chkXray.Checked == true)
                {
                    columnNo++;
                    if (query.Contains("Column"))
                    {
                        query = query.Insert(query.Length, ", ");
                    }
                    query = query.Insert(query.Length, "xray as Column" +
                    columnNo.ToString());

                    paramField = new ParameterField();
                    paramField.Name = "col" + columnNo.ToString();
                    paramDiscreteValue = new ParameterDiscreteValue();
                    paramDiscreteValue.Value = "Xray";
                    paramField.CurrentValues.Add(paramDiscreteValue);
                    paramFields.Add(paramField);
                }
                if (chkPharma.Checked == true)
                {
                    columnNo++;
                    if (query.Contains("Column"))
                    {
                        query = query.Insert(query.Length, ", ");
                    }
                    query = query.Insert(query.Length, "pharmacy as Column" +
                    columnNo.ToString());

                    paramField = new ParameterField();
                    paramField.Name = "col" + columnNo.ToString();
                    paramDiscreteValue = new ParameterDiscreteValue();
                    paramDiscreteValue.Value = "Pharmacy";
                    paramField.CurrentValues.Add(paramDiscreteValue);
                    paramFields.Add(paramField);
                }

                if (chkConsul.Checked == true)
                {
                    columnNo++;
                    if (query.Contains("Column"))
                    {
                        query = query.Insert(query.Length, ", ");
                    }
                    query = query.Insert(query.Length, "charges as Column" +
                    columnNo.ToString());

                    paramField = new ParameterField();
                    paramField.Name = "col" + columnNo.ToString();
                    paramDiscreteValue = new ParameterDiscreteValue();
                    paramDiscreteValue.Value = "Charges";
                    paramField.CurrentValues.Add(paramDiscreteValue);
                    paramFields.Add(paramField);
                }
                if (chkConsul.Checked == true)
                {
                    columnNo++;
                    if (query.Contains("Column"))
                    {
                        query = query.Insert(query.Length, ", ");
                    }
                    query = query.Insert(query.Length, "visits as Column" +
                    columnNo.ToString());

                    paramField = new ParameterField();
                    paramField.Name = "col" + columnNo.ToString();
                    paramDiscreteValue = new ParameterDiscreteValue();
                    paramDiscreteValue.Value = "Visits";
                    paramField.CurrentValues.Add(paramDiscreteValue);
                    paramFields.Add(paramField);
                }

                for (int i = columnNo; i < 5; i++)
                {
                    columnNo++;
                    paramField = new ParameterField();
                    paramField.Name = "col" + columnNo.ToString();
                    paramDiscreteValue = new ParameterDiscreteValue();
                    paramDiscreteValue.Value = "";
                    paramField.CurrentValues.Add(paramDiscreteValue);
                    paramFields.Add(paramField);
                }

                drp = new Reports.dynamicRep();
                DataTable dt = ReportQuery.rep_allpatientDetial(query, (string)cmbConsultant.SelectedValue , (string)cmbPatient.SelectedValue);
                frm.rptViewer.ParameterFieldInfo = paramFields;
                drp.SetDataSource(dt);
                frm.rptViewer.ReportSource = drp;

            }
            else if (Reportname == "Dialysis Patient Details")
            {

            }


            #endregion
            frm.Show();
        }

        private void frmReportParameters_Load(object sender, EventArgs e)
        {
            lblReport.Text = Reportname;
            this.Text = Reportname;
            bool Header = INIFile.ReadValue("ReportParameters", "ReportHeader") == "1" ? true : false;
            rdoWithHeader.Checked = Header;
            rdoWithoutHeader.Checked = !Header;
            string Fdate = "";
            string Tdate = "";
            if (Variable.iniDateNow == true)
            {
                Fdate = INIFile.ReadValue("RptParam_" + Reportname, "FDate", dtpFDate.Value.ToString("dd-MMM-yyyy"));
                Tdate = INIFile.ReadValue("RptParam_" + Reportname, "TDate", dtpTDate.Value.ToString("dd-MMM-yyyy"));
            }
            else
            {
                Fdate = DateTime.Now.ToString("dd-MMM-yyyy");
                Tdate = DateTime.Now.ToString("dd-MMM-yyyy");
            }

            dtpFDate.Value = DateTime.Parse(Fdate);
            dtpTDate.Value = DateTime.Parse(Tdate);
            #region Account Statement
            if (Reportname == "Account Statement")
            {
                grpAccounts.Location = new Point(91, 178);
                fillmcbAccounts();
                grpAccounts.Visible = true;
                grpDateRange.Location = new Point(91, 241);
                grpDateRange.Visible = true;
                dtpFDate.Focus();

                FillControls.FillcmbAccounts(cmbAccount);
                ManageControls(new Control[] { grpDateRange, grpAccounts });
            }
            #endregion
            #region Daily All User Income
            else if (Reportname == "Daily All User Income")
            {
                ManageControls(new Control[] { grpDateRange });
            }
            #endregion
            #region Member Invoice Detail
            else if (Reportname == "Member Invoice Detail")
            {
                ManageControls(new Control[] { grpDateRange, grpMember, grpActiveStatus ,grpGender});
                cmbStatus.SelectedIndex = 0;
            }
            #endregion
            #region Zakat Member Invoice Detail
            else if (Reportname == "Zakat Member Invoice Detail")
            {
                ManageControls(new Control[] { grpDateRange, grpMember, grpActiveStatus, grpOnlyZakat });
                cmbStatus.SelectedIndex = 0;
            }
            #endregion
            #region OPD Reference Detail
            else if (Reportname == "OPD Reference Detail")
            {
                FillControls.FillReferenceIndex(cmbReference);
                ManageControls(new Control[] { grpDateRange, grpReference });
            }
            #endregion

            #region ipd reference
            else if (Reportname == "IPD Reference Report")
            {
                FillControls.FillReferenceIndex(cmbReference);
                ManageControls(new Control[] { grpDateRange, grpReference });
                cmbReference.SelectedIndex = 0;
            }
            #endregion
            #region Room Wise Detail
            else if (Reportname == "Room Wise Detail")
            {

                ManageControls(new Control[] { grpDateRange, });

            }
            #region refund report
            else if (Reportname == "IPD refund summary")
            {

                ManageControls(new Control[] { grpDateRange, });

            }
            #endregion
            //
            #endregion
            #region Advance Collection Report
            else if (Reportname == "Advance Collection Report")
            {

                ManageControls(new Control[] { grpDateRange, grpUser });
                FillControls.FillUSer(cmbUser);
            }
            #endregion
            #region IPD Consultant Detail
            else if (Reportname == "IPD Consultant Detail")
            {

                ManageControls(new Control[] { grpDateRange });

            }
            #endregion
            #region BMJ Report Discharged
            else if (Reportname == "BMJ Report Discharged")
            {

                ManageControls(new Control[] { grpDateRange });

            }
            #endregion

            #region IPD test Summary
            else if (Reportname == "IPD Test Summary")
            {

                ManageControls(new Control[] { grpDateRange, grpAllCatagory, grpCatagoryTest,grpGender });
                FillControls.FillcmbAllTestCatagory(cmbAllCatagory);
                FillControls.FillcmbTest(cmbTest, "All");
                cmbAllCatagory.Text = "All";

            }
            #endregion
            #region admitted patient
            else if (Reportname == "Admitted Patient Report")
            {

                ManageControls(new Control[] { grpDateRange });

            }
            #endregion

            #region IPD / OPD Income Summary
            else if (Reportname == "IPD / OPD Income Summary")
            {
                ManageControls(new Control[] { grpDateRange });
            }
            else if (Reportname == "IPD / OPD Closing Summary")
            {
                ManageControls(new Control[] { grpDateRange });
            }
            #endregion
            #region Net Income Summary
            else if (Reportname == "Net Income Summary")
            {
                ManageControls(new Control[] { grpDateRange });
            }
            #endregion
            #region Gross Income Summary
            else if (Reportname == "Gross Income Summary")
            {
                ManageControls(new Control[] { grpDateRange });
            }
            #endregion
            #region OPD Catagory Wise Detail
            else if (Reportname == "OPD Catagory Wise Detail")
            {
                ManageControls(new Control[] { grpDateRange, grpCatagory, grpGender });
                FillControls.FillcmbTestCatagory(cmbCatagory);
            }
            #endregion
            #region OPD Consultant Wise Detail
            else if (Reportname == "OPD Consultant Wise Detail")
            {
                ManageControls(new Control[] { grpDateRange, grpConsultant });
                FillControls.FillcmbCunsultant(cmbConsultant);
            }
            #endregion
            #region OPD Consultant Summary
            else if (Reportname == "OPD Consultant Summary")
            {
                ManageControls(new Control[] { grpDateRange });
            }
            #endregion
            #region Consultant Ledger
            else if (Reportname == "Consultant Ledger")
            {
                ManageControls(new Control[] { grpDateRange, grpConsultant });
                FillControls.FillcmbCunsultant(cmbConsultant);
            }
            #endregion
            #region Member Detail
            else if (Reportname == "Member Detail")
            {
                ManageControls(new Control[] { grpActiveStatus });
            }
            else if (Reportname == "Client Nic Expiry")
            {
                ManageControls(new Control[] { grpDateRange });
            }
            #endregion

            #region DETAIL OF IN-PATIENT BILL
            else if (Reportname == "DETAIL OF IN-PATIENT BILL")
            {
                ManageControls(new Control[] { grpDateRange });
                FillControls.FillcmbCunsultant(cmbConsultant);
            }
            #endregion

            #region Discharged Report
            else if (Reportname == "Discharged Report")
            {
                ManageControls(new Control[] { grpDateRange });
                FillControls.FillcmbCunsultant(cmbConsultant);

            }
            #endregion

            #region  Due/Pending Amount Report
            else if (Reportname == "Due/Pending Amount Report")
            {
                ManageControls(new Control[] { grpDateRange });
                FillControls.FillcmbCunsultant(cmbConsultant);
            }
            #endregion

            #region Consultant IPD Summary
            else if (Reportname == "Consultant IPD Summary")
            {
                ManageControls(new Control[] { grpDateRange });
                FillControls.FillcmbCunsultant(cmbConsultant);
            }
            else if (Reportname == "SPD / ZF Report")
            {
                ManageControls(new Control[] { grpDateRange });
                FillControls.FillcmbCunsultant(cmbConsultant);
            }
            

            #endregion

            #region DisCharge Patient Bill Detail
            else if (Reportname == "DisCharge Patient Bill Detail")
            {
                ManageControls(new Control[] { grpDateRange });
                FillControls.FillcmbCunsultant(cmbCatagory);
            }

            #endregion

            #region Laboratory Statement Report
            else if (Reportname == "Laboratory Statement")
            {
                ManageControls(new Control[] { grpDateRange });

            }
            #endregion
            #region Zakat Recipient
            else if (Reportname == "Zakat Recipient")
            {
                ManageControls(new Control[] { grpZakatRecipient });
                FillControls.FillcmbZakatReference(cmbZakatReference);
            }
            #endregion
            #region package detail
            else if (Reportname == "Package Detail")
            {
                ManageControls(new Control[] { grpDateRange });

            }
            #endregion
            #region BMG MEMBER
            else if (Reportname == "BMG Member")
            {
                ManageControls(new Control[] { grpActiveUnActive, grpBMGmember,grpGender });
                FillControls.FillBMGMember(cmbBMGMember);
            }
            #endregion
            #region In-Patient Closing
            else if (Reportname == "In-Patient Closing")
            {
                ManageControls(new Control[] { grpDateRange, grpUser });
                FillControls.FillUSer(cmbUser);
            }
            #endregion

            #region OPD Test Receipt Detail
            else if (Reportname == "OPD Test Receipt Detail")
            {
                ManageControls(new Control[] { grpDateRange, grpAllCatagory, grpCatagoryTest,grpGender });
                FillControls.FillcmbAllTestCatagory(cmbAllCatagory);
                FillControls.FillcmbCatagoryTest(cmbTest, "");
                cmbAllCatagory.Text = "All";

                /* ManageControls(new Control[] { grpDateRange, grpAllCatagory, grpCatagoryTest });
                FillControls.FillcmbAllTestCatagory(cmbAllCatagory);
                FillControls.FillcmbTest(cmbTest, "");
                cmbAllCatagory.Text = "All";*/
            }
            //      cmbAllCatagory.SelectedIndexChanged += new EventHandler(cmbAllCatagory_SelectedIndexChanged); 
            #endregion

            #region Trial Balance

            else if (Reportname == "Trial Balance")
            {
                ManageControls(new Control[] { grpDateRange });

            }
            #endregion
            #region consultant share details
            else if (Reportname == "Consultant share details")
            {

                ManageControls(new Control[] { grpDateRange });

            }
            #region ipd consultant surgery detail
            else if (Reportname == "ipd consultant surgery detail")
            {
                ManageControls(new Control[] { grpDateRange, grpConsultant, grpPackage });
                FillControls.FillcmbCunsultant(cmbConsultant);
                FillControls.FillpackageIndex(cmbPackage, "All");
                cmbConsultant.Text = "All";
            }
            #endregion
            #endregion

            #region consultant visit
            else if (Reportname == "In-Patient Consultant visit details")
            {
                ManageControls(new Control[] { grpDateRange, grpConsultant });
                FillControls.FillcmbCunsultant(cmbConsultant);
            }
            #region all patient detail

            else if (Reportname == "All Patient Detail")
            {
                ManageControls(new Control[] { grpDateRange, grpConsultant, grpFilter,grpPatien });
                FillControls.FillcmbCunsultant(cmbConsultant);
                FillControls.FillcmbPatient(cmbPatient);

            }
            else if (Reportname == "Session Patient Report")
            {
                ManageControls(new Control[] { grpdate, grpDateRange, grpfile });
            }
            else if (Reportname == "Partially Payment Pending Report")
            {
                ManageControls(new Control[] { grpdate, grpDateRange, grpConsultant, grpfile });
                FillControls.FillcmbCunsultant(cmbConsultant);
            }
            else if (Reportname == "Surgery Wise Details Report")
            {
                ManageControls(new Control[] { grpDateRange, grpPackage });
                FillControls.FillpackageIndex(cmbPackage, "All");
            }
            else if (Reportname == "Doctor Wise Report")
            {
                ManageControls(new Control[] { grpDateRange,grpPackage });
                FillControls.FillpackageIndex(cmbPackage, "All");
            }
            else if (Reportname == "Total Surgeries Report")
            {
                ManageControls(new Control[] { grpDateRange});
            }
            else if (Reportname == "OPD Fund Utilization Report")
            {
                ManageControls(new Control[] { grpDateRange, grpAllFundType, grpGender });
            }
            else if (Reportname == "IPD Fund Utilization Report")
            {
                ManageControls(new Control[] { grpDateRange, grpAllFundType, grpGender });
            }
            else if (Reportname == "OPD Cash In Hand")
            {
                ManageControls(new Control[] { grpDateRange });
            }
            else if (Reportname == "IPD Cash In Hand")
            {
                ManageControls(new Control[] { grpDateRange});
            }
            else if (Reportname == "Discrepancies in vouchers")
            {
                ManageControls(new Control[] { });
            }
            #endregion
            #endregion

            #region
            else if (Reportname == "MMC-Hussaini Lab Report")
            {
                ManageControls(new Control[] { grpCatagory });
                FillControls.FillcmbAllTestCatagory(cmbAllCatagory);
            }
            #endregion
            
            #endregion
            FLogIn = false;
        }

        void cmbAllCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillControls.FillcmbCatagoryTest(cmbTest, cmbAllCatagory.SelectedValue.ToString());
        }
        private void rdoViewReport_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < chklstAccounts.Items.Count; i++)
            {
                chklstAccounts.SetItemChecked(i, chkSelectAll.Checked);

            }
        }
        private void frmReportParameters_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }
        private void txtAccountCode_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)cmbAccount.DataSource;
            DataRow dr = dt.Select(cmbAccount.ValueMember + " like  '%" + txtAccountCode.Text + "'").FirstOrDefault();
            if (dr != null)
                cmbAccount.SelectedValue = dr[cmbAccount.ValueMember];
        }
        private void rdoWithoutHeader_CheckedChanged(object sender, EventArgs e)
        {
            INIFile.WriteValue("ReportParameters", "ReportHeader", rdoWithHeader.Checked ? "1" : "0");
        }
        private void dtpFDate_ValueChanged(object sender, EventArgs e)
        {
            INIFile.WriteValue("RptParam_" + Reportname, "FDate", dtpFDate.Value.ToString("dd-MMM-yyyy"));
        }
        private void dtpTDate_ValueChanged(object sender, EventArgs e)
        {
            INIFile.WriteValue("RptParam_" + Reportname, "TDate", dtpTDate.Value.ToString("dd-MMM-yyyy"));
        }
        private void rdbConsultantAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbConsultantAll.Checked)
            {
                cmbConsultant.SelectedIndex = -1;
                cmbConsultant.Enabled = false;
            }
            else
            {
                cmbConsultant.Enabled = true;
            }
        }
        private void rdbReferenceAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbReferenceAll.Checked)
            {
                cmbReference.SelectedIndex = -1;
                cmbReference.Enabled = false;
            }
            else
            {
                cmbReference.Enabled = true;
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbConsultantAll.Checked)
            {
                cmbCatagory.SelectedIndex = -1;
                cmbCatagory.Enabled = false;
            }
            else
            {
                cmbCatagory.Enabled = true;
            }
        }
        private void cmbCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cmbAllCatagory_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //FillControls.FillcmbCatagoryTest(cmbTest, cmbAllCatagory.SelectedValue.ToString()== "System.Data.DataRowView" ? "All" : cmbAllCatagory.SelectedValue.ToString());
        }
        private void cmbAllCatagory_Validated(object sender, EventArgs e)
        {
            FillControls.FillcmbTest(cmbTest, Convert.ToString(cmbAllCatagory.SelectedValue));
        }
        private void cmbConsultant_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cmbConsultant_Validated(object sender, EventArgs e)
        {
            FillControls.FillpackageIndex(cmbPackage, Convert.ToString(cmbConsultant.SelectedValue));
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
             
        }
        string Fdate = "";
        string Tdate = "";
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                grpDateRange.Enabled = false;
                Fdate = "ALL";
                Tdate = "ALL";
            }
            else
            {
                grpDateRange.Enabled = true;
                Fdate = dtpFDate.Value.ToString("dd MMM yyyy");
                Tdate = dtpTDate.Value.ToString("dd MMM yyyy");
            }
        }
        private void cmbfileno_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }     
        private void cmbAccount_Validated(object sender, EventArgs e)
        {
            if (cmbAccount.SelectedValue != null)
            {
                if (cmbAccount.SelectedValue.ToString() == "001001005002001")
                {
                    banks = new DataTable();
                    cmbBank.DataSource = banks;
                    banks = Query.MasterQueryEC("SELECT bankcode, bankname FROM hms.bankdetail WHERE status=0");

                    DataRow rw = banks.NewRow();
                    rw["bankcode"] = "";
                    banks.Rows.InsertAt(rw, 0);

                    cmbBank.DataSource = banks;
                    cmbBank.DisplayMember = "bankname";
                    cmbBank.ValueMember = "bankcode";
                    cmbBank.SelectedValue = "";

                    lblBank.Visible = true;
                    cmbBank.Visible = true;
                }
                else
                {
                    lblbk.Visible = false;
                    cmbBank.Visible = false;
                }
            }
            else
            {
                lblbk.Visible = false;
                cmbBank.Visible = false;
            }
            
        }
    }
}
