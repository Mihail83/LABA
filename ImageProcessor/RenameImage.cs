using System;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ImageProcessor
{
    class RenameAndReplaceImage
    {
        FileInfo[] _imageInfo;
        public RenameAndReplaceImage(FileInfo[] imageinfo)
        {
            _imageInfo = imageinfo;
        }
       // Image
       // PropertyItem

        public void ChangeNameByYear()
        {
            var parentDirectoreName = _imageInfo[0].Directory.FullName;
            
            Directory.CreateDirectory(parentDirectoreName + "ChangeNameByYear");

            for (int i = 0; i < _imageInfo.Length; i++)
            {
                var newImageName = ImageInfo.MetaInfoDateTaken(_imageInfo[i]);
                _imageInfo[i].CopyWithoutRewrite(parentDirectoreName + "ChangeNameByYear\\ " + newImageName + _imageInfo[i].Extension);   //  _imageInfo[i].CreationTime.ToShortDateString;


            }
        }

        
        

    }
}
