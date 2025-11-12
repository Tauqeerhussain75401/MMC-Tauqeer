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
    public partial class frmReference : Form
    {
        public frmReference()
        {
            
            InitializeComponent();
        }

        DataTable dtQuery;
         void FillQuery()
        {
            dgvRefdetails.Rows.Clear();
              
              dtQuery = Query.ReferenceInfo();
             dgvRefdetails.AutoGenerateColumns = false;
             dgvRefdetails.DataSource = dtQuery;
             dgvRefdetails.Columns[clnID.Index ].DataPropertyName = "ID";
             dgvRefdetails.Columns[clnName.Index].DataPropertyName = "name";
             dgvRefdetails.Columns[clnReport.Index].DataPropertyName = "showzfheadinginreport";
             dgvRefdetails.Columns[clnActive.Index].DataPropertyName = "isActive";
            
            
             }
         internal void FillDetail(string ID)
         {
             DataTable dt;
             dt = Query.ReferenceSearch(ID);
             /////////////////////
            
             if (dt.Rows.Count > 0)
             {

                 txtid.Text= dt.Rows[0]["id"].ToString();
                 txtRname.Text = dt.Rows[0]["name"].ToString();
                 chkInReport.Checked = dt.Rows[0]["showzfheadinginreport"].ToString()=="0" ? false :true ;
                 chkActive.Checked= dt.Rows[0]["isActive"].ToString()=="0"?false :true ;
                 
             }
         }

         private void frmReference_Load(object sender, EventArgs e)
         {
             FillQuery();
         }

        

     

         private void btnExit_Click(object sender, EventArgs e)
         {
             this.Close();
         }

         private void btnNew_Click(object sender, EventArgs e)
         {
             dtQuery = Query.getData("select * from reference where rownum < 5");
             Validation.Clear(grpReferenceInfo);
         }

         

         private void btnSave_Click(object sender, EventArgs e)
         {
             if (txtRname.Text == "")
             {
                 MessageBox.Show("Enter Name");
                 return;

             }
             if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to save this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
             {
                 DML.reference_add_edit(txtid.Text, txtRname.Text, chkInReport.Checked ? "1" : "0", chkActive.Checked ? "1" : "0");
                 MessageBox.Show("Record Successfully Saved..!");
                 Validation.Clear(grpReferenceInfo);
                 

             }
         }

         private void dgvRefdetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
         {
             if (e.RowIndex != -1)
             {
                 FillDetail(dgvRefdetails.Rows[e.RowIndex].Cells[clnID.Index].Value.ToString());    
             }
             
         }

        

    }
}
