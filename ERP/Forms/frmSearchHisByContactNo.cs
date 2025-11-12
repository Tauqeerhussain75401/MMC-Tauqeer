using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERP.Forms
{
    public partial class frmSearchHisByContactNo : Form
    {
        public frmSearchHisByContactNo()
        {
            InitializeComponent();
           
            
        }
        //public frmSearchHisByContactNo(ref frmOPDReceipt frm)
        //{
        //    InitializeComponent();
        //    this.frm = frm;

        //}
        private frmOPDReceipt frm;
 
        public string contactno = "";
        
        private void frmSearchHisByContactNo_Load(object sender, EventArgs e)
        {
            FillQuery();
        }
        void FillQuery()
        {
            dgvQuery.Rows.Clear();

            DataTable dtQuery = Query.getData("SELECT receiptno,tokenNo, vdate, get_OPDcatagory(catagoryid) CatagoryTitle, Get_consultantName(consultantid) ConsultantName, get_PatientType(patienttype) patienttype, memberid, patientid, patienttitle, patientname, gender, contactno, age, ageunit, netamount, createdby, createdtime, editby, edittime,status,noofprint FROM OPDReceipt where status = 0 and contactno is not null and contactno='"+contactno+"' order by ReceiptNo desc");

            for (int i = 0; i < dtQuery.Rows.Count; i++)
            {
                int ind = dgvQuery.Rows.Add(dtQuery.Rows[i]["TokenNo"], "OP-" + dtQuery.Rows[i]["ReceiptNo"].ToString(),
                    ((DateTime)dtQuery.Rows[i]["VDate"]),
                      dtQuery.Rows[i]["CatagoryTitle"].ToString(),
                      dtQuery.Rows[i]["ConsultantName"].ToString(),
                      dtQuery.Rows[i]["patienttype"].ToString(),
                      dtQuery.Rows[i]["patientname"].ToString(),
                      dtQuery.Rows[i]["netamount"],
                      dtQuery.Rows[i]["CreatedBy"].ToString() + " | " + ((DateTime)dtQuery.Rows[i]["CreatedTime"]).ToString("dd-MMM-yyyy hh:mm:ss tt"),
                      dtQuery.Rows[i]["EditBy"].ToString() != "" ? dtQuery.Rows[i]["EditBy"].ToString() + " | " + ((DateTime)dtQuery.Rows[i]["EditTime"]).ToString("dd-MMM-yyyy hh:mm:ss tt") : null);
                if (dtQuery.Rows[i]["noofPrint"].ToString() == "0")
                {
                    dgvQuery.Rows[ind].DefaultCellStyle.BackColor = Color.LightGray;
                }
                if (dtQuery.Rows[i]["status"].ToString() != "0")
                {
                    dgvQuery.Rows[ind].DefaultCellStyle.BackColor = Color.Red;
                }


            }
            
        }

        public DataTable dtFillPatHis;

        private void dgvQuery_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex!=-1)
            {
                 dtFillPatHis = Query.getData("SELECT patienttype,memberid,patienttitle,patientname,gender,contactno,age,ageunit,referenceid,remarks FROM opdreceipt WHERE status=0 and receiptno='"+dgvQuery.Rows[e.RowIndex].Cells[clnVoucherNum.Index].Value.ToString().Remove(0,3)+"'");
                 if (dtFillPatHis.Rows.Count > 0) 
                {
                    //frmOPDReceipt frm = new frmOPDReceipt();
                    //frm.PType = dtFill.Rows[0]["patienttype"].ToString();
                    //frm.PBMJ = dtFill.Rows[0]["memberid"].ToString();
                    //frm.PTitle = dtFill.Rows[0]["patienttitle"].ToString();
                    //frm.PName = dtFill.Rows[0]["patientname"].ToString();
                    //frm.PGender = dtFill.Rows[0]["gender"].ToString();
                    //frm.PContact = dtFill.Rows[0]["contactno"].ToString();
                    //frm.PAge = dtFill.Rows[0]["age"].ToString();
                    //frm.PAgeUnit = dtFill.Rows[0]["ageunit"].ToString();
                    //frm.PReference = dtFill.Rows[0]["referenceid"].ToString();
                    //frm.Premakrs = dtFill.Rows[0]["remarks"].ToString();
                }
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
