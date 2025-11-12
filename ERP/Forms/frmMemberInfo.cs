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
    public partial class frmMemberInfo : Form
    {
        public frmMemberInfo()
        {
            InitializeComponent();
        }

        private void FillQuery()
        {
            DataTable dt = Query.getMemberIndex(txtName.Text, txtMobileNumber.Text, txtNIC.Text);
            dgvMember.Rows.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgvMember.Rows.Add(dt.Rows[i]["id"].ToString(), dt.Rows[i]["newno"].ToString(), dt.Rows[i]["membershipnumber"].ToString(), dt.Rows[i]["title"].ToString(), dt.Rows[i]["name"].ToString(), dt.Rows[i]["father"].ToString(),
                    dt.Rows[i]["contact"].ToString(), dt.Rows[i]["caste"].ToString(), dt.Rows[i]["cnic"].ToString(), dt.Rows[i]["voternumber"].ToString(), dt.Rows[i]["is_vote_eligible"]);
            }
        }
        private void FillDetail(string Filter)
        
        {

            string Id = Filter == "ID" ? dgvMember.CurrentRow.Cells[clnId.Index].Value.ToString() : "";

            DataTable dt = Query.getMemberDetail(Id, txtBmjCard.Text, Filter);
            Validation.Clear(this);

            if (dt.Rows.Count > 0)
            {
                /*GENERAL INFORMATION*/

                txtComputerId.Text = dt.Rows[0]["id"].ToString();
                chkActive.Checked = dt.Rows[0]["isdeactivate"].ToString() == "0" ? true : false;
                chkPaidByZakat.Checked = dt.Rows[0]["paidbyzakat"].ToString() == "0" ? false  : true ;
                chkVoteEligibility.Checked = dt.Rows[0]["is_vote_eligible"].ToString() == "0" ? false : true;
                cmbReferenceName.SelectedValue = dt.Rows[0]["referenceid"].ToString();
                cmbTitle.Text = dt.Rows[0]["title"].ToString();
                txtMemberName.Text = dt.Rows[0]["name"].ToString();
                txtFatherName.Text = dt.Rows[0]["father"].ToString();
                txtContactNumber.Text = dt.Rows[0]["contact"].ToString();
                txtSurnameCaste.Text = dt.Rows[0]["caste"].ToString();
                txtAddress.Text = dt.Rows[0]["address"].ToString();

                /*EXTRA INFORMATION*/

                txtGrandFatherName.Text = dt.Rows[0]["grandfather"].ToString();
                txtHusbandName.Text = dt.Rows[0]["husband"].ToString();
                txtMobileNumberForms.Text = dt.Rows[0]["mobilenumberforsms"].ToString();

                /*PERSONAL INFORMATION*/

                txtQualification.Text = dt.Rows[0]["qualification"].ToString();
                txtCnic.Text = dt.Rows[0]["cnic"].ToString();
                txtWork.Text = dt.Rows[0]["work"].ToString();
                txtVoter.Text = dt.Rows[0]["voternumber"].ToString();
                dtpDob.Value = dt.Rows[0]["dob"] == null || dt.Rows[0]["dob"].ToString() == "" ? dtpDob.MinDate : (DateTime)dt.Rows[0]["dob"];
                cmbMaritalStatus.Text = dt.Rows[0]["maritalstatus"].ToString();

                /*HOSPITAL INOFRMATION*/

                txtBmjCard.Text = dt.Rows[0]["newno"].ToString();
                txtBmjMembership.Text = dt.Rows[0]["membershipnumber"].ToString();
                txtOldBmjCard.Text = dt.Rows[0]["oldno"].ToString();
                txtNewBmjCard.Text = dt.Rows[0]["newno"].ToString();
                txtBtmcOld.Text = dt.Rows[0]["btmwcoldno"].ToString();

                TabControl1.SelectedIndex = 0;


                // Validity (LifeTime or TimePeriod)
                string validityType = dt.Rows[0]["membervalidity"].ToString(); // 0 = Lifetime, 1 = Time Period

                if (validityType == "0")
                {
                    chkLifeTime.Checked = true;
                    chkTimePeriod.Checked = false;
                    txtTimePeriodDate.Enabled = false;
                    txtTimePeriodDate.Value = DateTime.Now;
                }
                else
                {
                    chkLifeTime.Checked = false;
                    chkTimePeriod.Checked = true;

                    // Load the validity date
                    if (dt.Rows[0]["validitydate"] != DBNull.Value && !string.IsNullOrEmpty(dt.Rows[0]["validitydate"].ToString()))
                    {
                        txtTimePeriodDate.Enabled = true;
                        txtTimePeriodDate.Value = Convert.ToDateTime(dt.Rows[0]["validitydate"]);
                    }
                    else
                    {
                        txtTimePeriodDate.Enabled = false;
                        txtTimePeriodDate.Value = DateTime.Now;
                    }
                }



                dt = Query.getmemberdependent(txtBmjCard.Text);
                dgvBmjFamily.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvBmjFamily.Rows.Add(dt.Rows[i]["id"].ToString(), dt.Rows[i]["name"].ToString(), Convert.ToDateTime(dt.Rows[i]["dob"]).ToString("dd-MMM-yyyy"), dt.Rows[i]["newno"].ToString(), dt.Rows[i]["relation"].ToString(), dt.Rows[i]["cnic"].ToString());

                }



            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FillQuery();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Validation.Clear(this);
            chkPaidByZakat.Checked = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (chkPaidByZakat.Checked == true)
            {
                if (cmbReferenceName.SelectedValue == null)
                {
                    MessageBox.Show("Plz Select Reference Name...");
                    return;
                }
            }
            if (!chkLifeTime.Checked && !chkTimePeriod.Checked)
            {
                MessageBox.Show("Please select Member Validity 'Lifetime' or 'Time Period'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to save this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (UserInfo.UserLevel == "Admin")
                {
                    int memberValidity = chkLifeTime.Checked ? 0 : 1;
                    DateTime? validityDate = chkTimePeriod.Checked ? txtTimePeriodDate.Value : (DateTime?)null;

                    DML.MemberInfo_Add_Edit(txtComputerId.Text,
                                             txtBmjCard.Text,
                                             txtBmjCard.Text,
                                             txtBtmcOld.Text,
                                             txtOldBmjCard.Text,
                                             txtBmjMembership.Text,
                                             cmbTitle.Text,
                                             txtMemberName.Text,
                                             txtFatherName.Text,
                                             txtGrandFatherName.Text,
                                             txtHusbandName.Text,
                                             txtSurnameCaste.Text,
                                             cmbMaritalStatus.Text,
                                             dtpDob.Value.ToString("dd-MMM-yyyy"),
                                             txtQualification.Text,
                                             txtWork.Text,
                                             txtContactNumber.Text,
                                             txtCnic.Text,
                                             txtAddress.Text,
                                             txtVoter.Text,
                                             chkActive.Checked ? "0" : "1",
                                             txtMobileNumberForms.Text,
                                             "0",
                                             chkPaidByZakat.Checked ? "1" : "0",
                                             cmbReferenceName.SelectedValue == null ? "" : cmbReferenceName.SelectedValue.ToString(),
                                             memberValidity,
                                             validityDate
                                             );
                    MessageBox.Show("Record Save Successfully.....!!!!!");
                }
            }
            
        }

        private void dgvMember_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FillDetail("ID");
        }

        private void txtBmjCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FillDetail("BMJ");
            }
        }

        private void dgvMember_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvBmjFamily_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public static void Clear(Control Parentctrl)
        {
            foreach (Control ctrl in Parentctrl.Controls)
            {
                if (ctrl.Tag != (object)"Lock")
                {
                    if (ctrl.GetType() == typeof(TextBox)) ctrl.Text = "";
                    else if (ctrl.GetType() == typeof(RichTextBox)) ctrl.Text = "";

                    else if (ctrl.GetType() == typeof(NumericUpDown)) { ctrl.Text = "0"; }
                    else if (ctrl.GetType() == typeof(ComboBox))
                    {
                        (ctrl as ComboBox).SelectedIndex = -1;
                        ctrl.Text = "";
                    }

                    else if (ctrl.HasChildren == true)
                        Clear(ctrl);
                }
            }

        }
        private void FillDetail2()
        {
            Clear(this);
            DataTable dt = Query.getMemberFamilyDetail(dgvBmjFamily.CurrentRow.Cells[clnfamilyid.Index].Value.ToString());
            if (dt.Rows.Count > 0)
            {
                txtCompID.Text = dt.Rows[0]["id"].ToString();
                txtFamilyMember.Text = dt.Rows[0]["name"].ToString();
                txtdob.Text = dt.Rows[0]["dob"].ToString();
                txtBmjNo.Text = dt.Rows[0]["newno"].ToString();
                txtRelation.Text = dt.Rows[0]["relation"].ToString();
                familyCnic.Text = dt.Rows[0]["cnic"].ToString();
                chkDepIsActive.Checked = dt.Rows[0]["isdeactivated"].ToString() == "1" ? false : true;

            }


        }

        private void dgvBmjFamily_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FillDetail2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to save this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (UserInfo.UserLevel == "Admin")
                {
                    DML.FamilyInfo_add_edit(txtCompID.Text, txtFamilyMember.Text, txtdob.Text, txtBmjNo.Text, txtRelation.Text, txtCnic.Text, chkDepIsActive.Checked ? "0" : "1");
                    MessageBox.Show("Successfully saved...!");
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReportParameters frm = new frmReportParameters();
            frm.Reportname = "Member Detail";
            frm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to delete this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                DataTable dt = Query.getData("update memberdependent set status='1' where id='" + txtCompID.Text + "' ");

                MessageBox.Show("Record Delete Successfully ...!");
            }
        }

        private void frmMemberInfo_Load(object sender, EventArgs e)
        {
            FillControls.FillReferenceIndex(cmbReferenceName);
        }

        string CmbRefeneceValue = "";
        private void chkPaidByZakat_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPaidByZakat.Checked == true)
            {
                cmbReferenceName.Enabled = true;
                cmbReferenceName.SelectedValue = CmbRefeneceValue;
            }
            else
            {
                cmbReferenceName.Enabled = false;
                CmbRefeneceValue = cmbReferenceName.SelectedValue == null ? "" : cmbReferenceName.SelectedValue.ToString();
                cmbReferenceName.SelectedValue = -1;
            }
        }

        private void chkTimePeriod_CheckedChanged(object sender, EventArgs e)
        {
            txtTimePeriodDate.Enabled = chkTimePeriod.Checked;
            if (chkTimePeriod.Checked)
            {
                chkLifeTime.Checked = false;
            }
        }

        private void chkLifeTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLifeTime.Checked)
            {
                chkTimePeriod.Checked = false;
            }
        }
    }
}
