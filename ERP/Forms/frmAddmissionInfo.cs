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
    public partial class frmAddmissionInfo : Form
    {
        public frmAddmissionInfo()
        {
            InitializeComponent();
            ntxtRegNo.Text = "";
            FillControls.FillcmbPatientCatagory(cmbPatientType);
            FillControls.FillcmbMember(cmbMembership);
            FillControls.FillReferenceIndex(cmbReference);
            FillControls.FillcmbAreaIndex(cmbArea);
            FillControls.FillcmbCunsultant(cmbConsultant);
        }
        DataTable dtDependent = Query.MemberDependentIndex();
        DataTable dtDependentEmpty = new DataTable();
        bool FLogIn = true;
        void FillForm(bool All)
        {
            DataTable dt = Query.getData("SELECT * FROM vu_admissioninfo a where status = 0 " + (!All ? " and  rid <= 100 " : "") + " order by regnoalpha desc, to_number(regnonumeric) desc");
            dgvDetail.Rows.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgvDetail.Rows.Add(dt.Rows[i]["regnoalpha"].ToString() + "-" + dt.Rows[i]["regnonumeric"].ToString(),
                    dt.Rows[i]["admdate"],
                    dt.Rows[i]["admtime"],
                    dt.Rows[i]["bmjnewno"].ToString(),
                    dt.Rows[i]["title"].ToString(),
                    dt.Rows[i]["patientname"].ToString(),
                    dt.Rows[i]["roomname"].ToString(),
                    dt.Rows[i]["consultantname"].ToString(),
                     dt.Rows[i]["remarks"].ToString(),
                    dt.Rows[i]["relationname"].ToString(),
                    dt.Rows[i]["relation"].ToString(),

                    dt.Rows[i]["relationname"].ToString(),
                    dt.Rows[i]["age"].ToString(),
                    dt.Rows[i]["ymd"].ToString(),
                    dt.Rows[i]["gender"].ToString(),
                    dt.Rows[i]["address"].ToString(),
                    dt.Rows[i]["referencename"].ToString(),
                    //dt.Rows[i]["admittedfor"].ToString(),
                    dt.Rows[i]["emergency"].ToString(),
                    dt.Rows[i]["createdby"].ToString(),
                    dt.Rows[i]["CNIC"].ToString(),
                    dt.Rows[i]["CnicRelation"].ToString()

                    );
            }

        }
        string RoomId = "";
        DataTable dtDetail;
   
        void FillDetail()
        {
            dtDetail = Query.getData("SELECT a.*,get_roomTitle(roomid) roomname FROM admissioninfo a where regnoalpha = '" + txtRegAlpha.Text + "' and regnonumeric = '" + ntxtRegNo.Text + "'");
            if (dtDetail.Rows.Count > 0)
            {
                txtSerialNo.Text = dtDetail.Rows[0]["serialno"].ToString();
                txtRegAlpha.Text = dtDetail.Rows[0]["regnoalpha"].ToString();
                ntxtRegNo.Text = dtDetail.Rows[0]["regnonumeric"].ToString();
                dtpDate.Value = (DateTime)dtDetail.Rows[0]["admdate"];
                dtpTime.Value = (DateTime)dtDetail.Rows[0]["admtime"];
                txtRoom.Text = dtDetail.Rows[0]["roomname"].ToString();
                RoomId = dtDetail.Rows[0]["roomid"].ToString();
               // cmbPatientTitle.Text = dtDetail.Rows[0]["title"].ToString();
                //cmbPatientId.Text = dtDetail.Rows[0]["patientname"].ToString();
                cmbPatientType.SelectedValue = dtDetail.Rows[0]["patienttype"];
                cmbMembership.SelectedValue = dtDetail.Rows[0]["bmjnewno"];
                cmbPatientTitle.Text = dtDetail.Rows[0]["title"].ToString();
                cmbPatientId.Text = dtDetail.Rows[0]["patientname"].ToString();
                cmbGender.Text = dtDetail.Rows[0]["gender"].ToString();
                ntxtAge.Text = dtDetail.Rows[0]["age"].ToString();
                cmbAgeUnit.Text = dtDetail.Rows[0]["ymd"].ToString();
                //txtRelation.Text = dt.Rows[0]["relationname"].ToString();
                //cmbRelationType.Text = dt.Rows[0]["relation"].ToString();
                txtRelation.Text = dtDetail.Rows[0]["relationname"].ToString();
                cmbRelationType.Text = dtDetail.Rows[0]["relation"].ToString();

                txtCnic.Text = dtDetail.Rows[0]["cnic"].ToString();
                cmbCnicRelation.Text = dtDetail.Rows[0]["CnicRelation"].ToString();
                txtCNICPerson.Text = dtDetail.Rows[0]["CNICPerson"].ToString();
                cmbConsultant.SelectedValue = dtDetail.Rows[0]["consultantid"];
                txtReason.Text = dtDetail.Rows[0]["admittedfor"].ToString();
                cmbReference.SelectedValue = dtDetail.Rows[0]["referenceid"];
                txtRemarks.Text = dtDetail.Rows[0]["remarks"].ToString();
                cmbCity.SelectedIndex = Convert.ToInt32(dtDetail.Rows[0]["cityid"].ToString());
                cmbArea.SelectedValue = dtDetail.Rows[0]["areaid"];
                txtAddress.Text = dtDetail.Rows[0]["address"].ToString();
                txtEmergency.Text = dtDetail.Rows[0]["emergency"].ToString();
                txtMobile.Text = dtDetail.Rows[0]["mobile"].ToString();
                txtOtherContact.Text = dtDetail.Rows[0]["othercontact"].ToString();
                txtEmail.Text = dtDetail.Rows[0]["email"].ToString();

                lblUserName.Text = dtDetail.Rows[0]["createdby"].ToString();
                lblUserName.Visible = true;

                #region basit commit old code from this date 18/08/2020
                /*
                if (dtDetail.Rows[0]["dischargeyn"].ToString() == "1")
                {
                    grpBasicInfo.Enabled = false;
                    grpContact.Enabled = false;
                }
                else
                {
                    grpBasicInfo.Enabled = true;
                    grpContact.Enabled = true;
                }
                */
                #endregion


                #region basit write new code from this date 18/08/2020
                if (UserInfo.UserLevel == "Admin")
                {
                    //if (dtDetail.Rows[0]["dischargeyn"].ToString() == "1")
                    //{
                        //DialogResult dr = MessageBox.Show(txtRegAlpha.Text + " - " + ntxtRegNo.Text + " Are you sure , you want to update discharge patient recorde ?", "Question...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        //if (dr == DialogResult.Yes)
                        //{
                            grpBasicInfo.Enabled = true;
                            grpContact.Enabled = true;
                        //}
                        //else
                        //{
                        //    grpBasicInfo.Enabled = false;
                        //    grpContact.Enabled = false;
                        //}
                    //}
                    //else
                    //{
                    //    grpBasicInfo.Enabled = true;
                    //    grpContact.Enabled = true;
                    //    UserRights();
                    //}
                }
                else
                {
                    if (dtDetail.Rows[0]["dischargeyn"].ToString() == "1")
                    {
                         grpBasicInfo.Enabled = false;
                         grpContact.Enabled = false;
                    }
                    else
                    {
                        grpBasicInfo.Enabled = true;
                        grpContact.Enabled = true;
                        //UserRights();
                    }

                }

                if (txtSerialNo.Text != "")
                {
                    MessageBox.Show(txtRegAlpha.Text + "-" + ntxtRegNo.Text + "  this file is ready for Update !");
                }
                #endregion
              
            }          
        }
       
        public void UserRights()
        {
            //cmbPatientType.Enabled = true;
            //cmbPatientId.Enabled = true;
            //txtRemarks.Enabled = true;
            //txtReason.Enabled = true;
            //txtOtherContact.Enabled = true;
            //cmbReference.Enabled = true;
            //cmbPatientTitle.Enabled = true;

            
            //cmbGender.Enabled = false;
            //ntxtAge.Enabled = false;
            //cmbAgeUnit.Enabled = false;
            //txtRelation.Enabled = false;
            //cmbRelationType.Enabled = false;
            //cmbConsultant.Enabled = false;
            //cmbCity.Enabled = false;
            //txtEmergency.Enabled = false;
            //cmbArea.Enabled = false;
            //txtMobile.Enabled = false;
            //txtAddress.Enabled = false;
            //txtEmail.Enabled = false;
            
        }

        private void frmAddmissionInfo_Load(object sender, EventArgs e)
        {
            CurrentDateTime();
            if (UserInfo.UserLevel != "Admin")
            {
                //dtpDate.Value = DateTime.Now;
                //dtpTime.Value = DateTime.Now;
                CurrentDateTime();
                dtpDate.Enabled = false;
                dtpTime.Enabled = false;

            }

            FillForm(false);
            dtDependentEmpty = dtDependent.Copy();
            dtDependentEmpty.Rows.Clear();
            FLogIn = false;
            New();
            cmbCnicRelation.SelectedIndex = 0;
        }
        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string[] RegNo = dgvDetail.Rows[e.RowIndex].Cells[clnReg.Index].Value.ToString().Split('-');
                txtRegAlpha.Text = RegNo[0];
                ntxtRegNo.Text = RegNo[1];
                FillDetail();
            }
            catch (Exception ex)
            {
                    
            }        
        }
        private void txtRegAlpha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FillDetail();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnRoomSearch_Click(object sender, EventArgs e)
        {
            frmRoomStatus frm = new frmRoomStatus();
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtRoom.Text = frm.roomName;
                RoomId = frm.roomId;
            }
        }

        private void cmbPatientType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView dr = (DataRowView)cmbPatientType.SelectedItem;
            if (dr != null && dr["hasMemberShip"].ToString() == "1")
            {
                cmbMembership.Visible = true;
            }
            else
            {
                cmbMembership.Visible = false;
                cmbMembership.SelectedIndex = -1;
            }
            if (dr != null && dr["hasreferences"].ToString() == "1")
            {
                cmbReference.Visible = true;
            }
            else
            {
                cmbReference.Visible = false;
                cmbReference.SelectedIndex = -1;
            }
            /////////////////////////////
            if (dtDetail != null)
            {
                if (dtDetail.Rows.Count > 0)
                {

                    cmbPatientId.Text = dtDetail.Rows[0]["patientname"].ToString();

                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidationOnControls()==false) 
            {
                return;
            }
            if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to save this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                getRegno();
                DML.addmissionInfo_add_edit(txtSerialNo.Text, txtSerialNo.Text, txtRegAlpha.Text, ntxtRegNo.Text, dtpDate.Value, dtpTime.Value, RoomId, (string)cmbPatientType.SelectedValue,
                    Convert.ToString(cmbMembership.SelectedValue), cmbPatientTitle.Text, cmbPatientId.Text, txtRelation.Text, cmbRelationType.Text, ntxtAge.Text, cmbGender.Text, cmbAgeUnit.Text, (string)cmbConsultant.SelectedValue,
                    (string)cmbReference.SelectedValue, cmbReference.Text, "", txtReason.Text, "0", (string)cmbArea.SelectedValue, txtAddress.Text, txtEmergency.Text, txtMobile.Text,
                    txtOtherContact.Text, txtEmail.Text, txtRemarks.Text, "0", "0",txtCnic.Text,cmbCnicRelation.Text,txtCNICPerson.Text);
                MessageBox.Show("Record Successfully Saved..!");

                if (txtSerialNo.Text == "")
                {
                    dgvDetail.Rows.Insert(0, txtRegAlpha.Text + "-" + ntxtRegNo.Text,
                       dtpDate.Value,
                       dtpTime.Value,
                       null,
                       cmbPatientTitle.Text,
                       cmbPatientId.Text,
                       txtRoom.Text,
                       cmbConsultant.Text,
                       txtRelation.Text,
                       cmbRelationType.Text);
                }

                FillDetail(); 
                txtRegAlpha.Focus();
            }
        }

        private void cmbMembership_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!FLogIn)
            {
                DataRowView dr = (DataRowView)cmbMembership.SelectedItem;
                if (dr != null)
                {
                    string memberNewId = dr["newno"].ToString();

                    DataTable dtmember = Query.getData(" SELECT * FROM member WHERE   newno = '" + memberNewId + "'");
                    DateTime? validityDate = dtmember.Rows[0]["validitydate"] as DateTime?;
                    if (validityDate.HasValue)
                    {
                        if (DateTime.Now > validityDate.Value)
                        {
                            MessageBox.Show("Membership is no longer valid. The card has expired. Please contact the management.", "Invalid Membership", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbPatientId.DataSource = null;
                            return;
                        }
                    }

                    FillcmbDependent(memberNewId, dr);
                    cmbPatientId.DropDownStyle = ComboBoxStyle.DropDownList;
                }
                else
                {
                    FillcmbDependent("0", dr);
                    cmbPatientId.DropDownStyle = ComboBoxStyle.DropDown;
                    cmbPatientId.SelectedIndex = -1;
                }
            }
        }
        internal void FillcmbDependent(string Id, DataRowView drv)
        {
            DataTable dt = new DataTable();
            dt = dtDependent.Select("newno = '" + Id + "'").Count() > 0 ? dtDependent.Select("newno = '" + Id + "'").CopyToDataTable() : dtDependentEmpty;
            if (drv != null)
            {
                DataRow dr = dt.NewRow();
                dr["id"] = drv["newno"];
                dr["name"] = drv["name"];
                dt.Rows.InsertAt(dr, 0);
            }
            //cmbPatientId.DataSource = null;
            cmbPatientId.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                cmbPatientId.DisplayMember = "Name";
                cmbPatientId.ValueMember = "Id";
                cmbPatientId.SelectedIndex = -1;
            }
        }

        private void cmbPatientId_Validated(object sender, EventArgs e)
        {
            cmbPatientId.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(cmbPatientId.Text);
        }

        private void cmbPatientTitle_Validated(object sender, EventArgs e)
        {
            if (cmbPatientTitle.Text == "Ms." || cmbPatientTitle.Text == "Miss." || cmbPatientTitle.Text == "Mrs." || cmbPatientTitle.Text == "Baby." || cmbPatientTitle.Text == "D/O.")
                cmbGender.Text = "Female";
            else
                cmbGender.Text = "Male";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            New();
        }

        private void getRegno()
        {
            DataTable dt = Query.getData("SELECT * FROM Next_RegNo");
            txtRegAlpha.Text = dt.Rows[0]["regnoalpha"].ToString();
            ntxtRegNo.Text = dt.Rows[0]["regnonumeric"].ToString();
        }

        private void New()
        {
            DataTable dt = Query.getData("SELECT * FROM Next_RegNo");
            Validation.Clear(this);
            txtRegAlpha.Text = dt.Rows[0]["regnoalpha"].ToString();
            ntxtRegNo.Text = dt.Rows[0]["regnonumeric"].ToString();

            //grpBasicInfo.Enabled = true;
            //grpContact.Enabled = true;

            cmbPatientType.Enabled = true;
            cmbPatientId.Enabled = true;
            txtRemarks.Enabled = true;
            txtCNICPerson.Enabled = true;
            txtOtherContact.Enabled = true;


            cmbPatientTitle.Enabled = true;

            cmbGender.Enabled = true;
            ntxtAge.Enabled = true;
            cmbAgeUnit.Enabled = true;
            txtRelation.Enabled = true;
            cmbRelationType.Enabled = true;
            cmbConsultant.Enabled = true;
            cmbReference.Enabled = true;

            cmbCity.Enabled = true;
            txtEmergency.Enabled = true;
            cmbArea.Enabled = true;
            txtMobile.Enabled = true;
            txtAddress.Enabled = true;
            txtEmail.Enabled = true;
            cmbReference.Enabled = true;

            CurrentDateTime();
           
            //basit 14-07-2020
            txtRegAlpha.Focus();
            cmbPatientType.SelectedIndex = 0;
            lblUserName.Visible = false;
        }

        private void CurrentDateTime()
        {
            dtpDate.Value = SoftwareInfo.ServerDate;//DateTime.Now;
            dtpTime.Value = SoftwareInfo.ServerDate;//DateTime.Now;
        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            //Reports.CrpInPAdmForm rpt = new Reports.CrpInPAdmForm();
            //DataTable dt = ReportQuery.AddmissionForm(txtRegAlpha.Text + "-" + ntxtRegNo.Text);
            //string DepositAmount = dt.Rows[0]["DepositAmount"].ToString();
            //rpt.SetDataSource(dt);
            //rpt.SetParameterValue("pDeposit", DepositAmount);
            //frmReportView frm = new frmReportView();
            //frm.rptViewer.ReportSource = rpt;
            //frm.Show();

            PrintReport(false);

        }

        private void PrintReport(bool DirectPrint)
        {
            Reports.CrpInPAdmForm rpt = new Reports.CrpInPAdmForm();
            DataTable dt = ReportQuery.AddmissionForm(txtRegAlpha.Text + "-" + ntxtRegNo.Text);
            string DepositAmount = dt.Rows[0]["DepositAmount"].ToString();
            string CNIC = dt.Rows[0]["Cnic"].ToString();
            string CnicRelation = dt.Rows[0]["CnicRelation"].ToString();
            string CNICPerson = dt.Rows[0]["CNICPerson"].ToString();
            rpt.SetDataSource(dt);
            rpt.SetParameterValue("pDeposit", DepositAmount == "" ? "0" : DepositAmount);
            rpt.SetParameterValue("pCnic", CNIC == "" ? "" : CNIC);
            rpt.SetParameterValue("pCnicRelation", CnicRelation == "" ? "" : CnicRelation);
            rpt.SetParameterValue("pCNICPerson", CNICPerson == "" ? "" : CNICPerson);

            if (DirectPrint == false)
            {
                frmReportView frm = new frmReportView();
                frm.rptViewer.ReportSource = rpt;
                frm.Show();
            }
            else
            {
                rpt.PrintToPrinter(1, false, 1, 9999);
            }
            
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            FillForm(true);
        }

        private void btnShowLast_Click(object sender, EventArgs e)
        {
            FillForm(false);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //Reports.CrpInPAdmForm rpt = new Reports.CrpInPAdmForm();
            //DataTable dt = ReportQuery.AddmissionForm(txtRegAlpha.Text + "-" + ntxtRegNo.Text);
            //rpt.SetDataSource(dt);
            //rpt.SetParameterValue("pDeposit", 0);
            //rpt.PrintToPrinter(1, false, 1, 9999);

            PrintReport(true);
        }

        private void frmAddmissionInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
                
            }
            
            
        }

        private void txtRegAlpha_Validated(object sender, EventArgs e)
        {
            ntxtRegNo.Select(0, ntxtRegNo.Value.ToString().Length);
            DataTable dt = Query.getData("select count(*) from admissioninfo a where regnoalpha = '" + txtRegAlpha.Text + "' and regnonumeric = '" + ntxtRegNo.Text + "' and serialno != '" + txtSerialNo.Text + "'");
            if ((decimal)dt.Rows[0][0] > 0 && txtSerialNo.Text == "")
            {
                MessageBox.Show("Regno already registered...!");
                dt = Query.getData("SELECT * FROM Next_RegNo");
                txtRegAlpha.Text = dt.Rows[0]["regnoalpha"].ToString();
                ntxtRegNo.Text = dt.Rows[0]["regnonumeric"].ToString();
            }
            else if ((decimal)dt.Rows[0][0] > 0 && txtSerialNo.Text != "")
            {
                MessageBox.Show("Regno already registered in other file...!");
                dt = Query.getData("select regnoalpha,regnonumeric from admissioninfo a where serialno = '" + txtSerialNo.Text + "'");
                txtRegAlpha.Text = dt.Rows[0]["regnoalpha"].ToString();
                ntxtRegNo.Text = dt.Rows[0]["regnonumeric"].ToString();
            }
            if (txtSerialNo.Text == "")
            {
                FillData();
            }
           

        }
        private void ntxtRegNo_Leave(object sender, EventArgs e)
        {
           
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private bool ValidationOnControls() 
        {
            if (txtRoom.Text == "")
            {
                MessageBox.Show("Pls Select Room...!!!","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtRoom.Focus();
                return false;
            }
            else if (cmbPatientId.Text == "")
            {
                MessageBox.Show("Enter Patient..!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbPatientId.Focus();
                return false;
            }
            else if(Convert.ToInt32(ntxtAge.Value)==0.0)
            {
                MessageBox.Show("Enter Age...!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ntxtAge.Focus();
                return false;
            }
            else if (cmbConsultant.SelectedValue == null)
            {
                MessageBox.Show("Enter Consultant..!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbConsultant.Focus();
                return false;
            }
            else if(cmbMembership.SelectedValue==null && cmbMembership.Visible==true)
            {
                MessageBox.Show("Enter Member Id..!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbMembership.Focus();
                return false;
            }
            else if (cmbReference.SelectedValue == null && cmbReference.Visible == true)
            {
                MessageBox.Show("Enter Reference Id..!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbMembership.Focus();
                return false;
            }
            else if (txtCnic.Text == "")
            {
                MessageBox.Show("Enter the patient's CNIC Number..!!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCnic.Focus();
                return false;
            }
            else if (txtCnic.Text.Length != 15)
            {
                MessageBox.Show("Please enter the patient's CNIC number (13 digits, with dashes)..!!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCnic.Focus();
                return false;
            }
            
            else 
            {
                return true;
            }

        }

        private void btnCurRoom_Click(object sender, EventArgs e)
        {
            frmCurRoom frm = new frmCurRoom();
            frm.Show();
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtAddress__TextChanged(object sender, EventArgs e)
        {

        }

        private void grpBasicInfo_Enter(object sender, EventArgs e)
        {

        }
        string No_;
        string No;
        string noo;
        private void txtEmergency_Leave(object sender, EventArgs e)
        {
            try
            {
                string CellNo = txtEmergency.Text;
                if (CellNo.Contains("-"))
                {
                    string[] values1 = CellNo.Split('-');
                    noo = values1[0] + values1[1];
                }
                else
                {
                    noo = CellNo;
                }
                No = "0" + Convert.ToInt64(noo).ToString("##########");
                No_ = "0" + Convert.ToInt64(noo).ToString("###-#######");
                FillData();
            }
            catch (Exception ex)
            {
                
            }
        }
        private void txtMobile_Leave(object sender, EventArgs e)
        {
            try
            {
                string CellNo = txtMobile.Text;
                if (CellNo.Contains("-"))
                {
                    string[] values1 = CellNo.Split('-');
                    noo = values1[0] + values1[1];
                }
                else
                {
                    noo = CellNo;
                }
                No = "0" + Convert.ToInt64(noo).ToString("##########");
                No_ = "0" + Convert.ToInt64(noo).ToString("###-#######");
                FillData();
            }
            catch (Exception ex)
            {

            }
        }
        //No = String.Format("{0:##########}", Convert.ToString(CellNo));
        //No_ = String.Format("{0:### ### ###}", Convert.ToString(CellNo));

        //No = "0" + Convert.ToInt64(CellNo).ToString("##########");
        //No_ = "0" + Convert.ToInt64(CellNo).ToString("###-#######");
        DataTable dtDetail1;
        void FillData()
        {
            if (txtEmergency.Text != "" && txtRegAlpha.Text =="" )
            {
                dtDetail1 = Query.getData("SELECT  a.* FROM admissioninfo a where emergency='" + No + "' OR emergency='" + No_ + "'");
            }
            else if (txtMobile.Text != "" && txtRegAlpha.Text == "")
            {
                dtDetail1 = Query.getData("SELECT  a.* FROM admissioninfo a where mobile='" + No + "' OR mobile='" + No_ + "'");
            }
            else if (txtRegAlpha.Text.Length>0 && ntxtRegNo.Text.Length>0 && txtEmergency.Text == "")
            {
                dtDetail1 = Query.getData("SELECT  a.* FROM admissioninfo a  left JOIN  roomindex r ON a.roomid = r.id where regnoalpha='" + txtRegAlpha.Text + "' AND regnonumeric='" + ntxtRegNo.Text + "'");
            }
           
            if (dtDetail1.Rows.Count > 0)
            {
               /// txtSerialNo.Text = dtDetail.Rows[0]["serialno"].ToString();
                ///txtRegAlpha.Text = dtDetail.Rows[0]["regnoalpha"].ToString();
               /// ntxtRegNo.Text = dtDetail.Rows[0]["regnonumeric"].ToString();
              //// dtpDate.Value = (DateTime)dtDetail.Rows[0]["admdate"];
              ///  dtpTime.Value = (DateTime)dtDetail.Rows[0]["admtime"];
              ///  txtRoom.Text = dtDetail.Rows[0]["roomname"].ToString();
               /// RoomId = dtDetail.Rows[0]["roomid"].ToString();
                cmbPatientType.SelectedValue = dtDetail1.Rows[0]["patienttype"];
                cmbMembership.SelectedValue = dtDetail1.Rows[0]["bmjnewno"];
                cmbPatientTitle.Text = dtDetail1.Rows[0]["title"].ToString();
                getPatients();
               //cmbPatientId.Text = dtDetail.Rows[0]["patientname"].ToString();
                cmbGender.Text = dtDetail1.Rows[0]["gender"].ToString();
                ntxtAge.Text = dtDetail1.Rows[0]["age"].ToString();
                cmbAgeUnit.Text = dtDetail1.Rows[0]["ymd"].ToString();
                txtRelation.Text = dtDetail1.Rows[0]["relationname"].ToString();
                cmbRelationType.Text = dtDetail1.Rows[0]["relation"].ToString();

                cmbConsultant.SelectedValue = dtDetail1.Rows[0]["consultantid"];
                txtReason.Text = dtDetail1.Rows[0]["admittedfor"].ToString();
                cmbReference.SelectedValue = dtDetail1.Rows[0]["referenceid"];
                txtRemarks.Text = dtDetail1.Rows[0]["remarks"].ToString();
                cmbCity.SelectedIndex = Convert.ToInt32(dtDetail1.Rows[0]["cityid"].ToString());
                cmbArea.SelectedValue = dtDetail1.Rows[0]["areaid"];
                txtAddress.Text = dtDetail1.Rows[0]["address"].ToString();
                txtEmergency.Text = dtDetail1.Rows[0]["emergency"].ToString();
                txtMobile.Text = dtDetail1.Rows[0]["mobile"].ToString();
                txtOtherContact.Text = dtDetail1.Rows[0]["othercontact"].ToString();
                txtEmail.Text = dtDetail1.Rows[0]["email"].ToString();

                lblUserName.Text = dtDetail1.Rows[0]["createdby"].ToString();
                lblUserName.Visible = true;

                #region basit commit old code from this date 18/08/2020
                #endregion
                #region basit write new code from this date 18/08/2020
                if (UserInfo.UserLevel == "Admin")
                {
                    grpBasicInfo.Enabled = true;
                    grpContact.Enabled = true;
                }
                else
                {
                    string room = txtRoom.Text;
                    bool contains = room.Contains("DW");
                    if (dtDetail1.Rows[0]["dischargeyn"].ToString() == "1"  && contains == true)
                    {
                         grpBasicInfo.Enabled = true;
                         grpContact.Enabled = true;
                    }
                    else
                    {
                        grpBasicInfo.Enabled = true;
                        grpContact.Enabled = true;
                    }
                }
                #endregion
                MessageBox.Show(txtRegAlpha.Text + "-" + ntxtRegNo.Text + "  this file is ready for New Addmission !");
            }
            else
            {
            }
           
        }
        void getPatients()
        {
            try
            {
                string q = "";
                if (txtEmergency.Text != "" && txtRegAlpha.Text == "")
                {
                    q = "SELECT patientname FROM admissioninfo a where  emergency='" + No + "' OR emergency='" + No_ + "'";
                }
                else if (txtMobile.Text != "" && txtRegAlpha.Text == "")
                {
                    q = "SELECT patientname FROM admissioninfo a where  mobile='" + No + "' OR mobile='" + No_ + "'";
                }
                else if (txtRegAlpha.Text.Length > 0 && ntxtRegNo.Text.Length > 0 && txtEmergency.Text == "")
                {
                    q = "SELECT patientname FROM admissioninfo a where regnoalpha='" + txtRegAlpha.Text + "' AND regnonumeric='" + ntxtRegNo.Text + "'";
                }
                cmbPatientId.DataSource = Query.getData(q);
                cmbPatientId.DisplayMember = "patientname";
                cmbPatientId.ValueMember = "patientname";
                cmbPatientId.DataBindings.ToString();
            }
            catch (Exception ex)
            {
            }
           
        }

        private void cmbPatientId_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbPatientId.SelectedIndex>0)
                {
                    FillpatientsData();
                }
            }
            catch (Exception ex)
            {
            }
        }
        void FillpatientsData()
        {
            string q = "SELECT  a.* FROM admissioninfo a where patientname='" + cmbPatientId.Text + "' AND (emergency='" + No + "' OR emergency='" + No_ + "')";
            DataTable dtDetail = Query.getData(q);
           if (dtDetail.Rows.Count > 0)
            {
                /// txtSerialNo.Text = dtDetail.Rows[0]["serialno"].ToString();
                ///txtRegAlpha.Text = dtDetail.Rows[0]["regnoalpha"].ToString();
                /// ntxtRegNo.Text = dtDetail.Rows[0]["regnonumeric"].ToString();
                //// dtpDate.Value = (DateTime)dtDetail.Rows[0]["admdate"];
                ///  dtpTime.Value = (DateTime)dtDetail.Rows[0]["admtime"];
                ///  txtRoom.Text = dtDetail.Rows[0]["roomname"].ToString();
                /// RoomId = dtDetail.Rows[0]["roomid"].ToString();
                cmbPatientType.SelectedValue = dtDetail.Rows[0]["patienttype"];
                cmbMembership.SelectedValue = dtDetail.Rows[0]["bmjnewno"];
                cmbPatientTitle.Text = dtDetail.Rows[0]["title"].ToString();
               
                // cmbPatientId.Text = dtDetail.Rows[0]["patientname"].ToString();
                cmbGender.Text = dtDetail.Rows[0]["gender"].ToString();
                ntxtAge.Text = dtDetail.Rows[0]["age"].ToString();
                cmbAgeUnit.Text = dtDetail.Rows[0]["ymd"].ToString();
                txtRelation.Text = dtDetail.Rows[0]["relationname"].ToString();
                cmbRelationType.Text = dtDetail.Rows[0]["relation"].ToString();

                cmbConsultant.SelectedValue = dtDetail.Rows[0]["consultantid"];
                txtReason.Text = dtDetail.Rows[0]["admittedfor"].ToString();
                cmbReference.SelectedValue = dtDetail.Rows[0]["referenceid"];
                txtRemarks.Text = dtDetail.Rows[0]["remarks"].ToString();
                cmbCity.SelectedIndex = Convert.ToInt32(dtDetail.Rows[0]["cityid"].ToString());
                cmbArea.SelectedValue = dtDetail.Rows[0]["areaid"];
                txtAddress.Text = dtDetail.Rows[0]["address"].ToString();
                txtEmergency.Text = dtDetail.Rows[0]["emergency"].ToString();
                txtMobile.Text = dtDetail.Rows[0]["mobile"].ToString();
                txtOtherContact.Text = dtDetail.Rows[0]["othercontact"].ToString();
                txtEmail.Text = dtDetail.Rows[0]["email"].ToString();

                lblUserName.Text = dtDetail.Rows[0]["createdby"].ToString();
                lblUserName.Visible = true;

                #region basit commit old code from this date 18/08/2020
                #endregion
                #region basit write new code from this date 18/08/2020
                if (UserInfo.UserLevel == "Admin")
                {
                    grpBasicInfo.Enabled = true;
                    grpContact.Enabled = true;
                }
                else
                {
                    if (dtDetail.Rows[0]["dischargeyn"].ToString() == "1")
                    {
                        grpBasicInfo.Enabled = false;
                        grpContact.Enabled = false;
                    }
                    else
                    {
                        grpBasicInfo.Enabled = true;
                        grpContact.Enabled = true;
                    }
                }
                #endregion
            }
        }

        private void cmbRelationType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
