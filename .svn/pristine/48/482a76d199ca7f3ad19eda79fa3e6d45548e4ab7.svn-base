using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace ERP.Forms
{
    public partial class frmVersionUpdater : Form
    {
        public frmVersionUpdater()
        {
            InitializeComponent();
        }
        OpenFileDialog dialog = new OpenFileDialog();
       
        private void btnLocation_Click(object sender, EventArgs e)
        {

            //string ext = "bak";
            //dialog.Filter = "BAK files(*.BAK)|*.bak";
            //dialog.CheckFileExists = false;
            //dialog.DefaultExt = ext;
            //dialog.AddExtension = true;
            dialog.ShowDialog();
            txtLocation.Text = dialog.FileName;    

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            AssemblyName AssemblyName = AssemblyName.GetAssemblyName(txtLocation.Text  );
            DML.Load_SoftwareFile(File.ReadAllBytes(txtLocation.Text), AssemblyName.Version.ToString());
        }
    }
}
