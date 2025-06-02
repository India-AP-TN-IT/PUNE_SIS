using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace Ax.DEV.Utility.Library
{
    public static class ImageCollapse
    {
        /// <summary>
        /// ImageCollapse Process 이미지 축소 처리
        /// </summary>
        /// <param name="fileContent"></param>
        /// <param name="localPath"></param>
        /// <returns></returns>
        public static bool Process(byte[] fileContent, string localPath)
        {
            bool result = false;

            try
            {
                Bitmap _bmpSource = new Bitmap(Image.FromStream(new MemoryStream(fileContent)));

                int sourceWidth = _bmpSource.Size.Width;
                int sourceHeight = _bmpSource.Size.Height;
                int targetWidth = sourceWidth;
                int targetHeight = sourceHeight;

                // 가로사진이라면
                if (sourceWidth >= sourceHeight)
                {
                    // 가로가 1024보다 크면 가로를 1024로 고정하고 세로를 축소
                    if (sourceWidth > 1024)
                    {
                        targetWidth = 1024;
                        targetHeight = 1024 * sourceHeight / sourceWidth;
                    }
                }
                else
                {
                    // 세로가 1024보다 크면 세로를 1024로 고정하고 가로를 축소
                    if (sourceHeight > 1024)
                    {
                        targetWidth = 1024 * sourceWidth / sourceHeight;
                        targetHeight = 1024;
                    }
                }

                // 새로운 사이즈로 축소한다.
                Bitmap _bmpTarget = (new Bitmap(_bmpSource, targetWidth, targetHeight));

                //// GDI+를 이용해서 축소된 이미지 생성
                //Bitmap _bmpTarget = new Bitmap(targetWidth, targetHeight); 
                //Graphics g = Graphics.FromImage(_bmpTarget);
                //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                //g.DrawImage(_bmpSource, new Rectangle(0, 0, targetWidth, targetHeight));

                // 이미지 파일 축소후 저장
                _bmpTarget.Save(localPath, System.Drawing.Imaging.ImageFormat.Jpeg);

                result = true;
            }
            catch
            {
                result = false;
            }

            return result;
        }

    }
}
