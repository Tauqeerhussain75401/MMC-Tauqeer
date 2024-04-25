using System;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.Threading;
using System.Drawing.Printing;
using ERP;

namespace ERP
{
    public partial class FrmSupportDocuments : Form
    {
        #region Local Variables
        private int mlistCount;
        private string mdoucmentname;
        private bool mLockItem;
        #endregion
        #region Class Properties
        public int listCount
        {
            get
            {
                return mlistCount;
            }
            set
            {
                mlistCount = value;
            }
        }
        public string doucmentname
        {
            get
            {
                return mdoucmentname;
            }
            set
            {
                mdoucmentname = value;
            }
        }
        public bool LockItem
        {
            get
            {
                return mLockItem;
            }
            set
            {
                mLockItem = value;
            }
        }
        #endregion
        public FrmSupportDocuments()
        {
            InitializeComponent();
            bindingNavigator1.Renderer = new MyRenderer();
        }
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
            {
                if (e.Item.BackgroundImage == null) base.OnRenderButtonBackground(e);
                else
                {
                    Rectangle bounds = new Rectangle(Point.Empty, e.Item.Size);
                    e.Graphics.DrawImage(e.Item.BackgroundImage, bounds);
                    if (e.Item.Pressed)
                    {
                        // Something...
                    }
                    else if (e.Item.Selected)
                    {
                        // Something...
                    }
                    using (Pen pen = new Pen(Color.Black))
                    {
                        e.Graphics.DrawRectangle(pen, bounds.X, bounds.Y, bounds.Width - 1, bounds.Height - 1);
                    }
                }
            }
        }

        private IContainer components;
        private int lockitems = 0;
        private bool closed = false;
        //Thread Connectiontimer;
        //private void v()
        //{
        //    try
        //    {

        //        DataTable ecyear = new DataTable();
        //        DataTable soft = new DataTable();
        //        while (closed == false )
        //        {
        //            soft = Query.ChkupdateSoftware("");
        //            ecyear = Query.CDCBranches("");
        //            Thread.Sleep(7000);
        //        }
        //    }
        //    catch (Exception ee)
        //    {
        //        string ok = MyMessageBox.ShowBox("Connection Problem Re-login !", Variable.Version, 5);
        //        System.Windows.Forms.Application.Exit();
        //    }

        //}

        private void FrmSupportDocuments_Load(object sender, EventArgs e)
        {
            //Connectiontimer = new Thread(v);
            //Connectiontimer.IsBackground = true;
            //Connectiontimer.Priority = ThreadPriority.Lowest;
            //Connectiontimer.Start();

            listCount = 0;
            PostInitialize();
            RefreshImage();
            scalablePictureBoxImp.Visible = true;
 
            if (LockItem) 
            {
                lockitems = listBox1.Items.Count;
            }
            this.Text = Variable.Version;
            Variable.flags = Animate.AW_ACTIVATE | Animate.AW_CENTER;
            Animate.AnimateWindow(this.Handle, Variable.animationTime, Variable.flags);
        }

