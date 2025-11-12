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
    public partial class frmUsersControl : Form
    {
        DataTable dtusers = new DataTable();
        public frmUsersControl()
        {
            InitializeComponent();
        }
        bool Flogin = true;
        void FillUser()
        {
            cmbSearchUserId.DataSource = dtusers;
            cmbSearchUserId.DisplayMember = "UserId";
            cmbSearchUserId.ValueMember = "UserId";
            //dgvUsers.DataSource = dtusers; 
            dgvUsers.Rows.Clear();
            for (int i = 0; i < dtusers.Rows.Count; i++)
            {
                dgvUsers.Rows.Add(dtusers.Rows[i]["UserId"], dtusers.Rows[i]["UserName"], dtusers.Rows[i]["Password"], (dtusers.Rows[i]["IsLock"].ToString() == "1" ? true : false), dtusers.Rows[i]["CreatedBy"], dtusers.Rows[i]["EditBy"], (dtusers.Rows[i]["alert"].ToString() == "1" ? true : false), dtusers.Rows[i]["cellno"], dtusers.Rows[i]["email"]);
            }
        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
        private void frmUsersControl_Load(object sender, EventArgs e)
        {
            try
            {                
                dtusers = Query.UserList();
                FillUser();                
                Flogin = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());                
                this.Close();
            }
        }
        bool isexist()
        {
            bool exist = false;
            foreach (DataGridViewRow item in dgvUsers.Rows)
            {
                if (item.Cells[clnId.Index].Value.ToString() == txtUserId.Text)
                    exist = true;
            }
            return exist;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you wan't to save changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (isnew && isexist())
                    {
                        MessageBox.Show("Userid already exist..!");
                        return;
                    }
                    Cursor.Current = Cursors.WaitCursor;
                    string encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(txtPassword.Text));
                    //MSP.User_Add_Edit(txtUserId.Text, encoded, txtUserName.Text, txtSecurityLevel.Text, (rdoLock.Checked == true ? "1" : "0"), (rdoEmail.Checked == true ? "1" : "0"), "0", txtCellNo.Text, txtEmail.Text);                    
                   // dtusers = Query.UserList();
                    FillUser();
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Record Successfully Saved...!");
                    isnew = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                //Errors.writeline(ex.Message.ToString(), "frmUsersControl  btnSave_Click");
                this.Close();
            }
        }
        bool isnew = false;
        private void btnNew_Click(object sender, EventArgs e)
        {
            dgvUsers.ClearSelection();
            txtUserId.ReadOnly = false;
            txtUserId.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            rdoUnLock.Checked = true;
            isnew = true;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["rights"] = "N";
            }

        }
        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsers.CurrentRow != null)
                {
                    isnew = false;
                    txtUserId.Text = dgvUsers.CurrentRow.Cells[clnId.Index].Value.ToString();
                    txtUserId.ReadOnly = true;
                    txtUserName.Text = dgvUsers.CurrentRow.Cells[UserName.Index].Value.ToString();
                    txtPassword.Text = dgvUsers.CurrentRow.Cells[Password.Index].Value.ToString();
                    rdoLock.Checked = bool.Parse(dgvUsers.CurrentRow.Cells[clnLock.Index].Value.ToString());
                    rdoUnLock.Checked = !bool.Parse(dgvUsers.CurrentRow.Cells[clnLock.Index].Value.ToString());
                    chkAlert.Checked = bool.Parse(dgvUsers.CurrentRow.Cells[clnAlert.Index].Value.ToString());
                    txtCellNo.Text = dgvUsers.CurrentRow.Cells[clnCellno.Index].Value.ToString();
                    txtEmail.Text = dgvUsers.CurrentRow.Cells[clnEmail.Index].Value.ToString();
                    txtCreatedBy.Text = dtusers.Rows[cmbSearchUserId.SelectedIndex]["CreatedBy"].ToString();
                    txtEditBy.Text = dtusers.Rows[cmbSearchUserId.SelectedIndex]["EditBy"].ToString();
                
                    //updaterights();
                }

            }
            catch (Exception ex)
            { 
            
            }
        }
        DataTable dt = new DataTable();
        
        private void frmUsersControl_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                    SendKeys.Send("{tab}");
            }
            catch
            { }
        }
        
        
        
       // int preselection = -1;
       
    }
}
