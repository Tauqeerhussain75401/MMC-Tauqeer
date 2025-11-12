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
    public partial class FrmBankDetail : Form
    {
        string bankcode = "0";
        bool Flogin = true;
        public bool SaveRight=true;

      
       
        
        public FrmBankDetail()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
               
                        
                        
                        if (MessageBox.Show("Do you wan't to save changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            bankcode = MSP.Bank_add_edit1(bankcode, txtBankName.Text, txtBranch.Text, txtBranchCode.Text, (string)cmbCity.SelectedValue, (string)cmbCountry.SelectedValue, txtCurrency.Text,
                                cmbAccountType.Text, txtIBAN.Text, (string)cmbisoCountryCode.SelectedValue, txtIBANCheckDigits.Text, txtBBAN.Text, txtBankIdentifier.Text, (rdbSepaYes.Checked == true ? "1" : "0"), "0",  txtSDebit.Text, txtSCredit.Text);
                            foreach (DataGridViewRow item in dgvFacility.Rows)
                            {
                                if (item.Cells[clnNatureofFacility.Index].Value != null)
                                    MSP.BankFacilities_add_edit(bankcode, (string)item.Cells[clnNatureofFacility.Index].Value, (string)item.Cells[clnCurrency1.Index].Value,
                                        (string)item.Cells[clnLimitAmount.Index].Value, (string)item.Cells[clnMarkupRateCommission.Index].Value,
                                        (string)item.Cells[clnValidityReviewDate.Index].Value, (string)item.Cells[clnPurposeOfFinancing.Index].Value, "0", item.Index.ToString());
                                //  dgvFill();
                            }
                            foreach (DataGridViewRow item in dgvMargin.Rows)
                            {
                                if (item.Cells[clnSymbol.Index].Value != null)
                                    MSP.BankMargin_add_edit(bankcode, (string)item.Cells[clnSymbol.Index].Value, (string)item.Cells[clnMarginPer.Index].Value,
                                        (string)item.Cells[clnChargewithSECP.Index].Value, "0", item.Index.ToString());
                                //  dgvFill();
                            }
                            Cursor.Current = Cursors.Default;
                            fill();
                            MyMessageBox.ShowBox("Record successfully saved..!", "Message", 1);
                        }
                  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "FrmBankDetail btnSave_Click");
                this.Close();
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            Validation.Clear(tabControl1);
            bankcode = "0";
            txtbankCode.Text = "";
        }
        void fill()
        {
            dgvBankDetail.Rows.Clear();
            DataTable dt = Query.bankdetail();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgvBankDetail.Rows.Add(dt.Rows[i]["bankcode"], dt.Rows[i]["bban"], dt.Rows[i]["bankname"], dt.Rows[i]["branchname"], dt.Rows[i]["currency"]);
            }

        }
        string rights;
        private void FrmBankDetail_Load(object sender, EventArgs e)
        {
            //fillSecCode("Properietary");
            //fillSecCodeShortLiabilities();
            //fillSecCodeLongLiabilities();

            //basit 08-01-2020
           
            //basit 08-01-2020
            cmbCountry.DataSource = Query.CountryIndex();
            cmbCountry.DisplayMember = "countryname";
            cmbCountry.ValueMember = "countrycode";
            cmbCity.DataSource = Query.CityIndex();
            cmbCity.DisplayMember = "cityname";
            cmbCity.ValueMember = "citycode";
            cmbisoCountryCode.DataSource = Query.isocountryIndex();
            cmbisoCountryCode.DisplayMember = "isocountrycode";
            cmbisoCountryCode.ValueMember = "countrycode";

            fill();
            this.Text = Variable.Version;
            Variable.flags = Animate.AW_ACTIVATE | Animate.AW_CENTER;
            Animate.AnimateWindow(this.Handle, Variable.animationTime, Variable.flags);
            Flogin = false;
        }
        private void dgvBankDetail_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBankDetail.CurrentRow != null)
            {
                DataTable dtbank = Query.BankDetail(dgvBankDetail.CurrentRow.Cells[clnBankCode.Index].Value.ToString());
                txtbankCode.Text = dtbank.Rows[0]["bankcode"].ToString();
                bankcode = txtbankCode.Text;
                txtBankName.Text = dtbank.Rows[0]["bankname"].ToString();
                txtBranch.Text = dtbank.Rows[0]["branchname"].ToString();
                //Second Debit Credit 23-10-2020
                txtSDebit.Text = dtbank.Rows[0]["sdebit"].ToString();
                txtSCredit.Text = dtbank.Rows[0]["scredit"].ToString();

                txtBranchCode.Text = dtbank.Rows[0]["branchcode"].ToString();
                cmbCity.SelectedValue = dtbank.Rows[0]["fkciycode"];
                cmbCountry.SelectedValue = dtbank.Rows[0]["fkcountrycode"];
                txtCurrency.Text = dtbank.Rows[0]["currency"].ToString();
                cmbAccountType.Text = dtbank.Rows[0]["AccountType"].ToString();
                txtIBAN.Text = dtbank.Rows[0]["iban"].ToString();
                cmbisoCountryCode.SelectedValue = dtbank.Rows[0]["isoCountrycode"].ToString();
                txtIBANCheckDigits.Text = dtbank.Rows[0]["ibancheckdigits"].ToString();
                txtBBAN.Text = dtbank.Rows[0]["bban"].ToString();
                txtBankIdentifier.Text = dtbank.Rows[0]["bankidentifier"].ToString();
                //basit 25-2-2020 VSecondaryCode
               
                //basit 25-2-2020
                rdbSepaYes.Checked = (dtbank.Rows[0]["sepamember"].ToString() == "1" ? true : false);
                rdbSepaNo.Checked = !rdbSepaYes.Checked;
                
                DataTable dtFacility = Query.BankFacilities(dgvBankDetail.CurrentRow.Cells[clnBankCode.Index].Value.ToString());
                dgvFacility.Rows.Clear();
                for (int i = 0; i < dtFacility.Rows.Count; i++)
                {
                    dgvFacility.Rows.Add(dtFacility.Rows[i]["seq"], dtFacility.Rows[i]["natureoffacilities"], dtFacility.Rows[i]["cur"], dtFacility.Rows[i]["limitamount_millions"],
                        dtFacility.Rows[i]["commission"], dtFacility.Rows[i]["review_date"], dtFacility.Rows[i]["purposeoffinancing"]);
                }
                DataTable dtMargin = Query.BankMargin(dgvBankDetail.CurrentRow.Cells[clnBankCode.Index].Value.ToString());
                dgvMargin.Rows.Clear();
                for (int i = 0; i < dtMargin.Rows.Count; i++)
                {
                    dgvMargin.Rows.Add(dtMargin.Rows[i]["seq"], dtMargin.Rows[i]["natureoffacilities"], dtFacility.Rows[i]["cur"], dtFacility.Rows[i]["limitamount_millions"],
                        dtFacility.Rows[i]["commission"], dtFacility.Rows[i]["review_date"], dtFacility.Rows[i]["purposeoffinancing"]);
                }


            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

    }
}
