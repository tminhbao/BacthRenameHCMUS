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
using Batch_Rename;
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
 
        // Chọn nhiều file
        private void AddFileButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "All file (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                //Đọc file vào danh sách
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

        // Chọn tất cả file trong 1 thư mục
        private void AddDirectoryButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();
            browserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            browserDialog.ShowNewFolderButton = false;
            browserDialog.SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory;
            if (browserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string sPath = browserDialog.SelectedPath;
                DirectoryInfo directoryInfo = new DirectoryInfo(sPath);
                if (directoryInfo.Exists)
                {
                    foreach (FileInfo fileInfo in directoryInfo.GetFiles())
                    {
                        ListFileSelected.Items.Add(new FileSelected()
                        {
                            Filename = Path.GetFileName(fileInfo.Name),
                            Newname = Path.GetFileNameWithoutExtension(fileInfo.Name),
                            Oldname = Path.GetFileNameWithoutExtension(fileInfo.Name),
                            Path = fileInfo.FullName,
                            Error = " ",
                            IsGroovy = true,
                            Extension = Path.GetExtension(fileInfo.Name)
                        });
                    }
                }
            }
        }
        // Chọn được folder
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
        private void AddSubFolderButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();
            browserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            browserDialog.ShowNewFolderButton = false;
            browserDialog.SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory;
            if (browserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string sPath = browserDialog.SelectedPath;
                DirectoryInfo directoryInfo = new DirectoryInfo(sPath);
                if (directoryInfo.Exists)
                {
                    foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
                    {
                        ListFolderSelected.Items.Add(new FolderSelected()
                        {
                            Foldername = directory.Name,
                            NewFoldername = directory.Name,
                            Oldname = directoryInfo.Name,
                            PathFolder = directory.FullName,
                            ErrorFolder = " ",
                            IsGroovyDir = true
                        });
                    }
                }
            }
        }
        // Button di chuyển file
        List<FileSelected> _listFileSelected = new List<FileSelected>();
        private void MoveFirstFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListFileSelected.SelectedIndex > 0)
            {
                var item = (FileSelected)ListFileSelected.SelectedItem;
                var index = ListFileSelected.SelectedIndex;
                ListFileSelected.Items.RemoveAt(index);
                ListFileSelected.Items.Insert(0, item);
                ListFileSelected.SelectedItem = ListFileSelected.Items[0];
            }
        }
        private void MoveUpFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListFileSelected.SelectedIndex > 0)
            {
                var item = (FileSelected)ListFileSelected.SelectedItem;
                var index = ListFileSelected.SelectedIndex;
                ListFileSelected.Items.RemoveAt(index);
                ListFileSelected.Items.Insert(index - 1, item);
                ListFileSelected.SelectedItem = ListFileSelected.Items[index - 1];
            }
        }
        private void MoveDownFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListFileSelected.SelectedIndex >= 0 && ListFileSelected.SelectedIndex < ListFileSelected.Items.Count - 1)
            {
                var item = (FileSelected)ListFileSelected.SelectedItem;
                var index = ListFileSelected.SelectedIndex;
                ListFileSelected.Items.RemoveAt(index);
                ListFileSelected.Items.Insert(index + 1, item);
                ListFileSelected.SelectedItem = ListFileSelected.Items[index + 1];
            }
        }
        private void MoveBottomFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListFileSelected.SelectedIndex >= 0 && ListFileSelected.SelectedIndex < ListFileSelected.Items.Count)
            { 
                var item = (FileSelected)ListFileSelected.SelectedItem;
                var index = ListFileSelected.SelectedIndex;
                ListFileSelected.Items.RemoveAt(index);
                ListFileSelected.Items.Insert(ListFileSelected.Items.Count, item);
                ListFileSelected.SelectedItem = ListFileSelected.Items[ListFileSelected.Items.Count - 1];
            }
        }
        // Button di chuyển folder
        private void MoveFirstFolderButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListFolderSelected.SelectedIndex > 0)
            {
                var item = (FolderSelected)ListFolderSelected.SelectedItem;
                var index = ListFolderSelected.SelectedIndex;
                ListFolderSelected.Items.RemoveAt(index);
                ListFolderSelected.Items.Insert(0, item);
                ListFolderSelected.SelectedItem = ListFolderSelected.Items[0];
            }
        }
        private void MoveUpFolderButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListFolderSelected.SelectedIndex > 0)
            {
                var item = (FolderSelected)ListFolderSelected.SelectedItem;
                var index = ListFolderSelected.SelectedIndex;
                ListFolderSelected.Items.RemoveAt(index);
                ListFolderSelected.Items.Insert(index - 1, item);
                ListFolderSelected.SelectedItem = ListFolderSelected.Items[index - 1];
            }
        }
        private void MoveDownFolderButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListFolderSelected.SelectedIndex >= 0 && ListFolderSelected.SelectedIndex < ListFolderSelected.Items.Count - 1)
            {
                var item = (FolderSelected)ListFolderSelected.SelectedItem;
                var index = ListFolderSelected.SelectedIndex;
                ListFolderSelected.Items.RemoveAt(index);
                ListFolderSelected.Items.Insert(index + 1, item);
                ListFolderSelected.SelectedItem = ListFolderSelected.Items[index + 1];
            }
        }
        private void MoveBottomFolderButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListFolderSelected.SelectedIndex >= 0 && ListFolderSelected.SelectedIndex < ListFolderSelected.Items.Count)
            {
                var item = (FolderSelected)ListFolderSelected.SelectedItem;
                var index = ListFolderSelected.SelectedIndex;
                ListFolderSelected.Items.RemoveAt(index);
                ListFolderSelected.Items.Insert(ListFolderSelected.Items.Count, item);
                ListFolderSelected.SelectedItem = ListFolderSelected.Items[ListFolderSelected.Items.Count - 1];
            }
        }
        // Button di chuyển method
        private void MoveFirstMethodButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewMethod.SelectedIndex > 0)
            {
                var item = ListViewMethod.SelectedItem as Method;
                var index = ListViewMethod.SelectedIndex;
                ListViewMethod.Items.RemoveAt(index);
                ListViewMethod.Items.Insert(0, item);
                ListViewMethod.SelectedItem = ListViewMethod.Items[0];
            }
        }
        private void MoveUpMethodButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewMethod.SelectedIndex > 0)
            {
                var item = ListViewMethod.SelectedItem as Method;
                var index = ListViewMethod.SelectedIndex;
                ListViewMethod.Items.RemoveAt(index);
                ListViewMethod.Items.Insert(index - 1, item);
                ListViewMethod.SelectedItem = ListViewMethod.Items[index - 1];
            }
        }
        private void MoveDownMethodButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewMethod.SelectedIndex >= 0 && ListViewMethod.SelectedIndex < ListViewMethod.Items.Count - 1)
            {
                var item = ListViewMethod.SelectedItem as Method;
                var index = ListViewMethod.SelectedIndex;
                ListViewMethod.Items.RemoveAt(index);
                ListViewMethod.Items.Insert(index + 1, item);
                ListViewMethod.SelectedItem = ListViewMethod.Items[index + 1];
            }
        }
        private void MoveBottomMethodButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewMethod.SelectedIndex >= 0 && ListViewMethod.SelectedIndex < ListViewMethod.Items.Count)
            {
                var item = ListViewMethod.SelectedItem as Method;
                var index = ListViewMethod.SelectedIndex;
                ListViewMethod.Items.RemoveAt(index);
                ListViewMethod.Items.Insert(ListViewMethod.Items.Count, item);
                ListViewMethod.SelectedItem = ListViewMethod.Items[ListViewMethod.Items.Count - 1];
            }
        }

        //Hàm xử lý phương thức Replace
        public void ReplaceOperation(string from, string to)
        {
            foreach (FileSelected fileSelected in ListFileSelected.Items)
            {
                if (fileSelected.IsGroovy)
                {

                    fileSelected.Newname = fileSelected.Oldname;
                    string temp = fileSelected.Newname;
                    if (from.Length > 0)
                    {

                        fileSelected.Newname = temp.Replace(from, to);

                    }
                    else
                    {
                        fileSelected.Newname = temp;
                    }

                }
            }

            foreach (FolderSelected folderSelected in ListFolderSelected.Items)
            {
                if (folderSelected.IsGroovyDir)
                {

                    folderSelected.NewFoldername = folderSelected.Oldname;
                    string temp = folderSelected.NewFoldername;
                    if (from.Length > 0)
                    {

                        folderSelected.NewFoldername = temp.Replace(from, to);
                    }
                    else
                    {
                        folderSelected.NewFoldername = temp;
                    }

                }
            }
        }

        //Hàm xử lý sự kiện khi nhấn vào Replace trong AddMethod
        private void Replace_Click(object sender, RoutedEventArgs e)
        {
            ReplaceFrame replaceFrame = new ReplaceFrame();
            foreach (FileSelected fileSelected in ListFileSelected.Items)
            {
                fileSelected.Oldname = fileSelected.Newname;
            }

            foreach (FolderSelected folderSelected in ListFolderSelected.Items)
            {
                folderSelected.Oldname = folderSelected.NewFoldername;
            }

            replaceFrame.TextBoxChanged += ReplaceOperation;
            ListViewMethod.Items.Add(new Method() { PageMethod = replaceFrame, NameMethod = "Replace", IsCheckMethod = true });

        }

        
    }
}
