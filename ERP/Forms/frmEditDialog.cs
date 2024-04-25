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
    public partial class frmEditDialog : Form
    {
        //  Classes.dbMethods db = new Classes.dbMethods();
        public frmEditDialog()
        {
            InitializeComponent();
        }
        public static string ParentId;
        public static int Level;
        public static int Status;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "frmEditDialog btnCancel_Click");
                this.Close();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //if (Variable.FormRights == "S" || Variable.Privillages == "Admin")
                //{

                    string confirm = MyMessageBox.ShowBox("Are you Sure to "+ btnSave.Text  +" It ?", Variable.Version, 2);
                    if (confirm == "1")
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        string tf = MSP.ChartofAccounts_Add_Edit(lblAcc.Text, txtTitle.Text, ParentId.ToString(), (rbParent.Checked == true ? "Control" : "Detail"), Level.ToString(), Status.ToString());
                        if (tf.ToLower() == "true")
                        {
                            if (btnSave.Text == "Save")
                            {
                                string ok = MyMessageBox.ShowBox("Account Saved Successfully !", Variable.Version, 1);
                            }
                            else
                            {
                                string ok = MyMessageBox.ShowBox("Account Deleted Successfully !", Variable.Version, 1);
                            }
                            this.DialogResult = DialogResult.Yes;
                        }
                        //frmChartOfAccount ca = new frmChartOfAccount();
                        this.Close();
                        Cursor.Current = Cursors.Default;
                    }
                

                //}
                //else
                //    MessageBox.Show("You have no rights to save this...!");
        }
            catch (Exception ex)
            {
                MyMessageBox.ShowBox(ex.Message.ToString());
                //MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "frmEditDialog btnSave_Click");
                this.Close();
            }
        }
        private void frmEditDialog_Load(object sender, EventArgs e)
        {
            this.Text = Variable.Version;
        }
        private void txtTitle_Validated(object sender, EventArgs e)
        {
            txtTitle.Text = WordCase.WordSet(txtTitle.Text);
        }
    }
}
