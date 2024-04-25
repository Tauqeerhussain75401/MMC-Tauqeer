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
    public partial class frmPtAdvInfo : Form
    {
        public frmPtAdvInfo()
        {
           
            
            InitializeComponent();
            this.ActiveControl = txtalpha;
            rdocash.Checked = true;
            DateTime time = SoftwareInfo.ServerDate;//DateTime.Now;
            dtp_date.Value = time;
            
            
            

        }
        DateTime Admisdatetime;
        internal void BasicInfo(string regAlpha, string regNum)
        
        {
            DataTable dt;
            string no = txtsearchbillno.Text;
            dt = Query.AdmInfo(regAlpha, regNum,no);
            /////////////////////


            if (dt.Rows.Count > 0)
            {
                // cmbCatagory.SelectedValue = dt.Rows[0]["TesttypeId"].ToString();


                txtSerial.Text = dt.Rows[0]["admissionid"].ToString();
                txtadmDate.Text = ((DateTime)dt.Rows[0]["admdate"]).ToString("dd-MMM-yyyy");
                //txtadmTime.Text = ((DateTime)dt.Rows[0]["admtime"]).ToString("hh:mm tt");
                txtaccType.Text = dt.Rows[0]["patienttype"].ToString();
                txtpatName.Text = dt.Rows[0]["patientName"].ToString();
                txtroom.Text = dt.Rows[0]["roomTitle"].ToString();
                txtconsultant.Text = dt.Rows[0]["consultantname"].ToString();
                txtgnd.Text = dt.Rows[0]["gender"].ToString();
                txtage.Text = dt.Rows[0]["age"].ToString();

                Admisdatetime = (DateTime)dt.Rows[0]["admdate"];


            }
            else
            {
                MessageBox.Show("Admission Not Exist");
                Validation.Clear(grpPatientInfo);
                txtalpha.Focus();
            }
        }
        void FillAdvRec()
        {

            
            string serialno;
            serialno = txtSerial.Text;
            DataTable dtQuery = Query.RecInfo(serialno);
            dgvaHis.Rows.Clear();
         
            int amount = 0;
            /////////////////////

            for (int i = 0; i < dtQuery.Rows.Count; i++)
            {
                
                    dgvaHis.Rows.Add(dtQuery.Rows[i]["id"].ToString(),
                    Convert.ToDateTime(dtQuery.Rows[i]["vdate"]).ToString("dd-MMM-yyyy hh:mm tt"),
                    Convert.ToInt32(dtQuery.Rows[i]["amount"]),
                    dtQuery.Rows[i]["receiptmode"].ToString(),
                    dtQuery.Rows[i]["createdby"].ToString() != "" ? dtQuery.Rows[i]["createdby"].ToString() + " | " + ((DateTime)dtQuery.Rows[i]["createdtime"]).ToString("dd-MMM-yyyy hh:mm:ss tt") : null,

                    dtQuery.Rows[i]["editBy"].ToString() != "" ? dtQuery.Rows[i]["editBy"].ToString() + " | " + ((DateTime)dtQuery.Rows[i]["edittime"]).ToString("dd-MMM-yyyy hh:mm:ss tt") : null,
                    dtQuery.Rows[i]["terminalid"].ToString()
                    );

                    if (dtQuery.Rows[i]["status"].ToString() != "1")
                    {
                        amount += Convert.ToInt32(dtQuery.Rows[i]["amount"]);
                    }

            }
            txtTotAdv.Text = amount.ToString("N0");

            if (UserInfo.UserLevel == "Admin")
            {
                DeleteSlipRecodeRed(dtQuery);
            }
            else
            {
                HidDeleteSlipRecodeRed(dtQuery);
            }
            // cmbCatagory.SelectedValue = dt.Rows[0]["TesttypeId"].ToString();


            // basit add this code start

            for (int i = 0; i <= 0; i++)
            {
                if (dtQuery.Rows.Count > 0)
                {
                    FillDetail(dtQuery.Rows[i]["id"].ToString());
                }
            }
            // basit add this code end 





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


                    dgvaHis.Rows[i].Cells[clnMode.Index].Style.BackColor = Color.Red;
                    dgvaHis.Rows[i].Cells[clnMode.Index].ReadOnly = true;
                    dgvaHis.Rows[i].Cells[clnMode.Index].Style.SelectionBackColor = Color.Red;


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

        private void nudregNo_KeyDown(object sender, KeyEventArgs e)
            
         {
            if (e.KeyCode == Keys.Enter)
            {
                BasicInfo(txtalpha.Text, nudregNo.Text);
                //PreviousAmount();
                FillAdvRec();
                PreviousAmount();
                Validation.Clear(grpRecInfo); // basit comment this line 
            }
        }



        internal void FillDetail(string ID)
        {
            DataTable dt;
            dt = Query.PayInfo(ID);
            /////////////////////


            if (dt.Rows.Count > 0)
            {
                // cmbCatagory.SelectedValue = dt.Rows[0]["TesttypeId"].ToString();

                dtp_date.Value = Convert.ToDateTime(dt.Rows[0]["vdate"]);
                //dtpTime.Text = dt.Rows[0]["vdate"].ToString();
                //dtpTime.Value = Convert.ToDateTime(dt.Rows[0]["vdate"]);
                txtreceipt.Text = dt.Rows[0]["id"].ToString();
                //txtPrev.Text = dt.Rows[0]["amount"].ToString();
                ntxtamount.Value = (Decimal)dt.Rows[0]["amount"];
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

                #region basit commit old code from this date 18/08/2020
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

            //FillDetail(dgvaHis.Rows[e.RowIndex].Cells[clnSerialNo.Index].Value.ToString());
           // if (UserInfo.UserLevel == "Admin")
           // {
           //     if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to Delete this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
           //     {
           //         if (dgvaHis.Rows[e.RowIndex] != null)
           //         {
           //             dgvaHis.CurrentRow.Selected = true;
           //             string AdvId = dgvaHis.Rows[e.RowIndex].Cells[clnSerialNo.Index].FormattedValue.ToString();
           //             Query.Execute("UPDATE  ADVANCERECEIPT SET status ='1'   WHERE   id  = '" + AdvId + "'");
           //             FillAdvRec();
           //         }
           //     }
           // }
            if (e.RowIndex != -1)
            {
                FillDetail(dgvaHis.Rows[e.RowIndex].Cells[clnSerialNo.Index].Value.ToString());
            }

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string ReceiptNo = null;
            string mode_of_payment;

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

            if (txtSerial.Text == "")
            {
                MessageBox.Show("Admission not found");
                return;
            }
            if (ntxtamount.Text == "" || ntxtamount.Text=="0") 
            {
                MessageBox.Show("Amount Should be greater then '1'");
                ntxtamount.Focus();
                return;
            }
            if (UserInfo.UserLevel != "Admin" && txtreceipt.Text!="") 
            {
                MessageBox.Show("You have no rights to Update Amount");
                return;
            }                         
            else if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to save this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
                DML.receiptinfo_add_edit(txtreceipt.Text, txtSerial.Text,UserInfo.UserLevel != "Admin" ? SoftwareInfo.ServerDate : dtp_date.Value, ntxtamount.Value.ToString(), mode_of_payment, ref ReceiptNo);
                MessageBox.Show("Record Successfully Saved");
                FillAdvRec();
                
                //Validation.Clear(grpRecInfo);
                FillDetail(ReceiptNo);
                
               // txtalpha.Focus();
            }
        }
        

        private void btnnew_Click(object sender, EventArgs e)
        {
            Validation.Clear(grpRecInfo); 
            rdocash.Checked = true;
            ntxtamount.Focus();
            dtp_date.Value = DateTime.Now;


            #region basit commit old code from this date 18/08/2020
            Validation.Clear(grpModOfPayment);
            grpModOfPayment.Enabled = true;
            grpRecInfo.Enabled = true;
            #endregion
        }

        internal void PreviousAmount()
        {
           // string serialno;
            //serialno = txtSerial.Text;
            //DataTable dtQuery = Query.PayAmount(serialno);

            int amount = 0;
            

            for (int i = 0; i < dgvaHis.Rows.Count; i++)
            {

                int singleamount = Convert.ToInt32(dgvaHis.Rows[i].Cells["clnAmount"].Value.ToString());
                amount = amount + singleamount;
                

            }

        }

        private void ntxtamount_ValueChanged(object sender, EventArgs e)
        {
            if (txtreceipt.Text=="" && txtalpha.Text=="" && nudregNo.Value==0 ) 
            {
               // ntxtamount.Value=(txtPrev.Text);
                //txtcurrent.Text = ntxtamount.Value.ToString();
            }
        }

        private void nudregNo_TabIndexChanged(object sender, EventArgs e)
        {
            
        }


        private void nudregNo_Enter(object sender, EventArgs e)
        {
            nudregNo.Text = "";
            
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (txtreceipt.Text=="")
            {


                string ReceiptNo = null;
                string mode_of_payment;

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

                if (txtSerial.Text == "")
                {
                    MessageBox.Show("Admission not found");
                    return;
                }
                if (ntxtamount.Text == "" || ntxtamount.Text == "0")
                {
                    MessageBox.Show("Amount Should be greater then '1'");
                    ntxtamount.Focus();
                    return;
                }
                if (UserInfo.UserLevel != "Admin" && txtreceipt.Text != "")
                {
                    MessageBox.Show("You have no rights to Update Amount");
                    return;
                }


                DML.receiptinfo_add_edit(txtreceipt.Text, txtSerial.Text, UserInfo.UserLevel != "Admin" ? SoftwareInfo.ServerDate : dtp_date.Value, ntxtamount.Value.ToString(), mode_of_payment, ref ReceiptNo);

                FillAdvRec();


                FillDetail(ReceiptNo);
                txtalpha.Focus();
            }
            
            PrintReport(true);
            Validation.Clear(grpRecInfo);
        }

        private void btnpreview_Click(object sender, EventArgs e)
        {
            PrintReport(false);


           
        }

        private void PrintReport(bool DirectPrint)
        {
            Reports.CrpInPAdvRcpt rpt = new Reports.CrpInPAdvRcpt();


            //DataTable dt = DML.Rep_AdvanceReceipt(txtSerial.Text, txtreceipt.Text);
            DataTable dt = DML.Rep_AdvanceReceipt1(txtSerial.Text, txtreceipt.Text );
            

            if (dt.Rows.Count > 0)
            {
                rpt.SetDataSource(dt);

                rpt.SetParameterValue("pRegNo", txtalpha.Text + ' ' + nudregNo.Text);
                rpt.SetParameterValue("pPatientName", txtpatName.Text);
                rpt.SetParameterValue("pRoom", txtroom.Text);
                rpt.SetParameterValue("pGender", txtgnd.Text);
                rpt.SetParameterValue("pAge", txtage.Text);

                rpt.SetParameterValue("pRcpNo", txtreceipt.Text);
                rpt.SetParameterValue("pRcpDate", dtp_date.Value);
                rpt.SetParameterValue("pRcpTime", dtp_date.Value);
                rpt.SetParameterValue("pRcpAmount", ntxtamount.Text);
                DataTable get_userid=Query.getData("select createdby from advancereceipt where status=0 and id='" + txtreceipt.Text + "' and admissionid='"+txtSerial.Text+"'");
                rpt.SetParameterValue("@Userid", get_userid.Rows.Count>0?get_userid.Rows[0]["createdby"].ToString():UserInfo.UserId);

                rpt.SetParameterValue("pAdmisdatetime", Admisdatetime);

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
                rpt.SetParameterValue("pRegNo", txtalpha.Text + ' ' + nudregNo.Text);
                rpt.SetParameterValue("pPatientName", txtpatName.Text);
                rpt.SetParameterValue("pRoom", txtroom.Text);
                rpt.SetParameterValue("pGender", txtgnd.Text);
                rpt.SetParameterValue("pAge", txtage.Text);

                rpt.SetParameterValue("pRcpNo", txtreceipt.Text);
                rpt.SetParameterValue("pRcpDate", dtp_date.Value);
                rpt.SetParameterValue("pRcpTime", dtp_date.Value);
                rpt.SetParameterValue("pRcpAmount", ntxtamount.Text);
                rpt.SetParameterValue("pAdmisdatetime", Admisdatetime);
                DataTable get_userid = Query.getData("select createdby from advancereceipt where status=0 and id='" + txtreceipt.Text + "' and admissionid='" + txtSerial.Text + "'");
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
        

        private void frmPtAdvInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                SendKeys.Send("{tab}");
            }
        }

        private void frmPtAdvInfo_Load(object sender, EventArgs e)
        {
            if (UserInfo.UserLevel == "Admin" )
            {
                dtp_date.Enabled = true;
                txtsearchbillno.ReadOnly = false;
            }
        }

        private void ntxtamount_Enter(object sender, EventArgs e)
        {
            (sender as NumericUpDown).Select(0, (sender as NumericUpDown).Text.Length);
        }

        private void nudregNo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvaHis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //FillDetail(dgvaHis.Rows[e.RowIndex].Cells[clnSerialNo.Index].Value.ToString());
        }

        private void txtalpha_Validated(object sender, EventArgs e)
        {
            nudregNo.Select(0, nudregNo.Value.ToString().Length);
            
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (UserInfo.UserLevel == "Admin")
            {
                if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to Delete this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Query.Execute("UPDATE  ADVANCERECEIPT SET status ='1'   WHERE   id  = '" + txtreceipt.Text + "'");
                    FillAdvRec();
                }
            }
            else 
            {
                MessageBox.Show("You have no rights to Delete...!!!!");
            }
       }

        private void nudregNo_Validated(object sender, EventArgs e)
        {
            BasicInfo(txtalpha.Text, nudregNo.Text);
            //PreviousAmount();
            FillAdvRec();
            PreviousAmount();
            Validation.Clear(grpRecInfo);
        }

        private void nudregNo_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void txtsearchbillno_Validated(object sender, EventArgs e)
        {
            if (txtsearchbillno.Text.Length > 0 && nudregNo.Text != "0")
            {
                BasicInfo(txtalpha.Text, nudregNo.Text);
                FillAdvRec();
                PreviousAmount();
                Validation.Clear(grpRecInfo);
            }
        }
    }



    }


