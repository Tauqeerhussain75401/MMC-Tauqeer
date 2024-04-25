using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class PartialPayInfo : Form
    {
        public PartialPayInfo()
        {
            InitializeComponent();
            this.ActiveControl = nudregNo;
            rdocash.Checked = true;
            DateTime time = SoftwareInfo.ServerDate;//DateTime.Now;
            dtp_date.Value = time;
        }

        internal void BasicInfo(string regNum)
        {
            DataTable dt;
            dt = Query.OPDreceptInfo(regNum);
            /////////////////////


            if (dt.Rows.Count > 0)
            {
                txtpatName.Text = dt.Rows[0]["patientname"].ToString();
                txtadmDate.Text = ((DateTime)dt.Rows[0]["vdate"]).ToString("dd-MMM-yyyy");
                txtcontact.Text = dt.Rows[0]["contactno"].ToString();
                txtconsultant.Text = dt.Rows[0]["name"].ToString();
                txtgnd.Text = dt.Rows[0]["gender"].ToString();
                txtage.Text = dt.Rows[0]["age"].ToString();
                txttotalBalance.Text = dt.Rows[0]["netbalance"].ToString();
            }
            else
            {
                //MessageBox.Show("Receipt Not Exist");
                //Validation.Clear(grpPatientInfo);
                nudregNo.Focus();
                return;
            }
        }

        //private void nudregNo_Validated(object sender, EventArgs e)
        //{
        //    txtRegNo.Text = nudregNo.Text;
        //    BasicInfo(txtRegNo.Text);
        //    //PreviousAmount();
        //    FillAdvRec();
        //    // PreviousAmount();
        //    Validation.Clear(grpRecInfo); // basit comment this line 
        //}

        private void btnsave_Click(object sender, EventArgs e)
        {
            string ReceiptNo = null;
            string mode_of_payment;
            //if (ntxtamount.Value <= Convert.ToDecimal(txttotalBalance.Text))
            //{
            //    MessageBox.Show("Received Amount is greater than or equal to the Balance Amount.");
            //    return;
            //}
            if (rdocash.Checked)
            {
                mode_of_payment = "CASH";
            }
            else if (rdocCard.Checked)
            {
                mode_of_payment = "CARD";
            }
            else
            {
                mode_of_payment = "CHEQUE";
            }
            if (nudregNo.Text == "")
            {
                MessageBox.Show("Receipt not found");
                return;
            }
            if (ntxtamount.Text == "" || ntxtamount.Text == "0")
            {
                MessageBox.Show("Amount Should be greater then '0'");
                ntxtamount.Focus();
                return;
            }
            if (decimal.Parse(txttotalBalance.Text) < ntxtamount.Value)
            {
                MessageBox.Show("Received Amount is greater than Balance Amount.");
                ntxtamount.Focus();
                return;
            }
            else if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to save this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                string balance = Convert.ToString(decimal.Parse(txttotalBalance.Text) - ntxtamount.Value);
                DML.Partialreceiptinfo_add_edit(txtreceipt.Text,txtRegNo.Text, UserInfo.UserLevel != "Admin" ? SoftwareInfo.ServerDate : dtp_date.Value, ntxtamount.Value.ToString(), balance, mode_of_payment);
                MessageBox.Show("Record Successfully Saved");
                FillAdvRec();

                Validation.Clear(grpRecInfo);
                FillDetail(txtRegNo.Text, txtreceipt.Text);

                // txtalpha.Focus();
            }
        }

        void FillAdvRec()
        {
            DataTable dtQuery = Query.PartiallyDetail(txtRegNo.Text);
            dgvaHis.Rows.Clear();

            int Balance = 0;
            /////////////////////
            if (dtQuery.Rows.Count > 0)
            {
                for (int i = 0; i < dtQuery.Rows.Count; i++)
                {

                    dgvaHis.Rows.Add(dtQuery.Rows[i]["receiptno"].ToString(),
                    dtQuery.Rows[i]["id"].ToString(),
                    Convert.ToDateTime(dtQuery.Rows[i]["vdate"]).ToString("dd-MMM-yyyy hh:mm tt"),
                    Convert.ToInt32(dtQuery.Rows[0]["grossamount"]),
                    Convert.ToInt32(dtQuery.Rows[i]["netamount"]),
                    dtQuery.Rows[i]["createdby"].ToString() != "" ? dtQuery.Rows[i]["createdby"].ToString() + " | " + ((DateTime)dtQuery.Rows[i]["createdtime"]).ToString("dd-MMM-yyyy hh:mm:ss tt") : null,

                    dtQuery.Rows[i]["editBy"].ToString() != "" ? dtQuery.Rows[i]["editBy"].ToString() + " | " + ((DateTime)dtQuery.Rows[i]["edittime"]).ToString("dd-MMM-yyyy hh:mm:ss tt") : null,
                    dtQuery.Rows[i]["terminalid"].ToString()
                    );

                    if (dtQuery.Rows[i]["status"].ToString() != "1")
                    {
                        Balance += Convert.ToInt32(dtQuery.Rows[i]["netamount"]);
                    }

                }
                txttotalBalance.Text = Convert.ToString(Convert.ToInt32(dtQuery.Rows[0]["grossamount"]) - Balance);

                if (UserInfo.UserLevel == "Admin")
                {
                    DeleteSlipRecodeRed(dtQuery);
                }
                else
                {
                    HidDeleteSlipRecodeRed(dtQuery);
                }
            }
            
        }
        internal void HidDeleteSlipRecodeRed(DataTable dtQuery)
        {
            for (int i = 0; i < dtQuery.Rows.Count; i++)
            {
                if (dtQuery.Rows[i]["status"].ToString() == "1")
                {
                    dgvaHis.Rows[i].Visible = false;
                    dgvaHis.Rows[i].Visible = false;
                    dgvaHis.Rows[i].Visible = false;
                    dgvaHis.Rows[i].Visible = false;
                    dgvaHis.Rows[i].Visible = false;
                    dgvaHis.Rows[i].Visible = false;
                    dgvaHis.Rows[i].Visible = false;
                }
            }

        }
        public void DeleteSlipRecodeRed(DataTable dtQuery1)
        {
            for (int i = 0; i < dtQuery1.Rows.Count; i++)
            {
                if (dtQuery1.Rows[i]["status"].ToString() == "1")
                {
                    dgvaHis.Rows[i].Cells[clnSerialNo.Index].Style.BackColor = Color.Red;
                    dgvaHis.Rows[i].Cells[clnSerialNo.Index].ReadOnly = true;
                    dgvaHis.Rows[i].Cells[clnSerialNo.Index].Style.SelectionBackColor = Color.Red;

                    dgvaHis.Rows[i].Cells[clnAdvDate.Index].Style.BackColor = Color.Red;
                    dgvaHis.Rows[i].Cells[clnAdvDate.Index].ReadOnly = true;
                    dgvaHis.Rows[i].Cells[clnAdvDate.Index].Style.SelectionBackColor = Color.Red;


                    dgvaHis.Rows[i].Cells[clnAmount.Index].Style.BackColor = Color.Red;
                    dgvaHis.Rows[i].Cells[clnAmount.Index].ReadOnly = true;
                    dgvaHis.Rows[i].Cells[clnAmount.Index].Style.SelectionBackColor = Color.Red;


                    dgvaHis.Rows[i].Cells[TotalBill.Index].Style.BackColor = Color.Red;
                    dgvaHis.Rows[i].Cells[TotalBill.Index].ReadOnly = true;
                    dgvaHis.Rows[i].Cells[TotalBill.Index].Style.SelectionBackColor = Color.Red;


                    dgvaHis.Rows[i].Cells[clncreatedby.Index].Style.BackColor = Color.Red;
                    dgvaHis.Rows[i].Cells[clncreatedby.Index].ReadOnly = true;
                    dgvaHis.Rows[i].Cells[clncreatedby.Index].Style.SelectionBackColor = Color.Red;


                    dgvaHis.Rows[i].Cells[clnEditBy.Index].Style.BackColor = Color.Red;
                    dgvaHis.Rows[i].Cells[clnEditBy.Index].ReadOnly = true;
                    dgvaHis.Rows[i].Cells[clnEditBy.Index].Style.SelectionBackColor = Color.Red;



                    dgvaHis.Rows[i].Cells[clnterminalid.Index].Style.BackColor = Color.Red;
                    dgvaHis.Rows[i].Cells[clnterminalid.Index].ReadOnly = true;
                    dgvaHis.Rows[i].Cells[clnterminalid.Index].Style.SelectionBackColor = Color.Red;

                }
            }
        }
        private void btnnew_Click(object sender, EventArgs e)
        {
            Validation.Clear(grpRecInfo);
            dgvaHis.Rows.Clear();
            rdocash.Checked = true;
            nudregNo.Text = string.Empty;
            txtpatName.Text = string.Empty;
            txtgnd.Text = string.Empty;
            txtadmDate.Text = string.Empty;
            txtcontact.Text = string.Empty;
            txtconsultant.Text = string.Empty;
            txtage.Text = string.Empty;
            txttotalBalance.Text = "0";
            txtRegNo.Text = "0";
            nudregNo.Focus();
            dtp_date.Value = DateTime.Now;
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (UserInfo.UserLevel == "Admin")
            {
                if (txtRegNo.Text.Length > 0)
                {
                    if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to Delete this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Query.Execute("UPDATE  Partialreceipt SET status ='1'   WHERE   id  = '" + txtreceipt.Text + "'");
                        FillAdvRec();
                    }
                }
                
            }
            else
            {
                MessageBox.Show("You have no rights to Delete...!!!!");
            }
        }

        internal void FillDetail(string receiptNo,string ID)
        {
            DataTable dt;
            dt = Query.PartialInfo(receiptNo, ID);
            /////////////////////


            if (dt.Rows.Count > 0)
            {
                // cmbCatagory.SelectedValue = dt.Rows[0]["TesttypeId"].ToString();

                dtp_date.Value = Convert.ToDateTime(dt.Rows[0]["vdate"]);
                //dtpTime.Text = dt.Rows[0]["vdate"].ToString();
                //dtpTime.Value = Convert.ToDateTime(dt.Rows[0]["vdate"]);
                txtreceipt.Text = dt.Rows[0]["id"].ToString();
                //txtPrev.Text = dt.Rows[0]["amount"].ToString();
                ntxtamount.Value = (Decimal)dt.Rows[0]["partialamount"];
                string modeOfPay = dt.Rows[0]["receiptmode"].ToString();

                // rdocCard.Checked=false;
                //rdocash.Checked=false;
                //rdocheq.Checked=false;
                if (modeOfPay == "CHEQUE")
                {
                    rdocheq.Checked = true;
                }
                else if (modeOfPay == "CASH")
                {
                    rdocash.Checked = true;

                }
                else
                {
                    rdocCard.Checked = true;
                }

                #region 
                if (UserInfo.UserLevel == "Admin")
                {
                    grpModOfPayment.Enabled = true;
                    grpRecInfo.Enabled = true;
                }
                else
                {
                    grpModOfPayment.Enabled = true;
                    grpRecInfo.Enabled = true;
                }
                #endregion
            }
            
        }

        private void dgvaHis_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                FillDetail(dgvaHis.Rows[e.RowIndex].Cells[clnSerialNo.Index].Value.ToString(), dgvaHis.Rows[e.RowIndex].Cells[Id.Index].Value.ToString());
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {

        }

        private void btnpreview_Click(object sender, EventArgs e)
        {
            PrintReport(false);
        }


        private void PrintReport(bool DirectPrint)
        {
            Reports.CrpInPAdvRcpt1 rpt = new Reports.CrpInPAdvRcpt1();


            //DataTable dt = DML.Rep_AdvanceReceipt(txtSerial.Text, txtreceipt.Text);
            DataTable dt = Query.PartiallyDetailForReport(txtRegNo.Text,txtreceipt.Text);


            if (dt.Rows.Count > 0)
            {
                rpt.SetDataSource(dt);

                rpt.SetParameterValue("pRegNo", txtRegNo.Text);
                rpt.SetParameterValue("pPatientName", txtpatName.Text);
                rpt.SetParameterValue("pRoom", "");
                rpt.SetParameterValue("pGender", txtgnd.Text);
                rpt.SetParameterValue("pAge", txtage.Text);
                rpt.SetParameterValue("BalanceAmount", txttotalBalance.Text);
                rpt.SetParameterValue("pRcpNo", txtreceipt.Text);
                rpt.SetParameterValue("pRcpDate", dtp_date.Value);
                rpt.SetParameterValue("pRcpTime", dtp_date.Value);
                rpt.SetParameterValue("pRcpAmount", ntxtamount.Text);
                DataTable get_userid = Query.getData("select createdby from Partialreceipt where status=0 and id='" + txtreceipt.Text + "' and receiptno='" + txtRegNo.Text + "'");
                rpt.SetParameterValue("@Userid", get_userid.Rows.Count > 0 ? get_userid.Rows[0]["createdby"].ToString() : UserInfo.UserId);

                rpt.SetParameterValue("pAdmisdatetime", DateTime.Now);

                if (rdocash.Checked == true)
                {
                    rpt.SetParameterValue("pModeOfPayment", "CASH");
                }
                else if (rdocheq.Checked == true)
                {
                    rpt.SetParameterValue("pModeOfPayment", "CHEQUE");
                }
                else if (rdocCard.Checked == true)
                {
                    rpt.SetParameterValue("pModeOfPayment", "CREDIT CARD");
                }

            }
            else
            {
                dt.Rows.Add();
                rpt.SetParameterValue("pRegNo", txtRegNo.Text);
                rpt.SetParameterValue("pPatientName", txtpatName.Text);
                rpt.SetParameterValue("pRoom", "");
                rpt.SetParameterValue("pGender", txtgnd.Text);
                rpt.SetParameterValue("pAge", txtage.Text);

                rpt.SetParameterValue("pRcpNo", txtreceipt.Text);
                rpt.SetParameterValue("pRcpDate", dtp_date.Value);
                rpt.SetParameterValue("pRcpTime", dtp_date.Value);
                rpt.SetParameterValue("pRcpAmount", ntxtamount.Text);
                rpt.SetParameterValue("pAdmisdatetime", DateTime.Now);
                DataTable get_userid = Query.getData("select createdby from Partialreceipt where status=0 and id='" + txtreceipt.Text + "' and receiptno='" +txtRegNo.Text + "'");
                rpt.SetParameterValue("@Userid", get_userid.Rows.Count > 0 ? get_userid.Rows[0]["createdby"].ToString() : UserInfo.UserId);

                if (rdocash.Checked == true)
                {
                    rpt.SetParameterValue("pModeOfPayment", "CASH");
                }
                else if (rdocheq.Checked == true)
                {
                    rpt.SetParameterValue("pModeOfPayment", "CHEQUE");
                }
                else if (rdocCard.Checked == true)
                {
                    rpt.SetParameterValue("pModeOfPayment", "CREDIT CARD");
                }


            }

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

        private void nudregNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRegNo.Text = nudregNo.Text;
                BasicInfo(txtRegNo.Text);
                FillAdvRec();
                Validation.Clear(grpRecInfo);
            }
        }

        private void nudregNo_Validated(object sender, EventArgs e)
        {
            txtRegNo.Text = nudregNo.Text;
            BasicInfo(txtRegNo.Text);
            FillAdvRec();
            Validation.Clear(grpRecInfo);
            
        }

        private void nudregNo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
