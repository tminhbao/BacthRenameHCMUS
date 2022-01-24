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

namespace BatchRename
{
    /// <summary>
    /// Interaction logic for NewNameFrame.xaml
    /// </summary>
    public partial class NewNameFrame : Page
    {
        public delegate void NewNameDelegate(int number);
        public event NewNameDelegate textBlockMouseDown = null;
        public NewNameFrame()
        {
            InitializeComponent();
        }

        private void GuidName_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textBlockMouseDown?.Invoke(1);
        }

        private void IncNum_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textBlockMouseDown?.Invoke(2);
        }

        private void IncLetter_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textBlockMouseDown?.Invoke(3);
        }

        private void Normalize_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textBlockMouseDown?.Invoke(4);
        }
        private void ReturnOldName_Click(object sender, RoutedEventArgs e)
        {
            textBlockMouseDown?.Invoke(0);
        }
    }
}