        private void PostInitialize()
        {
            if (File.Exists(doucmentname))
            {
                //opened = true;
                if (opened) // the button works if the file is opened. you could go with button.enabled
                {
                    if (intCurrPage == 0) // it stops here if you reached the bottom, the first page of the tiff
                    { intCurrPage = 0; }
                    else
                    {
                        intCurrPage--; // if its not the first page, then go to the previous page
                    }
                }
                Image myImg; // setting the selected tiff
                Image myBmp; // a new occurance of Image for viewing

                myImg = System.Drawing.Image.FromFile(doucmentname);
                int ii = myImg.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page)-1;
                if (!opened) // the button works if the file is opened. you could go with button.enabled
                {
                    for (int i = 0; i <= ii; i++)
                    {
                        myImg.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, i); // going to the selected page
                        myBmp = new Bitmap(myImg);//, pictureBox1.Width, pictureBox1.Height); // setting the new page as an image
                        AddFrameToList(myBmp, -1);
                    }
                }
                myImg.Dispose();
                
            }
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (opened) // the button works if the file is opened. you could go with button.enabled
            {
                intCurrPage = 0;
                RefreshImage();
            }
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (opened) // the button works if the file is opened. you could go with button.enabled
            {
                intCurrPage = Convert.ToInt16(lblNumPages.Text);
                RefreshImage();
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            bool tf=false ;
            if (LockItem)
            {
                if (Convert.ToInt16(bindingNavigatorPositionItem.Text)  <= lockitems) tf = true;
            }
            if (Variable.Privillages == "Admin") tf = false; 
            if (!tf)
            {
                string ok = MyMessageBox.ShowBox("Are you Sure to Delete It ?", Variable.Version, 2);
                if (ok == "1")
                {
                    if (Convert.ToInt16(bindingNavigatorPositionItem.Text) - 1 >= 0)
                    {
                        this.listBox1.Items.RemoveAt(Convert.ToInt16(bindingNavigatorPositionItem.Text) - 1);
                        intCurrPage = 0;
                        if (Convert.ToInt16(bindingNavigatorPositionItem.Text) - 1 == 0)
                        {
                            bindingNavigatorPositionItem.Text = "0";
                            bindingNavigatorCountItem.Text = "of {0}";
                            opened = false;
                            File.Delete(doucmentname);
                            scalablePictureBoxImp.Picture = null;
                        }
                        lblNumPages.Text = (listBox1.Items.Count - 1).ToString();
                        bindingNavigatorPositionItem.Text = Convert.ToString(listBox1.Items.Count.ToString());
                        bindingNavigatorCountItem.Text = "of {" + Convert.ToString(listBox1.Items.Count.ToString()) + "}";
                        TemporySaved();
                        RefreshLastImage(); 
                    }
                }
            }
            else
            {
                string ok = MyMessageBox.ShowBox("Sorry ! you cannot Delete It ?", Variable.Version, 1);
            }
        }


        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (opened) // the button works if the file is opened. you could go with button.enabled
            {
                if (intCurrPage == 0) // it stops here if you reached the bottom, the first page of the tiff
                { intCurrPage = 0; }
                else
                {
                    intCurrPage--; // if its not the first page, then go to the previous page
                    RefreshImage(); // refresh the image on the selected page
                }
            }

        }
        private void TemporySaved()
        {
            bindingNavigatorMoveNextItem.Enabled = false;
            bindingNavigatorMoveLastItem.Enabled = false;
            bindingNavigatorMovePreviousItem.Enabled = false;
            bindingNavigatorMoveFirstItem.Enabled = false; 

            listCount = listBox1.Items.Count;
            
            //////////
            TiffManager TM = new TiffManager();
            string[] fn = new string[listBox1.Items.Count];
            Image[] Il = new Image[listBox1.Items.Count];

            if (listBox1.Items.Count == 1)
            {
                ImageItem ii = (ImageItem)this.listBox1.Items[0];
                Il[0] = ii.Image ;
            }
            else
            {
                for (int i = 0; i < this.listBox1.Items.Count; i++)
                {
                    ImageItem ii = (ImageItem)this.listBox1.Items[i];
                    Il[i] = ii.Image;
                }
            }
            TM.JoinTiffImages(fn, doucmentname, EncoderValue.CompressionLZW ,Il);  

            ////////////

            

            string[] w = bindingNavigatorCountItem.Text.Split('{');
            intCurrPage = Convert.ToInt16(w[1].Substring(0, w[1].Length - 1));
            bindingNavigatorMoveNextItem.Enabled = true;
            bindingNavigatorMoveLastItem.Enabled = true;
            bindingNavigatorMovePreviousItem.Enabled = true;
            bindingNavigatorMoveFirstItem.Enabled = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public class ImageItem
        {
            Bitmap _image;
            public Bitmap Image
            {
                get { return _image; }
            }
            protected ImageItem()
            {
            }
            public ImageItem(Image i)
            {
                this._image = (Bitmap)i;
            }
        }
        bool opened = false; // if an image was opened
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (opened) // the button works if the file is opened. you could go with button.enabled
            {
                if (intCurrPage == Convert.ToInt32(lblNumPages.Text))
                // the "-1" should be there for normalizing the number of pages
                { intCurrPage = Convert.ToInt32(lblNumPages.Text); }
                else
                {
                    if (intCurrPage < Convert.ToInt32(lblNumPages.Text))
                    {
                        intCurrPage++;
                        RefreshImage();
                    }
                }
            }
        }
        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (this.listBox1.Items.Count < 1)
                return;
            ImageItem i = (ImageItem)this.listBox1.Items[e.Index];
            e.Graphics.DrawImage(i.Image, e.Bounds, 0, 0, i.Image.Width, i.Image.Width, GraphicsUnit.Pixel);
        }
        private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            ImageItem item = (ImageItem)this.listBox1.Items[e.Index];
            float r = this.listBox1.ClientSize.Width;
            r /= item.Image.Width;
            e.ItemHeight = (int)(r * item.Image.Height);
            e.ItemWidth = (int)(r * item.Image.Width);
        }
        private int intCurrPage = 0;
        public void RefreshImage()
        {
            if (File.Exists(doucmentname))
            {
                opened = true;
                Image myImg; // setting the selected tiff
                Image myBmp; // a new occurance of Image for viewing

                myImg = System.Drawing.Image.FromFile(doucmentname); // setting the image from a file
                int intPages = myImg.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
                intPages--; // the first page is 0 so we must correct the number of pages to -1
                lblNumPages.Text = Convert.ToString(intPages);
                bindingNavigatorCountItem.Text = "of {" + Convert.ToString(intPages + 1) + "}"; // showing the number of pages
                bindingNavigatorPositionItem.Text = Convert.ToString(intCurrPage + 1);
                myImg.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, intCurrPage);
                myBmp = new Bitmap(myImg);//, scalablePictureBoxImp.Width, scalablePictureBoxImp.Height);
                scalablePictureBoxImp.Picture = myBmp; // showing the page in the pictureBox1
                FileInfo finfo = new FileInfo(doucmentname);
                double fsize= (finfo.Length / 1024f) / 1024f;

                if (fsize > 5)
                {
                  string msg = MyMessageBox.ShowBox("File Size[" + Math.Round(fsize, 2).ToString() + " MB] is Too Large reduce Image Size",Variable.Version,1,true);
                }


                myImg.Dispose();

            }
        }
        public void RefreshLastImage()
        {
            if (File.Exists(doucmentname))
            {
                opened = true;
                Image myImg; // setting the selected tiff
                Image myBmp; // a new occurance of Image for viewing

                myImg = System.Drawing.Image.FromFile(doucmentname); // setting the image from a file
                int intPages = myImg.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
                intPages--; // the first page is 0 so we must correct the number of pages to -1
                lblNumPages.Text = Convert.ToString(intPages);
                bindingNavigatorCountItem.Text = "of {" + Convert.ToString(intPages + 1) + "}"; // showing the number of pages

                myImg.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, listBox1.Items.Count - 1);
                myBmp = new Bitmap(myImg);//, scalablePictureBoxImp.Width, scalablePictureBoxImp.Height);
                scalablePictureBoxImp.Picture = myBmp; // showing the page in the pictureBox1
                myImg.Dispose();
            }
        }
        private void AddFrameToList(Image i, int pos)
        {
            if (pos == -1)
                this.listBox1.Items.Add(new ImageItem(i));
            else
                this.listBox1.Items.Insert(pos, new ImageItem(i));
        }
        private void toolStripScanner_Click(object sender, EventArgs e)
        {
            bindingNavigatorMoveNextItem.Enabled = false;
            bindingNavigatorMoveLastItem.Enabled = false;
            bindingNavigatorMovePreviousItem.Enabled = false;
            bindingNavigatorMoveFirstItem.Enabled = false; 
            
            Scanner imgs = new Scanner();
            Image img=null ;
            if (doucmentname == "CustomerDetail.tiff")
                img = imgs.scan(true);
            else
                img = imgs.scan(false);

            Bitmap toAppend = null;
            if (img != null)
            {
                toAppend = new Bitmap(img);
                if (!opened)
                {
                    this.AddFrameToList(toAppend, -1);
                }
                else
                {
                    this.AddFrameToList(toAppend, Convert.ToInt16(lblNumPages.Text) + 1);
                }
                TemporySaved();
                RefreshImage(); 
            }
            bindingNavigatorMoveNextItem.Enabled = true;
            bindingNavigatorMoveLastItem.Enabled = true;
            bindingNavigatorMovePreviousItem.Enabled = true;
            bindingNavigatorMoveFirstItem.Enabled = true;
        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image files|*.bmp;*.jpg;*.gif;*.tif;*.png";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Bitmap toAppend = (Bitmap)Image.FromFile(dlg.FileName);
                if (!opened)
                {
                    this.AddFrameToList(toAppend, -1);
                }
                else
                {
                    this.AddFrameToList(toAppend, Convert.ToInt16(lblNumPages.Text) + 1);
                }
                TemporySaved();
                RefreshImage();
            }
        }
        private void FrmSupportDocuments_FormClosing(object sender, FormClosingEventArgs e)
        {
            closed = true;
        }
        private void toolStripPrint_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += PrintPage;
            pd.Print();
        }
        private void PrintPage(object o, PrintPageEventArgs e)
        {

            //System.Drawing.Image img ;
            //img.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, listBox1.Items.Count - 1); //scalablePictureBoxImp.BackgroundImage ; //System.Drawing.Image.FromFile("D:\\Foto.jpg");
            Image myImg; // setting the selected tiff

            myImg = System.Drawing.Image.FromFile(doucmentname); // setting the image from a file
            int intPages = myImg.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
            intPages--; // the first page is 0 so we must correct the number of pages to -1
            lblNumPages.Text = Convert.ToString(intPages);
            bindingNavigatorCountItem.Text = "of {" + Convert.ToString(intPages + 1) + "}"; // showing the number of pages

            myImg.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page,Convert.ToInt16(bindingNavigatorPositionItem.Text)-1);

            myImg = Scanner.WaterMarking(myImg);
            Point loc = new Point(100, 100);
            e.Graphics.DrawImage(myImg,  loc);
        }
   }
}
