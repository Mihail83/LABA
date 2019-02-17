using System;
using System.Drawing.Imaging;
using System.Drawing;
using static System.Threading.Thread;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ImageProcessor
{
    class ImageInfo
    {
        public FileInfo[] ImageFilesInfo=null;

        public string GetWorkDirectory
        {
            get
            {
                if (ImageFilesInfo == null)
                {
                    return "Не задана";
                }
                else
                {
                    return ImageFilesInfo[0].DirectoryName;
                }
            }
        }
       
        public void GetImageInfo()
        {
            FileInfo[] ImageFilesInfoTEMP = null;            
            DirectoryInfo imageDirInfo;

            Console.WriteLine("ВВедите путь к обрабатываемой папке");
            var path = Console.ReadLine();
            //валидация??
            try
            {
                imageDirInfo = new DirectoryInfo(path);

            }
            catch (Exception)
            {
                Console.WriteLine("неправилный путь");
                Sleep(1500);
                return;                 
            }

            if (imageDirInfo.Exists)
            {
                ImageFilesInfoTEMP = imageDirInfo.GetFiles("*.jpg");   //больше форматов
            }
            else
            {
                Console.WriteLine("Такой папки не существует");
                Sleep(1500);
                return;
            }

            if (ImageFilesInfoTEMP.Length==0)
            {
                Console.WriteLine("Фотографии не найдены");
                Sleep(1500);
            }
            else
                ImageFilesInfo = ImageFilesInfoTEMP;

        }

        public static string MetaInfoDateTaken(FileInfo imagefileinfo)   // out  image???
        {
            Image image = new Bitmap(imagefileinfo.FullName);
            PropertyItem imageProperty = null;
            try
            {
                imageProperty = image.GetPropertyItem(0x132);
            }
            catch 
            {              
            }
            if (imageProperty != null)
            {
                string dateTaken = Encoding.UTF8.GetString(imageProperty.Value).Trim().Substring(0, 19).Replace(':', '-').Replace(' ', '-');
                return dateTaken;
            }
            else
                return imagefileinfo.LastWriteTime.ToShortDateString() +"-" + imagefileinfo.LastWriteTime.ToLongTimeString().Replace(':','-');
        }



        //public static string MetaInfoDateTaken2(FileInfo imagefileinfo)
        //{
        //    using (FileStream fs = new FileStream(imagefileinfo.FullName, FileMode.Open, FileAccess.Read))
        //    using (Image myImage = Image.FromStream(fs, false, false))
        //    {
        //        PropertyItem propItem = null;
        //        try
        //        {
        //            propItem = myImage.GetPropertyItem(0x132);
        //        }
        //        catch { }
        //        if (propItem != null)
        //        {
        //            string dateTaken = r.Replace(Encoding.UTF8.GetString(propItem.Value), "-", 2);
        //            return dateTaken;
        //        }
        //        else
        //            return imagefileinfo.LastWriteTime.ToLongDateString();
        //    }
        //}


    }
}
