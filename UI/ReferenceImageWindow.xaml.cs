using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Interaction logic for ReferenceImageWindow.xaml
    /// </summary>
    public partial class ReferenceImageWindow : MetroWindow
    {
        string path = Utilities.ReferenceImageFolderPath;

        List<string> fileNames = new List<string>();
        int currentFileIndex = 0;

        public ReferenceImageWindow()
        {
            InitializeComponent();
            this.Loaded += ReferenceImageWindow_Loaded;
        }

        void ReferenceImageWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(path);

            foreach (FileInfo fileInfo in d.GetFiles("*.jpg"))
                fileNames.Add(fileInfo.Name);

            if (fileNames.Count != 0)
                Utilities.SetImageOnHolder(path + fileNames[currentFileIndex], ImageHolder);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentFileIndex < fileNames.Count - 1)
                currentFileIndex++;
            else
                currentFileIndex = 0;

            Utilities.SetImageOnHolder(path + fileNames[currentFileIndex], ImageHolder);
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentFileIndex != 0)
                currentFileIndex--;
            else
                currentFileIndex = fileNames.Count - 1;

            Utilities.SetImageOnHolder(path + fileNames[currentFileIndex], ImageHolder);
        }
    }
}
