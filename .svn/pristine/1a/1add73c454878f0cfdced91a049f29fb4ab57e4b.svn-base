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
    public partial class frmbirthinfo : Form
    {
        public frmbirthinfo()
        {
            //clsConnection.Con();
            InitializeComponent();
            FillControls.FillcmbCunsultant(cmbcname);
            
            //ntxtweightlbs=Convert.ToDecimal(ntxtweightkg.Value* 2.2046);

        }
        DataTable dtSearch = new DataTable();
        string mother = "";
        string father = "";

        private void btnsave_Click(object sender, EventArgs e)
        {
           
            if(cmbgender.SelectedItem == null)
                {
                    MessageBox.Show("Select Gender");
                    cmbgender.Focus();  
                return;
                }
            else if (txtfname.Text == "")
                {
                    MessageBox.Show("Fill FatherName");
                    txtfname.Focus();
                    return;
                }
            else if (txtmname.Text == "")
                {
                    MessageBox.Show("Fill MotherName");
                    txtmname.Focus();
                    return;
                }
            //else if (txtaddress.Text == "")
            //    {
            //        MessageBox.Show("Fill Address");
            //        txtaddress.Focus();
            //        return;
            //    }
            else if (ntxtweightkg.Value == 0)
                {
                    MessageBox.Show("WeightKg should be greater then 0");
                    ntxtweightkg.Focus();
                    return;
                }
            else if (ntxtweightlbs.Value == 0)
                {   
                    MessageBox.Show("WeightKg should be greater then 0");
                    ntxtweightlbs.Focus();
                    return;
                }
            else if (cmbcname.SelectedItem == null)
                {
                    MessageBox.Show("Select consultant name");
                    cmbcname.Focus();
                     return;
                }

            else if (chkisactive.Checked == false)
                {
                     MessageBox.Show("Please Checked");
                     
                     return;
                }
            else if (txtrecname.Text == "")
                {
                     MessageBox.Show("Fill Receiver Name");
                     txtrecname.Focus();
                     return;
                }

             else if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to save this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
             {
                 DML.birthinfo_add_edit(txtserialno.Text,txtbirthid.Text, dtpbirthdate.Value, dtpbirthtime.Value, (string)cmbgender.SelectedItem, 
                                            txtmname.Text, txtfname.Text, txtgrand.Text, txtaddress.Text, (string)cmbcname.SelectedValue,
                                            ntxtweightkg.Value.ToString(), ntxtweightlbs.Value.ToString(), txtnote.Text, txtrecname.Text, 
                                            dtprecdate.Value, dtprectime.Value, txtrecrelation.Text, 
                                            chkisactive.Checked ? "1" : "0", txtremarks.Text, "0");
                      MessageBox.Show("Record Successfully Saved..!");
                      Validation.Clear(grprecptinfo);
                      Validation.Clear(grpchildinfo);
                      CurrentDateTime();
                      txtRegAlpha.Focus();
                      txtserialno.Text = "";
                      txtbirthid.Text = "";


            }
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            Validation.Clear(grprecptinfo);
            Validation.Clear(grpchildinfo);
            CurrentDateTime();
            txtRegAlpha.Focus();
            txtserialno.Text = "";
            txtbirthid.Text = "";
        }

        private void frmbirthinfo_Load(object sender, EventArgs e)
        {
           
            CurrentDateTime();
            cmbcname.SelectedIndex = 0;
            cmbgender.SelectedIndex = 0;
            //grpchildinfo.Focus();
            //txtRegAlpha.Focus();


        }

        private void CurrentDateTime()
        {
            dtpbirthdate.Value = SoftwareInfo.ServerDate;//DateTime.Now;
            dtpbirthtime.Value = SoftwareInfo.ServerDate;//DateTime.Now;

            dtprecdate.Value = SoftwareInfo.ServerDate;//DateTime.Now;
            dtprectime.Value = SoftwareInfo.ServerDate;//DateTime.Now;

           
        }
        private void frmbirthinfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void ntxtweightkg_ValueChanged(object sender, EventArgs e)
        {
            ntxtweightlbs.Value = Convert .ToDecimal (ntxtweightkg.Value * Convert.ToDecimal  (2.20462262185));   
        }

        private void btnpreview_Click(object sender, EventArgs e)
        {

            PrintReport(false);
        }

        private void PrintReport(bool DirectPrint)
        {
            if (ntxtRegNo.Value.ToString() != "" && txtRegAlpha.Text != "")
            {




                    DataTable isExistBirthCir = Query.getData("select count(*) as isexist from birthinfo where status=0 and birthid='" + txtbirthid.Text+"'");
                if (isExistBirthCir.Rows[0]["isexist"].ToString() != "0")
                {


                    Reports.CrpBirthCert rpt = new Reports.CrpBirthCert();
                    DataTable dt = ReportQuery.InPBirthCret(txtserialno.Text, txtbirthid.Text);

                    DataTable dtgetBirthinfo = Query.getData(@"SELECT birthid ,To_Char( birthdate,'Day,Monthdd,yyyy') AS BirthDate,To_Char(birthtime,'HH24:MI') AS BirthTime,gender,weightkg,round(weightlbs,2) as weightlbs,mothername,fathername,grandfmname,birthdate,
                                                        birthtime, get_consultantname(consult) AS Consult,createdby 
                                                         FROM   birthinfo WHERE   birthid = '" + txtbirthid.Text + "' AND serialno = '" + txtserialno.Text + "'");

                    string BodyText = "";
                    if (dtgetBirthinfo.Rows.Count > 0)
                    {
                        BodyText = "MemonMedical  Complex is pleased to certify that a \n" + dtgetBirthinfo.Rows[0]["gender"].ToString() + " baby weighting " + dtgetBirthinfo.Rows[0]["weightkg"].ToString() + " Kilograms(" + dtgetBirthinfo.Rows[0]["weightlbs"].ToString() + " pounds)\nwas born to Mrs. " + dtgetBirthinfo.Rows[0]["mothername"].ToString() + " w/o Mr." + dtgetBirthinfo.Rows[0]["fathername"].ToString() + "\nGrand Father: " + dtgetBirthinfo.Rows[0]["grandfmname"].ToString() + "\non " + dtgetBirthinfo.Rows[0]["BirthDate"].ToString() + " at " + dtgetBirthinfo.Rows[0]["BirthTime"].ToString() + "." + "\nBaby was delivered By " + dtgetBirthinfo.Rows[0]["Consult"].ToString();
                    }


                    rpt.SetDataSource(dt);
                    rpt.SetParameterValue("pBodyText", BodyText);
                    rpt.SetParameterValue("pUser", dtgetBirthinfo.Rows.Count > 0 ? dtgetBirthinfo.Rows[0]["createdby"].ToString() : UserInfo.UserName);

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
                else
                {
                    MessageBox.Show("Pls Save Birth Cirtificate.....");
                    btnsave.Focus();
                    return; 
                }
                
            }


            else
            {
                MessageBox.Show("Enter File No....");
                txtRegAlpha.Focus();
                return;
            }

        }

        

        private void btnprint_Click(object sender, EventArgs e)
        {

            PrintReport(true);
        }

   

        

        void FillDetail(string RegNo)
        {
            DataTable dtserialno = Query.getData("SELECT serialno FROM admissioninfo WHERE regnoalpha='"+txtRegAlpha.Text+"' AND regnonumeric='"+ntxtRegNo.Value+"' AND status=0");
            if (dtserialno.Rows.Count > 0)
            {
                txtserialno.Text = dtserialno.Rows[0]["serialno"].ToString();


                DataTable dt = Query.BirthDate(txtserialno.Text);
                if (dt.Rows.Count > 0)
                {


                    //txtRegAlpha.Text =dt.Rows[0][""].ToString();
                    //ntxtRegNo.Text =dt.Rows[0][""].ToString();
                    dtpbirthdate.Value = Convert.ToDateTime(dt.Rows[0]["birthdate"].ToString());
                    dtpbirthtime.Value = Convert.ToDateTime(dt.Rows[0]["birthtime"].ToString());
                    cmbgender.Text = dt.Rows[0]["gender"].ToString();
                    txtmname.Text = dt.Rows[0]["mothername"].ToString();
                    txtfname.Text = dt.Rows[0]["fathername"].ToString();
                    txtgrand.Text = dt.Rows[0]["grandfmname"].ToString();
                    txtaddress.Text = dt.Rows[0]["address"].ToString();
                    cmbcname.Text = dt.Rows[0]["consultants"].ToString();
                    ntxtweightkg.Value = Convert.ToDecimal(dt.Rows[0]["weightkg"].ToString());
                    ntxtweightlbs.Value = Convert.ToDecimal(dt.Rows[0]["weightlbs"].ToString());
                    txtnote.Text = dt.Rows[0]["note"].ToString();
                    txtrecname.Text = dt.Rows[0]["recperson"].ToString();
                    dtprecdate.Value = Convert.ToDateTime(dt.Rows[0]["recdate"].ToString());
                    dtprectime.Value = Convert.ToDateTime(dt.Rows[0]["rectime"].ToString());
                    txtrecrelation.Text = dt.Rows[0]["recralation"].ToString();
                    chkisactive.Checked = dt.Rows[0]["recvyn"].ToString() == "1" ? true : false;
                    txtremarks.Text = dt.Rows[0]["recremarks"].ToString();
                    txtbirthid.Text = dt.Rows[0]["birthid"].ToString();
                }
                else
                {
                    txtfname.Text = "";
                    txtmname.Text = "";
                    txtgrand.Text = "";
                    txtaddress.Text = "";
                    txtnote.Text = "";
                    Validation.Clear(grprecptinfo);
                    CurrentDateTime();
                    txtbirthid.Text = "";
                }
            }
            else
            {
                Validation.Clear(grprecptinfo);
                Validation.Clear(grpchildinfo);
                CurrentDateTime();
                txtRegAlpha.Focus();
                MessageBox.Show("Admission Not Found....!!!!");
                
            }
        }

        private void txtRegAlpha_Validated(object sender, EventArgs e)
        {
            ntxtRegNo.Select(0, ntxtRegNo.Value.ToString().Length);
        }

        private void ntxtRegNo_Validated(object sender, EventArgs e)
        {
         
               FillDetail(txtRegAlpha.Text + "-" + ntxtRegNo.Text);
            
           
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dtSearch = Query.searchbirth(dtpFrom.Value.ToString("dd MMM yyyy"), dtpTo.Value.ToString("dd MMM yyyy"),
                 (txtMother.Text.ToLower() != "" ? " and Lower(mothername) = '" + txtMother.Text.ToLower() + "'" : ""), (txtFather.Text != "" ? " and lower(fathername) = '" + txtFather.Text.ToLower() + "'" : ""));            // dgvData.Rows.Clear();
            FillSearch();
        }


        void FillSearch()
        {

            dgvSearch.Rows.Clear();
            for (int i = 0; i < dtSearch.Rows.Count; i++)
            {
                dgvSearch.Rows.Add(
                       dtSearch.Rows[i]["fileNo"],
                       dtSearch.Rows[i]["mothername"],
                       dtSearch.Rows[i]["fathername"],
                       dtSearch.Rows[i]["birthdate"]
                       );
            }
        }

      
    }
}

