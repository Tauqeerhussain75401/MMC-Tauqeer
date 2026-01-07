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
    public partial class frmTestCatagoryInfo : Form
    {
        public frmTestCatagoryInfo()
        {
            InitializeComponent();
        }

        private void frmTestCatagoryInfo_Load(object sender, EventArgs e)
        {
            FillQuery();

        }
        void FillQuery()
        {

            dgvtestcatagoryInfo.Rows.Clear();
            DataTable dtQuery = Query.getData("Select id,title, fkaccountid, accounttitle, isactive,hastest,fixedrate,To_Number(autotoken) as autotoken,To_Number(contactrequired) as contactrequired,printtype,nvl(isconsultantinvolved,0) isconsultantinvolved, Nvl(agerequired,0) AS AgeRequired,resforduptoken from testcatagory tc left join chartofaccounts ca on tc.fkaccountid = ca.accountid  ");
            //string fkaccount = dtQuery.Rows[i]["fkaccountid"].ToString(),
            for (int i = 0; i < dtQuery.Rows.Count; i++)
            {
                int ind = dgvtestcatagoryInfo.Rows.Add(dtQuery.Rows[i]["id"].ToString(),
                 dtQuery.Rows[i]["title"].ToString(),
                dtQuery.Rows[i]["fkaccountid"] == null ? null : dtQuery.Rows[i]["accounttitle"].ToString(),
                 dtQuery.Rows[i]["fixedrate"].ToString(),
                 dtQuery.Rows[i]["autotoken"].ToString() == "1" ? true : false,
                 dtQuery.Rows[i]["contactrequired"].ToString() == "1" ? true : false,
                  dtQuery.Rows[i]["isactive"].ToString() == "1" ? true : false,
                  dtQuery.Rows[i]["AgeRequired"].ToString() == "1" ? true : false,
                  dtQuery.Rows[i]["resforduptoken"].ToString() == "1" ? true : false)
                  ;
                
                dgvtestcatagoryInfo.Rows[ind].Cells[ClnFixedRate.Index].ReadOnly = dtQuery.Rows[i]["isconsultantinvolved"].ToString() == "1" ? false : true;
                dgvtestcatagoryInfo.Rows[ind].Cells[ClnFixedRate.Index].Style.BackColor = dtQuery.Rows[i]["isconsultantinvolved"].ToString() == "1" ? SystemColors.Window : Color.LightGray;
            }
            if (mcbAccounts.DataSource == null)
            {
                DataTable Accounts = Query.getData("SELECT accountid, accounttitle FROM chartofaccounts WHERE control = 'Detail' AND accountid LIKE '004001%' AND Length(accountid) = 15");
                
                mcbAccounts.DataSource = Accounts;
                mcbAccounts.DisplayMember = "accounttitle";
                mcbAccounts.ValueMember = "AccountID";
                //mcbAccounts.SelectedValue = "004001002004001";
            }
        }



        private void dgvtestcatagoryInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < dgvtestcatagoryInfo.Rows.Count; i++)
            //{
            //    if (dgvtestcatagoryInfo.Rows[i].Cells[ClnFixedRate.Index].Value.ToString() != "")
            //        Query.Execute("update testcatagory set title = '" + dgvtestcatagoryInfo.Rows[i].Cells[clnTitle.Index].Value.ToString() + "',fixedrate = " + dgvtestcatagoryInfo.Rows[i].Cells[ClnFixedRate.Index].Value.ToString() + "  where  id = '" + dgvtestcatagoryInfo.Rows[i].Cells[clnID.Index].Value.ToString() + "'");

            //}
            //FillQuery();

            DML.updatetestcatagory(txtID.Text, txtTitle.Text, mcbAccounts.SelectedValue == null ? "" : mcbAccounts.SelectedValue.ToString(), chkActive.Checked == true ? "1" : "0", ntxtFixedRate.Value.ToString(),chkAutOToken.Checked == true ? "1" : "0", chkContactRequired.Checked == true ? "1" : "0", chkAgeRequired.Checked == true ? "1":"0",chkRes_For_dup_token.Checked==true?"1":"0");
            MessageBox.Show("Successfully saved...!");
            FillQuery();
        }
        void fillDetail(string id)
        {
            ntxtFixedRate.ReadOnly = false;
            ntxtFixedRate.Increment = 1;
            DataTable dt;
            dt = Query.getData("Select id,title,fkaccountid,isactive,hastest,fixedrate,To_Number(autotoken) as autotoken,To_Number(contactrequired) as contactrequired,printtype,nvl(isconsultantinvolved,0) isconsultantinvolved,Nvl(agerequired,0) AS AgeRequired,resforduptoken from testcatagory where id='" + id + "'");
            
            if (dt.Rows.Count > 0)
            {
                txtID.Text = dt.Rows[0]["id"].ToString();
                txtTitle.Text = dt.Rows[0]["title"].ToString();
                mcbAccounts.SelectedValue = dt.Rows[0]["fkaccountid"].ToString();
                
                 ntxtFixedRate.Value=Convert.ToInt32( Validation.DBNullTo( dt.Rows[0]["fixedrate"],0));
                 
                
              
                chkActive.Checked = dt.Rows[0]["isactive"].ToString() == "1" ? true : false;
                chkAutOToken.Checked = dt.Rows[0]["autotoken"].ToString() == "1" ? true : false;
                chkContactRequired.Checked = dt.Rows[0]["contactrequired"].ToString() == "1" ? true : false;
                chkAgeRequired.Checked = dt.Rows[0]["AgeRequired"].ToString() == "1" ? true : false;
                chkRes_For_dup_token.Checked = dt.Rows[0]["resforduptoken"].ToString() == "1" ? true : false;
                if (ntxtFixedRate.Value ==0) 
                {
                    ntxtFixedRate.ReadOnly = true;
                    ntxtFixedRate.Increment = 0;
                }
            }
        
        }

       

        private void dgvtestcatagoryInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                fillDetail(dgvtestcatagoryInfo.Rows[e.RowIndex].Cells[clnID.Index].Value.ToString());
            }
        }

        private void frmTestCatagoryInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                SendKeys.Send("{tab}");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
