using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ERP
{
    public partial class frmAccountsSearching : Form
    {
        DataTable dtGeneralAccount = new DataTable();
        DataTable dtTradingAccount = new DataTable();

        public frmAccountsSearching()
        {
            InitializeComponent();


            dtGeneralAccount = Query.getData("SELECT accountid  AS account,''         AS clientcode ,accounttitle AS title,shortcutkeys AS ShortcutKeys FROM chartofaccounts WHERE status = '0' order by accounttitle asc");
            dtTradingAccount = Query.getData("SELECT ''         AS account,clientcode AS clientcode ,accounttitle AS title,fkdealer2 AS Dealer FROM tradingaccountdetail  WHERE status = '0' order by accounttitle asc");

        }

        
        private void frmSearching_Load(object sender, EventArgs e)
        {
            //dtGeneralAccount = Query.Get_dataTable("SELECT accountid  AS account ,accounttitle AS title FROM chartofaccounts WHERE status = 0");
            //dtTradingAccount = Query.Get_dataTable("SELECT clientcode AS account ,accounttitle AS title FROM tradingaccountdetail  WHERE status = 0");
            GetAccountData();
        }


        private void rdoGeneralAcc_CheckedChanged(object sender, EventArgs e)
        {
            GetAccountData();
        }

        private void GetAccountData()
        {
            this.dgvClientCodeList.DataSource = null;
            if (rdoGeneralAcc.Checked == true)
            {
                dgvClientCodeList.DataSource = dtGeneralAccount;
                this.dgvClientCodeList.Columns[1].Visible = false;
            }
            else
            {
                dgvClientCodeList.DataSource = dtTradingAccount;
                this.dgvClientCodeList.Columns[0].Visible = false;
            }
        }


        public string SearchingCCode = "";
        private void dgvClientCodeList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (rdoGeneralAcc.Checked == true)
            {
                SearchingCCode = dgvClientCodeList.CurrentRow.Cells[0].Value.ToString();
            }
            else
            {
                SearchingCCode = dgvClientCodeList.CurrentRow.Cells[1].Value.ToString();
            }
            this.DialogResult = DialogResult.OK;
        }


        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            int parsedValue;
            if (rdoGeneralAcc.Checked == true)
            {
                dtGeneralAccount.CaseSensitive = false;
                if (!int.TryParse(txtCode.Text, out parsedValue))
                {
                    list.Add("title like '%" + txtCode.Text + "*%'");
                }
                else
                {
                    list.Add("account like '%" + txtCode.Text + "%'");
                }
                string FilterGeneral = string.Join("and", list.ToArray());
                dtGeneralAccount.DefaultView.RowFilter = FilterGeneral;
                dtGeneralAccount.DefaultView.Sort = "title ASC";
                dgvClientCodeList.DataSource = dtGeneralAccount;
            }
            else
            {
                dtTradingAccount.CaseSensitive = false;
                if (!int.TryParse(txtCode.Text, out parsedValue))
                {
                    list.Add("title like '%" + txtCode.Text + "%'");
                }
                else
                {
                    list.Add("clientcode like '%" + txtCode.Text + "%'");
                }

                string FilterClinetCode = string.Join("and", list.ToArray());
                dtTradingAccount.DefaultView.RowFilter = FilterClinetCode;
                dtTradingAccount.DefaultView.Sort = "title ASC";
                dgvClientCodeList.DataSource = dtTradingAccount;
            }

        }



    }
}
