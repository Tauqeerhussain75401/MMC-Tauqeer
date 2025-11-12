using ERP;
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
    public partial class frmBankReconciliation : Form
    {
        public frmBankReconciliation()
        {
            InitializeComponent();
        }
        bool FLogIn = true;
        DataTable dtBank;
        public bool SaveRight;
        void FillcmbBank()
        {
            dtBank = Query.BankIndex();
            dtBank.PrimaryKey = new DataColumn[] { dtBank.Columns["Bankcode"] };
            cmbBankName.DataSource = dtBank;
            cmbBankName.DisplayMember = "BankName";
            cmbBankName.ValueMember = "Bankcode";
            cmbBankName.SelectedIndex = -1;
        }
        decimal bal = 0, ClearBal = 0, UnClearBal = 0;
        void FillBalances()
        {
            bal = 0;//Query.BankBal(cmbBankName.SelectedValue.ToString(), dtpFdate.Value.AddDays(-1));
            //txtPreBankLedger.Text = (bal >= 0 ? bal : -bal).ToString() + (bal >= 0 ? " Dr" : " Cr");
            ClearBal = 0;//Query.BankBal(cmbBankName.SelectedValue.ToString(), dtpFdate.Value.AddDays(-1) ,"1");
            //txtPreBankStatement.Text = (bal >= 0 ? bal : -bal).ToString() + (bal >= 0 ? " Dr" : " Cr");
            UnClearBal = 0;//Query.BankBal(cmbBankName.SelectedValue.ToString(), dtpFdate.Value.AddDays(-1), "0");
            //txtPrePendingCheque.Text = (bal >= 0 ? bal : -bal).ToString() + (bal >= 0 ? " Dr" : " Cr");
            //txtDrCr.Text = (bal >= 0 ? "Dr" : "Cr").ToString();                
        }
        void Filldgv()
        {
            string clear = "''";
            if (chkClear.Checked && !chkUnClear.Checked)
                clear = "1";
            else if (!chkClear.Checked && chkUnClear.Checked)
                clear = "0";
            else if (chkClear.Checked && chkUnClear.Checked)
                clear = "All";
            //DataTable banktransaction = Query.VoucherDetail (cmbBankName.SelectedValue.ToString(),dtpFdate.Value,dtpTdate.Value,clear);
            DataTable banktransaction = Query.VoucherDetailbankReconci(cmbBankName.SelectedValue.ToString(), dtpTdate.Value, clear);
            dgvBankReconcile.Rows.Clear();
            for (int i = 0; i < banktransaction.Rows.Count; i++)
            {
                dgvBankReconcile.Rows.Add(banktransaction.Rows[i]["vseq"].ToString(), banktransaction.Rows[i]["vdate"],
                    banktransaction.Rows[i]["vtype"].ToString() + "-" + banktransaction.Rows[i]["vno"].ToString(),
                    banktransaction.Rows[i]["description"],
                    banktransaction.Rows[i]["fktransactionid"], banktransaction.Rows[i]["chequeno"], banktransaction.Rows[i]["dr"], banktransaction.Rows[i]["cr"],
                    banktransaction.Rows[i]["clearentry"].ToString() == "1" ? true : false,
                    banktransaction.Rows[i]["reconciledate"].ToString() == "" ? null : banktransaction.Rows[i]["reconciledate"]);
                dgvBankReconcile.Rows[i].Cells[clnReconcileDate.Index].ReadOnly = ((bool)dgvBankReconcile.Rows[i].Cells[clnClear.Index].Value == false ? false : true);
                dgvBankReconcile.Rows[i].Cells[clnReconcileDate.Index].Style.BackColor = ((bool)dgvBankReconcile.Rows[i].Cells[clnClear.Index].Value == false ? Color.LightGray : Color.White);
                dgvBankReconcile.Rows[i].Cells[clnReconcileDate.Index].Style.SelectionBackColor = ((bool)dgvBankReconcile.Rows[i].Cells[clnClear.Index].Value == false ? Color.DarkGray : Color.DodgerBlue);
            }
            FillCurrentBal();
        }
        void FillCurrentBal()
        {
            decimal BankState = 0, Pending = 0, Ledger = 0;
            BankState = (from DataGridViewRow row in dgvBankReconcile.Rows
                         where (bool)row.Cells[clnClear.Index].Value == true
                         select Convert.ToDecimal(row.Cells[clnDr.Index].FormattedValue) - Convert.ToDecimal(row.Cells[clnCr.Index].FormattedValue)).Sum();
            Pending = (from DataGridViewRow row in dgvBankReconcile.Rows
                       where (bool)row.Cells[clnClear.Index].Value == false
                       select Convert.ToDecimal(row.Cells[clnDr.Index].FormattedValue) - Convert.ToDecimal(row.Cells[clnCr.Index].FormattedValue)).Sum();
            Ledger = (from DataGridViewRow row in dgvBankReconcile.Rows
                      select Convert.ToDecimal(row.Cells[clnDr.Index].FormattedValue) - Convert.ToDecimal(row.Cells[clnCr.Index].FormattedValue)).Sum();
            BankState += bal;
            Pending += ClearBal;
            Ledger += UnClearBal;
            txtCurBankStatement.Text = BankState >= 0 ? BankState.ToString() + "Dr" : (-BankState).ToString() + "Cr";
            txtCurPendingCheque.Text = Pending >= 0 ? Pending.ToString() + "Dr" : (-Pending).ToString() + "Cr";
            txtCurBankLedger.Text = Ledger >= 0 ? Ledger.ToString() + "Dr" : (-Ledger).ToString() + "Cr";
        }
        void Clear(Control ctrl)
        {
            foreach (Control item in ctrl.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                    item.Text = "";
                else if (item.HasChildren)
                    Clear(item);
            }
            dgvBankReconcile.Rows.Clear();
        }
        private void frmBankReconciliation_Load(object sender, EventArgs e)
        {
            this.Text = Variable.Version;
            Variable.flags = Animate.AW_ACTIVATE | Animate.AW_CENTER;
            Animate.AnimateWindow(this.Handle, Variable.animationTime, Variable.flags);
            try
            {
                FillcmbBank();
                FLogIn = false;
            }
            catch
            {


            }
        }
        private void cmbBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!FLogIn && cmbBankName.SelectedValue != null)
                {
                    // fillBankBal();
                    DataRowView dr = (DataRowView)cmbBankName.SelectedItem;
                    txtBranch.Text = dr["branchname"].ToString();
                    txtIBAN.Text = dr["iban"].ToString();

                }
            }
            catch
            {
                txtBranch.Text = "";
                txtIBAN.Text = "";
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbBankName.SelectedIndex != -1)
            {
                FillBalances();
                Filldgv();
            }
            else
            {
                Clear(this);
            }
        }
        private void dgvBankReconcile_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBankReconcile.CurrentCell != null && dgvBankReconcile.CurrentCell == dgvBankReconcile.CurrentRow.Cells[clnClear.Index])
            {
                if ((bool)dgvBankReconcile.CurrentCell.Value)
                {
                    if (dgvBankReconcile.CurrentRow.Cells[clnReconcileDate.Index].Value == null)
                        dgvBankReconcile.CurrentRow.Cells[clnReconcileDate.Index].Value = dgvBankReconcile.CurrentRow.Cells[clnDate.Index].Value;
                    dgvBankReconcile.CurrentRow.Cells[clnReconcileDate.Index].ReadOnly = false;
                    dgvBankReconcile.CurrentRow.Cells[clnReconcileDate.Index].Style.BackColor = Color.White;
                    dgvBankReconcile.CurrentRow.Cells[clnReconcileDate.Index].Style.SelectionBackColor = Color.DodgerBlue;
                }
                else
                {
                    dgvBankReconcile.CurrentRow.Cells[clnReconcileDate.Index].Value = null;
                    dgvBankReconcile.CurrentRow.Cells[clnReconcileDate.Index].ReadOnly = true;
                    dgvBankReconcile.CurrentRow.Cells[clnReconcileDate.Index].Style.BackColor = Color.LightGray;
                    dgvBankReconcile.CurrentRow.Cells[clnReconcileDate.Index].Style.SelectionBackColor = Color.DarkGray;
                }
                FillCurrentBal();
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                    if (MessageBox.Show("Do you wan't to save changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        foreach (DataGridViewRow row in dgvBankReconcile.Rows)
                        {
                            string[] vno = row.Cells[clnInvoiceNo.Index].Value.ToString().Split('-');
                            //MSP.BankReconcile_Add_Edit(cmbBankName.SelectedValue.ToString(), vno[0], vno[1], (bool)row.Cells[clnClear.Index].Value == true ? "1" : "0",
                            //    (bool)row.Cells[clnClear.Index].Value == true ? ((DateTime)row.Cells[clnReconcileDate.Index].Value).ToString("dd-MMM-yyyy") : null);
                            MSP.BankReconcile_Add_Edit1(cmbBankName.SelectedValue.ToString(), vno[0], vno[1], (bool)row.Cells[clnClear.Index].Value == true ? "1" : "0",
                                (bool)row.Cells[clnClear.Index].Value == true ? ((DateTime)row.Cells[clnReconcileDate.Index].Value).ToString("dd-MMM-yyyy") : null, row.Cells[clnCheckNum.Index].Value.ToString(), row.Cells[clnDr.Index].Value.ToString(), row.Cells[clnCr.Index].Value.ToString());
                        }
                        Filldgv();
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Saved Successfully...!");
                    }
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "frmBankReconciliation btnSave_Click");
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (cmbBankName.SelectedIndex != -1)
            {
                //frmReportView.ShowBox("Bank Reconcilation", cmbBankName.SelectedValue.ToString(), dtpTdate.Value.ToString("dd-MMM-yyyy"));
            }
        }




    }
}
