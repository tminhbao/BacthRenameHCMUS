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
    /// Interaction logic for ExtensionFrame.xaml
    /// </summary>
    public partial class ExtensionFrame : Page
    {
        public delegate void ExtensionDelegate(string convert, string to);
        public event ExtensionDelegate DataChanged;
        public ExtensionFrame()
        {
            InitializeComponent();
        }

        private void Convert_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxChanged();
        }

        private void To_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxChanged();
        }

        private void TextBoxChanged()
        {
            DataChanged.Invoke(Convert.Text, To.Text);
        }
    }
}
