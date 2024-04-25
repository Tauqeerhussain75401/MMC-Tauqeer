using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
namespace ERP
{
    public partial class FrmConsultant : Form
    {
        bool FLogIn = true ;
        string FkimageId = "0";
        string ConsultantId = "0";
        public FrmConsultant()
        {
            InitializeComponent();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

        }
        private static Image VpicHRPicture;
        private static Image VpicHRSignature;
        private void FrmHRForm_Load(object sender, EventArgs e)
        {
            VpicHRPicture = picHRPicture.Image;
            VpicHRSignature = picHRSignature.Image;            
            CamLoad();            
            FLogIn = false ;
        }
        internal void fill(string ConsultantId)
        {
            //if (mcbHrId.SelectedIndex != -1)
            //{
                Cursor.Current = Cursors.WaitCursor;  
                DataTable dt = Query.ConsultantDetail (ConsultantId );
                if (dt.Rows.Count > 0)
                {
                    txtConsultantId.Text = ConsultantId; 
            //        txtPunchID.Text = dt.Rows[0]["punchid"].ToString();
            //        cmbMr.Text = dt.Rows[0]["hrmr_mrs"].ToString();
                    txtName.Text = dt.Rows[0]["Name"].ToString();
                    chkIsActive.Checked = dt.Rows[0]["isdeactivate"].ToString() == "1" ? false : true ;
                    ntxtConsultationCharges.Value = Convert.ToDecimal(dt.Rows[0]["HospitalRate"]);
                    ntxtInPatientShare.Value = Convert.ToDecimal(dt.Rows[0]["consultantshareindoor"]);
                    ntxtOutPatientShare.Value = Convert.ToDecimal(dt.Rows[0]["consultantshareoutdoor"]);
            //        cmbSelectFH.Text = dt.Rows[0]s["father_husband"].ToString();
            //        txtFHName.Text = dt.Rows[0]["father_husbandtitle"].ToString();
            //        dtpDOB.Value = (dt.Rows[0]["dob"].ToString() == "" ? null : dt.Rows[0]["dob"]);
            //        cmbGender.Text = dt.Rows[0]["gender"].ToString();
                    txtQualification.Text = dt.Rows[0]["degrees"].ToString();
                    txtFaculty.Text = dt.Rows[0]["Faculty"].ToString();
            //        txtReligion.Text = dt.Rows[0]["religion"].ToString();
            //        txtExperience.Text  = dt.Rows[0]["experience"].ToString();
            //        cmbMarital.Text = dt.Rows[0]["maritalstatus"].ToString();
            //        txtDependent.Text = dt.Rows[0]["dependent"].ToString();
            //        txtCNIC.Text = dt.Rows[0]["cnic"].ToString();
            //        txtFamilyNo.Text = dt.Rows[0]["cnicfamilyno"].ToString();
            //        dtpCNICExpiry.Value = (dt.Rows[0]["cnicexpiry"].ToString() == "" ? null : dt.Rows[0]["cnicexpiry"]);
            //        chkCNICLifeTime.Checked = (dt.Rows[0]["cniclifetime"].ToString() == "1" ? true : false);            
            //        txtRefDetail.Text = dt.Rows[0]["refdetail_phonenos"].ToString();
            //        mcbDesignation.SelectedValue = dt.Rows[0]["fkdesignationid"];
            //        mcbDepartment.SelectedValue = dt.Rows[0]["fkdepartmentid"];
            //        mcbLocation.SelectedValue = dt.Rows[0]["fkbranchid"];
            //        dtpAppointmentDate.Value = (dt.Rows[0]["appointmentdate"].ToString() == "" ? null : dt.Rows[0]["appointmentdate"]);//(DateTime )dt.Rows[0]["appointmentdate"];
            //        dtpJoiningDate.Value = (dt.Rows[0]["joiningdate"].ToString() == "" ? null : dt.Rows[0]["joiningdate"]);//(DateTime)dt.Rows[0]["joiningdate"];
            //        txtRemarks.Text = dt.Rows[0]["remarks"].ToString();
            //        dtpResignDate.Value = (dt.Rows[0]["resigndate"].ToString() == "" ? null : dt.Rows[0]["resigndate"]);//DateTime)dt.Rows[0]["resigndate"];
            //        txtResignReason.Text = dt.Rows[0]["resignreason"].ToString();            
            //        FkimageId = dt.Rows[0]["fkimageid"].ToString();
            //        picHRPicture.Image = Scanner.byteArrayToImage((byte[])dt.Rows[0]["pic"]);
            //        picHRSignature.Image = Scanner.byteArrayToImage((byte[])dt.Rows[0]["sig"]);
            
            //        txtCreatedBy.Text = dt.Rows[0]["createdby"].ToString();
            //        txtEditBy.Text = dt.Rows[0]["editby"].ToString();
            //        txtApprovedBy.Text = dt.Rows[0]["approvedby"].ToString(); 


 


                }
                Cursor.Current = Cursors.Default ;
            //}
        }
        
