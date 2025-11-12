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
    public partial class frmConsultantSetup : Form
    {
        public frmConsultantSetup()
        {
            InitializeComponent();
        }
        void Fill(string[] filter)
        {
            dgvDetail.Rows.Clear();

            DataTable  dt = Query.ConsultantSetup(filter);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int ind = dgvDetail.Rows.Add(dt.Rows[i]["id"].ToString(), dt.Rows[i]["Name"].ToString(),                    
                      dt.Rows[i]["timings"].ToString(),
                      dt.Rows[i]["Faculty"].ToString(),
                      dt.Rows[i]["degrees"].ToString(),
                      dt.Rows[i]["department"].ToString(),
                      dt.Rows[i]["isdeactivate"].ToString() == "1" ? false : true //,
                      //dt.Rows[i]["CreatedBy"].ToString() + " | " + ((DateTime)dt.Rows[i]["CreatedTime"]).ToString("dd-MMM-yyyy hh:mm:ss tt"),
                      //dt.Rows[i]["EditBy"].ToString() != "" ? dt.Rows[i]["EditBy"].ToString() + " | " + ((DateTime)dt.Rows[i]["EditTime"]).ToString("dd-MMM-yyyy hh:mm:ss tt") : null
                );
                //if (dt.Rows[i]["status"].ToString() != "0")
                //{
                //    dgvDetail.Rows[ind].DefaultCellStyle.BackColor = Color.Red;
                //}

            }
            lblTotRecordsFetched.Text = "Total Records : " + dt.Rows.Count.ToString("N0");
        }
        private void frmConsultantSetup_Load(object sender, EventArgs e)
        {
            Fill(new string[] { });
        }

        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                FrmConsultant frm = new FrmConsultant();
                frm.fill(dgvDetail[clnID .Index ,e.RowIndex ].Value .ToString()); 
                frm.ShowDialog(); 
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
