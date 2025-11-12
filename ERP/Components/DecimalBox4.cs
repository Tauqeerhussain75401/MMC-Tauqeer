using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace ERP
{
    public partial class DecimalBox4 : System.Windows.Forms.TextBox 
    {

        public DecimalBox4()
        {
            this.Font = new Font("Arial", 10,FontStyle.Bold);
            InitializeComponent();
            this.KeyPress += new KeyPressEventHandler(DecimalBox4_KeyPress);
            this.Validated += new EventHandler(DecimalBox4_Validated);
            this.RightToLeft= System.Windows.Forms.RightToLeft.Yes ;
            this.MouseUp += new MouseEventHandler(DecimalBox4_MouseUp);
            
        }
        private void DecimalBox4_MouseUp(object sender, System.EventArgs e)
        {
            this.SelectionStart = 0;
            this.SelectionLength = this.Text.Length;
        }
        private void DecimalBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
                if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
                {
                    MessageBox.Show("Invalid character '" + e.KeyChar +

                        "' Only keys 0 to 9 and . are valid for this field!!");

                    e.Handled = true;
                }
 
        }

        private void DecimalBox4_Validated(object sender, System.EventArgs e)
        {
            try
            {
                decimal i = Convert.ToDecimal(this.Text);
                this.Text = i.ToString("###,###,###,##0.0000").ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show("("+ee.Message +")Invalid Value !");
                this.SelectionStart = 0;
                this.SelectionLength = this.Text.Length; 
                this.Focus();
            }
        }

    }
}
