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
    public partial class frmRoomInfo : Form
    {
        DataTable dtQuery;
        public frmRoomInfo()
        {
            
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtRName.Text == "") 
            {
                MessageBox.Show("Enter Room");
                txtRName.Focus();
                return;
            }
            else if(txtDesc.Text=="")
            {
                MessageBox.Show("Enter Description");
                txtDesc.Focus();
                return;
            }
            else if(cmbFNo.SelectedItem==null)
            {
                MessageBox.Show("Select Floor");
                cmbFNo.Focus();
                return;
            }
            else if(numHosRate.Value==0)
            {
                MessageBox.Show("Enter Hospital Rate");
                numHosRate.Focus();
                return;
            }
           

            else if (MessageBox.Show("Are you sure?" + Environment.NewLine + "You want to save this...!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DML.roominfo_add_edit(txtRoomid.Text,txtRName.Text,txtDesc.Text,(string)cmbFNo.SelectedItem,numHosRate.Text);
                MessageBox.Show("Record Successfully Saved..!");

            }
        }
        void FillQuery()
        {

            dgvRoomDetails.Rows.Clear();
            dtQuery = Query.RoomInfo();
            for (int i = 0; i < dtQuery.Rows.Count; i++)
            {
                dgvRoomDetails.Rows.Add(dtQuery.Rows[i]["id"].ToString(),
                dtQuery.Rows[i]["fullname"].ToString(),
                dtQuery.Rows[i]["description"].ToString(),
                dtQuery.Rows[i]["floornumber"].ToString(),
                dtQuery.Rows[i]["hospitalrate"].ToString());
               


            }
        }
        internal void FillDetail(string ID)
        {
            DataTable dt;
            dt = Query.RoomSearch(ID);
            /////////////////////
            //txtConsultantid.Text = ID;
            if (dt.Rows.Count > 0)
            {
                // cmbCatagory.SelectedValue = dt.Rows[0]["TesttypeId"].ToString();
                txtRoomid.Text = dt.Rows[0]["id"].ToString();
                txtRName.Text = dt.Rows[0]["fullname"].ToString();
                txtDesc.Text = dt.Rows[0]["description"].ToString();
                cmbFNo.Text = dt.Rows[0]["floornumber"].ToString();
                numHosRate.Text = dt.Rows[0]["hospitalrate"].ToString();
                
              

            }
        }
        

        private void frmRoomInfo_Load(object sender, EventArgs e)
        {
            FillQuery();
            numHosRate.Text = "";
            
            
            //FillControls.Fillcmbfloor(cmbFNo);
        }

        private void dgvRoomDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FillDetail(dgvRoomDetails.Rows[e.RowIndex].Cells[ID.Index].Value.ToString());
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            
            txtRName.Focus();
            
            Validation.Clear(grpRoomInfo);
        }


        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnnew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N) 
            {
               
            }
        }

        private void cmbFNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void grpRoomInfo_Enter(object sender, EventArgs e)
        {

        }

        private void btnpreview_Click(object sender, EventArgs e)
        {
            frmReportView frm = new frmReportView();
            Reports.RoomIndex rpt = new Reports.RoomIndex();
            rpt.SetDataSource(dtQuery);
            frm.rptViewer.ReportSource = rpt;
            frm.Show();
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            if (dtQuery == null)
            {
                return;
            }
            string searchtext = tb_search.Text.Trim().ToLower();
            dgvRoomDetails.Rows.Clear();

            foreach (DataRow row in dtQuery.Rows)
            {
                string id = row["id"]?.ToString() ?? "";
                string title = row["fullname"]?.ToString() ?? "";
                string description = row["description"]?.ToString() ?? "";
                if (id.ToLower().Contains(searchtext) || title.ToLower().Contains(searchtext) || description.ToLower().Contains(searchtext))
                {
                    string floornumber = row["floornumber"]?.ToString() ?? "";
                    string charges = row["hospitalrate"]?.ToString() ?? "";


                    dgvRoomDetails.Rows.Add(id, title, description, floornumber, charges);
                }
            }
        }
    }
}
