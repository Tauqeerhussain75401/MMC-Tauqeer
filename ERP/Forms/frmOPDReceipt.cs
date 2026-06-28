using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Drawing.Printing;
using ZXing;
using System.Threading.Tasks;
using ERP.Reports;

namespace ERP
{
    public partial class frmOPDReceipt : Form
    {
        public frmOPDReceipt()
        {
            InitializeComponent();
            FillControls.FillcmbTestCatagoryForOPD(new ComboBox[] { cmbOPDCatagory, cmbFilterOpdCatagory });
            FillControls.FillcmbPatientCatagory(cmbPatientType);
            FillControls.FillcmbMember(cmbMembership);
            FillControls.FillReferenceIndex(cmbReference);
        }
        public string PType, PBMJ, PTitle, PName, PGender, PContact, PAge, PAgeUnit, PReference, Premakrs = "";

        private int currentRow;
        private bool resetRow = false;
        bool FLogIn = true;
        private string VoucherNum = null;

        DataTable dtConsultant = Query.ConsultantIndex_opd();//hunain
        DataTable dtDependent = Query.MemberDependentIndex();
        DataTable dtDependentEmpty = new DataTable();
        DataTable dtTest = Query.TestIndex();    
        #region Fill Controls
        DataTable dtQuery;
        void FillQuery(string[] filter, bool GetAll)
        {
            dgvQuery.Rows.Clear();

            if (GetAll) dtQuery = Query.OPDReceiptQuery(filter, (string)cmbOPDCatagory.SelectedValue == null ? "3" : (string)cmbOPDCatagory.SelectedValue);
            for (int i = 0; i < dtQuery.Rows.Count; i++)
            {
                int ind = dgvQuery.Rows.Add(dtQuery.Rows[i].ItemArray);
                if (dtQuery.Rows[i]["noofPrint"].ToString() == "0")
                    dgvQuery.Rows[ind].DefaultCellStyle.BackColor = Color.LightGray;
                if (dtQuery.Rows[i]["status"].ToString() != "0")
                    dgvQuery.Rows[ind].DefaultCellStyle.BackColor = Color.Red;
            }
            lblTotRecordsFetched.Text = "Total Records : " + dtQuery.Rows.Count.ToString("N0");
        }
        internal void FillReceipt(string vno)
        {
            DataTable dt = Query.OPDReceiptDetail(vno);
            ///////////////////////
            dgvExpenses.Rows.Clear();
            if (dt.Rows.Count > 0)
            {
                txtVoucherNo.Text = "OP-" + vno;
                VoucherNum = vno;
                //ntxtTokenNo.Value = Convert.ToDecimal(dt.Rows[0]["tokenno"]);//hunain
                if (dt.Rows[0]["status"].ToString() != "0")
                {
                    pnlControl.Enabled = false;
                    lblStatus.Text = "Deleted";
                    lblStatus.Visible = true;
                    lblRestore.Visible = true;

                    cmbRefundUser.SelectedValue = dt.Rows[0]["RefundUser"];
                    dtpRefundDate.Value = (DateTime)dt.Rows[0]["refunddate"];
                }
                else
                {
                    cmbRefundUser.SelectedValue = dt.Rows[0]["CreatedBy"];
                    dtpRefundDate.Value = (DateTime)dt.Rows[0]["VDate"];
                    pnlControl.Enabled = true;
                    lblStatus.Visible = false;
                    lblRestore.Visible = false;
                }
                dtpDate.Value = (DateTime)dt.Rows[0]["VDate"];
                cmbOPDCatagory.SelectedValue = dt.Rows[0]["Catagoryid"];
                string category = dt.Rows[0]["Catagoryid"].ToString();

                if (category == "2")
                {
                    cmbConsultant.SelectedValue = dt.Rows[0]["laboratoryConsultantid"];
                }
                else
                {
                    cmbConsultant.SelectedValue = dt.Rows[0]["Consultantid"];
                }
                cmbPatientType.SelectedValue = dt.Rows[0]["patienttype"];//.ToString();
                cmbMembership.SelectedValue = dt.Rows[0]["memberid"];
                cmbGender.Text = dt.Rows[0]["gender"].ToString();
                cmbPatientTitle.Text = dt.Rows[0]["patienttitle"].ToString();
                cmbPatientId.Text = dt.Rows[0]["patientname"].ToString();
                txtContactNo.Text = dt.Rows[0]["contactno"].ToString();
                ntxtAge.Text = dt.Rows[0]["age"].ToString();
                cmbAgeUnit.Text = dt.Rows[0]["ageunit"].ToString();
                Application.DoEvents();
                lblGrossAmount.Text = dt.Rows[0]["GrossAmount"].ToString();
                ntxtDiscount.Value = (decimal)dt.Rows[0]["Discount"];
                cmbReference.SelectedValue = dt.Rows[0]["ReferenceId"];
                txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();
                txtCreatedBy.Text = dt.Rows[0]["CreatedBy"].ToString() + " | " + ((DateTime)dt.Rows[0]["CreatedTime"]).ToString("dd-MMM-yyyy hh:mm:ss tt");
                txtEditBy.Text = dt.Rows[0]["EditBy"].ToString() != "" ? dt.Rows[0]["EditBy"].ToString() + " | " + ((DateTime)dt.Rows[0]["EditTime"]).ToString("dd-MMM-yyyy hh:mm:ss tt") : null;
                txtMrno.Text = dt.Rows[0]["MRno"].ToString();


                DataTable dtDetail = Query.OPDTestReceiptDetail(vno);
                dgvExpenses.Rows.Clear();
                for (int i = 0; i < dtDetail.Rows.Count; i++)
                {
                    int ind = dgvExpenses.Rows.Add(i.ToString(), dtDetail.Rows[i]["fktestid"], dtDetail.Rows[i]["amount"].ToString(), dtDetail.Rows[i]["status"].ToString(), dtDetail.Rows[i]["rid"].ToString());
                    dgvExpenses.Rows[ind].Cells[dgvExpclnAmount.Index].Value = dtDetail.Rows[i]["amount"].ToString();
                    AmountValidate(ind);
                }
                dgvExpenses.Rows.Add();
                CalcTotAmount();
                ntxtTokenNo.Value = Convert.ToDecimal(dt.Rows[0]["tokenno"]);

                if (dt.Rows[0]["ispartial"].ToString() == "1")
                {
                    cmbpartialPayment.Text = "YES";
                    pnlPartial.Visible = true;
                    plnbalance.Visible = true;
                    txtpartial.Value = Convert.ToDecimal(dt.Rows[0]["partialamount"].ToString());
                    lblTotAmount.Text = Convert.ToString(txtpartial.Value);
                }
                else
                {
                    cmbpartialPayment.Text = "";
                    plnbalance.Visible = false;
                    pnlPartial.Visible = false;
                    txtpartial.Value = 0;
                }
            }
        }

        #endregion


