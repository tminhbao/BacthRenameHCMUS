using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
            ReadPreset();
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
        // Chọn folder
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

        //Hàm đọc các tập phương thức ra combobox
        private void ReadPreset()
        {
            //string relativePath = "..\\..\\..\\Batch Methods\\";
            string relativePath = $"{ AppDomain.CurrentDomain.BaseDirectory}\\";

            string path = Path.GetFullPath(relativePath);
            string[] files = Directory.GetFiles(path, "*.txt");
            foreach (string file in files)
            {
                ComboboxPreset.Items.Add(Path.GetFileNameWithoutExtension(file));
            }
        }

        // Nút refresh
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveItemCombobox();
            ReadPreset();
        }
        private void RemoveItemCombobox()
        {
            while (ComboboxPreset.Items.Count > 0)
            {
                ComboboxPreset.Items.RemoveAt(0);
            }
        }
        private void ComboboxPreset_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //xóa danh sách phương thức
            while (ListViewMethod.Items.Count > 0)
            {
                ListViewMethod.Items.RemoveAt(0);
            }

            //đọc tập phương thức mới
            string name = ComboboxPreset.SelectedItem as string;
            if (name != null)
            {
                string relativePath = "..\\..\\..\\Batch Methods\\" + name + ".txt";
                string path = Path.GetFullPath(relativePath);
                ReadFile(path);
            }
        }
        private void SavePresets()
        {

            //string relativePath = "..\\..\\..\\Batch Methods\\"; //lưu tệp vào thư mục Batch Methods
            string relativePath = $"{ AppDomain.CurrentDomain.BaseDirectory}preset\\";
            string path = Path.GetFullPath(relativePath);

            var saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.InitialDirectory = path;
            saveFileDialog.Filter = "Preset (*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == true)
            {

                FileStream file = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write);
                using (StreamWriter streamWriter = new StreamWriter(file))
                {
                    try
                    {
                        foreach (Method method in ListViewMethod.Items)
                        {
                            //ghi phương thức vào tệp
                            streamWriter.WriteLine(string.Format("{0}, {1}", method.NameMethod, method.IsCheckMethod));
                        }
                        streamWriter.Close();
                    }
                    catch (Exception msg)
                    {
                        System.Windows.MessageBox.Show("" + msg);
                    }
                    finally
                    {
                        file.Close();
                    }
                }
            }
        }

        //Hàm đọc các phương thức ra từ một tệp đã lưu trong thư mục Batch Methods
        private void ReadFile(string namefile)
        {
            FileStream file = new FileStream(namefile, FileMode.Open, FileAccess.Read);
            if (file.CanRead)
            {
                try
                {
                    using (StreamReader streamReader = new StreamReader(file))
                    {
                        string Line;
                        string[] Token;
                        while (!streamReader.EndOfStream)
                        {

                            Line = streamReader.ReadLine();
                            Token = Line.Split(',');
                            Method method = new Method();

                            switch (Token[0])
                            {
                                case "New name":
                                    method.NameMethod = "New name";
                                    var page = new NewNameFrame();
                                    page.textBlockMouseDown += NewNameOperation;
                                    method.PageMethod = page;
                                    break;

                                case "New case":
                                    method.NameMethod = "New case";
                                    var page1 = new NewCaseFrame();
                                    page1.RadioButtonChanged += NewCaseOperation;
                                    method.PageMethod = page1;
                                    break;

                                case "Remove":
                                    method.NameMethod = "Remove";
                                    var page3 = new RemoveFrame();
                                    page3.RemoveChanged += RemoveOperation;
                                    method.PageMethod = page3;
                                    break;

                                case "Replace":
                                    method.NameMethod = "Replace";
                                    var page4 = new ReplaceFrame();
                                    page4.TextBoxChanged += ReplaceOperation;
                                    method.PageMethod = page4;
                                    break;
                                case "Extension":
                                    method.NameMethod = "Extension";
                                    var page6 = new ExtensionFrame();
                                    page6.DataChanged += ExtensionOperation;
                                    method.PageMethod = page6;
                                    break;
                                default:
                                    break;
                            }
                            method.IsCheckMethod = Convert.ToBoolean(Token[1]);

                            ListViewMethod.Items.Add(method);

                        }

                        streamReader.Close();
                    }
                }
                catch (Exception exc)
                {
                    System.Windows.MessageBox.Show("" + exc);
                }
                finally
                {
                    file.Close();
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Can't read this file");
            }
        }

        //hàm xử lý chọn các tập phương thức đã lưu của người dùng
        private void OpenPresets()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            path = System.IO.Path.GetDirectoryName(path);
            path = path + @"\Batch Rename\Batch Methods";

            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.InitialDirectory = path;
            openFileDialog.Filter = "Preset (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                ReadFile(openFileDialog.FileName);
            }
        }

        private void AddPresetButton_Click(object sender, RoutedEventArgs e)
        {
            OpenPresets();
        }

        private void SavePresetButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewMethod.Items.Count != -1)
            {
                SavePresets();
            }
        }

        // Xử lí xóa danh sách phương thức
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            while (ListViewMethod.Items.Count > 0)
            {
                ListViewMethod.Items.RemoveAt(0);
            }

            foreach (FileSelected fileSelected in ListFileSelected.Items)
            {
                if (fileSelected.IsGroovy)
                {
                    fileSelected.Newname = fileSelected.Filename;
                }
            }

            foreach (FolderSelected folderSelected in ListFolderSelected.Items)
            {
                if (folderSelected.IsGroovyDir)
                {
                    folderSelected.NewFoldername = folderSelected.Foldername;
                }
            }
        }

        // Xóa 1 method
        private void RemoveMethodButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewMethod.SelectedIndex != -1)
            {
                var index = ListViewMethod.SelectedIndex;
                ListViewMethod.Items.RemoveAt(index);
            }
        }

        //Hàm xóa một phương thức trong danh sách
        private void IconLeftClear_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewMethod.SelectedIndex != -1 && ListViewMethod.Items.Count >= 0)
            {
                var index = ListViewMethod.SelectedIndex;
                ListViewMethod.Items.RemoveAt(index);
            }
        }

        //Hàm xử lý unchecked column checkbox file
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (FileSelected fileSelected in ListFileSelected.Items)
            {
                fileSelected.IsGroovy = false;
            }
        }

        //Hàm xử lý checked column checkbox folder
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (FolderSelected folderSelected in ListFolderSelected.Items)
            {
                folderSelected.IsGroovyDir = true;
            }
        }

        //Hàm thực hiện đổi tên file và folder - sự kiện nhấn vào button Start Batch
        private void StartBatchButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (FileSelected fileSelected in ListFileSelected.Items)
            {
                if (fileSelected.IsGroovy)
                {
                    FileInfo fileInfo = new FileInfo(fileSelected.Path);
                    try
                    {
                        if (fileSelected.Newname + fileSelected.Extension != fileSelected.Filename)
                        {
                            //trường hợp tên trống đặt lại tên cũ
                            if (fileSelected.Newname.Length <= 0)
                                fileSelected.Newname = Path.GetFileNameWithoutExtension(fileSelected.Filename);
                            //trường hợp tên mở rộng trống đặt lại tên mở rộng cũ
                            if (fileSelected.Extension == "." || fileSelected.Extension == "")
                                fileSelected.Extension = Path.GetExtension(fileSelected.Filename);

                            //trường hợp thiếu '.' trong tên mở rộng
                            if (fileSelected.Extension[0] != '.')
                                fileSelected.Extension = "." + fileSelected.Extension;

                            //đổi tên mới 
                            fileInfo.MoveTo(fileInfo.Directory.FullName + "\\" + fileSelected.Newname + fileSelected.Extension);
                            fileSelected.Filename = fileSelected.Newname + fileSelected.Extension;
                            fileSelected.Path = fileInfo.Directory.FullName + "\\" + fileSelected.Newname + fileSelected.Extension;
                            fileSelected.Error = "Success Rename";
                            fileSelected.Oldname = fileSelected.Newname;

                        }


                    }
                    catch (Exception exception)
                    {
                        fileSelected.Error = "Can't rename file :" + fileSelected.Filename + "\n Error: " + exception;
                    }
                }
            }

            foreach (FolderSelected folderSelected in ListFolderSelected.Items)
            {
                if (folderSelected.IsGroovyDir)
                {
                    FileInfo fileInfo = new FileInfo(folderSelected.PathFolder);
                    try
                    {


                        if (folderSelected.NewFoldername != folderSelected.Foldername)
                        {
                            if (folderSelected.NewFoldername.Length <= 0)
                                folderSelected.NewFoldername = folderSelected.Foldername;

                            fileInfo.MoveTo(fileInfo.Directory.FullName + "\\" + folderSelected.NewFoldername);
                            folderSelected.Foldername = folderSelected.NewFoldername;
                            folderSelected.PathFolder = fileInfo.Directory.FullName + "\\" + folderSelected.NewFoldername;
                            folderSelected.ErrorFolder = "Success Rename";
                            folderSelected.Oldname = folderSelected.Foldername;

                        }

                    }
                    catch (Exception exception)
                    {

                        folderSelected.ErrorFolder = "Can't rename folder :" + folderSelected.Foldername + "\n Error: " + exception;

                    }
                }
            }
        }







        //Hàm xử lý phương thức NewCase
        public void NewCaseOperation(int number)
        {
            //xử lý danh sách file
            foreach (FileSelected fileSelected in ListFileSelected.Items)
            {
                if (fileSelected.IsGroovy) // kiểm tra những file được check 
                {
                    fileSelected.Newname = fileSelected.Oldname;
                    string temp = fileSelected.Newname;
                    switch (number)
                    {

                        case 1:
                            fileSelected.Newname = temp.ToLower();
                            break;
                        case 2:
                            fileSelected.Newname = temp.ToUpper();
                            break;
                        case 3:
                            fileSelected.Newname = temp.Substring(0, 1).ToLower() + temp.Substring(1).ToUpper();
                            break;
                        case 4:
                            fileSelected.Newname = temp.Substring(0, 1).ToUpper() + temp.Substring(1).ToLower();
                            break;

                        default:
                            fileSelected.Newname = temp;
                            break;
                    }

                }
            }

            //xử lý danh sách folder
            foreach (FolderSelected folderSelected in ListFolderSelected.Items)
            {
                if (folderSelected.IsGroovyDir)
                {
                    folderSelected.NewFoldername = folderSelected.Oldname;
                    string temp = folderSelected.NewFoldername;
                    switch (number)
                    {
                        case 1:
                            folderSelected.NewFoldername = temp.ToLower();
                            break;
                        case 2:
                            folderSelected.NewFoldername = temp.ToUpper();
                            break;
                        case 3:
                            folderSelected.NewFoldername = temp.Substring(0, 1).ToLower() + temp.Substring(1).ToUpper();
                            break;
                        case 4:
                            folderSelected.NewFoldername = temp.Substring(0, 1).ToUpper() + temp.Substring(1).ToLower();
                            break;
                        default:
                            folderSelected.NewFoldername = temp;
                            break;
                    }
                }
            }
        }

        //Hàm cài đặt sự kiện click button
        private void NewCase_Click(object sender, RoutedEventArgs e)
        {
            NewCaseFrame newCaseFrame = new NewCaseFrame();
            foreach (FileSelected fileSelected in ListFileSelected.Items)
            {
                fileSelected.Oldname = fileSelected.Newname;
            }

            foreach (FolderSelected folderSelected in ListFolderSelected.Items)
            {
                folderSelected.Oldname = folderSelected.NewFoldername;
            }

            newCaseFrame.RadioButtonChanged += NewCaseOperation;

            ListViewMethod.Items.Add(new Method() { PageMethod = newCaseFrame, NameMethod = "New case", IsCheckMethod = true });

        }


        //hàm chuẩn hóa tên 
        public string NormalizeFullName(string origin)
        {
            string result = origin.Trim();
            int i = 0;
            int n = result.Length;
            while (i < n)
            {
                while (result[i] == ' ' && result[i + 1] == ' ')
                {
                    result = result.Remove(i + 1, 1);
                    --n;
                }
                i++;
            }

            result = result.ToLower();

            result = result.Substring(0, 1).ToUpper() + result.Substring(1);

            for (i = 1; i < result.Length; i++)
            {
                if (result[i] == ' ')
                {
                    result = result.Substring(0, i + 1) + result.Substring(i + 1, 1).ToUpper() + result.Substring(i + 2);
                }
            }
            return result;
        }


        //Hàm xử lý phương thức NewName
        public void NewNameOperation(int number)
        {
            foreach (FileSelected fileSelected in ListFileSelected.Items)
            {
                if (fileSelected.IsGroovy)
                {

                    string temp = fileSelected.Newname;
                    switch (number)
                    {
                        case 1://tạo tên duy nhất
                            Guid guid = Guid.NewGuid();
                            fileSelected.Newname = guid.ToString();
                            break;
                        case 2://thêm số phía sau tên
                            int index = ListFileSelected.Items.IndexOf(fileSelected);
                            fileSelected.Newname = temp + Convert.ToString(index + 1);
                            break;
                        case 3://thêm kí tự phía sau tên
                            int index1 = ListFileSelected.Items.IndexOf(fileSelected);
                            fileSelected.Newname = temp + Convert.ToChar(index1 % 24 + 65);
                            break;
                        case 4://chuẩn hóa họ tên

                            fileSelected.Newname = NormalizeFullName(temp);
                            break;
                        default:
                            fileSelected.Newname = fileSelected.Oldname;
                            break;
                    }
                }
            }

            foreach (FolderSelected folderSelected in ListFolderSelected.Items)
            {
                if (folderSelected.IsGroovyDir)
                {
                    string temp = folderSelected.NewFoldername;
                    switch (number)
                    {
                        case 1:
                            Guid guid = Guid.NewGuid();
                            folderSelected.NewFoldername = guid.ToString();
                            break;
                        case 2:
                            int index = ListFolderSelected.Items.IndexOf(folderSelected);
                            folderSelected.NewFoldername = temp + Convert.ToString(index + 1);
                            break;
                        case 3:
                            int index1 = ListFolderSelected.Items.IndexOf(folderSelected);
                            folderSelected.NewFoldername = temp + Convert.ToChar(index1 % 24 + 65);
                            break;
                        case 4:

                            folderSelected.NewFoldername = NormalizeFullName(temp);
                            break;

                        default:
                            folderSelected.NewFoldername = folderSelected.Oldname;
                            break;
                    }

                }
            }

        }

        //Hàm xử lý sự kiện Click vào NewName trong menu AddMethod
        private void NewName_Click(object sender, RoutedEventArgs e)
        {

            NewNameFrame newNameFrame = new NewNameFrame();
            newNameFrame.textBlockMouseDown += NewNameOperation;
            ListViewMethod.Items.Add(new Method() { PageMethod = newNameFrame, NameMethod = "New name", IsCheckMethod = true });

        }     

        //Hàm xử lý phương thức Remove
        public void RemoveOperation(string startIndex, string count)
        {

            int start, end;
            foreach (FileSelected fileSelected in ListFileSelected.Items)
            {
                if (fileSelected.IsGroovy)
                {

                    fileSelected.Newname = fileSelected.Oldname;
                    string temp = fileSelected.Newname;
                    if (startIndex.Length > 0 && count.Length > 0)
                    {
                        bool a = Int32.TryParse(startIndex, out start);
                        bool b = Int32.TryParse(count, out end);
                        if (a & b & start > 0 && start <= temp.Length && end > 0 && start + end <= temp.Length)
                        {

                            fileSelected.Newname = temp.Remove(start - 1, end);
                        }

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
                    if (startIndex.Length > 0 && count.Length > 0)
                    {
                        bool a = Int32.TryParse(startIndex, out start);
                        bool b = Int32.TryParse(count, out end);
                        if (a & b & start > 0 && start <= temp.Length && end > 0 && start + end <= temp.Length)
                        {

                            folderSelected.NewFoldername = temp.Remove(start - 1, end);
                        }

                    }
                    else
                    {
                        folderSelected.NewFoldername = temp;
                    }

                }
            }
        }


        //Hàm xử lý sự kiện click vào Remove trong MenuItem AddMethod       
        private void Remove_Click(object sender, RoutedEventArgs e)
        {

            RemoveFrame removeFrame = new RemoveFrame();
            foreach (FileSelected fileSelected in ListFileSelected.Items)
            {
                fileSelected.Oldname = fileSelected.Newname;
            }

            foreach (FolderSelected folderSelected in ListFolderSelected.Items)
            {
                folderSelected.Oldname = folderSelected.NewFoldername;
            }

            removeFrame.RemoveChanged += RemoveOperation;
            ListViewMethod.Items.Add(new Method() { PageMethod = removeFrame, NameMethod = "Remove", IsCheckMethod = true });

        }


        //Hàm xử lý phương thức đổi tên đuôi mở rộng
        public void ExtensionOperation(string convert, string to)
        {
            foreach (FileSelected fileSelected in ListFileSelected.Items)
            {
                if (fileSelected.IsGroovy)
                {
                    string temp = Path.GetExtension(fileSelected.Filename);
                    if (convert.Length > 0)
                    {
                        fileSelected.Extension = temp.Replace(convert, to);

                    }
                    else
                    {
                        fileSelected.Extension = temp;
                    }

                }
            }

        }

        //Hàm xử lý sự kiện click vào Extension trong AddMethod
        private void Extension_Click(object sender, RoutedEventArgs e)
        {
            ExtensionFrame extensionFrame = new ExtensionFrame();
            extensionFrame.DataChanged += ExtensionOperation;
            ListViewMethod.Items.Add(new Method() { PageMethod = extensionFrame, NameMethod = "Extension", IsCheckMethod = true });

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ListFileSelected.AllowDrop = true;
            
        }


        // Kéo thả file vào trong ứng dụng

        private void ListFileSelected_DragEnter(object sender, System.Windows.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop))
                e.Effects = System.Windows.DragDropEffects.Copy;
        }

        private void ListFileSelected_Drop(object sender, System.Windows.DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(System.Windows.DataFormats.FileDrop);
            foreach (string file in files)
            {
                ListFileSelected.Items.Add(new FileSelected()
                {
                    Filename = Path.GetFileName(file),
                    Newname = Path.GetFileNameWithoutExtension(file),
                    Oldname = Path.GetFileNameWithoutExtension(file),
                    Path = file,
                    Error = " ",
                    IsGroovy = true,
                    Extension = Path.GetExtension(file)
                });
            }
        }

        // Kéo thả folder vào ứng dụng

        private void ListFolderSelected_DragEnter(object sender, System.Windows.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop))
                e.Effects = System.Windows.DragDropEffects.Copy;
        }

        private void ListFolderSelected_Drop(object sender, System.Windows.DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(System.Windows.DataFormats.FileDrop);
            foreach (string file in files)
            {
                ListFileSelected.Items.Add(new FileSelected()
                {
                    Filename = Path.GetFileName(file),
                    Newname = Path.GetFileNameWithoutExtension(file),
                    Oldname = Path.GetFileNameWithoutExtension(file),
                    Path = file,
                    Error = " ",
                    IsGroovy = true,
                    Extension = Path.GetExtension(file)
                });
            }
        }


    }
}
