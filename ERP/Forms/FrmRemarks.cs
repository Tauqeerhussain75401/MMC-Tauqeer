using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERP.Forms;

namespace ERP
{
    public partial class FrmRemarks : Form
    {
        public FrmRemarks()
        {
            InitializeComponent();
        }

        public string SetVoucherType;

        private void FrmRemarks_Load(object sender, EventArgs e)
        {
            switch (SetVoucherType)
            {
                case "BankToBank":
                    lblHeader.Text = "Delete Bank to Bank Transfer - Enter Remarks";
                    break;
                case "Journal":
                    lblHeader.Text = "Delete Journal Voucher - Enter Remarks";
                    break;
                case "Payment":
                    lblHeader.Text = "Delete Payment Voucher - Enter Remarks";
                    break;
                case "Receipt":
                    lblHeader.Text = "Delete Receipt Voucher - Enter Remarks";
                    break;
                case "PostVoucher":
                    lblHeader.Text = "Delete Voucher - Enter Remarks";
                    break;
                default:
                    lblHeader.Text = "Enter Remarks";
                    break;
            }
        }

        private void richtxtRemarks_TextChanged(object sender, EventArgs e)
        {
            if (richtxtRemarks.Text.Length > 20)
                btnOK.Enabled = true;
            else
                btnOK.Enabled = false;
        }

        void ReturnText(string Type)
        {
            if (SetVoucherType == "Journal")
                frmGeneralVoucher2.Remarks = Type == "OK" ? richtxtRemarks.Text : "";
            else if (SetVoucherType == "Payment")
                frmPVoucherNew.Remarks = Type == "OK" ? richtxtRemarks.Text : "";
            else if (SetVoucherType == "Receipt")
                frmRVoucherNew.Remarks = Type == "OK" ? richtxtRemarks.Text : "";
            else if (SetVoucherType == "BankToBank")
            {
                frmBankToBank.Remarks = Type == "OK" ? richtxtRemarks.Text : "";
            }
            else if (SetVoucherType == "PostVoucher")
            {
                frmPostPV.Remarks = Type == "OK" ? richtxtRemarks.Text : "";
            }
            this.Close();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            ReturnText("OK");
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ReturnText("Close");
        }
    }
}
