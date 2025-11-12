using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

namespace ERP
{
    public partial class frmBankToBank : Form
    {
        DataTable dtPayment = new DataTable();
        DataTable dtquery = new DataTable();
        DataTable dtClients = new DataTable();
        DataTable dtEmployees = new DataTable();
        DataTable dtdirector = new DataTable();
        DataTable dtCashBalance = new DataTable();
        DataTable dtBank = new DataTable();
        public string Documentid = "0";
        string VNO = "";
        bool FLogIn = true;

        public bool SaveRight;
        public bool DeleteRight;

        public frmBankToBank()
        {
            InitializeComponent();
        }
        void Fillquery()
        {
            dgvQuery.Rows.Clear();
            for (int i = 0; i < dtquery.Rows.Count; i++)
            {
                dgvQuery.Rows.Add(dtquery.Rows[i]["VDate"],
                    "BT-" + dtquery.Rows[i]["VNO"].ToString(),
                    dtquery.Rows[i]["Narration"].ToString(),
                    dtquery.Rows[i]["Amount"].ToString(),
                    dtquery.Rows[i]["VNO"].ToString()
                    );

            }
        }
        string cheque = "";
        void FillPayment(DataTable dt)
        {
            FLogIn = true;
            SupportDocuments = new FrmSupportDocuments();
            SupportDocuments.doucmentname = "BankToBank.tiff";
            if (File.Exists("BankToBank.tiff")) File.Delete("BankToBank.tiff");
            dgvAccount.Rows.Clear();
            rdoCheque.Checked = true;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgvAccount.Rows.Add(dt.Rows[i]["Title"].ToString(), dt.Rows[i]["description"].ToString(), (dt.Rows[i]["dr"].ToString() == "" ? 0 : ((decimal)dt.Rows[i]["dr"])),
                    (dt.Rows[i]["cr"].ToString() == "" ? 0 : (decimal)dt.Rows[i]["cr"]),
                    dt.Rows[i]["cr"], Variable.UserId, null, null, dt.Rows[i]["fkaccountid"].ToString(), dt.Rows[i]["vno"].ToString(),
                    dt.Rows[i]["chequeno"].ToString(),
                     dt.Rows[i]["fkbankid"].ToString(), dt.Rows[i]["vseq"].ToString(),
                   dt.Rows[i]["editable"].ToString());
            }
            txtPreparedBy.Text = dt.Rows[0]["createdby"].ToString();
            txtEditBy.Text = dt.Rows[0]["editby"].ToString();
            txtApprovedBy.Text = dt.Rows[0]["approvedby"].ToString();
            txtPVNo.Text = "BT-" + dt.Rows[0]["VNO"].ToString();
            cmbBankName.SelectedValue = dt.Rows[0]["fkbankid"].ToString();
            rdoCheque.Checked = (cmbBankName.SelectedValue != null ? true : false);
            rdoCash.Checked = !rdoCheque.Checked;
            cmbBankName.SelectedValue = dt.Rows[0]["fkbankid"].ToString();
            mcbToBank.SelectedValue = dt.Rows[1]["fkbankid"].ToString();
            txtChequeNo.Text = dt.Rows[0]["chequeno"].ToString();
            txtSlipNo.Text = dt.Rows[0]["slipno"].ToString();
            status.Text = dt.Rows[0]["status"].ToString();
            cheque = dt.Rows[0]["chequeno"].ToString();
            txtBankDesc.Text = dt.Rows[0]["description"].ToString();
            richtxtToBankDesc.Text = dt.Rows[1]["description"].ToString();
            Documentid = dt.Rows[0]["fkdocumentid"].ToString();
            //txtAmount.Text = dt.Rows[0]["cr"].ToString();
            dgvAccount.CurrentCell = dgvAccount.Rows[dgvAccount.Rows.Count - 1].Cells[0];
            if (Variable.UserId == "Admin") dtpDate.Value = (DateTime)dt.Rows[0]["Vdate"];
            DocumentChanged = "1";