        private Image img;
        private void fromfile()
        {
            try
            {
                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = @":C:\Documents and Settings\Administrator\Desktop\icon\bmp";
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
                if (fldlg.ShowDialog() == DialogResult.OK)
                {
                    string file = fldlg.FileName;
                    Bitmap newimg = new Bitmap(file);
                    img = (Image)newimg;
                }
                fldlg = null;
            }
            catch (System.ArgumentException ae)
            {
             //   string result = MyMessageBox.ShowBox(ae.Message, Variable.Version, 1);
            }
            catch (Exception ex)
            {
               // string result = MyMessageBox.ShowBox(ex.Message, Variable.Version, 1);
            }

        }
        private FilterInfoCollection VideoCaptureDevices;
        private VideoCaptureDevice finalVideoSource;
        void CamLoad()
        {
            VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            //foreach (FilterInfo VideoCaptureDevice in VideoCaptureDevices)
            //{
            //   comboBox1.Items.Add(VideoCaptureDevice.Name);
            //}
        }
        private void btnHRSearch_Click(object sender, EventArgs e)
        {
            fromfile();
            if (rdoHRSelectPic.Checked)
            {
                picHRPicture.Image = img;
                picHRPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                picHRSignature.SizeMode = PictureBoxSizeMode.StretchImage;
                picHRSignature.Image = img;
            }
        }
        private void btnHRScan_Click(object sender, EventArgs e)
        {

        }
        private void btnCam_Click_1(object sender, EventArgs e)
        {        
            if (!FLogIn)
            {
                if (btnCam.Tag.ToString() == "On")
             
                {
                 

                    finalVideoSource.Stop();  
                   btnCam.Tag = "Off";
                }
                else
                {
                    if (VideoCaptureDevices.Count == 0)
                    {
                        MessageBox.Show("No Camera Found..!");
                        return;
                    }
                    btnCam.Tag = "On";
                    //if (VideoCaptureDevices.Count > 1 && !Variable.CamIsSelect)
                    //{
                    //    frmSelectCam popup = new frmSelectCam();
                    //    popup.ShowDialog();
                    //    Variable.CamIsSelect   = true;
                    //}
                    //else
                    //    Variable.CamIsSelect = false;
                    
                    finalVideoSource = new VideoCaptureDevice(VideoCaptureDevices[0].MonikerString);

                    finalVideoSource.NewFrame += new NewFrameEventHandler(finalVideoSource_NewFrame);
                    finalVideoSource.Start();  
                    
                }
            }
        }
        void finalVideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap image = (Bitmap)eventArgs.Frame.Clone();
            if (rdoHRSelectPic.Checked)
            {
                picHRPicture.Image = image ;

            }
            else
            {
                picHRSignature.Image = image;
            }
        }
        private void btnHRCancel_Click(object sender, EventArgs e)
        {
            if (rdoHRSelectPic.Checked)
            {
                picHRPicture.Image = VpicHRPicture;

            }
            else
            {
                picHRSignature.Image = VpicHRSignature;
            }
        }

       
        private void FrmHRForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (finalVideoSource != null && finalVideoSource.IsRunning)
            {
                finalVideoSource.Stop();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }
    }
}
