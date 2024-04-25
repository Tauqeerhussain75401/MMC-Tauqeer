using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ERP
{

    public partial class frmTransactionDetail : Form
    {

        DataTable dtTrans = new DataTable();
        public bool SaveRight=true;
        public frmTransactionDetail()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you wan't to exit it?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "TransactionDetail btnCancel_Click");
                this.Close();
            }
        }
        void dgvFill()
        {
            dgvTransactionDetail.Rows.Clear();
            //DataTable dt = db.getdata("select ID,TransNarration from TransactionCode where status = 0");
            DataTable dt = Query.NarrationIndex();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgvTransactionDetail.Rows.Add(dt.Rows[i]["narrationcode"], dt.Rows[i]["narrationtitle"], 1);
            }
        }
        private void frmTransactionDetail_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = Variable.Version;
                dgvFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "TransactionDetail frmTransactionDetail_Load");
                this.Close();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveRight == true)
                {
                    if (MessageBox.Show("Do you wan't to save changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        foreach (DataGridViewRow row in dgvTransactionDetail.Rows)
                        {
                            if (row.Cells[clnTransCode.Index].Value != null && row.Cells[clnTransNarration.Index].Value != null && row.Cells[IsEdit.Index].Value.ToString() == "0")
                            {
                                //if (!db.IsExist("select * from transactionCode where id = " + row.Cells[clnTransCode.Index].Value.ToString()))
                                //    db.ComExecute("exec savetransactiondetail '" + row.Cells[clnTransCode.Index].Value.ToString() + "','" + row.Cells[clnTransNarration.Index].Value.ToString() + "'");
                                //else
                                //    db.ComExecute("exec updatetransactiondetail '" + row.Cells[clnTransCode.Index].Value.ToString() + "','" + row.Cells[clnTransNarration.Index].Value.ToString() + "'");
                                MSP.Narration_Add_Edit(row.Cells[clnTransCode.Index].Value.ToString(), row.Cells[clnTransNarration.Index].Value.ToString(), "0");
                            }
                        }
                        dgvFill();
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Record Successfully Saved...!");
                    }

                }
                else
                {
                    MessageBox.Show("You have no rights to save this...!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "TransactionDetail btnSave_Click");
                this.Close();
            }
        }
        private void dgvTransactionDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvTransactionDetail.CurrentRow != null)
                {
                    dgvTransactionDetail.CurrentRow.Cells[IsEdit.Index].Value = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "TransactionDetail dgvTransactionDetail_CellValueChanged");
            }
        }
        private void dgvTransactionDetail_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dgvTransactionDetail.CurrentCell == dgvTransactionDetail.CurrentRow.Cells[clnTransCode.Index])
                    e.Control.TextChanged += new EventHandler(textBox_TextChanged);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "TransactionDetail dgvTransactionDetail_EditingControlShowing");
            }
        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvTransactionDetail.CurrentRow != null)
                {
                    if (dgvTransactionDetail.CurrentCell == dgvTransactionDetail.CurrentRow.Cells[clnTransCode.Index] && (sender as TextBox).Text != null && (sender as TextBox).Text.ToString().Length == 3)
                    {
                        int a = 0;
                        try
                        {
                            a = (from DataGridViewRow row in dgvTransactionDetail.Rows
                                 where row.Cells[0].Value != null && row != dgvTransactionDetail.CurrentRow && (sender as TextBox).Text.ToUpper() == row.Cells[0].Value.ToString().Substring(0, 3)
                                 select Convert.ToInt32(row.Cells[0].FormattedValue.ToString().Substring(4))).Max();
                        }
                        catch
                        {
                            a = 0;
                        }
                        (sender as TextBox).Text = (sender as TextBox).Text.ToUpper() + "-" + (a + 1).ToString("D3");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                Errors.writeline(ex.Message.ToString(), "TransactionDetail textBox_TextChanged");
            }
        }
    }
}


