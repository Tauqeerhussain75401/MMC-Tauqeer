using System;
using System.Collections.Generic;
using System.Text;
using WIA;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace ERP
{
    class Scanner
    {


        static Image _pbox;

        public static Image pbox
        {
            get
            {
                return _pbox;
            }
            set
            {
                _pbox = value;
            }
        }

        static Image[] _imagelist;

        public static Image[] imagelist
        {
            get
            {
                return _imagelist;
            }
            set
            {
                _imagelist=value;
            }
        }

        private static Image ResizeImage(int newSize, Image originalImage)
        {
            if (originalImage.Width <= newSize)
                newSize = originalImage.Width;

            var newHeight = originalImage.Height * newSize / originalImage.Width;

            if (newHeight > newSize)
            {
                // Resize with height instead 
                newSize = originalImage.Width * newSize / originalImage.Height;
                newHeight = newSize;
            }

            return originalImage.GetThumbnailImage(newSize, newHeight, null, IntPtr.Zero);
        } 
        public   Image scan(bool WaterMark)
        {
            Image ReturnImage = null; ;
            try
            {
                const string wiaFormatJPEG = "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}";
                WIA.CommonDialog wiaDiag = new WIA.CommonDialog(); //CommonDialogClass wiaDiag = new CommonDialogClass();
                WIA.ImageFile wiaImage = null;
                wiaImage = wiaDiag.ShowAcquireImage(WiaDeviceType.UnspecifiedDeviceType , WiaImageIntent.ColorIntent , WiaImageBias.MinimizeSize , wiaFormatJPEG,true, true, false);
  
                ///
               
                /////
                WIA.Vector vector = wiaImage.FileData;
               
                Image img = Image.FromStream(new MemoryStream((byte[])vector.get_BinaryData()));
                Image returnimage = img;
                
                if (WaterMark)
                {
                    img.Save("tsvd.jpg");
                    ResizeImage("tsvd.jpg", "ttsvd.jpg", 319, 439, false);
                    returnimage = Image.FromFile("ttsvd.jpg");
                    
                }
                else
                {
                    img.Save("tsvd.jpg");
                    ResizeImage("tsvd.jpg", "svd.jpg", 638, 878, true);
                    returnimage = Image.FromFile("svd.jpg");
                    //returnimage = CompressAndSaveImage(Image.FromFile("ttsvd.jpg"), "svd.jpg", 20);
                    //returnimage = img;
                }
                return returnimage;
                
            }
            catch (Exception ee)
            {
                string result = MyMessageBox.ShowBox("("+ee.Message +")Scanner not Found !", Variable.Version, 1);

                return ReturnImage;
            }
        }
//        private Image CompressAndSaveImage(Image img, string fileName,
//long quality)
//        {
//            EncoderParameters parameters = new EncoderParameters(1);
//            parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
//            img.Save(fileName, GetCodecInfo("image/jpeg"), parameters);
//            return Image.FromFile(fileName);
//        }
//        private static ImageCodecInfo GetCodecInfo(string mimeType)
//        {
//            foreach (ImageCodecInfo encoder in ImageCodecInfo.GetImageEncoders())
//                if (encoder.MimeType == mimeType)
//                    return encoder;
//            throw new ArgumentOutOfRangeException(
//                string.Format("'{0}' not supported", mimeType));
//        }


        public static Image WaterMarking(Image img)
        {

            Bitmap bmp = new Bitmap(img);
            Graphics canvas = Graphics.FromImage(bmp);
            Bitmap bmpNew = new Bitmap(bmp.Width, bmp.Height);
            canvas = Graphics.FromImage(bmpNew);
            canvas.DrawImage(bmp, new Rectangle(0, 0,
bmpNew.Width, bmpNew.Height), 0, 0, bmp.Width, bmp.Height,
GraphicsUnit.Pixel);
            bmp = bmpNew;

            canvas.DrawString("For Habib Qatar Use Only !", new Font("Verdana", 12,
FontStyle.Bold), new SolidBrush(Color.Beige), (bmp.Width / 4),
(bmp.Height / 2));
            bmp.Save("svd.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            return Image.FromFile("svd.jpg");

        }



        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            return ms.ToArray();
        }
        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        public static byte[] FileToArray(string path)
        {
            string sFilePath = path;

            System.IO.FileStream fs = new System.IO.FileStream(sFilePath,
                System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
            br.Close();
            fs.Close();
            return bytes;
        }
        public static void ArrayToFile(byte[] _ByteArray, string path)
        {
            System.IO.FileStream _FileStream = new System.IO.FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            _FileStream.Write(_ByteArray, 0, _ByteArray.Length);
            _FileStream.Close();
        }
        public void ResizeImage(string OriginalFile, string NewFile, int NewWidth, int MaxHeight, bool OnlyResizeIfWider)
        {
            System.Drawing.Image FullsizeImage = System.Drawing.Image.FromFile(OriginalFile);

            // Prevent using images internal thumbnail
            //FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
            //FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);

            if (OnlyResizeIfWider)
            {
                if (FullsizeImage.Width <= NewWidth)
                {
                    NewWidth = FullsizeImage.Width;
                }
            }

            int NewHeight = FullsizeImage.Height * NewWidth / FullsizeImage.Width;
            if (NewHeight > MaxHeight)
            {
                // Resize with height instead
                NewWidth = FullsizeImage.Width * MaxHeight / FullsizeImage.Height;
                NewHeight = MaxHeight;
            }

            System.Drawing.Image NewImage = FullsizeImage.GetThumbnailImage(NewWidth, NewHeight, null, IntPtr.Zero);
            System.Drawing.Bitmap  NewImage1 = (Bitmap)FullsizeImage.GetThumbnailImage(NewWidth, NewHeight, null, IntPtr.Zero);

            // Clear handle to original file so that we can overwrite it if necessary
            FullsizeImage.Dispose();

                // Save resized picture
                NewImage.Save(NewFile);
                NewImage.Dispose();
                Image.FromFile(NewFile).Dispose();
            
        }
    }
}
