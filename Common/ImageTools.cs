using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace FwjSoft.Common
{
    public class ImageTools
    {
        /// <summary>
        /// 二进制文件生成图片
        /// </summary>
        /// <param name="strDestFolder">目标文件夹</param>
        /// <param name="byteImage">二进制文件</param>
        /// <param name="strFileName">图片名称</param>
        public static void CreateImage(string strDestFolder,string strFileName, byte[] byteImage)
        {
            if (!Directory.Exists(strDestFolder))
            {
                Directory.CreateDirectory(strDestFolder);
            }
            string cFileFullName = string.Empty;  //文件全名，包含路径
            cFileFullName = string.Format("{0}\\{1}", strDestFolder, strFileName);
            if (File.Exists(cFileFullName))
            {
                File.Delete(cFileFullName);
            }
            System.IO.MemoryStream sImg = new MemoryStream(byteImage);
            Bitmap bt = new Bitmap(sImg);
            bt.Save(cFileFullName, System.Drawing.Imaging.ImageFormat.Jpeg);
            bt.Dispose();
        }
        /// <summary>
        /// 根据图片路径生成二进制文件
        /// </summary>
        /// <param name="strFileName"></param>
        public static byte[] CreateByteByImagePath(string strFileName)
        {
            FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read);//Layout就是你的strimg 
            byte[] xbytes = new byte[file.Length];
            file.Read(xbytes, 0, (int)file.Length);
            file.Close();
            return xbytes;
        }

    }
}