        void AllowNewRow()
        {
            if (dgvExpenses.CurrentRow.Index == dgvExpenses.Rows[dgvExpenses.Rows.Count - 1].Index)
            {
                if (dgvExpenses.CurrentRow.Cells[clnTest.Index].Value != null &&
                    dgvExpenses.CurrentRow.Cells[dgvExpclnAmount.Index].Value != null)
                    dgvExpenses.Rows.Add();
            }
        }
        void FillSessionBalance()
        {
            try
            {
                DataTable dt = Query.SessionBalanceAddPartialPayment(UserInfo.UserId);
                Decimal Balance = Decimal.Parse(dt.Rows[0][2].ToString());
                lblCash.Text = "Current Cash : " + Balance.ToString("N0");
            }
            catch
            {
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckSession(UserInfo.UserId);
        }
        private void CheckSession(string Vuser)
        {
            int status = MSP.Check_LastSession(Vuser);

            if (status > 0)
            {
                MessageBox.Show("Your previous session is still open...!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmReceipt_Load(object sender, EventArgs e)
        {
            cmbOPDCatagory.SelectedIndex = 1;
            txtFdate.Text = SoftwareInfo.ServerDate.ToString("dd-MMM-yyyy");
            if (UserInfo.UserLevel == "Admin")
            {
                dtpDate.Enabled = true;
                FillControls.FillcmbUser(cmbRefundUser);
                cmbRefundUser.SelectedValue = UserInfo.UserId;
                grpRefundInfo.Visible = true;
            }
            btnFind_Click(null, null); 
            btnNew_Click(null, null);
            FillSessionBalanceAsync();
            dtDependentEmpty = dtDependent.Copy(); 
            dtDependentEmpty.Rows.Clear(); 
            if (UserInfo.UserLevel == "Admin") 
            {
                btnCancelAll.Visible = true;
            }
            btnCancelAll.Visible = false;
            FLogIn = false;
            CheckSession(UserInfo.UserId);
            timer1.Interval = 21600000;
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("{tab}");
            }
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            AllowNewRow();
            resetRow = true;
            currentRow = e.RowIndex;

        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (resetRow)
            {
                resetRow = false;
                //dataGridView1.CurrentCell = dataGridView1.Rows[currentRow].Cells[0];
                dgvExpenses.CurrentCell = dgvExpenses.Rows[currentRow].Cells[dgvExpenses.CurrentCell.ColumnIndex];
            }


        }
        void CalcTotAmount()
        {
            decimal Tot = 0;
            if (FixedRate == 0)
            {
                try
                {
                    Tot = (from DataGridViewRow row in dgvExpenses.Rows
                           where row.Cells[dgvExpclnAmount.Index].Value != null && row.Cells[clnTest.Index].Value != null
                           select decimal.Parse(row.Cells[dgvExpclnAmount.Index].Value.ToString())).Sum();
                }
                catch
                {

                }
            }
            else
            {
                Tot = FixedRate;
            }
            lblGrossAmount.Text = Tot.ToString();
            //ntxtDiscount.Maximum = Tot;
            lblTotAmount.Text = (Tot - (ntxtDiscount.Value)).ToString();
            Application.DoEvents();
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvExpenses.CurrentCellAddress.X == clnTest.DisplayIndex)
            {
                ComboBox cb = e.Control as ComboBox;
                if (cb != null)
                {

                    //  cb.DropDownStyle = ComboBoxStyle.DropDown;
                    // cb.AutoCompleteSource = AutoCompleteSource.ListItems;
                    // cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cb.SelectedIndexChanged += new EventHandler(cb_SelectedIndexChanged);
                    e.CellStyle.BackColor = this.dgvExpenses.DefaultCellStyle.BackColor;
                }
            }
            if (dgvExpenses.CurrentCell.ColumnIndex == dgvExpclnAmount.Index)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null && e.Control.Text != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
                }
            }
        }
        void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvExpenses.CurrentCell.ColumnIndex == clnTest.Index)
            {
                dgvExpenses.Rows[dgvExpenses.CurrentCell.RowIndex].Cells[dgvExpclnAmount.Index].Value = "0";
                if ((sender as ComboBox).SelectedIndex != -1)
                {
                    DataRowView dr = (DataRowView)(sender as ComboBox).SelectedItem;
                    if (dr != null)
                    {
                        dgvExpenses.Rows[dgvExpenses.CurrentCell.RowIndex].Cells[dgvExpclnAmount.Index].Value = dr["HospitalRate"].ToString();
                        DataRowView drConsultant = (DataRowView)cmbConsultant.SelectedItem;
                        if (drConsultant != null && dr["id"].ToString() == "6")
                        {
                            dgvExpenses.Rows[dgvExpenses.CurrentCell.RowIndex].Cells[dgvExpclnAmount.Index].Value = drConsultant["HospitalRate"].ToString();
                        }

                        AmountValidate(dgvExpenses.CurrentCell.RowIndex);
                    }
                    if (dgvExpenses.Rows[dgvExpenses.CurrentCell.RowIndex].Cells[clnTest.Index].Value == null)
                    {
                        dgvExpenses.Rows[dgvExpenses.CurrentCell.RowIndex].Cells[clnTest.Index].Value = dr[0].ToString();
                    }
                }
            }
        }
        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvExpenses.CurrentCell.ColumnIndex == dgvExpclnAmount.Index)
            {
                if ((sender as TextBox).SelectedText.Length > 0)
                {
                    int selind = (sender as TextBox).SelectionStart;
                    (sender as TextBox).Text = (sender as TextBox).Text.Replace((sender as TextBox).SelectedText, "");
                    (sender as TextBox).SelectionStart = selind;
                    (sender as TextBox).SelectionLength = 0;
                }
                if (!char.IsControl(e.KeyChar)
           && !char.IsDigit(e.KeyChar)
           && !((sender as TextBox).Text.Count(a => a == '.') == 0 && e.KeyChar == '.'))
                {
                    e.Handled = true;
                }
            }
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalcTotAmount();

        }

        private void AmountValidate(int RowIndex)
        {
            if (RowIndex != -1)
            {
                if (dgvExpenses[dgvExpclnAmount.Index, RowIndex].Value == null || dgvExpenses[dgvExpclnAmount.Index, RowIndex].Value.ToString() == "0")
                {
                    dgvExpenses.Rows[RowIndex].Cells[dgvExpclnAmount.Index].ReadOnly = false;
                    dgvExpenses.Rows[RowIndex].Cells[dgvExpclnAmount.Index].Style.BackColor = Color.White;
                }
                else
                {
                    dgvExpenses.Rows[RowIndex].Cells[dgvExpclnAmount.Index].ReadOnly = true;
                    dgvExpenses.Rows[RowIndex].Cells[dgvExpclnAmount.Index].Style.BackColor = Color.LightGray;
                }
            }
        }
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int seq = 0;
            try
            {
                seq = (int)(from DataGridViewRow row in dgvExpenses.Rows
                            where row.Cells[clnSeq.Index].Value != null && row.Cells[clnSeq.Index].Value.ToString() != ""
                            select int.Parse(row.Cells[clnSeq.Index].Value.ToString())).Max();
            }
            catch
            {
            }
            if (dgvExpenses.Rows[e.RowIndex].Cells[clnSeq.Index].Value == null)
                dgvExpenses.Rows[e.RowIndex].Cells[clnSeq.Index].Value = (seq + 1).ToString();
        }
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }
        private bool SaveValidation()
        {

            if (txtVoucherNo.Text != "")
            {
                frmAuthentication frm = new frmAuthentication();
                if (UserInfo.UserLevel != "Admin")
                {
                    if (frm.ShowDialog() != DialogResult.OK)
                    {
                        return false;
                    }
                }
            }
            else if (cmbOPDCatagory.SelectedValue == null || cmbPatientId.Text == "")
            {
                MessageBox.Show("OPD Catagory And Patient Name Required...!");
                return false;
            }
            else if (Convert.ToDecimal(lblGrossAmount.Text) == 0)
            {
                MessageBox.Show("Record not saved with 0 amount...!");
                return false;
            }
            if (cmbConsultant.SelectedValue == null && cmbConsultant.Visible == true)
            {
                MessageBox.Show("Consultant Required...!");
                return false;
            }
            if (cmbReference.SelectedValue == null && cmbReference.Visible == true)
            {
                MessageBox.Show("Reference Required...!");
                return false;
            }
            if (cmbMembership.SelectedValue == null && cmbMembership.Visible == true)
            {
                MessageBox.Show("BMJ Member Required...!");
                return false;
            }
            if (txtContactNo.Text == "")
            {
                DataRowView dr = (DataRowView)cmbOPDCatagory.SelectedItem;
                if (dr["ContactRequired"].ToString() == "1")
                {
                    MessageBox.Show("Contact Number Required...!");
                    return false;
                }
            }
            if (txtContactNo.Text.Length != 11)
            {
                MessageBox.Show("Please enter a valid contact number. It should be exactly 11 digits.");
                return false;
            }
            if (ntxtAge.Value == 0)
            {
                DataRowView dr = (DataRowView)cmbOPDCatagory.SelectedItem;
                if (dr["agerequired"].ToString() == "1")
                {
                    MessageBox.Show("Age is Required...!");
                    return false;
                }

            }
            return true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CalcTotAmount();
            if (!SaveValidation())
            {
                return;
            }

            if (UserInfo.UserLevel != "Admin")
            {
                DataRowView TokenStatus = (DataRowView)cmbOPDCatagory.SelectedItem;
                if (TokenStatus["autotoken"].ToString() == "0" && TokenStatus["resforduptoken"].ToString() == "1")
                {
                    DataTable dt = Query.getData(@"SELECT Count(*) FROM opdreceipt opdr WHERE status = 0 AND consultantid = '" + cmbConsultant.SelectedValue.ToString() + "' AND catagoryid = '" + cmbOPDCatagory.SelectedValue.ToString() + "' AND vdate + (8/24) >= SYSDATE AND tokenno = '" + ntxtTokenNo.Value.ToString() + "'");
                    if (Convert.ToInt32(dt.Rows[0][0]) > 0)
                    {
                        if (dgvExpenses.Rows.Count > 0 && (string)dgvExpenses.Rows[0].Cells[clnTest.Index].Value == "6")
                        {
                            MessageBox.Show("This token number has already been issued. Please insert new number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
            if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to save this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string voucher = null;
                voucher = txtVoucherNo.Text == "" ? null : txtVoucherNo.Text.Split('-')[1];
                string cmbPartial = cmbpartialPayment.Text == "" ? "0" : "1";
                if (cmbOPDCatagory.SelectedValue != null)
                {
                    dtpDate.Value = UserInfo.UserLevel == "Admin" ? dtpDate.Value : SoftwareInfo.ServerDate;

                    List<string> fkTestId = new List<string>();
                    List<string> Status = new List<string>();

                    List<decimal> Amount = new List<decimal>();
                    List<string> Rowid = new List<string>();
                    foreach (DataGridViewRow row in dgvExpenses.Rows)
                    {
                        if (row.Cells[clnTest.Index].Value != null &&
                            row.Cells[dgvExpclnAmount.Index].Value != null)
                        {
                            fkTestId.Add(row.Cells[clnTest.Index].Value.ToString());
                            Amount.Add(Decimal.Parse(row.Cells[dgvExpclnAmount.Index].Value.ToString()));

                            if (cmbOPDCatagory.SelectedValue.ToString() == "3")
                            {
                                DataTable ValConsAmount = row.Cells[clnTest.Index].Value.ToString() == "6" ? Query.ConsultantDetail(cmbConsultant.SelectedValue.ToString()) : Query.ValidateTestAmount(row.Cells[clnTest.Index].Value.ToString());
                                if (ValConsAmount.Rows.Count > 0)
                                {
                                    if (ValConsAmount.Rows[0]["hospitalrate"].ToString() != row.Cells[dgvExpclnAmount.Index].Value.ToString())
                                    {
                                        MessageBox.Show("MisMatch Consultant Charges....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                DataTable ValidateTestAmount = Query.ValidateTestAmount(row.Cells[clnTest.Index].Value.ToString());
                                if (ValidateTestAmount.Rows.Count > 0)
                                {
                                    if (ValidateTestAmount.Rows[0]["hospitalrate"].ToString() != row.Cells[dgvExpclnAmount.Index].Value.ToString())
                                    {
                                        MessageBox.Show("MisMatch Test Charges....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                            }

                            Status.Add(row.Cells[clnStatus.Index].Value == null ? "0" : row.Cells[clnStatus.Index].Value.ToString());
                            Rowid.Add(row.Cells[clnRowId.Index].Value == null ? "" : row.Cells[clnRowId.Index].Value.ToString());
                        }
                    }

                    if (cmbOPDCatagory.SelectedValue.ToString() == "2")
                    {
                        string[] VfkTestId = fkTestId.ToArray();

                        // Check for duplicates
                        var duplicateTestIds = VfkTestId
                            .GroupBy(id => id)
                            .Where(g => g.Count() > 1)
                            .Select(g => g.Key)
                            .ToList();

                        if (duplicateTestIds.Any())
                        {
                            MessageBox.Show("A duplicate test has been selected in the list for this patient. Please review the test information to avoid duplicate entries.",
                            "Duplicate Test",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                            return;
                        }

                    }
                    GenerateNewMRNumber();
                    bool newvoucher = voucher == null ? true : false;
                    bool saved = DML.OPDReceipt_Add_Edit(voucher, ntxtTokenNo.Value, dtpDate.Value, cmbOPDCatagory.SelectedValue.ToString(), cmbConsultant.SelectedValue, cmbPatientType.SelectedValue, cmbMembership.SelectedValue,
                        cmbPatientId.SelectedValue, cmbPatientTitle.Text, cmbPatientId.Text, cmbGender.Text, txtContactNo.Text, ntxtAge.Value.ToString(), cmbAgeUnit.Text, (string)cmbReference.SelectedValue, txtRemarks.Text,
                        Decimal.Parse(lblGrossAmount.Text), ntxtDiscount.Value, Decimal.Parse(lblTotAmount.Text),
                        "0", cmbPartial , txtpartial.Value, Decimal.Parse(txtbalance.Text),0, txtMrno.Text, ref voucher);
                    if(newvoucher && !string.IsNullOrEmpty(voucher) && saved)
                    {
                        DataRowView dr = (DataRowView)cmbConsultant.SelectedItem;
                        dr["tokenno"] = (Convert.ToInt32(dr["tokenno"]) + 1);
                    }


                    if (fkTestId.Count > 0)
                        DML.OPDReceiptTestDetail_Add_Edit(fkTestId.Count, Enumerable.Repeat(voucher, fkTestId.Count).ToArray(), fkTestId.ToArray(), Amount.ToArray(), Status.ToArray(), Rowid.ToArray());
                    if (UserInfo.UserLevel != "Admin")
                    {
                        if (!Print(voucher))
                        {
                            MessageBox.Show("Printer Error....!" + Environment.NewLine + "Application will be Exit...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                        }
                    }
                    MessageBox.Show("Record Successfully Saved..!");
                    FillSessionBalance();
                    btnNew_Click(null, null);
                }
            }

        }
        private void dgvQuery_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!FLogIn && e.RowIndex != -1)
            {
                string voucherNo = dgvQuery.Rows[e.RowIndex].Cells[clnVoucherNum.Index].Value.ToString();
                tabDetailQuery.SelectedTab = tabpgDetail;
                FillReceipt(voucherNo.Substring(3));
                //pnlControl.Enabled = true;
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (UserInfo.UserLevel == "Admin")
            {
                if (txtReceiptNo.Text != "")
                {
                    btnCancelAll.Visible = true;
                }
                else
                {
                    btnCancelAll.Visible = false;
                }
            }
            string FDate = txtFdate.Text, TDate = txtTdate.Text, UserId = txtUserid.Text, ReceiptNo = txtReceiptNo.Text, OPDCatagory = (string)cmbOPDCatagory.SelectedValue;
            //FillQuery(new string[] { FDate != "" ? " and trunc(Vdate) >= '" + FDate + "'" : "",
            //    TDate != "" ? " and trunc(Vdate) <= '" + TDate + "'" : "",
            //    UserId != "" ? " and createdby = '" + UserId + "'" : "",
            //    ReceiptNo  != "" ? " and to_number(receiptno)  in (" + ReceiptNo.Replace(' ',',') +")" : "",
            //    txtContact.Text!=""?"and contactno='"+txtContact.Text+"'":""
            //}, true);  Tauqeer 


            FillQueryAsync(new string[] { FDate != "" ? " and trunc(Vdate) >= '" + FDate + "'" : "",
                TDate != "" ? " and trunc(Vdate) <= '" + TDate + "'" : "",
                UserId != "" ? " and createdby = '" + UserId + "'" : "",
                ReceiptNo  != "" ? " and to_number(receiptno)  in (" + ReceiptNo.Replace(' ',',') +")" : "",
                txtContact.Text!=""?"and contactno='"+txtContact.Text+"'":""
            }, true);

        }
        private void txtFdate_Validated(object sender, EventArgs e)
        {
            try
            {
                string text = (sender as TextBox).Text.Replace(" ", "-").Replace("/", "-");
                DateTime date = DateTime.ParseExact(text, Validation.dateformats, CultureInfo.InvariantCulture, DateTimeStyles.None);
                (sender as TextBox).Text = date.ToString("dd-MMM-yyyy");
            }
            catch (Exception)
            {
                (sender as TextBox).Text = "";
            }
        }
        private void dgvQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvQuery.CurrentRow != null)
                {
                    string voucherNo = dgvQuery.CurrentRow.Cells[clnVoucherNum.Index].Value.ToString();
                    tabDetailQuery.SelectedTab = tabpgDetail;
                    FillReceipt(voucherNo.Substring(3));
                    e.Handled = true;
                }
            }
        }
        enum Navigators { Up, Down, Home, End };
        int VoucherIndex = 0;
        void Navigate(Navigators Nav)
        {
            if (dgvQuery.CurrentRow != null && tabDetailQuery.SelectedTab == tabpgDetail)
            {
                if (Nav == Navigators.Up && 0 < VoucherIndex)
                {
                    VoucherIndex--;
                    string voucherNo = dtQuery.Rows[VoucherIndex]["receiptno"].ToString();
                    FillReceipt(voucherNo);
                }
                else if (Nav == Navigators.Down && dtQuery.Rows.Count - 1 > VoucherIndex)
                {
                    VoucherIndex++;
                    string voucherNo = dtQuery.Rows[VoucherIndex]["receiptno"].ToString();
                    FillReceipt(voucherNo);
                }
                else if (Nav == Navigators.End)
                {
                    VoucherIndex = 0;
                    string voucherNo = dtQuery.Rows[VoucherIndex]["receiptno"].ToString();
                    FillReceipt(voucherNo);
                }
                else if (Nav == Navigators.Home)
                {
                    VoucherIndex = dtQuery.Rows.Count - 1;
                    string voucherNo = dtQuery.Rows[VoucherIndex]["receiptno"].ToString();
                    FillReceipt(voucherNo);
                }
            }
        }
        private void tabDetailQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PageDown)
            {
                Navigate(Navigators.Down);
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                Navigate(Navigators.Up);
            }
            else if (e.KeyCode == Keys.Home)
            {
                Navigate(Navigators.Home);
            }
            else if (e.KeyCode == Keys.End)
            {
                Navigate(Navigators.End);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void FillLastIssuedSlip()
        {
            //Tauqeer
            //DataTable Lastentry = Query.getData("SELECT * FROM opdreceipt WHERE  createdby = '" + UserInfo.UserId + "' AND receiptno = (SELECT Max(To_Number(receiptno)) FROM opdreceipt WHERE createdby = '" + UserInfo.UserId + "')");
            DataTable Lastentry = Query.getData(
                        "SELECT patientname, grossamount FROM (" +
                        " SELECT patientname, grossamount FROM opdreceipt " +
                        " WHERE Trunc(vdate) >= Trunc(SYSDATE - 50) AND createdby = '" + UserInfo.UserId + "' " +
                        " ORDER BY TO_NUMBER(receiptno) DESC" +
                        ") WHERE ROWNUM = 1"
                    );
            if (Lastentry.Rows.Count > 0)
            {
                lblLastRecord.Text = "Last Slip Issued Patient Name : " + Lastentry.Rows[0]["patientname"].ToString() + " Of Amount " + Lastentry.Rows[0]["grossamount"].ToString();
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            RefreshCharges();
            dgvExpenses.Rows.Clear();
            int ConsultIndex = cmbConsultant.SelectedIndex;
            Validation.Clear(grpInvoiceDetail);
            dgvExpenses.Rows.Add();
            dtpDate.Focus();
            cmbOPDCatagory_SelectedIndexChanged(null, null);
            cmbPatientType.SelectedIndex = 0;
            cmbpartialPayment.SelectedIndex = 0;
            cmbGender.SelectedIndex = 0;
            cmbAgeUnit.SelectedIndex = 0;
            txtpartial.Value = 0;
            dtpDate.Value = SoftwareInfo.ServerDate;
            cmbConsultant.SelectedIndex = ConsultIndex;
            cmbOPDCatagory.Focus();
            FillLastIssuedSlip(); //Tauqeer
            txtRSearch.Clear();
            txtMrno.Text = string.Empty;
            txtContactNo.Clear();
        }
        #region Navigation
        private void btnHome_Click(object sender, EventArgs e)
        {
            Navigate(Navigators.Home);
        }

        private void btnPri_Click(object sender, EventArgs e)
        {
            Navigate(Navigators.Down);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Navigate(Navigators.Up);
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            Navigate(Navigators.End);
        }
        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtVoucherNo.Text != "")
            {
                frmAuthentication frm = new frmAuthentication();
                if (UserInfo.UserLevel != "Admin")
                {
                    if (frm.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                }
                if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to Delete this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DML.Change_OPDReceipt_Status(txtVoucherNo.Text.Substring(3), "1", (string)cmbRefundUser.SelectedValue, dtpRefundDate.Value);

                    DataGridViewRow row = dgvQuery.Rows.Cast<DataGridViewRow>()
           .Where(r => r.Cells[clnVoucherNum.Index].Value.ToString().Equals(txtVoucherNo.Text))
           .First();
                    btnNew_Click(null, null);
                    dgvQuery.Rows.Remove(row);
                    CalcTotAmount();
                    MessageBox.Show("Record Successfully Deleted..!");
                }

            }
        }

        private void deleteRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserInfo.UserLevel == "Admin" && txtVoucherNo.Text != "")
            {
                if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to Delete this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (dgvExpenses[clnTest.Index, dgvExpenses.CurrentRow.Index].Value != null)
                    {

                        if (txtVoucherNo.Text != "")
                        {
                            DML.OPDReceiptTestDetail_Add_Edit(1, Enumerable.Repeat(txtVoucherNo.Text.Replace("OP-", ""), 1).ToArray(),
                                Enumerable.Repeat(dgvExpenses.CurrentRow.Cells[clnTest.Index].Value.ToString(), 1).ToArray(),
                                Enumerable.Repeat(Convert.ToDecimal(dgvExpenses.CurrentRow.Cells[dgvExpclnAmount.Index].Value.ToString()), 1).ToArray(),
                                Enumerable.Repeat("1", 1).ToArray(), Enumerable.Repeat((string)dgvExpenses.CurrentRow.Cells[clnRowId.Index].Value, 1).ToArray());

                        }
                        dgvExpenses.Rows.RemoveAt(dgvExpenses.CurrentRow.Index);
                        CalcTotAmount();
                        MessageBox.Show("Record Successfully Deleted..!");
                    }
                }
            }
            else if (txtVoucherNo.Text == "")
            {
                if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to Delete this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (dgvExpenses[clnTest.Index, dgvExpenses.CurrentRow.Index].Value != null)
                    {
                        dgvExpenses.Rows.RemoveAt(dgvExpenses.CurrentRow.Index);
                        CalcTotAmount();
                        MessageBox.Show("Record Successfully Deleted..!");
                    }
                }
            }
        }

        private void dgvExpenses_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                dgvExpenses.Rows[e.RowIndex].Selected = true;
                dgvExpenses.CurrentCell = this.dgvExpenses.Rows[e.RowIndex].Cells[e.ColumnIndex];
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void frmReceipt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !dgvExpenses.Focused)
            {
                SendKeys.Send("{tab}");
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
            if (dr != null && dr["allowdiscount"].ToString() == "1")
            {
                lblDiscount.Text = dr["Title"].ToString();
                pnlDiscount.Visible = true;
            }
            else
            {
                ntxtDiscount.Value = 0;
                pnlDiscount.Visible = false;
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
            if (txtVoucherNo.Text == "" && ntxtDiscount.Visible)
            {
                ntxtDiscount.Value = Decimal.Parse(lblGrossAmount.Text);
            }

        }
        decimal FixedRate = 0;
        private void cmbOPDCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            DataRowView dr = (DataRowView)cmbOPDCatagory.SelectedItem;
            if (dr != null && dr["IsConsultantInvolved"].ToString() == "1")
            {
                FixedRate = dr["fixedRate"].ToString() == "" ? 0 : (Decimal)dr["fixedRate"];
                string TestTypeId = dr["showallconsultant"].ToString() == "1" ? "" : dr["altidforconsultant"].ToString() == "" ? dr["id"].ToString() : dr["altidforconsultant"].ToString();
                FillcmbCunsultant(TestTypeId, dr["addnullvalinconsultant"].ToString());
                cmbConsultant.Visible = true;
            }
            else
            {
                FixedRate = 0;
                cmbConsultant.Visible = false;
                cmbConsultant.SelectedIndex = -1;
            }
            if (dr != null && dr["HasTest"].ToString() == "1")
            {
                dgvExpenses.Visible = true;
                dgvExpenses.Rows.Clear();
                //string GetTest, GetRate;
                if (dr != null)
                {
                    FillcmbTest(dr["id"].ToString()/*, out GetTest, out GetRate*/);
                }
                int ind = dgvExpenses.Rows.Add();
                //dgvExpenses.Rows[0].Cells[clnTest.Index].Value = GetTest;
                //dgvExpenses.Rows[0].Cells[clnAmount.Index].Value = GetRate;
                            if (dr != null && dr["DefaultTestId"].ToString() != "")
                {
                    dgvExpenses[clnTest.Index, ind].Value = dr["DefaultTestId"].ToString();
                    DataRow drTest = dtTest.Select("id = '" + dr["DefaultTestId"].ToString() + "'").FirstOrDefault();
                    if (drTest != null)
                    {
                        dgvExpenses[dgvExpclnAmount.Index, ind].Value = drTest["hospitalrate"].ToString();
                        AmountValidate(ind);
                    }
                   
                }
            }
            else
            {
                dgvExpenses.Visible = false;
                dgvExpenses.Rows.Clear();

            }
            if (dr != null && dr["autotoken"].ToString() == "1")
            {
                if (UserInfo.UserLevel != "Admin")
                {
                    ntxtTokenNo.Text = "0";
                    ntxtTokenNo.Enabled = false;
                }
            }

            else
            {
                ntxtTokenNo.Text = "0";
                ntxtTokenNo.Enabled = true;
            }

            CalcTotAmount();
        }

        internal void FillcmbCunsultant(string Id, string NullVal)
        {
            DataTable dt = new DataTable();

            if (Id != "" && Id != "2")
                dt = dtConsultant.Select("testtypeid = '" + Id + "'").Count() > 0 ? dtConsultant.Select("testtypeid = '" + Id + "'").CopyToDataTable() : new DataTable();
            else dt = dtConsultant;

            //if (NullVal != "")
            //{
            //    DataRow dr = dt.NewRow();
            //    dr["Id"] = 0;
            //    dr["Name"] = NullVal;
            //    dt.Rows.InsertAt(dr, 0); 
            //}
            cmbConsultant.DataSource = dt;

            if (dtConsultant.Rows.Count > 0)
            {
                cmbConsultant.DisplayMember = "Name";
                cmbConsultant.ValueMember = "Id";
                cmbConsultant.SelectedIndex = -1;
            }

        }
        internal void FillcmbTest(string Id/*, out string RetTest, out string RetRate*/)
        {

            DataTable dt = dtTest.Select("testtypeid = '" + Id + "'").Count() > 0 ? dtTest.Select("testtypeid = '" + Id + "'").CopyToDataTable() : new DataTable();



            clnTest.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                clnTest.DisplayMember = "Title";
                clnTest.ValueMember = "Id";
            }
            //RetTest = dt.Rows.Count == 1 ? dt.Rows[0]["id"].ToString() : null;
            //RetRate = dt.Rows.Count == 1 ? dt.Rows[0]["hospitalrate"].ToString() : null;
        }

        private void cmbConsultant_SelectedIndexChanged(object sender, EventArgs e)
        {

            lblConsultantCharges.Text = "0";
            DataRowView dr = (DataRowView)cmbConsultant.SelectedItem;
            if (dr != null)
            {
               // ntxtTokenNo.Value = Convert.ToInt32(dr["tokenno"]) + 1;
                lblConsultantCharges.Text = dr["HospitalRate"].ToString();
                for (int i = 0; i < dgvExpenses.Rows.Count; i++)
                {
                    if ((string)dgvExpenses[clnTest.Index, i].Value == "6" || (string)dgvExpenses[clnTest.Index, i].Value == "1366" || (string)dgvExpenses[clnTest.Index, i].Value == "1368")
                    {
                        dgvExpenses[dgvExpclnAmount.Index, i].Value = dr["HospitalRate"].ToString();
                    }
                }
            }

            //DataRowView TokenStatus = (DataRowView)cmbOPDCatagory.SelectedItem;
            //if (TokenStatus != null && cmbConsultant.SelectedValue  != null && TokenStatus["autotoken"].ToString() == "0" && TokenStatus["resforduptoken"].ToString() == "1")
            //{
            //    string q = @"SELECT tokenno FROM opdreceipt opdr WHERE consultantid = '" + cmbConsultant.SelectedValue.ToString() + "' AND catagoryid = '" + cmbOPDCatagory.SelectedValue.ToString() + "' AND vdate + (8/24) >= SYSDATE AND tokenno = '" + ntxtTokenNo.Value.ToString() + "'";
            //    DataTable dt = Query.getData(q);
            //    if (Convert.ToInt32(dt.Rows[0][0]) > 0)
            //    {
            //        if (dgvExpenses.Rows.Count > 0 && (string)dgvExpenses.Rows[0].Cells[clnTest.Index].Value == "6")
            //        {
            //            MessageBox.Show("This token number has already being issued. Please insert new number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }
            //    }
            //}


            //-----------------------------------------------
            //DataRowView drConsultant = null;
            //DataRowView drOpdCategory = null;
            //int consultant = 0;
            //int opdCategory = 0;

            //if ((cmbConsultant.SelectedItem as DataRowView) != null &&
            //    (cmbOPDCatagory.SelectedItem as DataRowView) != null &&
            //    cmbConsultant.SelectedValue != null &&
            //    cmbOPDCatagory.SelectedValue != null &&
            //    int.TryParse(cmbConsultant.SelectedValue.ToString(), out consultant) &&
            //    int.TryParse(cmbOPDCatagory.SelectedValue.ToString(), out opdCategory))
            //{

            //    string q = "SELECT NVL(Max(op.tokenno), 0) AS LastToken  FROM opdreceipt op JOIN usersession us ON us.sessionid = op.sessionid WHERE op.consultantid ='" + cmbConsultant.SelectedValue.ToString() + "'  AND  op.catagoryid = '" + cmbOPDCatagory.SelectedValue.ToString() + "' AND op.vdate >= SYSDATE - INTERVAL '4' HOUR";
            //    DataTable dt = Query.getData(q);
            //    lblLastTokenNo.Text = dt.Rows[0]["LastToken"].ToString();
            //}



            //    if (drconsultant != null && drOpdCategory != null)
            //{
            //    if (cmbConsultant.SelectedValue != null && cmbOPDCatagory.SelectedValue != null)
            //    {
            //        int opdCategory = Convert.ToInt32(cmbConsultant.SelectedValue);
            //        int consultant = Convert.ToInt32(cmbOPDCatagory.SelectedValue);
            //        if (true)
            //        {

            //        }

            //        string q = "SELECT NVL(Max(op.tokenno), 0) AS LastToken  FROM opdreceipt op JOIN usersession us ON us.sessionid = op.sessionid WHERE op.consultantid ='" + cmbConsultant.SelectedValue.ToString() + "'  AND  op.catagoryid = '" + cmbOPDCatagory.SelectedValue.ToString() + "' AND op.vdate >= SYSDATE - INTERVAL '4' HOUR";
            //        DataTable dt = Query.getData(q);
            //    }
            //}



        }

        private void numericUpDown1_Enter(object sender, EventArgs e)
        {
            ntxtAge.Select(0, 5);
        }

        private void dgvExpenses_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (UserInfo.UserLevel == "Admin")
            {
                Print(VoucherNum);
            }
            else
            {
                DataTable dt = ReportQuery.OPDReceipt(VoucherNum);
                if (dt.Rows[0]["noofPrint"].ToString() == "0")
                {
                    Print(VoucherNum);
                }
                else
                {
                    MessageBox.Show("You do not have permission to print this document again.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private bool Print(string voucher)
        {
            bool IsPrinted = false;
            try
            {
                if (voucher != "")
                {
                    DataRowView dr = (DataRowView)cmbOPDCatagory.SelectedItem;
                    if (dr != null && dr["PrintType"].ToString() != "CARD")
                    {
                        DataTable dt = ReportQuery.OPDReceipt(voucher);
                        string category = dt.Rows[0]["CatagoryTitle"].ToString();
                        if (category == "Laboratory")
                        {
                            PrintHussainiLaboratory(voucher, dt);
                            return true;
                        }

                        Reports.OPDReceipt rpt = new Reports.OPDReceipt();
                        DataTable dtTest = ReportQuery.OPDTestReceipt(voucher);
                        dtTest.Columns.Add("QRcode", typeof(byte[]));


                      //  string VoucherNo = "OP-" + voucher;
                      // string QRimagePath = Application.StartupPath + "\\QRCode.jpeg";
                      //  DataTable dtQRcode = Query.GenerateQRCode(VoucherNo, QRimagePath);
                      // foreach (DataRow dr2 in dtTest.Rows)
                      // {
                      // dr2["QRcode"] = (byte[])dtQRcode.Rows[0]["Qrcode"];
                      //}



                        rpt.SetDataSource(dtTest);
                        rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                        rpt.SetParameterValue("@Contact", CompanyInfo.ContactHead);
                        rpt.SetParameterValue("@Address", CompanyInfo.Address);
                        rpt.SetParameterValue("@Catagory", dt.Rows[0]["CatagoryTitle"].ToString());
                        rpt.SetParameterValue("@ReceiptNo", "OP-" + voucher);
                        rpt.SetParameterValue("@Date", (DateTime)dt.Rows[0]["Vdate"]);
                        rpt.SetParameterValue("@Patient", dt.Rows[0]["patientName"].ToString());
                        rpt.SetParameterValue("@Gender", dt.Rows[0]["Gender"].ToString());
                        rpt.SetParameterValue("@Consultant", dt.Rows[0]["ConsultantName"].ToString());
                        rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                        rpt.SetParameterValue("@User", UserInfo.UserName);
                        rpt.SetParameterValue("@Discount", dt.Rows[0]["Discount"].ToString());
                        rpt.SetParameterValue("@Remarks", dt.Rows[0]["Remarks"].ToString());
                        rpt.SetParameterValue("@GrossAmount", dt.Rows[0]["GrossAmount"].ToString());
                        decimal NetAmouunt = Convert.ToDecimal(dt.Rows[0]["NetAmount"].ToString());
                        decimal kECharges = Convert.ToDecimal(dt.Rows[0]["electricitycharges"].ToString());
                        decimal Total = NetAmouunt + kECharges;
                        rpt.SetParameterValue("@NetAmount", NetAmouunt);
                        rpt.SetParameterValue("@electricitycharges", dt.Rows[0]["electricitycharges"].ToString());
                        rpt.SetParameterValue("@DiscountName", dt.Rows[0]["patientType"].ToString());
                        rpt.SetParameterValue("@ReferenceName", dt.Rows[0]["ReferenceName"].ToString());
                        rpt.SetParameterValue("@MemberId", dt.Rows[0]["memberid"].ToString());
                        rpt.SetParameterValue("@TokenNo", dt.Rows[0]["TokenNo"].ToString());
                        rpt.SetParameterValue("@Age", dt.Rows[0]["Age"].ToString());
                        rpt.SetParameterValue("@CreatedBY", dt.Rows[0]["createdby"].ToString());
                        rpt.SetParameterValue("@partialName", "Partial Payment");
                        rpt.SetParameterValue("@Partial", dt.Rows[0]["netbalance"].ToString());
                        rpt.SetParameterValue("@Createdtime", (DateTime)dt.Rows[0]["createdtime"]);
                        rpt.SetParameterValue("@PrintedBy", UserInfo.UserId);
                        rpt.SetParameterValue("@terminal", SoftwareInfo.Terminal);
                        rpt.SetParameterValue("@urcompanyname", CompanyInfo.UrCompanyName);
                        rpt.SetParameterValue("@phoneNo", dt.Rows[0]["contactno"].ToString());
                        rpt.ReportFooterSection7.SectionFormat.EnableUnderlaySection = true;
                        if (dt.Rows[0]["Discount"].ToString() == "0") rpt.ReportFooterSection3.SectionFormat.EnableSuppress = true;
                        if (dt.Rows[0]["electricitycharges"].ToString() == "0") rpt.ReportFooterSection20.SectionFormat.EnableSuppress = true;
                        if (dt.Rows[0]["ispartial"].ToString() == "0") rpt.ReportFooterSection12.SectionFormat.EnableSuppress = true;
                        if (dt.Rows[0]["ReferenceName"].ToString() == "") rpt.ReportFooterSection5.SectionFormat.EnableSuppress = true;
                        if (dt.Rows[0]["memberid"].ToString() == "")
                        {
                            rpt.ReportFooterSection6.SectionFormat.EnableSuppress = true;
                            rpt.ReportFooterSection7.SectionFormat.EnableUnderlaySection = false;
                        }
                        if (dt.Rows[0]["tokenNo"].ToString() == "0") rpt.ReportFooterSection7.SectionFormat.EnableSuppress = true;
                        rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                        if (UserInfo.UserLevel == "Admin")
                        {
                            frmReportView frm = new frmReportView();
                            frm.rptViewer.ReportSource = rpt;
                            frm.Show();
                        }
                        else
                        {
                            rpt.PrintToPrinter(1, true, 1, 9999);
                            Query.Execute("update opdreceipt set noofprint = nvl(noofprint,0) + 1 where receiptno = '" + voucher + "'");
                        }
                    }
                    else
                    {
                        Reports.OPDCard rpt = new Reports.OPDCard();
                        DataTable dt = ReportQuery.OPDReceipt(voucher);
                        rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
                        rpt.SetParameterValue("@Contact", CompanyInfo.ContactHead);
                        rpt.SetParameterValue("@Address", CompanyInfo.Address);
                        rpt.SetParameterValue("@Catagory", dt.Rows[0]["CatagoryTitle"].ToString());
                        rpt.SetParameterValue("@ReceiptNo", "OP-" + voucher);
                        rpt.SetParameterValue("@Date", (DateTime)dt.Rows[0]["Vdate"]);
                        rpt.SetParameterValue("@Patient", dt.Rows[0]["patientName"].ToString());
                        rpt.SetParameterValue("@Gender", dt.Rows[0]["Gender"].ToString());
                        rpt.SetParameterValue("@Consultant", dt.Rows[0]["ConsultantName"].ToString());
                        rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
                        rpt.SetParameterValue("@User", dt.Rows[0]["createdby"].ToString());
                        rpt.SetParameterValue("@Discount", dt.Rows[0]["Discount"].ToString());
                        rpt.SetParameterValue("@Remarks", dt.Rows[0]["Remarks"].ToString());
                        rpt.SetParameterValue("@GrossAmount", dt.Rows[0]["GrossAmount"].ToString());
                        rpt.SetParameterValue("@NetAmount", dt.Rows[0]["NetAmount"].ToString());
                        rpt.SetParameterValue("@DiscountName", dt.Rows[0]["patientType"].ToString() == "PUBLIC" ? "" : dt.Rows[0]["patientType"].ToString());
                        rpt.SetParameterValue("@ReferenceName", dt.Rows[0]["ReferenceName"].ToString());
                        rpt.SetParameterValue("@MemberId", dt.Rows[0]["memberid"].ToString());
                        rpt.SetParameterValue("@TokenNo", dt.Rows[0]["TokenNo"].ToString());
                        rpt.SetParameterValue("@Age", dt.Rows[0]["Age"].ToString());
                        rpt.SetParameterValue("@CreatedBY", dt.Rows[0]["createdby"].ToString());
                        rpt.SetParameterValue("@Createdtime", (DateTime)dt.Rows[0]["createdtime"]);
                        rpt.SetParameterValue("@PrintedBy", UserInfo.UserId);
                        rpt.SetParameterValue("@terminal", SoftwareInfo.Terminal);
                        rpt.SetParameterValue("@urcompanyname", CompanyInfo.UrCompanyName);
                        rpt.SetParameterValue("@phoneNo", dt.Rows[0]["contactno"].ToString());
                        if (dt.Rows[0]["Discount"].ToString() == "0") rpt.ReportFooterSection3.SectionFormat.EnableSuppress = true;
                        if (dt.Rows[0]["ReferenceName"].ToString() == "") rpt.ReportFooterSection5.SectionFormat.EnableSuppress = true;
                        if (dt.Rows[0]["memberid"].ToString() == "")
                        {
                            rpt.ReportFooterSection6.SectionFormat.EnableSuppress = true;
                        }
                        else
                        {
                            rpt.ReportFooterSection1.SectionFormat.EnableUnderlaySection = true;
                        }
                        if (dt.Rows[0]["tokenNo"].ToString() == "0") rpt.ReportFooterSection7.SectionFormat.EnableSuppress = true;
                        if (UserInfo.UserLevel == "Admin")
                        {
                            frmReportView frm = new frmReportView();
                            frm.rptViewer.ReportSource = rpt;
                            frm.Show();
                        }
                        else
                        {
                            rpt.PrintToPrinter(1, true, 1, 9999);
                            Query.Execute("update opdreceipt set noofprint = nvl(noofprint,0) + 1 where receiptno = '" + voucher + "'");
                        }

                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void ntxtDiscount_ValueChanged(object sender, EventArgs e)
        {
            lblTotAmount.Text = (Decimal.Parse(lblGrossAmount.Text) - (ntxtDiscount.Value)).ToString();
            if (txtpartial.Value > 0)
            {
                lblTotAmount.Text = (Decimal.Parse(lblGrossAmount.Text) - (ntxtDiscount.Value + txtpartial.Value)).ToString();
                //Net Received
                lblTotAmount.Text = (txtpartial.Value).ToString();
                //Balance
                txtbalance.Text = (Decimal.Parse(lblGrossAmount.Text) - (ntxtDiscount.Value + txtpartial.Value)).ToString();
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
                            string formattedDate = validityDate.Value.ToString("dd-MMM-yyyy"); // e.g., 21-Jul-2025
                            MessageBox.Show(
                                "Membership is no longer valid.The card expired on " + formattedDate +
                                ". Please contact the management.",
                                "Invalid Membership",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
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
            dt = dtDependent.Select("newno = '" + Id + "'").Count() > 0 ? dtDependent.Select("newno = '" + Id + "'").CopyToDataTable() : dtDependentEmpty.Copy();
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

        private void ntxtTokenNo_Enter(object sender, EventArgs e)
        {
            ntxtTokenNo.Select(0, 20);
        }

        private void cmbPatientTitle_Validated(object sender, EventArgs e)
        {
            if (cmbPatientTitle.Text == "Ms." || cmbPatientTitle.Text == "Miss." || cmbPatientTitle.Text == "Mrs." || cmbPatientTitle.Text == "Baby." || cmbPatientTitle.Text == "D/O.")
                cmbGender.Text = "Female";
            else
                cmbGender.Text = "Male";
        }

        private void lblRestore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtVoucherNo.Text != "")
            {
                frmAuthentication frm = new frmAuthentication();
                if (UserInfo.UserLevel != "Admin")
                {
                    if (frm.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                }
                if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to Restore this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DML.Change_OPDReceipt_Status(txtVoucherNo.Text.Substring(3), "0", null, dtpRefundDate.Value);

                    btnNew_Click(null, null);
                    CalcTotAmount();
                    MessageBox.Show("Record Successfully Restored..!");
                }

            }
        }

        private void cmbpartialPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            object data = cmbpartialPayment.SelectedItem;
            if (data != "" && data != null)
            {
                pnlPartial.Visible = true;
                plnbalance.Visible = true;
                label20.Text = "Net Rec Amount :";
            }
            else
            {
                pnlPartial.Visible = false;
                plnbalance.Visible = false;
                cmbpartialPayment.SelectedIndex = -1;
                label20.Text = "Net Amount :";
            }

        }

        private void txtpartial_ValueChanged(object sender, EventArgs e)
        {
            lblTotAmount.Text = (Decimal.Parse(lblGrossAmount.Text) - (ntxtDiscount.Value)).ToString();
            if (txtpartial.Value >0)
            {
                lblTotAmount.Text =  (Decimal.Parse(lblGrossAmount.Text) - (ntxtDiscount.Value + txtpartial.Value)).ToString();
                //Net Received
                lblTotAmount.Text = (txtpartial.Value).ToString();
                //Balance
                txtbalance.Text = (Decimal.Parse(lblGrossAmount.Text) - (ntxtDiscount.Value + txtpartial.Value)).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tabDetailQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (UserInfo.UserId != "Admin" && tabDetailQuery.SelectedTab == tpDetail)
            //{
            //    btnFind_Click(null, null);
            //} Tauqeer

        }

        private void lblGrossAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtVoucherNo.Text == "" && ntxtDiscount.Visible)
            {
                ntxtDiscount.Value = Decimal.Parse(lblGrossAmount.Text);
            }
        }


        //BASIT 4/3/2020
        private void dgvExpenses_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clnTest.Index && e.RowIndex > -1)
            {
                string name = (string)dgvExpenses.Rows[e.RowIndex].Cells[clnTest.Index].Value;
                if (name != null)
                {
                    DataRow drTest = dtTest.Select("id = '" + name + "'").FirstOrDefault();
                    if (drTest != null)
                    {
                        if ((string)dgvExpenses[clnTest.Index, e.RowIndex].Value == name && drTest["id"].ToString() != "6")
                        {
                            if (txtReceiptNo.Text == null)
                            {
                                dgvExpenses[dgvExpclnAmount.Index, e.RowIndex].Value = drTest != null ? drTest["HospitalRate"].ToString() : null;
                            }
                        }
                        else
                        {
                            DataRowView drConsultant = (DataRowView)cmbConsultant.SelectedItem;
                            if (drConsultant != null && drTest["id"].ToString() == "6")
                            {
                                dgvExpenses[dgvExpclnAmount.Index, e.RowIndex].Value = drConsultant["HospitalRate"].ToString();
                            }
                        }
                    }
                }
            }
        }

        private void txtContactNo_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7 && txtContactNo.Focused == true && txtContactNo.Text != "")
            {
                Forms.frmSearchHisByContactNo frm = new Forms.frmSearchHisByContactNo();
                frm.contactno = txtContactNo.Text;
                //frm.Show();
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.dtFillPatHis.Rows.Count > 0)
                    {
                        dgvExpenses.Rows.Clear();
                        Validation.Clear(grpInvoiceDetail);
                        lblTotAmount.Text = "0";
                        lblGrossAmount.Text = "0";
                        ntxtDiscount.Value = 0;
                        DataRow dr = frm.dtFillPatHis.Rows[0];

                        cmbPatientType.SelectedValue = dr["patienttype"].ToString();
                        if (dr["memberid"].ToString() != "")
                        {
                            cmbMembership.SelectedValue = dr["memberid"].ToString();
                        }
                        cmbPatientTitle.Text = dr["patienttitle"].ToString();
                        cmbPatientId.Text = dr["patientname"].ToString();
                        cmbGender.Text = dr["gender"].ToString();
                        txtContactNo.Text = dr["contactno"].ToString();
                        ntxtAge.Value = Convert.ToInt32(dr["age"].ToString());
                        cmbAgeUnit.Text = dr["ageunit"].ToString();
                        cmbReference.SelectedValue = dr["referenceid"].ToString();
                        txtRemarks.Text = dr["remarks"].ToString();
                        txtMrno.Text = dr["mrno"].ToString();
                    }
                    cmbOPDCatagory.Focus();

                }

            }
        }


        private void btnCancelAll_Click(object sender, EventArgs e)
        {
            frmAuthentication frm = new frmAuthentication();
            if (UserInfo.UserLevel != "Admin")
            {
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }
            if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to Delete this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                for (int i = 0; i < dgvQuery.Rows.Count; i++)
                {
                    //string refundUser = "", refundate;
                    //string[] refundUserArray = dgvQuery.Rows[i].Cells[ClnCreatedby .Index ].Value.ToString().Split('|');
                    //string  refundUser  = refundUserArray[0].TrimEnd();
                    //string refundate = refundUserArray[1].TrimStart() ;
                    DML.Change_OPDReceipt_Status(dgvQuery.Rows[i].Cells[clnVoucherNum.Index].Value.ToString().Substring(3), "1", null, null);
                }

            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshCharges();

        }
        private void RefreshCharges()
        {
            FillControls.FillcmbMember(cmbMembership);
            FillControls.FillReferenceIndex(cmbReference);
            cmbOPDCatagory.SelectedItem = 1;
            dtTest.Rows.Clear();
            dtTest = Query.TestIndex();
            DataRowView dr = (DataRowView)cmbOPDCatagory.SelectedItem;
            dgvExpenses.Visible = false;
            dgvExpenses.Rows.Clear();
            if (dr != null)
            {
                FillcmbTest(dr["id"].ToString());
            }
            int ind = dgvExpenses.Rows.Add();
            if (dr != null && dr["DefaultTestId"].ToString() != "")
            {
                dgvExpenses[clnTest.Index, ind].Value = dr["DefaultTestId"].ToString();
                DataRow drTest = dtTest.Select("id = '" + dr["DefaultTestId"].ToString() + "'").FirstOrDefault();
                if (drTest != null)
                {
                    dgvExpenses[dgvExpclnAmount.Index, ind].Value = drTest["hospitalrate"].ToString();
                    AmountValidate(ind);
                    cmbOPDCatagory.SelectedIndex = -1;
                }
            }
            //dtConsultant.Rows.Clear(); Tauqeer
            //dtConsultant = Query.ConsultantIndex(); Tauqeer
            cmbConsultant.DataSource = dtConsultant;
            if (dtConsultant.Rows.Count > 0)
            {
                cmbConsultant.DisplayMember = "Name";
                cmbConsultant.ValueMember = "Id";
                cmbConsultant.SelectedIndex = -1;
            }
            cmbOPDCatagory.Focus();
        }
        private void btnRefreshQuery_Click(object sender, EventArgs e)
        {
            btnFind_Click(null, null);      
        }

        private void txtContactNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7 && txtContactNo.Focused == true && txtContactNo.Text != "")
            {
                Forms.frmSearchHisByContactNo frm = new Forms.frmSearchHisByContactNo();
                frm.contactno = txtContactNo.Text;
                //frm.Show();
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.dtFillPatHis.Rows.Count > 0)
                    {
                        dgvExpenses.Rows.Clear();
                        Validation.Clear(grpInvoiceDetail);
                        lblTotAmount.Text = "0";
                        lblGrossAmount.Text = "0";
                        ntxtDiscount.Value = 0;
                        DataRow dr = frm.dtFillPatHis.Rows[0];

                        cmbPatientType.SelectedValue = dr["patienttype"].ToString();
                        if (dr["memberid"].ToString() != "")
                        {
                            cmbMembership.SelectedValue = dr["memberid"].ToString();
                        }
                        cmbPatientTitle.Text = dr["patienttitle"].ToString();
                        cmbPatientId.Text = dr["patientname"].ToString();
                        cmbGender.Text = dr["gender"].ToString();
                        txtContactNo.Text = dr["contactno"].ToString();
                        ntxtAge.Value = Convert.ToInt32(dr["age"].ToString());
                        cmbAgeUnit.Text = dr["ageunit"].ToString();
                        cmbReference.SelectedValue = dr["referenceid"].ToString();
                        txtRemarks.Text = dr["remarks"].ToString();
                        txtMrno.Text = dr["mrno"].ToString();
                    }
                    cmbOPDCatagory.Focus();

                }

            }
        }

        private void txtRSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //string voucherNo = txtRSearch.Text;//dgvQuery.Rows[e.RowIndex].Cells[clnVoucherNum.Index].Value.ToString();
                if (txtRSearch.Text != "")
                {
                    tabDetailQuery.SelectedTab = tabpgDetail;
                    FillReceipt(txtRSearch.Text);
                    FillLastIssuedSlip();
                }
                else
                {
                    btnNew_Click(null, null);

                }
            }
        }

        void PrintHussainiLaboratory(string voucher, DataTable dt)
        {
            Reports.OPDReceipt_Laboratory rpt = new Reports.OPDReceipt_Laboratory();
            DataTable dtTest = ReportQuery.OPDTestReceipt(voucher);
            dtTest.Columns.Add("QRcode", typeof(byte[]));


            // string VoucherNo = "OP-" + voucher;
            // string QRimagePath = Application.StartupPath + "\\QRCode.jpeg";
            //  DataTable dtQRcode = Query.GenerateQRCode(VoucherNo, QRimagePath);
           
            rpt.SetDataSource(dtTest);
            rpt.SetParameterValue("@companyname", CompanyInfo.CompanyName);
            rpt.SetParameterValue("@Contact", CompanyInfo.ContactHead);
            rpt.SetParameterValue("@Address", CompanyInfo.Address);
            rpt.SetParameterValue("@Catagory", dt.Rows[0]["CatagoryTitle"].ToString());
            rpt.SetParameterValue("@ReceiptNo", "OP-" + voucher);
            rpt.SetParameterValue("@Date", (DateTime)dt.Rows[0]["Vdate"]);
            rpt.SetParameterValue("@Patient", dt.Rows[0]["patientName"].ToString());
            rpt.SetParameterValue("@Gender", dt.Rows[0]["Gender"].ToString());
            rpt.SetParameterValue("@Consultant", dt.Rows[0]["laboratoryConsultantName"].ToString());
            rpt.SetParameterValue("@ServerDate", SoftwareInfo.ServerDate);
            rpt.SetParameterValue("@User", UserInfo.UserName);
            rpt.SetParameterValue("@Discount", dt.Rows[0]["Discount"].ToString());
            rpt.SetParameterValue("@Remarks", dt.Rows[0]["Remarks"].ToString());
            rpt.SetParameterValue("@GrossAmount", dt.Rows[0]["GrossAmount"].ToString());
            decimal NetAmouunt = Convert.ToDecimal(dt.Rows[0]["NetAmount"].ToString());
            decimal kECharges = Convert.ToDecimal(dt.Rows[0]["electricitycharges"].ToString());
            decimal Total = NetAmouunt + kECharges;
            rpt.SetParameterValue("@NetAmount", NetAmouunt);
            rpt.SetParameterValue("@electricitycharges", dt.Rows[0]["electricitycharges"].ToString());
            rpt.SetParameterValue("@DiscountName", dt.Rows[0]["patientType"].ToString());
            rpt.SetParameterValue("@ReferenceName", dt.Rows[0]["ReferenceName"].ToString());
            rpt.SetParameterValue("@MemberId", dt.Rows[0]["memberid"].ToString());
            rpt.SetParameterValue("@TokenNo", dt.Rows[0]["TokenNo"].ToString());
            rpt.SetParameterValue("@Age", dt.Rows[0]["Age"].ToString());
            rpt.SetParameterValue("@CreatedBY", dt.Rows[0]["createdby"].ToString());
            rpt.SetParameterValue("@phoneNo", dt.Rows[0]["contactno"].ToString());
            rpt.SetParameterValue("@partialName", "Partial Payment");
            rpt.SetParameterValue("@Partial", dt.Rows[0]["netbalance"].ToString());
            rpt.SetParameterValue("@Createdtime", (DateTime)dt.Rows[0]["createdtime"]);
            rpt.SetParameterValue("@PrintedBy", UserInfo.UserId);
            rpt.SetParameterValue("@terminal", SoftwareInfo.Terminal);
            rpt.SetParameterValue("@urcompanyname", CompanyInfo.UrCompanyName);
            rpt.ReportFooterSection7.SectionFormat.EnableUnderlaySection = true;
            if (dt.Rows[0]["Discount"].ToString() == "0") rpt.ReportFooterSection3.SectionFormat.EnableSuppress = true;
            if (dt.Rows[0]["electricitycharges"].ToString() == "0") rpt.ReportFooterSection20.SectionFormat.EnableSuppress = true;
            if (dt.Rows[0]["ispartial"].ToString() == "0") rpt.ReportFooterSection12.SectionFormat.EnableSuppress = true;
            if (dt.Rows[0]["ReferenceName"].ToString() == "") rpt.ReportFooterSection5.SectionFormat.EnableSuppress = true;
            if (dt.Rows[0]["memberid"].ToString() == "")
            {
                rpt.ReportFooterSection6.SectionFormat.EnableSuppress = true;
                rpt.ReportFooterSection7.SectionFormat.EnableUnderlaySection = false;
            }
            if (dt.Rows[0]["tokenNo"].ToString() == "0") rpt.ReportFooterSection7.SectionFormat.EnableSuppress = true;
            rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            if (UserInfo.UserLevel == "Admin")
            {
                frmReportView frm = new frmReportView();
                frm.rptViewer.ReportSource = rpt;
                frm.Show();
            }
            else
            {
                rpt.PrintToPrinter(1, true, 1, 9999);
                Query.Execute("update opdreceipt set noofprint = nvl(noofprint,0) + 1 where receiptno = '" + voucher + "'");
            }
        }

        private async void FillSessionBalanceAsync()
        {
            try
            {
                var balance = await Task.Run(() =>
                {
                    DataTable dt = Query.SessionBalanceAddPartialPayment(UserInfo.UserId);
                    return Decimal.Parse(dt.Rows[0][2].ToString());
                });
                lblCash.Text = "Current Cash : " + balance.ToString("N0");
            }
            catch (Exception ex)
            {
                lblCash.Text = "Error loading balance";
            }
        }

        private async void FillQueryAsync(string[] filter, bool GetAll)
        {
            try
            {
                progressBar1.Visible = true;
                dgvQuery.Rows.Clear(); 

                DataTable dt = await Task.Run(() =>
                {
                    if (GetAll)
                    {
                        var selectedValue = cmbOPDCatagory.InvokeRequired
                            ? (string)cmbOPDCatagory.Invoke(new Func<object>(() => cmbOPDCatagory.SelectedValue))
                            : (string)cmbOPDCatagory.SelectedValue;

                        string catId = string.IsNullOrEmpty(selectedValue) ? "3" : selectedValue;
                        return Query.OPDReceiptQuery(filter, catId);
                    }
                    else
                    {
                        return new DataTable(); // or handle the non-GetAll case differently
                    }
                });

                dtQuery = dt; // optional if you use dtQuery elsewhere

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int ind = dgvQuery.Rows.Add(dt.Rows[i].ItemArray);

                    if (dt.Rows[i]["noofPrint"].ToString() == "0")
                        dgvQuery.Rows[ind].DefaultCellStyle.BackColor = Color.LightGray;

                    if (dt.Rows[i]["status"].ToString() != "0")
                        dgvQuery.Rows[ind].DefaultCellStyle.BackColor = Color.Red;
                }

                lblTotRecordsFetched.Text = "Total Records : " + dt.Rows.Count.ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load query data.\n" + ex.Message);
            }
            finally
            {
                progressBar1.Visible = false;
            }
        }
        private void GenerateNewMRNumber()
        {
            if (txtContactNo.Text != "")
            {
                DataTable dt = Query.GetOPDDetailsByContactNo(txtContactNo.Text);
                if (dt.Rows.Count > 0)
                {
                    txtMrno.Text = dt.Rows[0]["MRNo"].ToString();
                }
            }
            if (txtMrno.Text == "")
            {
                int currentYear = DateTime.Now.Year;
                string yearString = currentYear.ToString();

                DataTable dt = Query.GetMaxMRno();
                int lastMrNumberForYear = 0;

                if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
                {
                    string lastMrNumber = dt.Rows[0][0].ToString();
                    if (lastMrNumber.StartsWith(yearString))
                    {
                        string numberPart = lastMrNumber.Substring(4);
                        int number;
                        if (int.TryParse(numberPart, out number))
                        {
                            lastMrNumberForYear = number;
                        }
                    }
                }
                int newMrNumber = lastMrNumberForYear + 1;
                string newMrNumberString = yearString + newMrNumber.ToString("D6");
                txtMrno.Text = newMrNumberString;
            }
        }
    }
}
