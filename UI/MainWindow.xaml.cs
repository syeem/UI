using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestInterfaceLib;
using System.IO;
using MahApps.Metro.Controls;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        string path = Utilities.DropboxPath;

        List<string> fileNames = new List<string>();
        int currentFileIndex = 0;

        TestInterfaceLib.NewInterface iface = null;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
                       
            DirectoryInfo d = new DirectoryInfo(path);

            foreach (FileInfo fileInfo in d.GetFiles("*.jpg"))
                fileNames.Add(fileInfo.Name);

            if (fileNames.Count != 0)
                Utilities.SetImageOnHolder(path + fileNames[currentFileIndex], ImageHolder);

            iface = new NewInterface();
            iface.InputPath = path + fileNames[currentFileIndex];
            MyLabel.Content = iface.InputPath;
        }


        #region Private ButtonHandlers

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

        private void ReferenceButton_Click(object sender, RoutedEventArgs e)
        {
            Window w = new ReferenceImageWindow();
            w.Show();
        }

        private void SharpenButton_Click(object sender, RoutedEventArgs e)
        {
            iface = new NewInterface();
            iface.InputPath = path + fileNames[currentFileIndex];
            iface.Sharpen();
            string outputPath = iface.OutputPath;

            Utilities.SetImageOnHolder(outputPath, ImageHolder);
        }

        private void BrightenButton_Click(object sender, RoutedEventArgs e)
        {
            iface = new NewInterface();
            iface.InputPath = path + fileNames[currentFileIndex];
            iface.Brighten();
            string outputPath = iface.OutputPath;

            Utilities.SetImageOnHolder(outputPath, ImageHolder);
        }

        private void ErodeButton_Click(object sender, RoutedEventArgs e)
        {
            iface = new NewInterface();
            iface.InputPath = path + fileNames[currentFileIndex];
            iface.Erode();
            string outputPath = iface.OutputPath;

            Utilities.SetImageOnHolder(outputPath, ImageHolder);
        }

        #endregion

    }
}
