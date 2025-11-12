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
    public partial class CButton : System.Windows.Forms.Button 
    {
        System.Drawing.Color mStartColor;
        System.Drawing.Color mEndColor;
        public CButton()
        {
            InitializeComponent();
            PaintGradient();
            this.MouseLeave += new System.EventHandler(this.Mouse_Leave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Mouse_Move);
            this.TextChanged += new EventHandler(CButton_TextChanged);

        }
        private void CButton_TextChanged(object sender, System.EventArgs e)
        {
            this.PageStartColor = Variable.ButtonStartColor;
            this.PageEndColor = Variable.ButtonEndColor;
        }
        private void Mouse_Leave(object sender, System.EventArgs e)
        {
            this.PageStartColor = Variable.ButtonStartColor;
            this.PageEndColor = Variable.ButtonEndColor;
        }
        private void Mouse_Move(object sender, System.EventArgs e)
        {
            this.PageStartColor = Variable.ButtonMStartColor;
            this.PageEndColor = Variable.ButtonMEndColor;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public System.Drawing.Color PageStartColor
        {
            get
            {
                return mStartColor;
            }
            set
            {
                mStartColor = value;
                PaintGradient();
            }
        }


        public System.Drawing.Color PageEndColor
        {
            get
            {
                return mEndColor;
            }
            set
            {
                mEndColor = value;
                PaintGradient();
            }
        }


        private void PaintGradient()
        {
            System.Drawing.Drawing2D.LinearGradientBrush gradBrush;
            gradBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new Point(0, 0),
            new Point(this.Width, this.Height), PageStartColor, PageEndColor);

            Bitmap bmp = new Bitmap(this.Width, this.Height);

            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(gradBrush, new Rectangle(0, 0, this.Width, this.Height));
            this.BackgroundImage = bmp;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

    }
}
