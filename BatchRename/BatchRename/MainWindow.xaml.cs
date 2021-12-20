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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.Win32;


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

        class Filename : INotifyPropertyChanged
        {
            public int id { get; set; }
            public string oldName { get; set; }
            public string filePath { get; set; }
            public string newName { get; set; }
            public string err { get; set; }
            public event PropertyChangedEventHandler PropertyChanged;
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            FileTab.Items.Refresh();
            FolderTab.Items.Refresh();
        }


        public string Path { get; set; }
        private void AddFileButtons_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if(openFileDialog.ShowDialog()==true)
            {
                Path = openFileDialog.FileName;
                MessageBox.Show(Path);
            }
        }
        
    }
}
