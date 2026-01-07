using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Globalization;
using System.Reflection;
using System.Drawing.Imaging;
using ERP.Forms;

namespace ERP
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        
        private void CompanyCetreLoc()
        {
            lblCompanyName.Location = new Point((this.Size.Width - lblCompanyName.Size.Width) / 2, lblCompanyName.Location.Y);
            lblUrCompanyName.Location = new Point((this.Size.Width - lblUrCompanyName.Size.Width) / 2, lblUrCompanyName.Location.Y);
            picLogo.Location = new Point((this.Size.Width - picLogo.Size.Width) / 2, (this.Size.Height - picLogo.Size.Height) / 2);
        }
        private void chartOfAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChartOfAcc frm = new frmChartOfAcc();
            frm.MdiParent = this;
            frm.Show();
        }
        Form frmLogin;
        Thread th;
        void INISetting()
        {
            INIFile MyINI = new INIFile(Application.StartupPath + "\\Settings.ini");
            ConfigInfo.PrinterName = INIFile.ReadValue("PrinterSetting", "Printer");
            //SoftwareInfo.Terminal  = INIFile.ReadValue("Application", "Terminal","001");
        }
        private void frmMain_Load(object sender, EventArgs e)

        {
            Validate();
            if (UserInfo.UserId == "Admin")
            {
                mnSoftwareAdministrator.Visible = true;
            }
            //String name = UserInfo.UserId;
            //if (name.Contains("A-") == true)
            //{
            //    UserInfo.UserId = "Admin";
            //}
            INISetting();
            StlblUserId.Text = UserInfo.UserName;
            this.Text = CompanyInfo.CompanyName;
            lblCompanyName.Text = CompanyInfo.CompanyName;
            ///lblUrCompanyName.Text = CompanyInfo.UrCompanyName;
            //AccountHead.Customer = "001002001001";
            //AccountHead.Farmer = "002001001001"; 
            AccountHead.CashInBank = "001001005002001";
            AccountHead.ClientAccount = "001001002001001";
            Variable.BranchCode = "001";
            CompanyCetreLoc();
            frmLogin = this.Owner;
            frmLogin.Hide();
            th = new Thread(Connection);
            th.Start();

            clsConnection.con.ClientId = UserInfo.UserId;
            stockBalanceToolStripMenuItem.Visible = false;
            incomeSummeryToolStripMenuItem.Visible = false;
            balanceSheetToolStripMenuItem.Visible = false;
            itemLedgerToolStripMenuItem.Visible = false;

        }
        private void frmMain_Shown(object sender, EventArgs e)
        {
            MainPait();
        }
        Bitmap Mainbmp;
        private void MainPait()
        {
            Mainbmp = new Bitmap(panel1.Width, panel1.Height);
            Graphics g = Graphics.FromImage(Mainbmp);
            g.CopyFromScreen(PointToScreen(panel1.Location), new Point(0, 0), panel1.Size);
            panel1.DrawToBitmap(Mainbmp, new Rectangle(Point.Empty, Mainbmp.Size));
            this.Controls.Remove(panel1);
            this.BackgroundImage = Mainbmp;

        }

        void it_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = (sender as ToolStripItem).Text;
            frm.MdiParent = this;
            frm.Show();
        }


        void Connection()
        {
            while (true)

            {
                try
                {
                    DataTable dt = Query.getData("select sysdate from  dual");
                    SoftwareInfo.ServerDate = (DateTime)dt.Rows[0][0];
                    //clsConnection.con.ClientInfo = ((DateTime)dt.Rows[0][0]).ToString("dd MMM yyyy hh:mm:ss tt ffff") + "|" + SoftwareInfo.Terminal + "|" + Application.ProductVersion;
                    clsConnection.con.ClientInfo = SoftwareInfo.Terminal + "|" + Application.ProductVersion;
                    lblServerDate.Text = ((DateTime)dt.Rows[0][0]).ToString("dd MMM yyyy hh:mm:ss tt");
                    //StConStatus.Text = clsConnection.con.State.ToString(); 
                }
                catch (Exception)
                {
                    try
                    {
                        //clsConnection.con = clsConnection.Con();
                        clsConnection.Con();
                    }
                    catch
                    {
                    }
                }
                Thread.Sleep(1000);
                //StConStatus.Text = clsConnection.con.State.ToString();
            }

        }

        private void paymentVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPVoucherNew frm = new frmPVoucherNew();
            frm.MdiParent = this;
            frm.Show();

        }

        private void narrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNarration frm = new frmNarration();
            frm.MdiParent = this;
            frm.Show();
        }

        private void receiptVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRVoucherNew frm = new frmRVoucherNew();
            frm.MdiParent = this;
            frm.Show();
        }



        private void unitsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }










        private void accountStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "Account Statement";
            frm.Show();

        }



        private void stockBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "Stock Balance";
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            ///th.Abort();
            //Application.Exit();
            Environment.Exit(0);

        }



        private void journalVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGeneralVoucher2 frm = new frmGeneralVoucher2();
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.X)
            {
                if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to exit this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        private void itemLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "Stock Ledger";
            frm.MdiParent = this;
            frm.Show();
        }

        private void incomeSummeryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "Income Summery";
            frm.MdiParent = this;
            frm.Show();
        }

        private void trialBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "Trial Balance";
            frm.MdiParent = this;
            frm.Show();
        }

        private void balanceSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "Balance Sheet";
            frm.MdiParent = this;
            frm.Show();
        }





        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            CompanyCetreLoc();
        }

        private void bankReconcilationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPostPV frm = new frmPostPV();
            frm.MdiParent = this;
            frm.Show();
        }

        private void abcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "abc";
            frm.MdiParent = this;
            frm.Show();

        }



        private void customerBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "Customer Bill";
            frm.MdiParent = this;
            frm.Show();
        }



        private void farmerBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "Farmer Bill";
            frm.MdiParent = this;
            frm.Show();
        }

        private void customerCurrentBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "Customer Current Bill";
            frm.MdiParent = this;
            frm.Show();
        }

        private void farmerCurrentBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "Farmer Current Bill";
            frm.MdiParent = this;
            frm.Show();
        }

        private void customerMandiBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "Customer Mandi Bill";
            frm.MdiParent = this;
            frm.Show();
        }

        private void farmerMandiBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "Farmer Mandi Bill";
            frm.MdiParent = this;
            frm.Show();
        }



        private void accountStatementToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "Account Statement (Urdu)";
            frm.MdiParent = this;
            frm.Show();
        }


        private void balanceDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "Balance Detail (Urdu)";
            frm.MdiParent = this;
            frm.Show();
        }

        private void milkDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "Milk Detail";
            frm.MdiParent = this;
            frm.Show();
        }

        private void mandiRateToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "U Mandi Rate";
            frm.MdiParent = this;
            frm.Show();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBackup frm = new frmBackup();
            frm.MdiParent = this;
            frm.ShowDialog();
        }



        private void milkDetailVehicleWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "Milk Detail Vehicle Wise";
            frm.MdiParent = this;
            frm.Show();
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmConfiguration frm = new Forms.frmConfiguration();
            frm.MdiParent = this;
            frm.Show();
        }

        private void chartOfAccountLevel5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChartOfAccLvl5 frm = new frmChartOfAccLvl5();
            frm.MdiParent = this;
            frm.Show();
        }



        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "Customer Current Bill 2";
            frm.MdiParent = this;
            frm.Show();
        }

        private void customerAggrementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "Customer Aggrement";
            frm.MdiParent = this;
            frm.Show();
        }

        private void farmerAggrementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "Farmer Aggrement";
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "Sale Milk Detail For 5 Days";
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "Purchase Milk Detail For 5 Days";
            frm.MdiParent = this;
            frm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://nubitsoft.com/");
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "Milk Difference";
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "Customer Bill Detail";
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "Farmer Bill Detail";
            frm.MdiParent = this;
            frm.Show();
        }


        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "Profit And Loss (Urdu)";
            frm.MdiParent = this;
            frm.Show();
        }



        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmChangepassword frm = new Forms.frmChangepassword();
            frm.MdiParent = this;
            frm.Show();
        }


        private void receiptDetailDayWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "Receipt Detail Day Wise";
            frm.MdiParent = this;
            frm.Show();
        }

        private void oPDReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOPDReceipt frm = new frmOPDReceipt();
            frm.MdiParent = this;
            frm.Show();

        }

        private void userSessionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmUserSession frm = new Forms.frmUserSession();
            frm.MdiParent = this;
            frm.Show();
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void picExit_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }
        private void picExit_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void dailyAllUsersIncomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "Daily All User Income";
            frm.MdiParent = this;
            frm.Show();
        }

        private void fileLoaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmVersionUpdater frm = new Forms.frmVersionUpdater();
            frm.MdiParent = this;
            frm.Show();
        }

        private void consultantDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultantInfo frm = new frmConsultantInfo();
            frm.MdiParent = this;
            frm.Show();
        }

        private void memberInvoiceDetail4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "Member Invoice Detail";
            frm.MdiParent = this;
            frm.Show();
        }

        private void referenceInvoiceDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "OPD Reference Detail";
            frm.MdiParent = this;
            frm.Show();
        }

        private void iPDOPDIncomeSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "IPD / OPD Income Summary";
            frm.MdiParent = this;
            frm.Show();
        }

        private void reportDesignerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.UltrasoundReportDesigner frm = new Forms.UltrasoundReportDesigner();
            frm.MdiParent = this;
            frm.Show();
        }

        private void securityLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void userControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserInfo.UserLevel == "Admin")
            {
                 frmUserInfo frm = new frmUserInfo();
                 frm.MdiParent = this;
                 frm.Show();
            }
        }

        private void testParametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmTestParameters frm = new Forms.frmTestParameters();
            frm.MdiParent = this;
            frm.Show();
        }

        private void netIncomeSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "Net Income Summary";
            frm.Show();
        }

        private void grossIncomeSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "Gross Income Summary";
            frm.Show();
        }

        private void labReortEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmLabReportEntry frm = new Forms.frmLabReportEntry();
            frm.MdiParent = this;
            frm.Show();
        }

        private void oPDConsultantWiseDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "OPD Catagory Wise Detail";
            frm.Show();
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "OPD Consultant Wise Detail";
            frm.Show();
        }

        private void oPDConsultantSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "OPD Consultant Summary";
            frm.Show();
        }

        private void masterRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmMasterRegister frm = new Forms.frmMasterRegister();
            frm.MdiParent = this;
            frm.Show();
        }

        private void headRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmMasterHead frm = new Forms.frmMasterHead();
            frm.MdiParent = this;
            frm.Show();
        }

        private void consultantLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "Consultant Ledger";
            frm.Show();
        }

        private void eSSALabRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmESSARegister frm = new Forms.frmESSARegister();
            frm.MdiParent = this;
            frm.Show();
        }

        private void testInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTest frm = new frmTest();
            frm.MdiParent = this;
            frm.Show();
        }

        private void memberInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMemberInfo frm = new frmMemberInfo();
            frm.MdiParent = this;
            frm.Show();
        }

        private void addmissionInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmAddmissionInfo frm = new Forms.frmAddmissionInfo();
            frm.MdiParent = this;
            frm.Show();
        }

        private void roomStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmRoomStatus frm = new Forms.frmRoomStatus();
            frm.MdiParent = this;
            frm.Show();
        }

        private void reportDesignerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.frmTemplateDesigner frm = new Forms.frmTemplateDesigner();
            frm.MdiParent = this;
            frm.Show();
        }

        private void receiptSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReceiptSearch frm = new ReceiptSearch();
            frm.MdiParent = this;
            frm.Show();
        }

        private void inPatientBillingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmIPDBilling frm = new Forms.frmIPDBilling();
            frm.MdiParent = this;
            frm.Show();
        }

        private void roomSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserInfo.UserLevel == "Admin")
            {
                frmRoomInfo frm = new frmRoomInfo();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void packageInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserInfo.UserLevel == "Admin")
            {
                PTPackages frm = new PTPackages();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void referenceInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReference frm = new frmReference();
            frm.MdiParent = this;
            frm.Show();
        }

        private void advanceReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPtAdvInfo frm = new frmPtAdvInfo();
            frm.MdiParent = this;
            frm.Show();
        }

        private void labTestRemarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLabRemarks frm = new frmLabRemarks();
            frm.MdiParent = this;
            frm.Show();
        }
        internal void Validate()
        {
            if (UserInfo.UserLevel == "Receptionist" || UserInfo.UserLevel == "Receptionist|In-Patient")
            {
                MainAccounts.Visible = false;
                MainSetup.Visible = false;
                MainReports.Visible = false;
                MainStatistics.Visible = true;
                MainUltraSound.Visible = false;
                MainInPatient.Visible = false;
                Mainlaboratory.Visible = false;
                SubMainbackup.Visible = false;
                SubMainrestore.Visible = false;
                SubMainconfiguration.Visible = false;
                SubMaintest.Visible = false;
                // SubMainReceipt.Visible = false;

                receiptSearchToolStripMenuItem.Visible = false;
                if (UserInfo.UserLevel == "Receptionist|In-Patient")
                {
                    MainAccounts.Visible = false;

                    MainReports.Visible = false;
                    MainStatistics.Visible = true;
                    Mainlaboratory.Visible = false;
                    MainUltraSound.Visible = false;
                    SubMainReportDesigner.Visible = false;

                    MainOutPatient.Visible = true;
                    SubMainbackup.Visible = false;
                    SubMainrestore.Visible = false;
                    SubMainconfiguration.Visible = false;
                    SubMaintest.Visible = false;
                    SubMainChartOfAccount.Visible = false;
                    SubMainDetailAccount.Visible = false;
                    SubMaincompanyInformation.Visible = false;
                    SubMainNarration.Visible = false;
                    SubMainConsultantInfo.Visible = false;
                    SubMainTestInformationToolStripMenuItem.Visible = false;
                    SubMainmemberInformationToolStripMenuItem.Visible = false;
                    userControlToolStripMenuItem.Visible = false;
                    securityLevelToolStripMenuItem.Visible = false;


                    packageInfoToolStripMenuItem.Visible = false;
                    referenceInfoToolStripMenuItem.Visible = false;

                    SubMainLabTestRemarks.Visible = false;
                    SubMainTestParameters.Visible = false;
                    SubMainLabTestRemarks.Visible = false;
                    MainInPatient.Visible = true;



                }

            }
            else if (UserInfo.UserLevel == "Accountant")
            {
                SubMainDetailAccount.Visible = false;
                SubMaincompanyInformation.Visible = false;
                SubMainNarration.Visible = false;
                SubMainConsultantInfo.Visible = false;
                SubMainTestInformationToolStripMenuItem.Visible = false;
                SubMainmemberInformationToolStripMenuItem.Visible = false;
                userControlToolStripMenuItem.Visible = false;
                securityLevelToolStripMenuItem.Visible = false;
                SubMainTestParameters.Visible = false;
                SubMainReportDesigner.Visible = false;
                roomSetupToolStripMenuItem.Visible = false;
                packageInfoToolStripMenuItem.Visible = false;
                referenceInfoToolStripMenuItem.Visible = false;
                SubMainLabTestRemarks.Visible = false;
                menuCatagoryInfo.Visible = false;
                MainOutPatient.Visible = false;
                MainInPatient.Visible = false;
                MainStatistics.Visible = false;
                stockBalanceToolStripMenuItem.Visible = false;
                itemLedgerToolStripMenuItem.Visible = false;
                trialBalanceToolStripMenuItem.Visible = true;
                incomeSummeryToolStripMenuItem.Visible = true;
                balanceSheetToolStripMenuItem.Visible = true;
                dailyAllUsersIncomeToolStripMenuItem.Visible = true;
                memberInvoiceDetail4ToolStripMenuItem.Visible = true;
                referenceInvoiceDetailToolStripMenuItem.Visible = true;
                iPDOPDIncomeSummaryToolStripMenuItem.Visible = true;
                netIncomeSummaryToolStripMenuItem.Visible = true;
                grossIncomeSummaryToolStripMenuItem.Visible = true;
                oPDConsultantWiseDetailToolStripMenuItem.Visible = true;
                oPDConsultantSummaryToolStripMenuItem.Visible = true;
                consultantLedgerToolStripMenuItem.Visible = true;
                inPatientToolStripMenuItem.Visible = true;
                oPDTestReceiptDetailToolStripMenuItem.Visible = true;
                labStatementToolStripMenuItem.Visible = true;
                zakatRecipientToolStripMenuItem.Visible = true;
                bMGMemberToolStripMenuItem.Visible = true;
                zakatMemberInvoiceDetailToolStripMenuItem.Visible = true;
                SubMainbackup.Visible = false;
                SubMainrestore.Visible = false;
                SubMainconfiguration.Visible = false;
                SubMaintest.Visible = false;
                mnSoftwareAdministrator.Visible = false;
                MainUltraSound.Visible = false;
                Mainlaboratory.Visible = false;
                toolStripMenuItem1.Visible = false;
                SubMainNarration.Visible = true;
                bankAccountToolStripMenuItem.Visible = true;



            }
            else if (UserInfo.UserLevel == "Laboratory")
            {
                MainAccounts.Visible = false;

                MainReports.Visible = false;
                MainStatistics.Visible = false;
                MainUltraSound.Visible = false;


                MainManagement.Visible = false;
                SubMainReceipt.Visible = false;
                SubMainbackup.Visible = false;
                SubMainrestore.Visible = false;
                SubMainconfiguration.Visible = false;
                SubMaintest.Visible = false;
                SubMainChartOfAccount.Visible = false;
                SubMainDetailAccount.Visible = false;
                SubMaincompanyInformation.Visible = false;
                SubMainNarration.Visible = false;
                SubMainConsultantInfo.Visible = false;
                SubMainTestInformationToolStripMenuItem.Visible = false;
                SubMainmemberInformationToolStripMenuItem.Visible = false;
                userControlToolStripMenuItem.Visible = false;
                securityLevelToolStripMenuItem.Visible = false;
                SubMainReportDesigner.Visible = false;
                roomSetupToolStripMenuItem.Visible = false;
                packageInfoToolStripMenuItem.Visible = false;
                referenceInfoToolStripMenuItem.Visible = false;
                MainInPatient.Visible = false;
                menuCatagoryInfo.Visible = false;


                MainInPatient.Visible = true;
                addmissionInfoToolStripMenuItem.Visible = false;
                advanceReceiptToolStripMenuItem.Visible = false;
                roomStatusToolStripMenuItem.Visible = false;
                inPatientBillingToolStripMenuItem.Visible = false;
                inPatientRefundInformationToolStripMenuItem.Visible = false;
                birthInfoToolStripMenuItem.Visible = false;
                inPatientSearchToolStripMenuItem.Visible = false;
                inRecToolStripMenuItem.Visible = true;
                //MainOutPatient.Visible = false;

            }
            else if (UserInfo.UserLevel == "Ultrasound")
            {
                MainAccounts.Visible = false;

                MainReports.Visible = false;
                MainStatistics.Visible = false;
                Mainlaboratory.Visible = false;


                MainManagement.Visible = false;
                SubMainReceipt.Visible = false;
                SubMainbackup.Visible = false;
                SubMainrestore.Visible = false;
                SubMainconfiguration.Visible = false;
                SubMaintest.Visible = false;
                SubMainChartOfAccount.Visible = false;
                SubMainDetailAccount.Visible = false;
                SubMaincompanyInformation.Visible = false;
                SubMainNarration.Visible = false;
                SubMainConsultantInfo.Visible = false;
                SubMainTestInformationToolStripMenuItem.Visible = false;
                SubMainmemberInformationToolStripMenuItem.Visible = false;
                userControlToolStripMenuItem.Visible = false;
                securityLevelToolStripMenuItem.Visible = false;

                roomSetupToolStripMenuItem.Visible = false;
                packageInfoToolStripMenuItem.Visible = false;
                referenceInfoToolStripMenuItem.Visible = false;
                MainInPatient.Visible = false;
                SubMainLabTestRemarks.Visible = false;
                SubMainTestParameters.Visible = false;
                menuCatagoryInfo.Visible = false;
                


            }
            else if (UserInfo.UserLevel == "In-Patient" || UserInfo.UserLevel == "Receptionist|In-Patient")
            {
                MainAccounts.Visible = false;

                MainReports.Visible = false;
                MainStatistics.Visible = true;
                Mainlaboratory.Visible = false;
                MainUltraSound.Visible = false;
                SubMainReportDesigner.Visible = false;

                MainOutPatient.Visible = false;
                SubMainbackup.Visible = false;
                SubMainrestore.Visible = false;
                SubMainconfiguration.Visible = false;
                SubMaintest.Visible = false;
                SubMainChartOfAccount.Visible = false;
                SubMainDetailAccount.Visible = false;
                SubMaincompanyInformation.Visible = false;
                SubMainNarration.Visible = false;
                SubMainConsultantInfo.Visible = false;
                SubMainTestInformationToolStripMenuItem.Visible = false;
                SubMainmemberInformationToolStripMenuItem.Visible = false;
                userControlToolStripMenuItem.Visible = false;
                securityLevelToolStripMenuItem.Visible = false;


                packageInfoToolStripMenuItem.Visible = false;
                referenceInfoToolStripMenuItem.Visible = false;

                SubMainLabTestRemarks.Visible = false;
                SubMainTestParameters.Visible = false;
                SubMainLabTestRemarks.Visible = false;
            }
            else if (UserInfo.UserLevel == "Audit")
            {
                MainAccounts.Visible = true;

                MainReports.Visible = true;
                MainStatistics.Visible = false;
                Mainlaboratory.Visible = false;
                MainOutPatient.Visible = false;
                MainsSetting.Visible = false;
                logoutToolStripMenuItem.Visible = false;
                MainUltraSound.Visible = false;
                MainSetup.Visible = false;
                MainManagement.Visible = false;
                SubMainReceipt.Visible = false;
                SubMainbackup.Visible = false;
                SubMainrestore.Visible = false;
                SubMainconfiguration.Visible = false;
                SubMaintest.Visible = false;
                SubMainChartOfAccount.Visible = false;
                SubMainDetailAccount.Visible = false;
                SubMaincompanyInformation.Visible = false;
                SubMainNarration.Visible = false;
                SubMainConsultantInfo.Visible = false;
                SubMainTestInformationToolStripMenuItem.Visible = false;
                SubMainmemberInformationToolStripMenuItem.Visible = false;
                userControlToolStripMenuItem.Visible = false;
                securityLevelToolStripMenuItem.Visible = false;

                roomSetupToolStripMenuItem.Visible = false;
                packageInfoToolStripMenuItem.Visible = false;
                referenceInfoToolStripMenuItem.Visible = false;
                MainInPatient.Visible = false;
                SubMainLabTestRemarks.Visible = false;
                SubMainTestParameters.Visible = false;
                menuCatagoryInfo.Visible = false;
                MainAccounts.Visible = true;
            }

            if (UserInfo.UserLevel == "Admin")
            {
                eCToolStripMenuItem.Visible = true;
                echoTemplateDesignerToolStripMenuItem.Visible = true;
            }

            if (UserInfo.UserLevel == "Echo")
            {
                MainAccounts.Visible = false;

                MainReports.Visible = false;
                MainStatistics.Visible = false;
                Mainlaboratory.Visible = false;


                MainManagement.Visible = false;
                SubMainReceipt.Visible = false;
                SubMainbackup.Visible = false;
                SubMainrestore.Visible = false;
                SubMainconfiguration.Visible = false;
                SubMaintest.Visible = false;
                SubMainChartOfAccount.Visible = false;
                SubMainDetailAccount.Visible = false;
                SubMaincompanyInformation.Visible = false;
                SubMainNarration.Visible = false;
                SubMainConsultantInfo.Visible = false;
                SubMainTestInformationToolStripMenuItem.Visible = false;
                SubMainmemberInformationToolStripMenuItem.Visible = false;
                userControlToolStripMenuItem.Visible = false;
                securityLevelToolStripMenuItem.Visible = false;

                roomSetupToolStripMenuItem.Visible = false;
                packageInfoToolStripMenuItem.Visible = false;
                referenceInfoToolStripMenuItem.Visible = false;
                MainInPatient.Visible = false;
                SubMainLabTestRemarks.Visible = false;
                SubMainTestParameters.Visible = false;
                menuCatagoryInfo.Visible = false;
                MainUltraSound.Visible = false;
                partialPaymentToolStripMenuItem.Visible = false;
                bankAccountToolStripMenuItem.Visible = false;
                SubMainReportDesigner.Visible = false;

                eCToolStripMenuItem.Visible = true;
                echoTemplateDesignerToolStripMenuItem.Visible = true;
            }

        }



        private void catagoryInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserInfo.UserLevel == "Admin")
            {


                frmTestCatagoryInfo frm = new frmTestCatagoryInfo();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void inPatientRefundInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRefundInformation frm = new frmRefundInformation();
            frm.MdiParent = this;
            frm.Show();
        }

        private void detailOfInPatientBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Deu/Pending Amount Report
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "DETAIL OF IN-PATIENT BILL";
            frm.Show();

        }

        private void deuPendingAmountReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "Due/Pending Amount Report";
            frm.Show();
        }

        private void dischargedReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "Discharged Report";
            frm.Show();
        }

        private void consultantIPDSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "Consultant IPD Summary";
            frm.Show();


        }

        private void disChargePatientBillDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "DisCharge Patient Bill Detail";
            frm.Show();
        }

        private void birthInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmbirthinfo frm = new frmbirthinfo();
            frm.MdiParent = this;
            frm.Show();

        }

        private void inPatientSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInPatientSearch frm = new frmInPatientSearch();
            frm.MdiParent = this;
            frm.Show();
        }

        private void oPDTestReceiptDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "OPD Test Receipt Detail";
            frm.Show();
        }

        private void labReportEntry2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmLabReportEntry2 frm = new Forms.frmLabReportEntry2();
            frm.MdiParent = this;
            frm.Show();
        }


        private void currentCashStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCurrentCashStatus frm = new frmCurrentCashStatus();
            frm.MdiParent = this;
            frm.Show();
        }

        private void labStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "Laboratory Statement";
            frm.Show();
        }

        //private void laboratoryStatementToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmReportParameters frm = new frmReportParameters();
        //    frm.MdiParent = this;
        //    frm.Reportname = "Laboratory Statement";
        //    frm.Show();
        //}

        private void labToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "Laboratory Statement";
            frm.Show();
        }

        private void zakatRecipientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "Zakat Recipient";
            frm.Show();
        }

        private void bMGMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "BMG Member";
            frm.Show();
        }

        private void zakatMemberInvoiceDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "Zakat Member Invoice Detail";
            frm.Show();
        }

        private void inRecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InRecieptSearch frm = new InRecieptSearch();
            frm.MdiParent = this;
            frm.Show();
        }

        private void dailyCashStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "In-Patient Closing";
            frm.Show();
        }

        private void iPDReferenceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "IPD Reference Report";
            frm.Show();
        }

        private void bankReconcilationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBankReconciliation frm = new frmBankReconciliation();
            frm.MdiParent = this;
            frm.Show();
        }

        private void bankAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBankDetail frm = new FrmBankDetail();
            frm.MdiParent = this;
            frm.Show();
        }

        private void admittedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "Admitted Patient Report";
            frm.Show();
        }

        private void roomWiseDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "Room Wise Detail";
            frm.Show();
        }

        private void advanceCollectionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "Advance Collection Report";
            frm.Show();
        }

        private void iPDRefundSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "IPD refund summary";
            frm.Show();
        }

        private void iPDConsultantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "IPD Consultant Detail";
            frm.Show();
        }

        private void iPDTestSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "IPD Test Summary";
            frm.Show();
        }

        private void dischargeBMJMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "BMJ Report Discharged";
            frm.Show();
        }

        private void packageDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "Package Detail";
            frm.Show();
        }

        private void trialBalanceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "Trial Balance";
            frm.Show();
        }

        private void consultantChargesWithShareDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "Consultant share details";
            frm.Show();
        }

        private void consultantIPDSummaryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "Consultant IPD Summary";
            frm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)

        {
            Variable.iniDateNow = chkDate.Checked;
        }

        private void consultantSurgeryDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "ipd consultant surgery detail";
            frm.Show();
            
        }

        private void consultantVisitDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "In-Patient Consultant visit details";
            frm.Show();
        }

        private void allPatientDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "All Patient Detail";
            frm.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* frmLogIn frm = new frmLogIn();
            this.Hide();
            frm.Show();*/
        }

        private void existToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void dialysisPatientDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "Session Patient Report";
            frm.Show();
        }

        private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "SPD / ZF Report";
            frm.Show();
        }

        private void toolStripSeparator2_Click(object sender, EventArgs e)
        {

        }

        private void mnSoftwareAdministrator_Click(object sender, EventArgs e)
        {

        }

        private void MainSetup_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
           // Application.Exit();
        }

        private void bankToBankTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBankToBank frm = new frmBankToBank();
            frm.MdiParent = this;
            frm.Show();

           
        }

        private void partialPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PartialPayInfo frm = new PartialPayInfo();
            frm.MdiParent = this;
            frm.Show();
        }

        private void partiallyPaymentPendingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "Partially Payment Pending Report";
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reports.TESTReport rpt = new Reports.TESTReport();
            frmReportView frm = new frmReportView();
            frm.rptViewer.ReportSource = rpt;
            frm.Show();

        }

        private void MainReports_Click(object sender, EventArgs e)
        {

        }

        private void surgeryWiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "Surgery Wise Details Report";
            frm.Show();
        }

        private void doctorWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "Doctor Wise Report";
            frm.Show();
        }

        private void totalSurgeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "Total Surgeries Report";
            frm.Show();
        }

        private void oPDFundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "OPD Fund Utilization Report";
            frm.Show();
        }

        private void iPDFunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "IPD Fund Utilization Report";
            frm.Show();
        }

        private void oPDCashInHandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "OPD Cash In Hand";
            frm.Show();
        }

        private void toolStripMenuItem5_Click_1(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "IPD Cash In Hand";
            frm.Show();
        }

        private void OPDCashInHandToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "OPD Cash In Hand";
            frm.Show();
        }

        private void toolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "Discrepancies in vouchers";
            frm.Show();
        }

        private void toolStripMenuItem6_Click_1(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.MdiParent = this;
            frm.Reportname = "IPD / OPD Closing Summary";
            frm.Show();
        }

        private void echoCardioGraphyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.EchoCardioGraphy frm = new Forms.EchoCardioGraphy();
            frm.MdiParent = this;
            frm.Show();
        }

        private void echoTemplateDesignerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.EchoTemplateDesigner frm = new Forms.EchoTemplateDesigner();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mMCHussainiLabReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "MMC-Hussaini Lab Report";
            frm.MdiParent = this;
            frm.Show();*/
            Forms.frmHussainiReportEntry frm = new Forms.frmHussainiReportEntry();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tellerClosingVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTellerClosingVoucher frm = new frmTellerClosingVoucher();
            frm.MdiParent = this;
            frm.Show();
        }

        //private void consultantIPDSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmReportParameters frm = new frmReportParameters();
        //    frm.Reportname = "Consultant IPD Summary";
        //    frm.Show();
        //}

        //private void refundSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmReportParameters frm = new frmReportParameters();
        //    frm.Reportname = "Refund Summary";
        //    frm.Show();
        //}

        //private void advanceCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmReportParameters frm = new frmReportParameters();
        //    frm.Reportname = "Advance Collection";
        //    frm.Show();
        //}
    }
}
