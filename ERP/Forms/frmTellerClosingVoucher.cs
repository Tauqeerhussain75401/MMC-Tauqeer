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
using System.IO;
using ERP.Forms;
using System.Text.RegularExpressions;

namespace ERP
{
    public partial class frmTellerClosingVoucher : Form
    {
        DataTable dtReceipt = new DataTable();
        DataTable dtquery = new DataTable();
        DataTable dtClients = new DataTable();
        DataTable dtEmployees = new DataTable();
        DataTable dtdirector = new DataTable();
        DataTable dtDealer = new DataTable();
        DataTable dtBank = new DataTable();
        public string Documentid = "0";
        string VNO = "";
        bool FLogIn = true;

        public bool SaveRight;
        public bool DeleteRight;

        public frmTellerClosingVoucher()
        {
            InitializeComponent();
        }
        private int currentRow;
        private bool resetRow = false;
        void Fillquery()
        {
            dgvQuery.Rows.Clear();
            for (int i = 0; i < dtquery.Rows.Count; i++)
            {
                DataTable dtstatus = Query.getData("select status from voucherdetail where status!=1 and vno='" + dtquery.Rows[i]["VNO"].ToString() + "'");
                if (dtstatus.Rows[0]["status"].ToString() == "0")
                {
                    dgvQuery.Rows.Add(Convert.ToDateTime(dtquery.Rows[i]["VDate"]).ToString("dd MMM yyyy"),
                        dtquery.Rows[i]["vtype"].ToString() + "-" + dtquery.Rows[i]["VNO"].ToString(),
                        dtquery.Rows[i]["Narration"] + "(sessionid:" + dtquery.Rows[i]["sessionid"] + ")",
                        dtquery.Rows[i]["Amount"],
                        dtquery.Rows[i]["VNO"]
                        );
                    dgvQuery.Rows[i].DefaultCellStyle = new DataGridViewCellStyle() { SelectionForeColor = Color.Black, SelectionBackColor = Color.White, BackColor = Color.White };
                }
                else
                {

                    dgvQuery.Rows.Add(Convert.ToDateTime(dtquery.Rows[i]["VDate"]).ToString("dd MMM yyyy"),
                        dtquery.Rows[i]["vtype"].ToString() + "-" + dtquery.Rows[i]["VNO"].ToString(),
                        dtquery.Rows[i]["Narration"],
                        dtquery.Rows[i]["Amount"],
                        dtquery.Rows[i]["VNO"]
                        );
                    dgvQuery.Rows[i].DefaultCellStyle = new DataGridViewCellStyle() { SelectionForeColor = Color.Black, SelectionBackColor = Color.Gainsboro, BackColor = Color.Gainsboro };


                }
            }
        }
        public void FillDetail(string Vno)
        {
            SupportDocuments = new FrmSupportDocuments();
            SupportDocuments.doucmentname = "Receipt.tiff";
            if (File.Exists("Receipt.tiff")) File.Delete("Receipt.tiff");
            dgvAccount.Rows.Clear();
            dgvDebit.Rows.Clear();
            DataTable dt = Query.getVoucher_TellerClosing(Vno, Variable.BranchCode);
            //txtJVNum.Tag = dt.Rows.Cast<DataRow>().Where(w => Convert.ToDecimal(w["dr"]) > 0).ToArray()[0]["vseq"].ToString();
            //txtBankDesc.Text = dt.Select("vseq = '" + Convert.ToString(txtJVNum.Tag) + "'")[0]["description"].ToString();
            //dt.Rows.RemoveAt(dt.Rows.Cast<DataRow>().Where(w => Convert.ToDecimal(w["dr"]) > 0).Select((s, index) => new { index = dt.Rows.IndexOf(s) }).ToArray()[0].index);
            
            //dt.Rows.Cast<DataRow>().Where(w => Convert.ToDecimal(w["dr"]) > 0 && w["vtype"].ToString() == "RV").ToList().ForEach(fe => dt.Rows.RemoveAt(dt.Rows.IndexOf(fe)));
            //dt.Rows.Cast<DataRow>().Where(w => Convert.ToDecimal(w["cr"]) > 0 && w["vtype"].ToString() == "PV").ToList().ForEach(fe => dt.Rows.RemoveAt(dt.Rows.IndexOf(fe)));
            
            txtJVNum.Text = dt.Rows[0]["VNO"].ToString();
            textBox3.Text = Vno;
            dgvAccount.Rows.Clear();
            dgvDebit.Rows.Clear();
            
            DataRow[] rows = dt.Select("vtype = 'RV'");
            
            DataTable dtRV  = rows.Length > 0
            ? rows.CopyToDataTable()
            : dt.Clone();

            rows = dt.Select("vtype = 'PV'");

            DataTable dtPV = rows.Length > 0
            ? rows.CopyToDataTable()
            : dt.Clone();

            for (int i = 0; i < dtRV.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtRV.Rows[i]["cr"]) > 0)
                {
                    int Index = dgvAccount.Rows.Add(dtRV.Rows[i]["Vseq"].ToString(), 0, dtRV.Rows[i]["fkaccountid"].ToString(), null, dtRV.Rows[i]["description"].ToString(),
                        ((decimal)dtRV.Rows[i]["cr"]).ToString("N2"), dtRV.Rows[i]["chequeno"].ToString(), dtRV.Rows[i]["slipno"].ToString(), dtRV.Rows[i]["status"].ToString(), dtRV.Rows[i-1]["fkaccountid"].ToString());
                    SubAccountDataSource(Index, dgvAccount, clnTitleofAccount, clnSubAccountDetail);
                    dgvAccount.Rows[Index].Cells[clnSubAccountDetail.Index].Value = dtRV.Rows[i]["fkaccountid"].ToString() == AccountHead.ClientAccount ? dtRV.Rows[i]["fkclientcode"].ToString() :
                                                                                    dtRV.Rows[i]["fkaccountid"].ToString() == AccountHead.EmployeeAccount ? dtRV.Rows[i]["fkhrid"].ToString() :
                                                                                    dtRV.Rows[i]["fkaccountid"].ToString() == AccountHead.DirectorAccount ? dtRV.Rows[i]["fkdirectorid"].ToString() :
                                                                                    /*dt.Rows[i]["fkaccountid"].ToString() == AccountHead.DealerAccount ? dt.Rows[i]["fkdealercode"].ToString() :*/ null;
                }
            }
            for (int i = 0; i < dtPV.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtPV.Rows[i]["dr"]) > 0)
                {
                    int Index = dgvDebit.Rows.Add(dtPV.Rows[i]["Vseq"].ToString(), 0, dtPV.Rows[i]["fkaccountid"].ToString(), null, dtPV.Rows[i]["description"].ToString(),
                    ((decimal)dtPV.Rows[i]["dr"]).ToString("N2"), dtPV.Rows[i]["chequeno"].ToString(), dtPV.Rows[i]["slipno"].ToString(), dtPV.Rows[i]["status"].ToString(), dtPV.Rows[i-1]["fkaccountid"].ToString());
                    SubAccountDataSource(Index, dgvDebit, dgvDebitClnTitleOfAccount, dgvDebitClnSubAccount);
                    dgvDebit.Rows[Index].Cells[dgvDebitClnSubAccount.Index].Value = dt.Rows[i]["fkaccountid"].ToString() == AccountHead.ClientAccount ? dt.Rows[i]["fkclientcode"].ToString() :
                                                                                    dt.Rows[i]["fkaccountid"].ToString() == AccountHead.EmployeeAccount ? dt.Rows[i]["fkhrid"].ToString() :
                                                                                    dt.Rows[i]["fkaccountid"].ToString() == AccountHead.DirectorAccount ? dt.Rows[i]["fkdirectorid"].ToString() :
                                                                                    /*dt.Rows[i]["fkaccountid"].ToString() == AccountHead.DealerAccount ? dt.Rows[i]["fkdealercode"].ToString() :*/ null;
                }
            }
            dgvAccount.Rows.Add();
            dgvDebit.Rows.Add();
            Calculate(dgvAccount, txtTotalDebit, clnCredit.Index);
            Calculate(dgvDebit, textBox1, dgvDebitclnDebit.Index);
            txtStatus.Text = dt.Rows[0]["status"].ToString();
            txtCreatedBy.Text = dt.Rows[0]["createdby"].ToString();
            txtEditBy.Text = dt.Rows[0]["editby"].ToString();
            txtApprovedBy.Text = dt.Rows[0]["approvedby"].ToString();
            //cmbTransCode.SelectedValue = dt.Rows[0]["fktransactionid"].ToString();
            //cmbBankName.SelectedValue = dt.Rows[0]["fkbankid"].ToString();
            //rdoCheque.Checked = (cmbBankName.SelectedValue != null ? true : false);
            //rdoCash.Checked = !rdoCheque.Checked;
            //cmbBankName.SelectedValue = dt.Rows[0]["fkbankid"].ToString();
            lblImage.Text = dt.Rows[0]["fkdocumentid"].ToString();
            Documentid = dt.Rows[0]["fkdocumentid"].ToString();
            dtpDate.Value = (DateTime)dt.Rows[0]["Vdate"];
            DocumentChanged = "1";
        }
        void FillNarration()
        {
            DataTable dtTransCode = Query.NarrationIndex_TellerVoucher();
            //dtTransCode.Rows.RemoveAt(dtTransCode.Rows.Cast<DataRow>().Where(w => w[0].ToString() == "CLS-0001").Select((s, index) => new { s = s, index = dtTransCode.Rows.IndexOf(s) }).ToArray()[0].index);
            //string[] codesToRemove = { "CLS-0001", "S S-001"};

            //for (int i = dtTransCode.Rows.Count - 1; i >= 0; i--)
            //{
            //    if (codesToRemove.Contains(dtTransCode.Rows[i][0].ToString()))
            //    {
            //        dtTransCode.Rows.RemoveAt(i);
            //    }
            //}
            //cmbTransCode.DataSource = dtTransCode;
            //cmbTransCode.DisplayMember = "narrationtitle";
            //cmbTransCode.ValueMember = "narrationcode";
        }
        void FillcmbBank()
        {
            dtBank = Query.BankIndex();
            dtBank.PrimaryKey = new DataColumn[] { dtBank.Columns["Bankcode"] };
            //cmbBankName.DataSource = dtBank;
            //cmbBankName.DisplayMember = "BankName";
            //cmbBankName.ValueMember = "Bankcode";
            //cmbBankName.SelectedIndex = -1;
        }
        void FillcmbToPay()
        {
            DataTable dtAcc = Query.DetailAccounts();
            clnTitleofAccount.DataSource = dtAcc;
            clnTitleofAccount.DisplayMember = "accounttitle";
            clnTitleofAccount.ValueMember = "AccountId";

            
            dgvDebitClnTitleOfAccount.DataSource = dtAcc;
            dgvDebitClnTitleOfAccount.DisplayMember = "accounttitle";
            dgvDebitClnTitleOfAccount.ValueMember = "AccountId";

        }
        void FillFilterNarration()
        {
            DataTable dtFilterNarration = Query.NarrationIndex();
            DataRow dr = dtFilterNarration.NewRow();
            dr["narrationcode"] = "ALL";
            dr["narrationtitle"] = "ALL";
            dtFilterNarration.Rows.InsertAt(dr, 0);
            cmbFilterNarration.DataSource = dtFilterNarration;
            cmbFilterNarration.DisplayMember = "narrationtitle";
            cmbFilterNarration.ValueMember = "narrationcode";
        }
        bool Calculate(DataGridView dgv, TextBox txtbox, int columnIndex)
        {
            int indexClnTOA = dgv.Name == "dgvAccount" ? clnTitleofAccount.Index : dgv.Name == "dgvDebit" ? dgvDebitClnTitleOfAccount.Index : 0;
            decimal Dr = 0, Cr = 0;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                //if (dgvAccount.Rows[i].Cells[clnDebit.Index].Value != null && dgvAccount.Rows[i].Visible == true && dgvAccount.Rows[i].Cells[clnTitleofAccount.Index].Value != null)
                //    Dr += decimal.Parse(dgvAccount.Rows[i].Cells[clnDebit.Index].Value.ToString());
                if (dgv.Rows[i].Cells[columnIndex].Value != null && dgv.Rows[i].Visible == true && dgv.Rows[i].Cells[indexClnTOA].Value != null)
                    Cr += decimal.Parse(dgv.Rows[i].Cells[columnIndex].Value.ToString());
            }
            txtbox.Text = Cr.ToString("N2");
            txtBoxNet.Text = Convert.ToString(Math.Abs(Convert.ToDecimal(txtTotalDebit.Text == "" ? "0" : txtTotalDebit.Text) - Convert.ToDecimal(textBox1.Text == "" ? "0" : textBox1.Text)));
            //txtTotalCredit.Text = Cr.ToString();
            return (Dr == Cr ? true : false);
        }
        void Clear()
        {
            txtJVNum.Text = "";
            txtCreatedBy.Text = Variable.User;
            txtEditBy.Text = "";
            txtApprovedBy.Text = "";
            dgvAccount.Rows.Clear();
            dgvDebit.Rows.Clear();
            dtpDate.Value = SoftwareInfo.ServerDate;
        }
        void AllowNewRow(DataGridView dgv, DataGridViewComboBoxColumn dgvClnTitleOfAccount, DataGridViewTextBoxColumn dgvClnCredit)
        {
            if (dgv.CurrentRow.Index == dgv.Rows[dgv.Rows.Count - 1].Index)
            {
                if (dgv.CurrentRow.Cells[dgvClnTitleOfAccount.Index].Value != null &&
                    (dgv.CurrentRow.Cells[dgvClnCredit.Index].Value != null
                    //|| dgvAccount.CurrentRow.Cells[clnCredit.Index].Value != null
                    ))
                    dgv.Rows.Add();
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
                Errors.writeline(ex.Message.ToString(), "frmGeneralVoucher  btnCancel_Click");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                //if (SaveRight == true)
                //{
                if (MessageBox.Show("Do you wan't to save changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sessionid = textBox3.Text;
                    List<int> Seq = new List<int>();
                    List<string> Account = new List<string>();
                    List<string> Descr = new List<string>();
                    List<decimal> dr = new List<decimal>();
                    List<decimal> cr = new List<decimal>();
                    List<string> SubAccount = new List<string>();
                    List<int> Status = new List<int>();
                    List<string> ChequeNo = new List<string>();
                    List<string> SlipNo = new List<string>();
                    //Seq.Add(txtJVNum.Text == "" ? 0 : Convert.ToInt32(txtJVNum.Tag));
                    //Account.Add(rdoCash.Checked == true ? Convert.ToString(rdoCash.Tag) : AccountHead.CashInBank);
                    //Descr.Add(txtBankDesc.Text);
                    //dr.Add(dgvAccount.Rows.Cast<DataGridViewRow>().Sum(s => Convert.ToDecimal(s.Cells[clnCredit.Index].Value)));
                    //cr.Add(0);
                    //SubAccount.Add(Convert.ToString(cmbBankName.SelectedValue));
                    //Status.Add(0);
                    //ChequeNo.Add("");
                    if (Convert.ToString(textBox3.Text) == "")
                    {
                        textBox3.Focus();
                        MessageBox.Show("Session ID required...!");
                        return;
                    }
                    //if (rdoCheque.Checked && Convert.ToString(cmbBankName.SelectedValue) == "")
                    //{
                    //    cmbBankName.Focus();
                    //    MessageBox.Show("Bank Name required...!");
                    //    return;
                    //}
                    
                    //DataTable dt = Query.getData(
                    //                "select vno, vtype from voucherdetail " +
                    //                "where fktransactionid = 'S S-001' and description like '%" + sessionid + "%' " +
                    //                "group by vno, vtype");

                    //DataTable dt = Query.getData(
                    //               "select vno, vtype from voucherdetail " +
                    //               "where fktransactionid = 'S S-001(sessionid:" + sessionid + ")' " +
                    //               "group by vno, vtype");
                    DataTable dt = Query.getVoucher_TellerClosing(sessionid, Variable.BranchCode);
                    
                    dt = dt.DefaultView.ToTable(
                     true,   // distinct
                     "vno", "vtype"
                      );

                    string Vno = "";
                    
                    var rows = dt.AsEnumerable().Where(r => r.Field<string>("vtype") == "RV").ToArray();

                    if (rows.Count() > 0 && txtJVNum.Text == "")
                    {
                        MessageBox.Show("Voucher for session " + sessionid + " already created. You can search for and open the voucher from the query tab.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                     if(rows.Count() > 0)   
                        Vno = rows[0]["vno"].ToString();

                    voucher_details("RV", sessionid, dgvAccount, Seq, Account, Descr, dr, cr, SubAccount, Status, ChequeNo, SlipNo, clnTitleofAccount, clnCredit, clnVseq, clnSubAccountDetail, clnDescription, clnChequeNo, clnSlipNo, clnDebitAccId);
                    
                    if(Seq.Count > 0 && Account.Count > 0 && cr.Count > 0)
                        Vno = MSP.Voucher_post2("RV", Vno, sessionid, dtpDate.Value, "S S-001", UserInfo.UserId, Variable.BranchCode, "", Seq, Account, Descr, dr, cr, SubAccount, Status, ChequeNo, SlipNo, DocumentChanged, Documentid, (File.Exists("Receipt.tiff") ? Scanner.FileToArray("Receipt.tiff") : null), "");
                    else
                    {
                        if (Vno != "")
                        {
                            if (MessageBox.Show("Do you wan't to save changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {

                            }
                        }
                    }
                        
                    
                    Seq.Clear(); Account.Clear(); Descr.Clear(); dr.Clear(); cr.Clear(); SubAccount.Clear(); Status.Clear(); ChequeNo.Clear(); SlipNo.Clear();
                    
                    Vno = "";
                    
                    rows = dt.AsEnumerable().Where(r => r.Field<string>("vtype") == "PV").ToArray();

                    
                    if (rows.Count() > 0)
                        Vno = rows[0]["vno"].ToString();

                    voucher_details("PV", sessionid, dgvDebit, Seq, Account, Descr, dr, cr, SubAccount, Status, ChequeNo, SlipNo, dgvDebitClnTitleOfAccount, dgvDebitclnDebit, dgvDebitClnVseq, dgvDebitClnSubAccount, dgvDebitClnDesc, dgvDebitClnChequeNo, dgvDebitClnSlipNo, dgvDebitClnCreditAccountId);
                    
                    if (Seq.Count > 0 && Account.Count > 0 && cr.Count > 0)
                        Vno = MSP.Voucher_post2("PV", Vno, sessionid, dtpDate.Value, "S S-001", UserInfo.UserId, Variable.BranchCode, "", Seq, Account, Descr, dr, cr, SubAccount, Status, ChequeNo, SlipNo, DocumentChanged, Documentid, (File.Exists("Receipt.tiff") ? Scanner.FileToArray("Receipt.tiff") : null), "");
                    else
                    {
                        if (Vno != "")
                        {
                            if (MessageBox.Show("Do you wan't to save changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {

                            }
                        }
                    }
                    
                        
                    
                    

                    MessageBox.Show("Record Successfully Saved...!");
                    try
                    {
                        Clear();
                        dgvAccount.Rows.Add();
                        dgvDebit.Rows.Add();
                        Documentid = "0";
                        dtpDate.Focus();
                        lblImage.Text = "0";

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                        Errors.writeline(ex.Message.ToString(), "frmGeneralVoucher _btnNew_Click");
                    }
                    if (Vno != "")
                    {
                        FillDetail(textBox3.Text);
                    }
                }

                // }
                else
                {
                    MessageBox.Show("You have no rights to save this...!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "Receipt_ btnSave_Click");
                this.Close();
            }
        }
        private void voucher_details(string vtype, string sessionid,DataGridView dgv, List<int> Seq, List<string> Account, List<string> Descr, List<decimal> dr, List<decimal> cr, List<string> SubAccount, List<int> Status, List<string> ChequeNo, List<string> SlipNo, DataGridViewComboBoxColumn dgvClnTitleOfAccount, DataGridViewTextBoxColumn dgvClnCredit, DataGridViewTextBoxColumn dgvClnVseq, DataGridViewComboBoxColumn dgvClnSubAccount, DataGridViewTextBoxColumn dgvClnDescription, DataGridViewTextBoxColumn dgvClnChequeNo, DataGridViewTextBoxColumn dgvClnSlipNo, DataGridViewTextBoxColumn dgvClnDebitAcc)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv[dgvClnTitleOfAccount.Index, i].Value != null && dgv[dgvClnCredit.Index, i].Value != null /*&& dgvAccount[clnCredit.Index, i].Value != null*/)
                {
                    if (((string)dgv[dgvClnTitleOfAccount.Index, i].Value == AccountHead.ClientAccount ||
                        (string)dgv[dgvClnTitleOfAccount.Index, i].Value == AccountHead.DirectorAccount ||
                        (string)dgv[dgvClnTitleOfAccount.Index, i].Value == AccountHead.EmployeeAccount ||
                        (string)dgv[dgvClnTitleOfAccount.Index, i].Value == AccountHead.DealerAccount) &&
                        (dgv[clnSubAccountDetail.Index, i].Value == null))
                    {
                        dgv.CurrentCell = dgv.Rows[i].Cells[dgvClnSubAccount.Index];
                        MessageBox.Show("Sub Account required...!");
                        return;
                    }
                    //if (rdoCheque.Checked && (Convert.ToString(dgvAccount[clnChequeNo.Index, i].Value).Replace(" ", "") == "" || Convert.ToString(dgvAccount[clnSlipNo.Index, i].Value).Replace(" ", "") == ""))
                    //{
                    //    dgvAccount.CurrentCell = dgvAccount.Rows[i].Cells[clnChequeNo.Index];
                    //    MessageBox.Show("Cheque/Slip No. required...!");
                    //    return;
                    //}
                   
                   
                        
                        Seq.Add((Convert.ToInt16(dgv[dgvClnVseq.Index, i].Value) > 0 ? -1 : 0) + Convert.ToInt16(dgv[dgvClnVseq.Index, i].Value));
                        string acc = dgv[dgvClnDebitAcc.Index, i].Value == null ? "001001005001001" : (string)dgv[dgvClnDebitAcc.Index, i].Value;
                        Account.Add(acc);
                        Descr.Add((string)dgv[dgvClnDescription.Index, i].Value);// + "(sessionid:" + sessionid +")");
                        if (vtype == "RV")
                            dr.Add(Convert.ToDecimal(dgv[dgvClnCredit.Index, i].Value.ToString()));
                        else
                            dr.Add(Convert.ToDecimal(0.00m));
                        if (vtype == "RV")
                            cr.Add(Convert.ToDecimal(0.00m));
                        else
                            cr.Add(Convert.ToDecimal(dgv[dgvClnCredit.Index, i].Value.ToString()));
                    //SubAccount.Add(Convert.ToString(cmbBankName.SelectedValue));
                    object a = dgv[dgvClnSubAccount.Index, i].Value;
                        SubAccount.Add((string)a);
                        //Status.Add(Convert.ToInt16(dgvAccount[clnStatus.Index, i].Value.ToString()));
                        Status.Add(0);
                        string nah = Convert.ToString(dgv[dgvClnChequeNo.Index, i].Value == null ? "" : dgv[dgvClnChequeNo.Index, i].Value.ToString());
                        ChequeNo.Add(nah);
                        string na2 = Convert.ToString(dgv[dgvClnSlipNo.Index, i].Value == null ? "" : dgv[dgvClnSlipNo.Index, i].Value.ToString());
                        SlipNo.Add(na2);

                        Seq.Add(Convert.ToInt16(dgv[dgvClnVseq.Index, i].Value.ToString()));
                        Account.Add((string)dgv[dgvClnTitleOfAccount.Index, i].Value);
                        Descr.Add((string)dgv[dgvClnDescription.Index, i].Value);
                        
                        if(vtype == "RV")
                            dr.Add(Convert.ToDecimal(0.00m));
                        else
                            dr.Add(Convert.ToDecimal(dgv[dgvClnCredit.Index, i].Value.ToString()));
                       
                        if (vtype == "RV")
                            cr.Add(Convert.ToDecimal(dgv[dgvClnCredit.Index, i].Value.ToString()));
                        else
                            cr.Add(Convert.ToDecimal(0.00m));
                        
                        SubAccount.Add((string)dgv[dgvClnSubAccount.Index, i].Value);
                        //Status.Add(Convert.ToInt16(dgvAccount[clnStatus.Index, i].Value.ToString()));
                        Status.Add(0);
                        ChequeNo.Add(Convert.ToString(dgv[dgvClnChequeNo.Index, i].Value == null ? "" : dgv[dgvClnChequeNo.Index, i].Value.ToString()));
                        SlipNo.Add(Convert.ToString(dgv[dgvClnSlipNo.Index, i].Value == null ? "" : dgv[dgvClnSlipNo.Index, i].Value.ToString()));
                    
                    //if(vtype == "PV")
                    //{
                    //    int ssq = (Convert.ToInt16(dgv[dgvClnVseq.Index, i].Value) > 0 ? -1 : 0) + Convert.ToInt16(dgv[dgvClnVseq.Index, i].Value);
                    //    Seq.Add(ssq);
                    //    string acc = dgv[dgvClnDebitAcc.Index, i].Value == null ? "001001005001001" : (string)dgv[dgvClnDebitAcc.Index, i].Value;
                    //    Account.Add(acc);
                    //    Descr.Add((string)dgv[dgvClnDescription.Index, i].Value);// + "(sessionid:" + sessionid + ")");
                    //    dr.Add(Convert.ToDecimal(0.00m));
                    //    cr.Add(Convert.ToDecimal(dgv[dgvClnCredit.Index, i].Value.ToString()));
                    //    //SubAccount.Add(Convert.ToString(cmbBankName.SelectedValue));
                    //    SubAccount.Add((string)dgv[dgvClnSubAccount.Index, i].Value);
                    //    //Status.Add(Convert.ToInt16(dgvAccount[clnStatus.Index, i].Value.ToString()));
                    //    Status.Add(0);


                    //    string hello = Convert.ToString(dgv[dgvClnChequeNo.Index, i].Value == null ? "" : dgv[dgvClnChequeNo.Index, i].Value.ToString());
                    //    ChequeNo.Add(hello);
                    //    SlipNo.Add("");

                    //    Seq.Add(Convert.ToInt16(dgv[dgvClnVseq.Index, i].Value.ToString()));
                    //    Account.Add((string)dgv[dgvClnTitleOfAccount.Index, i].Value);
                    //    Descr.Add((string)dgv[dgvClnDescription.Index, i].Value);
                    //    dr.Add(Convert.ToDecimal(dgv[dgvClnCredit.Index, i].Value.ToString()));
                    //    cr.Add(Convert.ToDecimal(0.00m));
                    //    SubAccount.Add((string)dgv[dgvClnSubAccount.Index, i].Value);
                    //    //Status.Add(Convert.ToInt16(dgvAccount[clnStatus.Index, i].Value.ToString()));

                    //    Status.Add(0);
                    //    ChequeNo.Add(Convert.ToString(dgv[dgvClnChequeNo.Index, i].Value == null ? "" : dgv[dgvClnChequeNo.Index, i].Value.ToString()));
                    //    SlipNo.Add("");
                    //}
                }
            }

            if (dr.Sum() != cr.Sum())
            {
                MessageBox.Show("Credit And Credit not equal...");
                return;
            }
        }
        private void fillBankBal()
        {
            if (!FLogIn)
            {
                //decimal bal = Query.BankBal(cmbBankName.SelectedValue.ToString());
                //txtBalance.Text = (bal >= 0 ? bal : -bal).ToString();
                //txtDrCr.Text = (bal >= 0 ? "Dr" : "Cr").ToString();
            }
        }
        private void fillCashBal()
        {
            if (!FLogIn)
            {
                decimal bal = Query.CashBal();
                //txtBalance.Text = (bal >= 0 ? bal : -bal).ToString();
                //txtDrCr.Text = (bal >= 0 ? "Dr" : "Cr").ToString();
            }
        }
        private void frmGeneralVoucher_Load(object sender, EventArgs e)
        {
            try
            {
                
                this.Text = Variable.Version;
                SupportDocuments = new FrmSupportDocuments();
                SupportDocuments.doucmentname = "Receipt.tiff";
                if (File.Exists("Receipt.tiff")) File.Delete("Receipt.tiff");
                FillcmbBank();
                FillNarration();

                //dtpDate.Value = null;
                //if (UserInfo.UserId == "Admin") pnlDate.Enabled = true;
                pnlDate.Enabled = true;
                dtClients = Query.ClientIndex2();
                dtEmployees = Query.HRindex4();
                dtdirector = Query.DirectorIndex();
                dtDealer = Query.DealerInfo();
                FillcmbToPay();
                statusUser.Text = "User Name: " + Variable.User;
                statusDateTime.Text = "LogIn Time: " + Variable.UserDateTime;

                FLogIn = false;
                this.Text = Variable.Version;
                btnNew_Click(null, null);
                cmbFilter.SelectedIndex = 0;

                Variable.flags = Animate.AW_ACTIVATE | Animate.AW_CENTER;
                Animate.AnimateWindow(this.Handle, Variable.animationTime, Variable.flags);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "frmGeneralVoucher frmGeneralVoucher_Load");
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
                dgvAccount.Rows.Add();
                dgvDebit.Rows.Add();
                Documentid = "0";
                dtpDate.Focus();
                lblImage.Text = "0";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "frmGeneralVoucher _btnNew_Click");
            }
        }
        private void dgvQuery_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string sessionid = dgvQuery.CurrentRow.Cells[TransNarrationQ.Index].Value.ToString();
                var match = Regex.Match(sessionid, @"sessionid:(\d+)");
                if (match.Success)
                {
                    sessionid = match.Groups[1].Value;
                    
                }
                FillDetail(sessionid);
                //FillDetail(dgvQuery.CurrentRow.Cells[PVNumberQ.Index].Value.ToString());
                tabJournalQuery.SelectedTab = tabJournal;
                if (UserInfo.UserLevel == "Audit")
                {
                    tabJournal.Enabled = false;
                    tabQuery.Enabled = true;
                    MessageBox.Show("You have no rights to edit the voucher because the voucher is posted.\nPlease contact your Administrator.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "JournAL dgvQuery_CellDoubleClick");
            }
            Cursor.Current = Cursors.Default;
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                string narration = cmbFilterNarration.Text != "ALL" ? Convert.ToString(cmbFilterNarration.SelectedValue) : "ALL";
                string sessionid = textBox4.Text;
                string vno = txtFilterVoucher.Text.Trim();
                string filter = cmbFilter.Text;

                if (!string.IsNullOrWhiteSpace(vno) && !vno.All(char.IsDigit))
                {
                    MessageBox.Show("Only numbers are allowed in Voucher No.");
                    return;
                }

                dtquery = Query.TellerReceiptFilterWithPendingApr(
                    dtpFrom.Value.ToString("dd MMM yyyy"),
                    dtpTo.Value.ToString("dd MMM yyyy"),
                    sessionid,
                    vno,
                    filter);

                Fillquery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Errors.writeline(ex.Message.ToString(), "Receipt_btnFind_Click");
            }
        }

        //private void btnFind_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        dtquery = Query.ReceiptFilterWithPendingApr(dtpFrom.Value.ToString("dd MMM yyyy"), dtpTo.Value.ToString("dd MMM yyyy"),
        //            (cmbFilterNarration.Text != "ALL" ? "  and fktransactionid = '" + Convert.ToString(cmbFilterNarration.SelectedValue) + "'" : ""),
        //            (VNO != "" ? " and VNO = " + VNO : ""), cmbFilter.Text);
        //        Fillquery();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message.ToString());
        //        Errors.writeline(ex.Message.ToString(), "Receipt_btnFind_Click");
        //    }
        //}

        private void txtFilterVoucher_Validated(object sender, EventArgs e)
        {
            try
            {
                if (txtFilterVoucher.Text.Length == 8)
                    VNO = (int.Parse(txtFilterVoucher.Text.Substring(3))).ToString();
            }
            catch
            {
                VNO = "VNO";
                txtFilterVoucher.Text = "";
            }
        }
        private void frmGeneralVoucher_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && !dgvAccount.Focused)
                    SendKeys.Send("{tab}");
            }
            catch
            { }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtJVNum.Text != "")
            {
                string voucherNum = txtJVNum.Text;
                string sessionid = textBox3.Text;
                string AcountClient = "S S-001" + "(" + sessionid + ")";
                try
                {
                    DataTable dt = Query.getVoucher_TellerClosing(sessionid, Variable.BranchCode);
                    DataRow dr = dt.Select("vtype = 'RV'").FirstOrDefault();


                    frmReportView.ShowBox("Voucher", Convert.ToDateTime(dtpDate.Value).ToString("dd-MMM-yyyy"), "RV", int.Parse(dr["vno"].ToString()).ToString("D6"), "Journal Voucher", txtEditBy.Text, txtStatus.Text);
                     
                    frmReportView.ShowBox("Voucher", Convert.ToDateTime(dtpDate.Value).ToString("dd-MMM-yyyy"), "PV", int.Parse(voucherNum).ToString("D6"), "Journal Voucher", AcountClient, txtStatus.Text);
                 
                }
                catch
                {
                    MessageBox.Show("Invalid Voucher Number...!");
                    return;
                }
            }
            else
                MessageBox.Show("Invalid Voucher Number...!");
        }
        public static string Remarks = "";
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //if (DeleteRight == true)
                //{
                if (txtJVNum.Text != "" && UserInfo.UserId == "Admin")
                {
                    string tf = "";
                    if (MessageBox.Show("Do you wan't to delete this?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        FrmRemarks frm = new FrmRemarks();
                        frm.SetVoucherType = "TellerClosingVoucher";
                        frm.ShowDialog();

                        if (Remarks != "")
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            string sessionid = textBox3.Text;
                            DataTable dt = Query.getVoucher_TellerClosing(sessionid, Variable.BranchCode);

                            dt = dt.DefaultView.ToTable(
                             true,   // distinct
                             "vno", "vtype");
                            foreach(DataRow  dr in dt.Rows)
                            {
                                string voucherNum = dr["vno"].ToString();
                                string type = dr["vtype"].ToString();
                                tf = MSP.Change_GL_status(voucherNum, type, "1", Remarks);

                                Cursor.Current = Cursors.Default;
                                if (tf == "True") 
                                    MessageBox.Show("Record Successfully Deleted...!");
                                else
                                {
                                    MessageBox.Show("" + type + " Not Deleted...!");
                                }
                            }
                           
                            btnNew_Click(null, null);
                            btnFind_Click(null, null);
                            Calculate(dgvAccount, txtTotalDebit, clnCredit.Index);
                            Calculate(dgvDebit, textBox1, dgvDebitclnDebit.Index);
                            Remarks = "";
                        }
                    }
                }
                else
                    MessageBox.Show("Record not Exist..!");
                //  }
                //else
                //{
                //    MessageBox.Show("You have no rights to delete this...!");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "Receipt_ btnDelete_Click");
                this.Close();
            }
        }
        bool Fquery = true;
        private void tabJournalQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Fquery) FillFilterNarration();
            Fquery = false;
        }

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

        private void dgvAccount_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clnTitleofAccount.Index)
            {
                SubAccountDataSource(e.RowIndex, dgvAccount, clnTitleofAccount, clnSubAccountDetail);
            }
            if (e.ColumnIndex >= clnTitleofAccount.Index && e.ColumnIndex < clnDescription.Index)
            {
                if (FLogIn) return;
                try
                {
                    string[] Account = new string[] { Convert.ToString(dgvAccount.Rows[e.RowIndex].Cells[clnTitleofAccount.Index].Value), Convert.ToString(dgvAccount.Rows[e.RowIndex].Cells[clnTitleofAccount.Index].FormattedValue) };
                    string SubAccount = "";
                    try
                    {
                        SubAccount = Convert.ToString(((DataGridViewComboBoxCell)dgvAccount.Rows[e.RowIndex].Cells[clnSubAccountDetail.Index]).Items.Cast<DataRowView>().Where(w => w[0].ToString() == Convert.ToString(dgvAccount.Rows[e.RowIndex].Cells[clnSubAccountDetail.Index].Value)).ToArray()[0][Account[0] == AccountHead.ClientAccount ? 3 : 1].ToString());
                    }
                    catch (Exception ee) { }
                    if ((Account[0] == AccountHead.ClientAccount || Account[0] == AccountHead.DirectorAccount || Account[0] == AccountHead.EmployeeAccount) && SubAccount != "")
                        dgvAccount.Rows[e.RowIndex].Cells[clnDescription.Index].Value = "Receipt From " + SubAccount;
                    else
                        dgvAccount.Rows[e.RowIndex].Cells[clnDescription.Index].Value = "Receipt From " + Account[1];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    Errors.writeline(ex.Message.ToString(), "Payment_ cmbToPay_SelectedValueChanged");
                }
            }
        }
        private void dgvDebit_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDebitClnTitleOfAccount.Index)
            {
                SubAccountDataSource(e.RowIndex, dgvDebit, dgvDebitClnTitleOfAccount, dgvDebitClnSubAccount);
            }
            if (e.ColumnIndex >= dgvDebitClnTitleOfAccount.Index && e.ColumnIndex < dgvDebitClnDesc.Index)
            {
                if (FLogIn) return;
                try
                {
                    string[] Account = new string[] { Convert.ToString(dgvDebit.Rows[e.RowIndex].Cells[dgvDebitClnTitleOfAccount.Index].Value), Convert.ToString(dgvDebit.Rows[e.RowIndex].Cells[dgvDebitClnTitleOfAccount.Index].FormattedValue) };
                    string SubAccount = "";
                    try
                    {
                        SubAccount = Convert.ToString(((DataGridViewComboBoxCell)dgvDebit.Rows[e.RowIndex].Cells[dgvDebitClnSubAccount.Index]).Items.Cast<DataRowView>().Where(w => w[0].ToString() == Convert.ToString(dgvDebit.Rows[e.RowIndex].Cells[dgvDebitClnSubAccount.Index].Value)).ToArray()[0][Account[0] == AccountHead.ClientAccount ? 3 : 1].ToString());
                    }
                    catch (Exception ee) { }
                    if ((Account[0] == AccountHead.ClientAccount || Account[0] == AccountHead.DirectorAccount || Account[0] == AccountHead.EmployeeAccount) && SubAccount != "")
                        dgvDebit.Rows[e.RowIndex].Cells[dgvDebitClnDesc.Index].Value = "Payment For " + SubAccount;
                    else
                        dgvDebit.Rows[e.RowIndex].Cells[dgvDebitClnDesc.Index].Value = "Payment For " + Account[1];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    Errors.writeline(ex.Message.ToString(), "Payment_cmbToPay_SelectedValueChanged");
                }
            }
        }
        private void SubAccountDataSource(int RowInd, DataGridView dgv, DataGridViewComboBoxColumn dgvClnTitleOfAccount, DataGridViewComboBoxColumn dgvClnSubAccount)
        {
            if (RowInd > -1)
            {

                if (FLogIn) return;
                try
                {
                    DataGridViewComboBoxCell dgvcbc = new DataGridViewComboBoxCell();
                    if (Convert.ToString(dgv.Rows[RowInd].Cells[dgvClnTitleOfAccount.Index].Value) == AccountHead.ClientAccount)//Client
                    {
                        DataTable dt = new DataTable();
                        dgvcbc.DataSource = dt;
                        DataView SortingData = dtClients.DefaultView;
                        SortingData.Sort = "clienttitle";
                        dtClients = SortingData.ToTable();
                        dgvcbc.DataSource = dtClients;
                        dgvcbc.DisplayMember = "clienttitle";
                        dgvcbc.ValueMember = "clientid";
                        dgv[dgvClnSubAccount.Index, RowInd] = dgvcbc;
                        dgv[dgvClnSubAccount.Index, RowInd].ReadOnly = false;
                    }
                    else if (Convert.ToString(dgv.Rows[RowInd].Cells[dgvClnTitleOfAccount.Index].Value) == AccountHead.DirectorAccount)//Director
                    {
                        DataTable dt = new DataTable();
                        dgvcbc.DataSource = dt;
                        dgvcbc.DataSource = dtdirector;
                        dgvcbc.DisplayMember = "directorname";
                        dgvcbc.ValueMember = "directorid";
                        dgv[dgvClnSubAccount.Index, RowInd] = dgvcbc;
                        dgv[dgvClnSubAccount.Index, RowInd].ReadOnly = false;
                    }
                    else if (Convert.ToString(dgv.Rows[RowInd].Cells[dgvClnTitleOfAccount.Index].Value) == AccountHead.EmployeeAccount)//Employees
                    {
                        DataTable dt = new DataTable();
                        dgvcbc.DataSource = dt;
                        dgvcbc.DataSource = dtEmployees;
                        dgvcbc.DisplayMember = "hrname";
                        dgvcbc.ValueMember = "hrid";
                        dgv[dgvClnSubAccount.Index, RowInd] = dgvcbc;
                        dgv[dgvClnSubAccount.Index, RowInd].ReadOnly = false;
                    }
                    else if (Convert.ToString(dgv.Rows[RowInd].Cells[dgvClnTitleOfAccount.Index].Value) == AccountHead.DealerAccount)//Dealer
                    {
                        DataTable dt = new DataTable();
                        dgvcbc.DataSource = dt;
                        dgvcbc.DataSource = dtDealer;
                        dgvcbc.DisplayMember = "code";
                        dgvcbc.ValueMember = "code";
                        dgv[dgvClnSubAccount.Index, RowInd] = dgvcbc;
                        dgv[dgvClnSubAccount.Index, RowInd].ReadOnly = false;
                    }
                    else
                    {
                        DataTable dt = new DataTable();
                        dgvcbc.DataSource = dt;
                        dgv[dgvClnSubAccount.Index, RowInd].Value = null;
                        dgv[dgvClnSubAccount.Index, RowInd].ReadOnly = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    Errors.writeline(ex.Message.ToString(), "Receipt_ cmbCredit_SelectedIndexChanged");
                }
            }

        }

        private void dgvAccount_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            txtJVNum.ReadOnly = false;
            txtJVNum.Focus();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = MessageBox.Show("Delete this transaction?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning).ToString();
                if (msg == "Yes")
                {
                    if (txtJVNum.Text != "")
                    {
                        dgvAccount.Rows[dgvAccount.CurrentRow.Index].Cells[clnStatus.Index].Value = "1";
                        dgvAccount.CurrentRow.Visible = false;
                    }
                    else
                    {
                        dgvAccount.Rows.RemoveAt(dgvAccount.CurrentRow.Index);
                    }
                    Calculate(dgvAccount, txtTotalDebit, clnCredit.Index);
                    Calculate(dgvDebit, textBox1, dgvDebitclnDebit.Index);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Errors.writeline(er.Message.ToString(), "Form_ Frm_Voucher_ deleteToolStripMenuItem_Click");
            }
        }
        private void dgvAccount_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStrip1.Show();
            }
        }

        private void dgvAccount_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            AllowNewRow(dgvAccount, clnTitleofAccount, clnCredit);
            AllowNewRow(dgvDebit, dgvDebitClnTitleOfAccount,dgvDebitClnChequeNo);
            resetRow = true;
            currentRow = e.RowIndex;
            //if (e.RowIndex > -1 && e.ColumnIndex == clnDebit.Index)
            //{
            //
            //    dgvAccount[clnCredit.Index, e.RowIndex].Value = "0";
            //}
            //if (e.RowIndex > -1 && e.ColumnIndex == clnCredit.Index)
            //{
            //    dgvAccount[clnDebit.Index, e.RowIndex].Value = "0";
            //}
            Calculate(dgvAccount, txtTotalDebit, clnCredit.Index);
            Calculate(dgvDebit, textBox1, dgvDebitclnDebit.Index);
        }

        private void dgvAccount_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgvAccount.Rows[e.RowIndex].Cells[clnStatus.Index].Value == null)
                dgvAccount.Rows[e.RowIndex].Cells[clnStatus.Index].Value = "2";
            if (dgvAccount.Rows[e.RowIndex].Cells[clnVseq.Index].Value == null)
                dgvAccount.Rows[e.RowIndex].Cells[clnVseq.Index].Value = "0";

            ReassignSerialNumbers(dgvAccount, sno);
        }
        private void dgvDebit_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgvDebit.Rows[e.RowIndex].Cells[dgvDebitClnStatus.Index].Value == null)
                dgvDebit.Rows[e.RowIndex].Cells[dgvDebitClnStatus.Index].Value = "2";
            if (dgvDebit.Rows[e.RowIndex].Cells[dgvDebitClnVseq.Index].Value == null)
                dgvDebit.Rows[e.RowIndex].Cells[dgvDebitClnVseq.Index].Value = "0";

            ReassignSerialNumbers(dgvDebit, dgvDebitClnSno);
        }
        private void ReassignSerialNumbers(DataGridView dgv, DataGridViewTextBoxColumn dgvTBC)
        {
            int serial = 1;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    row.Cells[dgvTBC.Index].Value = serial++;
                }
            }
        }
        private void dgvAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.F3)
            {
                if (dgvAccount.CurrentRow.Index > 0 && dgvAccount.CurrentCell.ReadOnly == false)
                {
                    int colIndex = dgvAccount.CurrentCell.ColumnIndex;
                    dgvAccount.CurrentCell.Value = dgvAccount.Rows[dgvAccount.CurrentRow.Index - 1].Cells[colIndex].Value;
                }
            }
            else if (e.KeyCode == Keys.F7 && dgvAccount.CurrentCell.ColumnIndex == clnTitleofAccount.Index)
            {
                frmAccountsSearching srch = new frmAccountsSearching();
                srch.rdoGeneralAcc.Checked = true;
                if (srch.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    dgvAccount.CurrentCell.Value = srch.SearchingCCode;
                }
            }
        }
        private void dgvDebit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.F3)
            {
                if (dgvDebit.CurrentRow.Index > 0 && dgvDebit.CurrentCell.ReadOnly == false)
                {
                    int colIndex = dgvDebit.CurrentCell.ColumnIndex;
                    dgvDebit.CurrentCell.Value = dgvDebit.Rows[dgvDebit.CurrentRow.Index - 1].Cells[colIndex].Value;
                }
            }
            else if (e.KeyCode == Keys.F7 && dgvDebit.CurrentCell.ColumnIndex == dgvDebitClnTitleOfAccount.Index)
            {
                frmAccountsSearching srch = new frmAccountsSearching();
                srch.rdoGeneralAcc.Checked = true;
                if (srch.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    dgvDebit.CurrentCell.Value = srch.SearchingCCode;
                }
            }
        }
        private void dgvAccount_SelectionChanged(object sender, EventArgs e)
        {
            if (resetRow)
            {
                resetRow = false;
                dgvAccount.CurrentCell = dgvAccount.Rows[currentRow].Cells[dgvAccount.CurrentCell.ColumnIndex];
            }
        }

        private void dgvDebit_SelectionChanged(object sender, EventArgs e)
        {
            if (resetRow)
            {
                resetRow = false;
                dgvDebit.CurrentCell = dgvDebit.Rows[currentRow].Cells[dgvDebit.CurrentCell.ColumnIndex];
            }
        }

        private void txtJVNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt = Query.MasterQueryEC(@"select vd.*,get_accountitle_m(vd.fkaccountid,fkclientcode,fkdirectorid,fkhrid,fkbankid) AS title,
                   (CASE WHEN  trunc(To_Date(vdate,'dd Mon yyyy')) = trunc(To_Date(SYSDATE,'dd Mon yyyy')) THEN 1 ELSE 0 END)  AS editable from Voucherdetail vd 
                    where VNO = '" + txtJVNum.Text + "' AND fkbrcode = '" + Variable.BranchCode + "' AND vtype = 'RV' and status <> 1 AND dr = 0 ORDER BY vseq asc");
                if (dt.Rows.Count > 0)
                {
                    dgvAccount.RowsAdded -= new DataGridViewRowsAddedEventHandler(dgvAccount_RowsAdded);
                    dgvAccount.Rows.Clear();
                    txtJVNum.Text = "";
                    txtJVNum.ReadOnly = true;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int Index = dgvAccount.Rows.Add();
                        dgvAccount.BeginEdit(true);
                        dgvAccount.CurrentCell = dgvAccount.Rows[Index].Cells[clnTitleofAccount.Index];
                        dgvAccount.Rows[Index].Cells[clnTitleofAccount.Index].Value = dt.Rows[i]["fkaccountid"];
                        dgvAccount.Rows[Index].Cells[clnDescription.Index].Value = dt.Rows[i]["description"].ToString();
                        dgvAccount.Rows[Index].Cells[clnCredit.Index].Value = (dt.Rows[i]["cr"] == DBNull.Value ? null : dt.Rows[i]["cr"].ToString());
                        dgvAccount.Rows[Index].Cells[clnVseq.Index].Value = "0";
                        dgvAccount.CurrentCell = dgvAccount.Rows[Index].Cells[clnVseq.Index];
                        dgvAccount.Rows[Index].Cells[clnSubAccountDetail.Index].Value =
                            (Convert.ToString(dt.Rows[i]["fkaccountid"]) == AccountHead.ClientAccount ? dt.Rows[i]["fkclientcode"].ToString() :
                            (Convert.ToString(dt.Rows[i]["fkaccountid"]) == AccountHead.EmployeeAccount ? dt.Rows[i]["fkhrid"].ToString() :
                            (Convert.ToString(dt.Rows[i]["fkaccountid"]) == AccountHead.DirectorAccount ? dt.Rows[i]["fkdirectorid"].ToString() :
                        (Convert.ToString(dt.Rows[i]["fkaccountid"]) == AccountHead.DealerAccount ? dt.Rows[i]["fkdealercode"].ToString() : ""))));
                        dgvAccount.Rows[Index].Cells[clnStatus.Index].Value = "0";
                        dgvAccount.EndEdit();
                    }
                    //cmbBankName.SelectedValue = Convert.ToString(dt.Rows[0]["fkbankid"]);
                    //rdoCheque.Checked = (cmbBankName.SelectedValue != null ? true : false);
                    //rdoCash.Checked = !rdoCheque.Checked;
                    //cmbTransCode.SelectedValue = dt.Rows[0]["fktransactionid"].ToString();
                    dgvAccount.RowsAdded += new DataGridViewRowsAddedEventHandler(dgvAccount_RowsAdded);
                    dgvAccount.Rows.Add();
                }
                else
                {
                    MessageBox.Show("Voucher Number not found...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void txtJVNum_Leave(object sender, EventArgs e)
        {
            txtJVNum.Text = "";
            txtJVNum.ReadOnly = true;
        }

        private void cmbBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!FLogIn && cmbBankName.SelectedValue != null && rdoCheque.Checked == true)
            //    {
            //        fillBankBal();
            //        DataRowView dr = (DataRowView)cmbBankName.SelectedItem;
            //        txtBranch.Text = dr["branchname"].ToString();
            //        txtIBAN.Text = dr["iban"].ToString();
            //    }
            //    else if (rdoCash.Checked == true)
            //    {
            //        fillCashBal();
            //        txtBranch.Text = "";
            //        txtIBAN.Text = "";
            //    }
            //}
            //catch
            //{

            //}
        }

        private void rdoCash_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //if (rdoCash.Checked == true)
                //{
                //    cmbBankName.Enabled = false;
                //    cmbBankName.SelectedIndex = -1;
                //    cmbBankName.SelectedValue = "";
                //    dgvAccount.Rows.Cast<DataGridViewRow>().ToList().ForEach(fe => { fe.Cells[clnChequeNo.Index].Value = ""; fe.Cells[clnSlipNo.Index].Value = ""; });
                //}
                //else
                //{
                //    cmbBankName.Enabled = true;
                //    cmbBankName.SelectedIndex = 0;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "Receipt_rdoCash_CheckedChanged");
            }
            //cmbBankName_SelectedIndexChanged(null, null);
        }

        private void dgvAccount_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAccount.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly == true)
                SendKeys.Send("{tab}");
        }

        private void dgvDebit_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDebit.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly == true)
                SendKeys.Send("{tab}");
        }

        private void dgvAccount_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var comboBox = e.Control as DataGridViewComboBoxEditingControl;
            if (comboBox != null)
            {
                comboBox.DropDownStyle = ComboBoxStyle.DropDown;
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
        }
        private void dgvDebit_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var comboBox = e.Control as DataGridViewComboBoxEditingControl;
            if (comboBox != null)
            {
                comboBox.DropDownStyle = ComboBoxStyle.DropDown;
                comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
        }
        private void set_control_session_closing_narration(bool a)
        {
            //rdoCash.Checked = a;
            //rdoCheque.Checked = !a;
            //grpChqCash.Enabled = !a;
            
            //cmbBankName.SelectedValue = a ? "007" : "";
            //cmbBankName.Enabled = !a;
            //txtBranch.Enabled = !a;
            //txtIBAN.Enabled = !a;
        }
        private void cmbTransCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string a = Convert.ToString(cmbTransCode.SelectedValue);
            //if (!FLogIn && Convert.ToString(cmbTransCode.SelectedValue) == "S S-001")
            //{
            //    dgvAccount.Rows.Clear();
            //    set_control_session_closing_narration(true);
                
            //    string sessionId;
            //    string refundSlipNo;
            //    using (var f = new frmInput("Session Id"))
            //    {
            //        if (f.ShowDialog() == DialogResult.OK)
            //            sessionId = f.inputText;
            //        else
            //            return;

            //    }
            //    //using (var f = new frmInput("Refund Slip No"))
            //    //{
            //    //    if (f.ShowDialog() == DialogResult.OK)
            //    //        refundSlipNo = f.inputText;
            //    //    else
            //    //        return;

            //    //}

            //    DataTable dt = ReportQuery.ClosingSummarySessionWise(sessionId);

            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        dgvAccount.Rows.Add(null, null, dt.Rows[i][1].ToString(), null, null, dt.Rows[i][5].ToString(), null, null, null);
            //    }
            //    dgvAccount.Rows.Add();

            //    DataTable dt1 = ReportQuery.get_session_IPDrefundInfo(sessionId);
            //    dgvDebit.Rows.Clear();
            //    for (int i = 0; i < dt1.Rows.Count; i++)
            //    {
            //        dgvDebit.Rows.Add(null, null, "005001006006069", null, null, dt1.Rows[i][2].ToString(), null, null, null);
            //    }
            //    dgvDebit.Rows.Add();
            //}
            //else if(!FLogIn &&  Convert.ToString(cmbTransCode.SelectedValue) != "")
            //    set_control_session_closing_narration(false);
        }

        private void tabJournal_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void grpVouDetail_Enter(object sender, EventArgs e)
        {

        }

        private void lblTransNarration_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFilterVoucher_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cmbFilterNarration_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvQuery_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDebit_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (!userTyped)
                return;
            
            userTyped = false; // reset

            ProcessTextBoxLeave();

        }
        private void ProcessTextBoxLeave()
        {
            
            string sessionId = textBox3.Text;
            DataTable dt = Query.getData("select * from voucherdetail where fkclientcode = " + sessionId + " and status != 1");
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Voucher for session " + sessionId + " already created. You can search for and open the voucher from the query tab.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dt = Query.getData("select shiftname, userid  from vu_usersession where sessionid = " + sessionId + " and status != 1");
            string shiftname = dt.Rows[0][0].ToString();
            txtUserSession.Text = dt.Rows[0][1].ToString();
            if (sessionId != "")
            {
                dgvAccount.Rows.Clear();
                
                dt = ReportQuery.ClosingSummarySessionIPD(sessionId);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int index = dgvAccount.Rows.Add(null, null, dt.Rows[i]["creditacc"].ToString(), null, null, dt.Rows[i]["amount"].ToString(), null, null, null, dt.Rows[i]["debitacc"].ToString());

                    dgvAccount.Rows[index].Cells[clnDescription.Index].Value = "Receipt from " + dgvAccount.Rows[index].Cells[clnTitleofAccount.Index].FormattedValue + " (" + shiftname + ")";
                }
                
                dt = ReportQuery.ClosingSummarySessionWise(sessionId);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int index = dgvAccount.Rows.Add(null, null, dt.Rows[i]["creditacc"].ToString(), null, null, dt.Rows[i]["netamount"].ToString(), null, null, null, dt.Rows[i]["debitacc"].ToString());

                    dgvAccount.Rows[index].Cells[clnDescription.Index].Value = "Receipt from " + dgvAccount.Rows[index].Cells[clnTitleofAccount.Index].FormattedValue + " Public" + " (" + shiftname + ")";
                }

                dt = ReportQuery.SubAddLessDetail(sessionId);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int index = dgvAccount.Rows.Add(null, null, dt.Rows[i]["deptAcc"].ToString(), null, null, dt.Rows[i]["amount"].ToString(), null, null, null, dt.Rows[i]["debitacc"].ToString());

                    dgvAccount.Rows[index].Cells[clnDescription.Index].Value = "Receipt from " + dgvAccount.Rows[index].Cells[clnTitleofAccount.Index].FormattedValue + " " + dt.Rows[i]["patienttype"].ToString() + " (" + shiftname + ")";
                }
                
                dgvAccount.Rows.Add();
               
                Calculate(dgvAccount, txtTotalDebit, clnCredit.Index);

                dgvDebit.Rows.Clear();

                var result = dt.AsEnumerable()
               .GroupBy(r => new
               {
                   PatientType = r.Field<string>("patienttype"),
                   DebitAcc = r.Field<string>("debitacc"),
                   CreditAcc = r.Field<string>("creditacc")
               })
               .Select(g => new
               {
                   g.Key.PatientType,
                   g.Key.DebitAcc,
                   g.Key.CreditAcc,
                   Amount = g.Sum(x => x.Field<decimal>("amount")),
               });
                //dt = result.CopyToDataTable();
                foreach (var item in result)
                {
                    {
                        int index = dgvDebit.Rows.Add(null, null, item.DebitAcc, null, null, item.Amount, null, null, null, item.CreditAcc);
                        dgvDebit.Rows[index].Cells[dgvDebitClnDesc.Index].Value = "Payment for " + dgvDebit.Rows[index].Cells[dgvDebitClnTitleOfAccount.Index].FormattedValue + " (" + shiftname + ")";
                    }
                }

                dt = ReportQuery.get_session_IPDrefundInfo(sessionId);
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int index = dgvDebit.Rows.Add(null, null, dt.Rows[i]["refundacc"].ToString(), null, null, dt.Rows[i]["refundamount"].ToString(), null, null, null, dt.Rows[i]["creditAcc"].ToString());
                    dgvDebit.Rows[index].Cells[dgvDebitClnDesc.Index].Value = "Payment for inpatient refund" + " (" + shiftname + ")";
                }
                Calculate(dgvDebit, textBox1, dgvDebitclnDebit.Index);
                dgvDebit.Rows.Add();
            }
        }
        bool userTyped = false;
        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            // Only mark user activity
            if (textBox3.Focused)
                userTyped = true;
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && userTyped)
            {
                userTyped = false;
                ProcessTextBoxLeave();
                e.SuppressKeyPress = true;
            }
        }
    }
}
