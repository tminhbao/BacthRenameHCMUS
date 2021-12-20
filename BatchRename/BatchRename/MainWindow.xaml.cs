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

    


        List<Path> _paths = new List<Path>();
        class Path
        {
            public string Name { get; set; }
        }

        private void AddFileButtons_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == true)
            {
                _paths.Add(new Path() { Name = openFileDialog.FileName });
            }
        }

    }
}