            FLogIn = false;
        }
        bool Calculate()
        {
            decimal Dr = 0, Cr = 0;
            for (int i = 0; i < dgvAccount.Rows.Count; i++)
            {
                if (dgvAccount.Rows[i].Cells[clnDebit.Index].Value != null)
                    Dr += decimal.Parse(dgvAccount.Rows[i].Cells[clnDebit.Index].Value.ToString());
                if (dgvAccount.Rows[i].Cells[clnCredit.Index].Value != null)
                    Cr += decimal.Parse(dgvAccount.Rows[i].Cells[clnCredit.Index].Value.ToString());
            }
            txtTotalDebit.Text = Dr.ToString();
            txtTotalCredit.Text = Cr.ToString();
            return (Dr == Cr ? true : false);
        }
        void Clear()
        {
            dgvAccount.Rows.Clear();
            txtPVNo.Text = "";
            txtPreparedBy.Text = Variable.User;
            txtEditBy.Text = "";
            txtApprovedBy.Text = "";
            txtChequeNo.Text = "";
            richtxtToBankDesc.Text = "";
            txtAmount.Text = "";
        }
        void Clear2()
        {
            txtPVNo.Text = "";
            txtPreparedBy.Text = Variable.User;
            txtEditBy.Text = "";
            txtApprovedBy.Text = "";
            // txtChequeNo.Text = "";
            richtxtToBankDesc.Text = "";
            txtAmount.Text = "";
        }
        void FillcmbBank()
        {
            dtBank = Query.BankIndex();
            dtBank.PrimaryKey = new DataColumn[] { dtBank.Columns["Bankcode"] };

            DataRow rw = dtBank.NewRow();
            rw["Bankcode"] = "000";
            rw["BankName"] = "Cash On Hand";
            dtBank.Rows.InsertAt(rw, 0);

            cmbBankName.DataSource = dtBank;
            cmbBankName.DisplayMember = "BankName";
            cmbBankName.ValueMember = "Bankcode";

            cmbBankName.SelectedIndex = -1;


            mcbToBank.DataSource = dtBank.Copy();
            mcbToBank.DisplayMember = "BankName";
            mcbToBank.ValueMember = "Bankcode";
            mcbToBank.SelectedIndex = -1;

        }
        //string rights;
        private void frmPayment_Load(object sender, EventArgs e)
        {
            try
            {


                this.Text = Variable.Version;
                SupportDocuments = new FrmSupportDocuments();
                SupportDocuments.doucmentname = "BankToBank.tiff";
                if (File.Exists("BankToBank.tiff")) File.Delete("BankToBank.tiff");
                if (Variable.UserId == "Admin")
                    txtChequeNo.ReadOnly = false;
                FillcmbBank();
                rdoCash_CheckedChanged(null, null);
                cmbBankName_SelectedValueChanged(null, null);
                dtClients = Query.ClientIndex2();
                dtEmployees = Query.HRindex4();
                dtdirector = Query.DirectorIndex();
                dtpDate.Value = null;
                if (UserInfo.UserId == "Admin")
                {

                    dtpDate.Enabled = true;
                }
                else
                {
                    dtpDate.Enabled = false;
                }
                statusUserName.Text = "User Name: " + Variable.User;
                statusDateTime.Text = "LogIn Time: " + Variable.UserDateTime;
                FLogIn = false;
                btnPlus.Enabled = true;
                this.Text = Variable.Version;
                Variable.flags = Animate.AW_ACTIVATE | Animate.AW_CENTER;
                Animate.AnimateWindow(this.Handle, Variable.animationTime, Variable.flags);
                dtpDate.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "Payment_ frmPayment_Load");
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "Payment_btnCancel_Click");
            }
        }
        private bool valid()
        {
            bool tf = true;

            if (txtBankDesc.Text.Length == 0 || richtxtToBankDesc.Text.Length == 0)
            {
                string err = MyMessageBox.ShowBox("Enter Description !", Variable.Version, 1);
                txtBankDesc.Focus();
            }
            return tf;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            try
            {
                if (valid())
                {
                    if (txtPVNo.Text == "")
                    {
                        if ((rdoCash.Checked == true || cmbBankName.SelectedValue != null) && txtAmount.Text != "" && mcbToBank.SelectedValue != null)
                        {

                            bool rights = true;// ((rdoCheque.Checked == true && Query.BankBal(cmbBankName.SelectedValue.ToString()) >= amount) ? true : Query.CashBal() >= amount ? true : false);
                            if (Variable.UserId == "Admin" || rights == true)
                            {
                                //if(row != null)

                                if (dgvAccount.Rows.Count == 0)
                                {
                                    dgvAccount.Rows.Add(cmbBankName.Text, txtBankDesc.Text, "0", txtAmount.Text, txtAmount.Text, Variable.UserId, (txtEditBy.Text == "" ? null : txtEditBy.Text), null, (cmbBankName.Text == "Cash On Hand" ? "001001005001001" : AccountHead.CashInBank), (txtPVNo.Text == "" ? null : txtPVNo.Text), (rdoCheque.Checked == true ? txtChequeNo.Text : null), (rdoCheque.Checked == true ? cmbBankName.SelectedValue : null), (dgvAccount.Rows.Count + 1).ToString(), 1);
                                    dgvAccount.Rows.Add(mcbToBank.Text, richtxtToBankDesc.Text, txtAmount.Text, "0", txtAmount.Text, Variable.UserId, (txtEditBy.Text == "" ? null : txtEditBy.Text), null, (mcbToBank.Text == "Cash On Hand" ? "001001005001001" : AccountHead.CashInBank), (txtPVNo.Text == "" ? null : txtPVNo.Text), txtSlipNo.Text, mcbToBank.SelectedValue, (dgvAccount.Rows.Count + 1).ToString(), 1);
                                }
                                decimal a = 0;
                                if (dgvAccount.Rows.Count > 0)
                                {
                                    try
                                    {
                                        a = (from DataGridViewRow row in dgvAccount.Rows
                                             where row.Cells[clnDebit.Index].Value != null
                                             select Convert.ToDecimal(row.Cells[clnDebit.Index].FormattedValue)).Sum();
                                    }
                                    catch
                                    { }
                                    dgvAccount.Rows[0].Cells[clnCredit.Index].Value = a;
                                    dgvAccount.Rows[0].Cells[Amount.Index].Value = a.ToString();
                                }
                                SetDescription(a);
                                Calculate();
                                Clear2();
                            }
                            else
                            {
                                MessageBox.Show("You can't credit more amount from cash or bank...!");
                                txtAmount.Focus();
                            }
                        }
                        else
                            MessageBox.Show("Missing Parameters...!");

                    }
                    else
                        MessageBox.Show("You can't add any existing record...!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "Payment_btnPlus_Click");
                this.Close();
            }
        }
        private void SetDescription(decimal a)
        {
            if (dgvAccount.Rows.Count > 2)
            {
                string BankDesc = "Transfer to " + mcbToBank.Text + " of " + a.ToString();
                foreach (DataGridViewRow item in dgvAccount.Rows)
                {
                    if (item.Index != 0)
                        BankDesc += Environment.NewLine + item.Cells[clnTitleofAccount.Index].Value.ToString() + " = " + item.Cells[clnDebit.Index].Value.ToString() + ",";
                }
                BankDesc = BankDesc.Substring(0, BankDesc.Count() - 1);
                dgvAccount.Rows[0].Cells[clnDescription.Index].Value = BankDesc;
                txtBankDesc.Text = BankDesc;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAccount.Rows.Count == 0)
                    btnPlus_Click(null, null);
                if (dgvAccount.Rows.Count > 0)
                {
                    if (MessageBox.Show("Do you wan't to save changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (txtChequeNo.Text == "" || txtSlipNo.Text == "")
                        {
                            MessageBox.Show("Cheque & Slip No must be required..!");
                            return;
                        }
                        if (true)// if (rights == "S" || rights == "P")
                        {
                            if (!Calculate()) return;
                            Cursor.Current = Cursors.WaitCursor;
                            // for (int i = 0; i < dgvAccount.Rows.Count; i = i + 2)
                            //{
                            string Paccount = "", PDesc = "", Pbankid = "", PchequeNum = "", PDr = "", Pcr = "", PVseq = "", Ptrans = "";
                            foreach (DataGridViewRow item in dgvAccount.Rows)
                            {
                                if ((string)item.Cells[BankID.Index].Value == "" || (string)item.Cells[BankID.Index].Value == null)
                                {
                                    MessageBox.Show("Please Select Bank..!");
                                    return;
                                }
                                Paccount += (string)item.Cells[clnAccount.Index].Value;
                                PDesc += (string)item.Cells[clnDescription.Index].Value;
                                Pbankid += (string)item.Cells[BankID.Index].Value;
                                PDr += (item.Cells[clnDebit.Index].Value != null ? (Convert.ToDecimal(item.Cells[clnDebit.Index].Value.ToString())).ToString() : null);
                                Pcr += (item.Cells[clnCredit.Index].Value != null ? (Convert.ToDecimal(item.Cells[clnCredit.Index].Value.ToString())).ToString() : null);
                                PVseq += (string)item.Cells[Vseq.Index].Value;
                                Ptrans += "BTB-001";
                                PchequeNum += (string)item.Cells[clnCheque.Index].Value;



                                if (item.Index != dgvAccount.Rows.Count - 1)
                                {
                                    Paccount += "~";
                                    PDesc += "~";
                                    Pbankid += "~";
                                    PchequeNum += "~";
                                    PDr += "~";
                                    Pcr += "~";
                                    PVseq += "~";
                                    Ptrans += "~";
                                }
                            }
                            string tf = DML.GL_Add_Edit(dtpDate.Value != null ? ((DateTime)dtpDate.Value).ToString("dd-MMM-yyyy") : null, Paccount, "BT", (string)dgvAccount.Rows[0].Cells[PVNumber.Index].Value, PDesc,
                                 Pbankid, txtChequeNo.Text, PDr,
                                 Pcr, null, null, null, "0", PVseq,
                                 null, null, null, Ptrans, "0", null, null, null, null, null,
                            null,
                                 null, null, null,
                            DocumentChanged, Documentid, (File.Exists("BankToBank.tiff") ? Scanner.FileToArray("BankToBank.tiff") : null), txtSlipNo.Text, null, null);
                            Cursor.Current = Cursors.Default;
                            if (tf.ToLower() == "true") MessageBox.Show("Record Successfully Saved...!");
                            btnNew_Click(null, null);
                            //btnFind_Click(null, null);
                            Calculate();
                        }

                    }
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "Payment_ btnSave_Click");
                this.Close();
            }
        }
        private void fillBankBal()
        {
            if (!FLogIn)
            {
                decimal bal = Query.BankBal(cmbBankName.SelectedValue.ToString());
                txtBalance.Text = (bal >= 0 ? bal : -bal).ToString();
                txtDrCr.Text = (bal >= 0 ? "Dr" : "Cr").ToString();
            }
        }
        private void fillCashBal()
        {
            if (!FLogIn)
            {
                decimal bal = Query.CashBal();
                txtBalance.Text = (bal >= 0 ? bal : -bal).ToString();
                txtDrCr.Text = (bal >= 0 ? "Dr" : "Cr").ToString();
            }
        }
        private void cmbBankName_SelectedValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if ((rdoCash.Checked == true || cmbBankName.SelectedValue != null) && cmbToPay.SelectedValue != null && cmbTransCode.SelectedValue != null)
            //        btnPlus.Enabled = true;
            //    else
            //        btnPlus.Enabled = false;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //    Errors.writeline(ex.Message.ToString(), "Payment_cmbBankName_SelectedValueChanged");
            //}

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
                grpAmount.Enabled = true;
                cmbBankName_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "Payment_btnNew_Click");
            }
        }
        private void rdoCash_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdoCash.Checked == true)
                {
                    cmbBankName.Enabled = false;
                    cmbBankName.SelectedIndex = -1;
                    // txtChequeNo.Enabled = false;
                    if (txtPVNo.Text != "" && !FLogIn)
                    {

                        dgvAccount.Rows[0].Cells[BankID.Index].Value = null;
                        dgvAccount.Rows[0].Cells[clnTitleofAccount.Index].Value = "Cash On Hand";
                        dgvAccount.Rows[0].Cells[clnAccount.Index].Value = "001001005001001";
                    }
                    fillCashBal();
                }
                else
                {
                    cmbBankName.Enabled = true;
                    //  txtChequeNo.Enabled = true;
                    cmbBankName.SelectedIndex = 0;
                    if (txtPVNo.Text != "" && !FLogIn)
                    {
                        // dgvAccount.Rows[0].Cells[PaymentMode.Index].Value = "Cheque";
                        // dgvAccount.Rows[0].Cells[ChequeNumber.Index].Value = txtChequeNo.Text;
                        dgvAccount.Rows[0].Cells[BankID.Index].Value = cmbBankName.SelectedValue;
                        dgvAccount.Rows[0].Cells[clnTitleofAccount.Index].Value = cmbBankName.Text;
                        dgvAccount.Rows[0].Cells[clnAccount.Index].Value = AccountHead.CashInBank;
                    }

                }
                // txtAmount_Validated(null,null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "Payment_rdoCash_CheckedChanged");
            }
            cmbBankName_SelectedIndexChanged(null, null);
        }
        private void dgvQuery_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataTable dt = DML.Voucher(dgvQuery.CurrentRow.Cells[PVNumberQ.Index].Value.ToString(), Variable.BranchCode, "BT", "BTB-001");
                if (dt.Rows.Count > 0)
                {
                    FillPayment(dt);
                    tabPayQuery.SelectedTab = tabPayment;
                }
                Calculate();
                //cmbBankName_SelectedIndexChanged(null, null);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "Payment_dgvQuery_CellDoubleClick");
            }
            Cursor.Current = Cursors.Default;
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                dtquery = DML.VoucherFilter(new string[] {
                    "( trunc(VDate)   between TO_DATE('" + dtpFrom.Value.ToString("dd MMM yyyy")   + "', 'dd MON yyyy')  and TO_DATE('" + dtpTo.Value.ToString("dd MMM yyyy") + "', 'dd MON yyyy') ) " ,
                "fktransactionid =  'BTB-001'",
                "Vtype = 'BT'"
                });
                Fillquery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "Payment_btnFind_Click");
            }
        }
        private void txtAmount_Validated(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    decimal.Parse(txtAmount.Text);
                }
                catch
                {
                    txtAmount.Text = "0";
                }
                if (txtPVNo.Text != "" && dgvAccount.CurrentRow.Index != 0)
                {
                    dgvAccount.Rows[dgvAccount.CurrentRow.Index].Cells[clnDebit.Index].Value = txtAmount.Text;
                    dgvAccount.Rows[dgvAccount.CurrentRow.Index].Cells[Amount.Index].Value = txtAmount.Text;
                    decimal a = 0;
                    if (dgvAccount.Rows.Count > 0)
                    {
                        try
                        {
                            a = (from DataGridViewRow row in dgvAccount.Rows
                                 where row.Cells[clnDebit.Index].Value != null
                                 select Convert.ToDecimal(row.Cells[clnDebit.Index].FormattedValue)).Sum();
                        }
                        catch
                        { }
                        dgvAccount.Rows[0].Cells[clnCredit.Index].Value = a.ToString();
                        dgvAccount.Rows[0].Cells[Amount.Index].Value = a.ToString();
                    }
                    SetDescription(a);
                    Calculate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "Payment_txtAmount_Validated");
            }
        }
        private void richtxtDescription_Validated(object sender, EventArgs e)
        {
            try
            {
                if (txtPVNo.Text != "")
                {
                    dgvAccount.Rows[1].Cells[clnDescription.Index].Value = richtxtToBankDesc.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "frmBankToBank _richtxtDescription_Validated");
            }

        }
        private void txtBankDesc_Validated(object sender, EventArgs e)
        {
            try
            {
                if (txtPVNo.Text != "")
                {
                    dgvAccount.Rows[0].Cells[clnDescription.Index].Value = txtBankDesc.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "Payment_richtxtDescription_Validated");
            }
        }

        private void cmbBankName_Validated(object sender, EventArgs e)
        {
            try
            {
                if (txtPVNo.Text != "" && cmbBankName.SelectedValue != null && rdoCheque.Checked == true)
                {
                    dgvAccount.Rows[0].Cells[BankID.Index].Value = cmbBankName.SelectedValue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "Payment_cmbBankName_Validated");
            }

        }
        private void mcbToBank_Validated(object sender, EventArgs e)
        {
            try
            {
                if (txtPVNo.Text != "" && mcbToBank.SelectedValue != null)
                {
                    dgvAccount.Rows[1].Cells[BankID.Index].Value = mcbToBank.SelectedValue;
                    dgvAccount.Rows[1].Cells[clnTitleofAccount.Index].Value = mcbToBank.Text;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "Payment_cmbBankName_Validated");
            }
        }

        private void txtFilterVoucher_Validated(object sender, EventArgs e)
        {
            try
            {
                if (txtFilterVoucher.Text.Length == 8)
                    VNO = (int.Parse(txtFilterVoucher.Text.Substring(3))).ToString();
            }
            catch
            {
                VNO = "";
                txtFilterVoucher.Text = "";
            }
        }
        private void frmPayment_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                    SendKeys.Send("{tab}");
            }
            catch
            { }
        }
        private void cmbBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbBankName.SelectedValue != null && rdoCheque.Checked == true)
                {
                    fillBankBal();
                    DataRowView dr = (DataRowView)cmbBankName.SelectedItem;
                    txtBranch.Text = dr["branchname"].ToString();
                    txtIBAN.Text = dr["iban"].ToString();
                    // if(dgvAccount.Rows[0].Cells[BankID.Index].Value  == null)
                    if (txtPVNo.Text == "" || (dgvAccount.Rows.Count > 0 && dr["bankcode"].ToString() != (string)dgvAccount.Rows[0].Cells[BankID.Index].Value))
                        txtChequeNo.Text = DML.NextCheque(dr["bankcode"].ToString());
                    else
                        txtChequeNo.Text = cheque == "" ? DML.NextCheque(dr["bankcode"].ToString()) : cheque;


                }
                else if (rdoCash.Checked == true)
                {
                    fillCashBal();
                    txtBranch.Text = "";
                    txtIBAN.Text = "";
                    txtChequeNo.Text = "";

                }
                else
                    lblBankBalance.Text = "";

            }
            catch
            {
                lblBankBalance.Text = "";
            }
        }
        public static string Remarks = "";
        private void btnDelete_Click(object sender, EventArgs e)/*&& (dgvAccount.Rows[0].Cells[Editable.Index].Value.ToString() == "1"*/
        {
            try
            {
                if (dgvAccount.Rows.Count > 0 && dgvAccount.Rows[0].Cells[PVNumber.Index].Value != null)
                {
                    string tf = "";
                    if (MessageBox.Show("Do you wan't to delete this?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        FrmRemarks frm = new FrmRemarks();
                        frm.SetVoucherType = "BankToBank";
                        frm.ShowDialog();

                        if (Remarks != "")
                        {
                            Cursor.Current = Cursors.WaitCursor;

                            string voucherNum = dgvAccount.Rows[0].Cells[PVNumber.Index].Value.ToString();
                            tf = MSP.Change_GL_status(voucherNum, "BT", "1", Remarks);

                            Cursor.Current = Cursors.Default;
                            if (tf == "True") MessageBox.Show("Record Successfully Deleted...!");
                            btnNew_Click(null, null);
                            btnFind_Click(null, null);
                            Calculate();
                            Remarks = "";
                        }
                    }
                }
                else
                    MessageBox.Show("Record not Exist..!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "Payment_ btnDelete_Click");
                this.Close();
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //frmReportView.ShowBox("Voucher", Convert.ToDateTime(dtpDate.Value).ToString("dd-MMM-yyyy"), "JV", int.Parse(voucherNum).ToString("D6"), "Journal Voucher", txtCreatedBy.Text, txtStatus.Text);
                frmReportView.ShowBox("Voucher", Convert.ToDateTime(dtpDate.Value).ToString("dd-MMM-yyyy"), "BT", txtPVNo.Text.Substring(3), "Voucher", "", status.Text);
            }
            catch
            {
                MyMessageBox.ShowBox("Invalid Voucher Number...!", Variable.Version, 1);
                return;
            }
        }
        bool Fquery = true;



        private Image SDImage;
        private FrmSupportDocuments SupportDocuments = new FrmSupportDocuments();
        string DocumentChanged = "1";
        private void picDoucments_Click(object sender, EventArgs e)
        {

            picDoucments.Enabled = false;
            SDImage = picDoucments.Image;
            picDoucments.Image = Properties.Resources.loading;
            backgroundWorker1.RunWorkerAsync();
            picDoucments.Enabled = true;
            DocumentChanged = "0";
        }
        delegate void Function();

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string doc = "";
            this.Invoke(new Function(delegate ()
            {
                // doc = lblDoucmentNo.Text;
                doc = Documentid;
            }));
            SupportDocuments.LockItem = false;
            if (doc != "0") SupportDocuments.LockItem = true;
            if (doc != "0" && (!File.Exists(SupportDocuments.doucmentname)))
            {
                DataTable DoucmentGenerate = new DataTable();
                DoucmentGenerate = Query.CallInvDoucment(doc);
                for (int ii = 0, cc = DoucmentGenerate.Rows.Count; ii < cc; ii++)
                {
                    if (DoucmentGenerate.Rows[ii][0] != DBNull.Value)
                        Scanner.ArrayToFile((byte[])DoucmentGenerate.Rows[ii][0], SupportDocuments.doucmentname);
                }

            }
            this.Invoke(new Function(delegate ()
            {
                SupportDocuments.ShowDialog();
            }));
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            picDoucments.Image = SDImage;
        }


        private void rdoCheque_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnPrintClient_Click(object sender, EventArgs e)
        {
            try
            {
                ////FrmReportView.ShowBox("Voucher", Convert.ToDateTime(dtpDate.Value).ToString("dd-MMM-yyyy"), "BT", txtPVNo.Text.Substring(3), "Voucher");
            }
            catch
            {
                MyMessageBox.ShowBox("Invalid Voucher Number...!", Variable.Version, 1);
                return;
            }
        }

        private void mcbToBank_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (mcbToBank.SelectedValue != null)
            {
                fillBankBal();
                DataRowView dr = (DataRowView)mcbToBank.SelectedItem;
                txtToIBAN.Text = dr["iban"].ToString();
            }
        }

        private void dgvAccount_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPVNo.Text != "" && /*dgvAccount.CurrentRow.Index != 0*/dgvAccount.SelectedRows.Count > 0)
                {

                    txtAmount.Text = dgvAccount.Rows[dgvAccount.CurrentRow.Index].Cells[clnDebit.Index].Value.ToString();
                }
                else if (txtPVNo.Text != "" && dgvAccount.CurrentRow.Index == 0)
                {

                    txtAmount.Text = dgvAccount.Rows[dgvAccount.CurrentRow.Index].Cells[clnCredit.Index].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "frmGeneralVoucher dgvAccount_SelectionChanged");
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    decimal.Parse(txtAmount.Text);
                }
                catch
                {
                    txtAmount.Text = "0";
                }
                if (txtPVNo.Text != "" && dgvAccount.CurrentRow.Index != 0)
                {
                    dgvAccount.Rows[dgvAccount.CurrentRow.Index].Cells[clnDebit.Index].Value = txtAmount.Text;
                    dgvAccount.Rows[dgvAccount.CurrentRow.Index].Cells[Amount.Index].Value = txtAmount.Text;
                    decimal a = 0;
                    if (dgvAccount.Rows.Count > 0)
                    {
                        try
                        {
                            a = (from DataGridViewRow row in dgvAccount.Rows
                                 where row.Cells[clnDebit.Index].Value != null
                                 select Convert.ToDecimal(row.Cells[clnDebit.Index].FormattedValue)).Sum();
                        }
                        catch
                        { }
                        dgvAccount.Rows[0].Cells[clnCredit.Index].Value = a.ToString();
                        dgvAccount.Rows[0].Cells[Amount.Index].Value = a.ToString();
                    }
                    SetDescription(a);
                    Calculate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "Payment_txtAmount_Validated");
            }
        }








    }
}





