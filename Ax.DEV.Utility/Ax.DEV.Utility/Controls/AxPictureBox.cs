using System;
using System.IO;
using C1.Win.C1Input;
using System.Drawing;
using System.Drawing.Imaging;
using Ax.DEV.Utility.Library;
using System.Runtime.InteropServices;
namespace Ax.DEV.Utility.Controls
{
    /// <summary>
    /// C1PictureBox 클래스를 상속받은 이미지 박스입니다.
    /// </summary>
    public class AxPictureBox : C1PictureBox, IAxControl
    {
        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        public static extern IntPtr DeleteObject(IntPtr hDc);

        #region IHEControl 멤버

        /// <summary>
        /// MemoryStream을 이용하여 이미지에 대한 정보를 Byte[]로 반환합니다.
        /// </summary>
        public object GetValue()
        {
            Byte[] byteArray = null;
            if (this.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    this.Image.Save(ms, ImageFormat.Jpeg);

                    byteArray = new Byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(byteArray, 0, Convert.ToInt32(ms.Length));
                }
            }

            return byteArray;
        }


        public void SetValue(object value)
        {
            this.SetValue(value, true);
        }

        /// <summary>
        /// 이미지에 대한 정보를 Byte[]로 받아 MemoryStream을 이용하여 이미지 박스에 표시합니다.
        /// 다만 이미지 사이즈가 1024 보다 클 경우는 비율에 맞게끔 이미지를 자동 축소합니다.
        /// </summary>
        public void SetValue(object value, bool autoSizeDown)
        {
            if (value == null)
            {
                this.Initialize();
                return;
            }

            try
            {
                byte[] byteArray = (byte[])value;

                using (MemoryStream stream = new MemoryStream(byteArray))
                {
                    this.Initialize();
                    this.Image = Image.FromStream(stream);
                }

                //이미지 축소하는 로직이 메모리 많이 잡아먹음.. 
                if (autoSizeDown)
                {
                    // 여기서 부터 이미지 축소술
                    using (Bitmap _bmpSource = new Bitmap(this.Image))
                    {
                        using (Bitmap _bmpTarget = CreateBitmap(_bmpSource))
                        {
                            string tarFileName = Environment.GetEnvironmentVariable("TEMP") + "\\" + DateTime.Now.Ticks.ToString() + ".jpg";

                            _bmpTarget.Save(tarFileName, System.Drawing.Imaging.ImageFormat.Jpeg);

                            this.Initialize();
                            //this.Image = Image.FromHbitmap(_bmpTarget.GetHbitmap());

                            Image img = null;
                            IntPtr hbitmap = _bmpTarget.GetHbitmap();
                            try
                            {
                                img = Image.FromHbitmap(hbitmap);
                                this.Image = img;
                            }
                            finally
                            {
                                DeleteObject(hbitmap);
                            }
                            

                            System.IO.File.Delete(tarFileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Image Fileload Error\r\n" + ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        public void Initialize()
        {
            if (this.Image != null)
                this.Image.Dispose();

            this.Image = null;
        }

        private Bitmap CreateBitmap(Bitmap oriImage)
        {
            int sourceWidth, sourceHeight, targetWidth, targetHeight;
            sourceWidth = oriImage.Size.Width;
            sourceHeight = oriImage.Size.Height;

            targetWidth = sourceWidth;
            targetHeight = sourceHeight;

            if (sourceWidth >= sourceHeight)
            {
                if (sourceWidth > 1024)
                {
                    targetWidth = 1024;
                    targetHeight = 1024 * sourceHeight / sourceWidth;
                }
            }
            else
            {
                if (sourceHeight > 1024)
                {
                    targetWidth = 1024 * sourceWidth / sourceHeight;
                    targetHeight = 1024;
                }
            }

            return (new Bitmap(oriImage, targetWidth, targetHeight));
        }

        #endregion
    }
}
