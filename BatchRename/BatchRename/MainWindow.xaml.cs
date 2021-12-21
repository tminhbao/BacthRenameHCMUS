using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.Win32;
using Path = System.IO.Path;


namespace BatchRename
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Load file lên UI
            List<File> _files = new List<File>();
            _files.Add(new File() { filePath = "path đây nè", oldName = "ABC", newName = "BCD" });
            _files.Add(new File() { filePath = "path đây nè 11", oldName = "ABC  11", newName = "BCD 11" });

        }

        public class File : INotifyPropertyChanged
        {
            public string oldName { get; set; }
            public string filePath { get; set; }
            public string newName { get; set; }
            public string err { get; set; }

            public event PropertyChangedEventHandler PropertyChanged;
        }

        class FileSelected
        {
            public string Filename { get; set; }
            public string Newname { get; set; }
            public string Oldname { get; set; }
            public string Path { get; set; }
            public string Error { get; set; }
            public bool IsGroovy { get; set; }
            public string Extension { get; set; }
        }

        class FolderSelected
        {
            public string Foldername { get; set; }
            public string NewFoldername { get; set; }
            public string Oldname { get; set; }
            public string PathFolder { get; set; }
            public string ErrorFolder { get; set; }
            public bool IsGroovyDir { get; set; }
        }
            


        // Load được file lên UI
        private void AddFileButtons_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "All file (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                //đọc file vào danh sách
                foreach (string filename in openFileDialog.FileNames)
                {
                    ListFileSelected.Items.Add(new FileSelected()
                    {
                        Filename = Path.GetFileName(filename),
                        Newname = Path.GetFileNameWithoutExtension(filename),
                        Oldname = Path.GetFileNameWithoutExtension(filename),
                        Path = filename,
                        Error = " ",
                        IsGroovy = true,
                        Extension = Path.GetExtension(filename)
                    });
                }
            }
        }
        private void AddFolderButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();
            browserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            browserDialog.ShowNewFolderButton = false;
            browserDialog.SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory;
            if (browserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string sPath = browserDialog.SelectedPath;
                DirectoryInfo directoryInfo = new DirectoryInfo(sPath);
                ListFolderSelected.Items.Add(new FolderSelected()
                {
                    Foldername = directoryInfo.Name,
                    NewFoldername = directoryInfo.Name,
                    Oldname = directoryInfo.Name,
                    PathFolder = directoryInfo.FullName,
                    ErrorFolder = " ",
                    IsGroovyDir = true
                });
            }
        }
    }
}
