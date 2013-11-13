using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace UI
{
    class Utilities
    {

        #region Public Static Properties
        public static string DropboxPath = "G:/Dropbox/Camera Uploads/";
        //public static string DropboxPath = "G:/Dropbox/RETINAL SCANNERS (^v^)/Joy/Samples/";
        public static string ReferenceImageFolderPath = "G:/Dropbox/RETINAL SCANNERS (^v^)/Shi Qi/Templates/";

        #endregion

        #region Public Static Functions

        public static void SetImageOnHolder(string filePath, Image imageHolder)
        {
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri(filePath, UriKind.Absolute);
            img.DecodePixelHeight = 400;
            img.DecodePixelWidth = 400;
            img.EndInit();

            imageHolder.Source = img;
        }

        #endregion

    }
}
