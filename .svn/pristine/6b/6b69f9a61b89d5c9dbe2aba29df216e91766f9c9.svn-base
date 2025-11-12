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
    public partial class frmUserInfo : Form
    {
        public frmUserInfo()
        {
           
            
            InitializeComponent();
            FillControls.FillUserLevelIndex(cmbUserLevel);
        }
       
        void FillQuery()
        {

            dgvUserDetails.Rows.Clear();
            DataTable dtQuery = Query.UserInformation();
            for (int i = 0; i < dtQuery.Rows.Count; i++)
            {
                dgvUserDetails.Rows.Add(dtQuery.Rows[i]["userid"].ToString(),
                dtQuery.Rows[i]["username"].ToString(),
                    //dtQuery.Rows[i]["password"].ToString(),
                dtQuery.Rows[i]["userlevel"].ToString(),
                dtQuery.Rows[i]["islock"].ToString() == "1" ? true : false,
                dtQuery.Rows[i]["multilogin"].ToString() == "1" ? true : false);
               


               
               


            }
        }
        internal void FillDetail(string ID)
        {
            DataTable dt;
            dt = Query.UserSearh(ID);
            /////////////////////
            //txtConsultantid.Text = ID;
            if (dt.Rows.Count > 0)
            {
                // cmbCatagory.SelectedValue = dt.Rows[0]["TesttypeId"].ToString();
                txtUserid.Text = dt.Rows[0]["userid"].ToString();
                txtUname.Text = dt.Rows[0]["username"].ToString();
                cmbUserLevel.Text = dt.Rows[0]["userlevel"].ToString();
                chkLock.Checked = dt.Rows[0]["islock"].ToString() == "1" ? true : false;
                chkMultiLogin.Checked = dt.Rows[0]["multilogin"].ToString() == "1" ? true : false;
                txtpass.Text = dt.Rows[0]["password"].ToString();
                txtCnfrmPassword.Text = dt.Rows[0]["password"].ToString();
                

                

                


            }
        }
        

       

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            cmbUserLevel.Enabled = true;
            
            if (UserInfo.UserLevel != "Admin")
            {
                MessageBox.Show("You have no rights to access user information");
                this.Close();

                return;

            }
            else
            {
                txtUserid.Focus();
                FillQuery();
                //string[] productName = new string[dgvUserDetails.Rows.Count];
                
                
               
                //for (int i = 0; i < productName.Length; i++)
                //{
                //    if (productName[i] == txtUserid.Text)
                //    {
                //        //MessageBox.Show("User Already Exists");
                //        validate = false;
                //        return;
                //    }
                //}            
            }
        }

       

        private void btNew_Click(object sender, EventArgs e)
        {
            Validation.Clear(grpUserInfo);
            cmbUserLevel.Enabled = true;
            txtUserid.Enabled = true;
            

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

                //for (int i = 0; i < dgvUserDetails.Rows.Count; i++)
                //{
                //    if (dgvUserDetails.Rows[i].Cells[0].Value.ToString() == txtUserid.Text)
                //    {
                //        MessageBox.Show("User Exist");
                //        return;
                //    }
                //}
            
                
            //if (cmbUserLevel.SelectedText !="Admin")
            //{
            //      MessageBox.Show("You have no rights to Change userlevel to Admin");
            //      return;
            //} 
            //else
            if (txtUserid.Text == "")
            {
                MessageBox.Show("Enter User id");
                this.Focus();
                return;
            }
            else if(txtUserid.Text=="Admin")
            {
                MessageBox.Show("You can not create userid as Admin");
                return;
            }

            else if (txtUname.Text == "") 
            {
                 MessageBox.Show("Enter User Name");
                 this.Focus();
                 return;
            }           
            else if (txtpass.Text == "") 
            {
                MessageBox.Show("Enter Password");
                return;
            }
            else if(txtCnfrmPassword.Text=="")
            {
                MessageBox.Show("Enter Confirm Password");
                return;
            }
            else if (txtpass.Text != txtCnfrmPassword.Text)
            {
                MessageBox.Show("Password Does not Macth");
                return;
            }                                       
           
                
            else if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to save this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DML.userinfo_add_edit(txtUserid.Text, txtUname.Text,txtpass.Text, (string)cmbUserLevel.SelectedValue,chkLock.Checked?"1":"0",chkMultiLogin.Checked?"1":"0","0");

                MessageBox.Show("Record Successfully Saved..!");

            }
            
        }

     

        private void dgvUserDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FillDetail(dgvUserDetails.Rows[e.RowIndex].Cells[clnLoginId.Index].Value.ToString());
            if (txtUserid.Text == "Admin" && cmbUserLevel.Text == "Admin")
            {
                cmbUserLevel.Enabled = true;
                txtUserid.Enabled = true;
            }
        }

        

        }
    }

