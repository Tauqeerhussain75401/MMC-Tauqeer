using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace ERP
{
    public partial class frmLogIn : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hwnd);
        public frmLogIn()
        {
            InitializeComponent();
        }
        private void frmLogIn_Load(object sender, EventArgs e)
        {
                CheckApplicationOpen();
                this.Text = "ERP Version(" + Application.ProductVersion + ")"; 
                UserInfo.UserId = "Log Out";
                thConnecting = new Thread(Connecting);
                thConnecting.Start();

           
        }

        Thread thConnecting;
        #region Cross Thread Delegate Info

        public delegate void BtnLogInEnableDelegate(bool Enable);
        public delegate void tsslMsgDelegate(string Text);
        public delegate void txtTerminalIdDelegate(string Text);
        public delegate void progressBarDelegate(bool Visible);
        public void BtnLogInEnable(bool Enable)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new BtnLogInEnableDelegate(BtnLogInEnable),Enable );
            }
            else
            {
                btnLogIn.Enabled = Enable;
            }
        }
        public void ProgressBarVisChg(bool Visible)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new progressBarDelegate(ProgressBarVisChg), Visible);
            }
            else
            {
                progressBar1.Visible  = Visible;
                  
            }
        }
        public void tsslMsgChg(string Text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new tsslMsgDelegate(tsslMsgChg), Text);
            }
            else
            {
                tsslMsg.Text  = Text;
            }
        }
        public void txtTerminalIdChg(string Text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new txtTerminalIdDelegate(txtTerminalIdChg), Text);
            }
            else
            {
                txtTerminalId.Text = Text;
            }
        }

        #endregion

        void Connecting()
        {
            ProgressBarVisChg(true);            
            BtnLogInEnable(false);
            tsslMsgChg("Connecting to Server...,");
            clsConnection.Con();
            clsConnection.con.ClientId = UserInfo.UserId;
            ////temporary////
            tsslMsgChg("Getting Organization Information...,");
            DataTable dt = Query.get_CompanyInfo();
            CompanyInfo.CompanyName = dt.Rows[0]["CompanyName"].ToString();
            CompanyInfo.UrCompanyName = dt.Rows[0]["UrCompanyName"].ToString();
            CompanyInfo.Address = dt.Rows[0]["Address"].ToString();
            CompanyInfo.ContactHead = dt.Rows[0]["ContactHead"].ToString();
            CompanyInfo.CellTitle = dt.Rows[0]["ContactPerson"].ToString();
            CompanyInfo.Cell = dt.Rows[0]["Cell"].ToString();
            CompanyInfo.Cell2Title = dt.Rows[0]["ContactPerson2"].ToString();
            CompanyInfo.Cell2 = dt.Rows[0]["Cell2"].ToString();

            ////////////////////
            //////////////////////// Getting Terminal Id
            tsslMsgChg("Getting Terminal Id...,");
            string ProcessorId = HardwareInfo.GetProcessorId();
            string HDDSerialNo = "";// HardwareInfo.GetHDDSerialNo();
            string ComputerName = HardwareInfo.GetComputerName();
            string MacAddress = HardwareInfo.GetMACAddress();
            string TerminalId = Query.get_TerminalId(ProcessorId, HDDSerialNo, ComputerName);
            if (CompanyInfo.CompanyName == "MEMON MEDICAL COMPLEX")
            {
                SoftwareInfo.Terminal = "MMC-" + TerminalId;
            }
            else
            {
                SoftwareInfo.Terminal = "BEH-" + TerminalId;
            }
            
            txtTerminalIdChg(SoftwareInfo.Terminal);
            tsslMsgChg("Check Updates...,");
            DataTable dtVersion = Query.getData("select version from softwareupdates where version != '" + Application.ProductVersion + "'");
            if (dtVersion.Rows.Count > 0)
            {
                tsslMsgChg("Downloading Updates...,");
                //MessageBox.Show("Please update software this version are different " + Application.ProductVersion + "'");
                GetFile();
                //Thread th;
                //th = new Thread(GetFile);
                //th.Start();
            }
            tsslMsgChg("ready");
            ////////////////////////////////
            ProgressBarVisChg(false);
            BtnLogInEnable(true);
        }

        static void ChangeFile(string Newfile, string Origfile, Process process)
        {
            File.Replace(Newfile, Origfile, Newfile + "old");
        }
        void GetFile()
        {
            try
            {
                //if (!Directory.Exists(Application.StartupPath + "\\UpdateFiles"))
                //        {
                //            Directory.CreateDirectory(Application.StartupPath + "\\UpdateFiles");

                //        }
                // Query.getUpdateFile(Application.ProductVersion, Application.StartupPath + "\\UpdateFiles\\ERP.exe");

                //    VersionUpdater.Program prog = new VersionUpdater.Program();
                //    VersionUpdater.Program.ChangeFile(Application.StartupPath + "\\UpdateFiles\\ERP.exe", Application.StartupPath + "\\ERP.exe", Process.GetCurrentProcess());
                //    Application.Restart();    
            }
            catch (Exception)
            {
                try
                {
                                      
                }
                catch
                {
                }
            }
            
        }
        
        private static void CheckApplicationOpen()
        {
            Process currentProcess = Process.GetCurrentProcess();
            Process[] proc = Process.GetProcessesByName(currentProcess.ProcessName);
            int a = Convert.ToInt16(proc.Count().ToString());
            if (a > 1)
            {
                if (MessageBox.Show("This application is already running...! " + Environment.NewLine + "You want to exit privious running application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (Process item in proc)
                    {
                        if (item.Id != currentProcess.Id)
                        {
                            item.Kill();
                        }
                    }
                }
                else
                {
                    foreach (Process item in proc)
                    {
                        if (item.Id != currentProcess.Id)
                        {
                            SetForegroundWindow(item.MainWindowHandle);
                            break;
                        }
                    }
                    currentProcess.Kill();
                }
            }
        }
        private void btnLogIn_Click(object sender, EventArgs e)
        {
 
            ////////////////////////////

            progressBar1.Visible = true;
            Cursor.Current = Cursors.WaitCursor;  
            DataTable dtUsers = Query.UserDetail(txtUserId.Text);
            if (dtUsers.Rows.Count > 0)
            {
                if (dtUsers.Rows[0]["islock"].ToString() == "1")
                {
                    MessageBox.Show("Your Account is locked..!");  
                    return;
                }
                if (dtUsers.Rows[0]["Password"].ToString() == txtPassword.Text)
                {
                    frmMain frm = new frmMain();
                    frm.Owner = this;
                    UserInfo.UserId = (string )dtUsers.Rows[0]["userid"];
                    UserInfo.UserName  = (string)dtUsers.Rows[0]["username"];
                    UserInfo.UserLevel = dtUsers.Rows[0]["Userlevel"].ToString();
                    UserInfo.LogInDateTime = (DateTime)dtUsers.Rows[0]["LogIndate"];                                         
                    frm.ShowDialog();                    
                }
                else
                    MessageBox.Show("Invalid Password..!");  
            }
            else
                MessageBox.Show("Invalid User ID..!");
            progressBar1.Visible = false ;
            Cursor.Current = Cursors.Default;          
        }

        private void frmLogIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys .Enter )
            {
                SendKeys.Send("{tab}");  
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
               
        }

        

        





       
    }
}
