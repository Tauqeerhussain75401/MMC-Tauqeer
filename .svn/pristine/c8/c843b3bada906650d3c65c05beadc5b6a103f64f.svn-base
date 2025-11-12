using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace ERP
{
    public partial class MyMessageBox : Form
    {
        public static int pbtn;
        public static bool colo=false;
        public int tmr = 1;
        static MyMessageBox newMessageBox;
        public Timer msgTimer;
        static string Button_id;
        static string text;
        public int Closetmr = 1;


        public MyMessageBox()
        {
            InitializeComponent();
            MyInitialize();
        }
        private void MyInitialize()
        {
           btnOk.PageStartColor = Variable.ButtonStartColor;
           btnOk.PageEndColor = Variable.ButtonEndColor;
           btnCancel.PageStartColor = Variable.ButtonStartColor;
           btnCancel.PageEndColor = Variable.ButtonEndColor;
           btnSave.PageEndColor = Variable.ButtonEndColor;
           btnSave.PageStartColor = Variable.ButtonStartColor;
            btnNo.PageStartColor = Variable.ButtonStartColor;
            btnNo.PageEndColor = Variable.ButtonEndColor;
            text = "";
        }
        private void MyMessageBox_Load(object sender, EventArgs e)
        {

            if (colo == true)
            {
                timer1.Enabled = true;
                timer1.Interval = 100;
            }
            if (pbtn == 2)
            {
               
                btnOk.Visible = false;
                btnCancel.Visible = false;
                btnSave.Visible = true;
                btnNo.Visible = true;
            }
            if (pbtn == 3)
            {

                btnOk.Visible = false;
                btnSave.Visible = true;
                btnNo.Visible = true;
                btnCancel.Visible = true;
            }
            if (pbtn == 1)
            {
                btnOk.Visible = true;
                btnSave.Visible = false;
                btnNo.Visible = false;
                btnCancel.Visible = false;
                //timer2.Enabled = true;
                //timer2.Interval = 1000;
                if (lblMessage.Text =="Remarks")
                grpCancellationRemarks.Visible = true;
            }
            if (pbtn == 4)
            {
                btnOk.Visible = true;
                btnSave.Visible = false;
                btnNo.Visible = false;
                btnCancel.Visible = false;
            }
            if (pbtn == 5)
            {
                lblTime.Visible = true; 
                btnOk.Visible = true;
                btnSave.Visible = false;
                btnNo.Visible = false;
                btnCancel.Visible = false;
                timer2.Enabled = true;
                timer2.Interval = 1000;
                if (lblMessage.Text == "Remarks")
                    grpCancellationRemarks.Visible = true;
            }

        }
        public static string ShowBox(string txtMessage)
        {
            pbtn = 2;
            newMessageBox = new MyMessageBox();
            newMessageBox.lblMessage.Text = txtMessage;
            newMessageBox.ShowDialog();
            return Button_id;
        }

        public static string ShowBox(string txtMessage, string txtTitle)
        {
            pbtn = 2;
            newMessageBox = new MyMessageBox();
            newMessageBox.lblTitle.Text = txtTitle;
            newMessageBox.lblMessage.Text = txtMessage;
            newMessageBox.ShowDialog();
            return Button_id;
        }
        public static string ShowBox(string txtMessage, string txtTitle, int btn)
        {
            colo = false;
            pbtn = btn;
            newMessageBox = new MyMessageBox();
            newMessageBox.lblTitle.Text = txtTitle;
            newMessageBox.lblMessage.Text = txtMessage;
            newMessageBox.ShowDialog();
            return Button_id;
        }
        public static string ShowBox(string txtMessage, string txtTitle, int btn,bool col)
        {

            pbtn = btn;
            colo = col;
            newMessageBox = new MyMessageBox();
            newMessageBox.lblTitle.Text = txtTitle;
            newMessageBox.lblMessage.Text = txtMessage;
            newMessageBox.ShowDialog();
            col = false;
            if (pbtn == 3)
            {
                return text;
            }
            else
            {
                return Button_id;
            }
        }


        //private void MyMessageBox_Paint(object sender, PaintEventArgs e)
        //{
        //    Graphics mGraphics = e.Graphics;
        //    Pen pen1 = new Pen(Color.FromArgb(96, 155, 173), 1);

        //    Rectangle Area1 = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
        //    LinearGradientBrush LGB = new LinearGradientBrush(Area1, Color.FromArgb(96, 155, 173), Color.FromArgb(245, 251, 251), LinearGradientMode.Vertical);
        //    mGraphics.FillRectangle(LGB, Area1);
        //    mGraphics.DrawRectangle(pen1, Area1);

        //}

        private void txtcheck_TextChanged(object sender, EventArgs e)
        {
            //text = txtcheck.Text; 
        }







        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tmr == 1)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                tmr = 2;
            }
            else if (tmr == 2)
            {
                lblMessage.ForeColor = System.Drawing.Color.Blue;
                tmr = 3;
            }
            else if (tmr == 3)
            {
                lblMessage.ForeColor = System.Drawing.Color.Magenta;
                tmr = 1;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Closetmr += 1;
            lblTime.Text = "0" + Closetmr.ToString();
            if (Closetmr == 10) this.Close();
        }

        private void btnFok_Click(object sender, EventArgs e)
        {
            //Button_id = "4";
            Button_id = txtFCCancellationRemarks.Text; 
            newMessageBox.Dispose(); 
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            Button_id = "1";
            newMessageBox.Dispose(); 
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Button_id = "2";
            newMessageBox.Dispose(); 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Button_id = "3";
            newMessageBox.Dispose(); 
        }

        private void btnSave_MouseMove(object sender, MouseEventArgs e)
        {
            btnSave.PageStartColor = Variable.ButtonMStartColor;
            btnSave.PageEndColor = Variable.ButtonMEndColor;

        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.PageStartColor = Variable.ButtonStartColor;
            btnSave.PageEndColor = Variable.ButtonEndColor;

        }

        private void btnNo_MouseLeave(object sender, EventArgs e)
        {
            btnNo.PageStartColor = Variable.ButtonStartColor;
            btnNo.PageEndColor = Variable.ButtonEndColor;
        }

        private void btnNo_MouseMove(object sender, MouseEventArgs e)
        {
            btnNo.PageStartColor = Variable.ButtonMStartColor;
            btnNo.PageEndColor = Variable.ButtonMEndColor;

        }

        private void btnCancel_MouseMove(object sender, MouseEventArgs e)
        {
            btnCancel.PageStartColor = Variable.ButtonMStartColor;
            btnCancel.PageEndColor = Variable.ButtonMEndColor;

        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.PageStartColor = Variable.ButtonStartColor;
            btnCancel.PageEndColor = Variable.ButtonEndColor;
        }

        private void btnOk_MouseMove(object sender, MouseEventArgs e)
        {
            btnOk.PageStartColor = Variable.ButtonMStartColor;
            btnOk.PageEndColor = Variable.ButtonMEndColor;
        }

        private void btnOk_MouseLeave(object sender, EventArgs e)
        {
            btnOk.PageStartColor = Variable.ButtonStartColor;
            btnOk.PageEndColor = Variable.ButtonEndColor;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }





    }
}
