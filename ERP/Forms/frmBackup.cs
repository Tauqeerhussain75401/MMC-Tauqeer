using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO.Compression;
using System.IO;
namespace ERP
{
   
    public partial class frmBackup : Form
    {
        OpenFileDialog dialog = new OpenFileDialog();
        public frmBackup()
        {
            InitializeComponent();
        }
        private void btnLocation_Click(object sender, EventArgs e)
        {            

            string ext = "bak";
            dialog.Filter = "BAK files(*.BAK)|*.bak";
            dialog.CheckFileExists = false;
            dialog.DefaultExt = ext;
            dialog.AddExtension = true;
            dialog.ShowDialog();
            txtLocation.Text = dialog.FileName;    
        }
        private void btnBackup_Click(object sender, EventArgs e)
        {
            //prgbar.PerformStep();
            //string connection = @"Data Source=" + clsConnection.Host + @"\SQLEXPRESS;Initial Catalog=master;User ID=mutahhar;Password=mutahhar11";
            //string com = "BACKUP DATABASE MilkWholeSeller     TO  DISK = '" + txtLocation.Text + "'  with mediapassword = 'ERP197932'";
            //connection = @"Data Source=" + clsConnection.Host + @"\SQLEXPRESS;Initial Catalog=master;User ID=mutahhar;Password=mutahhar11";
            //SqlConnection con = new SqlConnection(connection);
            //prgbar.PerformStep();
            //con.Open();
            ////OracleDataAdapter adap = new OracleDataAdapter(com, clsConnection.con);
            ////DataTable dt = new DataTable();
            ////adap.Fill(dt);
            //OracleCommand comm = new OracleCommand(com, con);
            //comm.ExecuteNonQuery();
            //prgbar.PerformStep();
            //con.Close();
            ////Backup(txtLocation.Text);
            //prgbar.Value = 100; 
            //MessageBox.Show("Backup successfully saved......!");
        }
       
        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            if (txtLocation.Text != "")
                btnBackup.Enabled = true;
            else
                btnBackup.Enabled = false;
        }
        private void frmBackup_Load(object sender, EventArgs e)
        {
            txtLocation_TextChanged(null, null);  
        }
    }
}
