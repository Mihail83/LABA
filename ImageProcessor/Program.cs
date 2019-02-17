using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            ControlImageProcessor();
            //var imageInfo1 = new ImageInfo();
            //var renameImage1 = new RenameAndReplaceImage(imageInfo1.GetImageInfo());


            //renameImage1.ChangeNameByYear();
        }

        public static void ControlImageProcessor()
        {
            var imageInfo1 = new ImageInfo();
            //string workDirectory = imageInfo1.GetWorkDirectory;
            while (true)
            {
                Console.Clear();
                //status bar
                Console.WriteLine("Рабочая папка: " + imageInfo1.GetWorkDirectory);
                Console.WriteLine("выбор папки -  S, выход - E \n переименовать по дате съемки - 1, добавить пометку с датой на фото -2, ");

                switch (Console.ReadKey().KeyChar)
                {
                    case 's':
                    case 'S':                       
                        imageInfo1.GetImageInfo();

                        break;
                    case 'e':
                    case 'E':
                        return;                        
                    case '1':
                        var renameImage1 = new RenameAndReplaceImage(imageInfo1.ImageFilesInfo);
                        renameImage1.ChangeNameByYear();


                        break;
                    case '2':
                        var addDateToImage = new ImageWithData(imageInfo1.ImageFilesInfo);
                        addDateToImage.AddDateToImage();
                        break;
                    default:
                        Console.WriteLine("Не то");
                        break;
                }


            }
            //Console.WriteLine("ВВедите путь к папке с изображениями Jpeg");
            //var path = Console.ReadLine();
            //var imageInfo1 = new ImageInfo();
            //imageInfo1.GetImageInfo();



        }
    }
}
