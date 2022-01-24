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
    /// Interaction logic for AddPrefixFrame.xaml
    /// </summary>
    public partial class AddPrefixFrame : Page
    {
        public delegate void AddPrefixDelegate(string Prefix);
        public event AddPrefixDelegate TextBoxChanged = null;
        public AddPrefixFrame()
        {
            InitializeComponent();
        }

        private void AddPrefix_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxChanged?.Invoke(AddPrefix.Text);
        }
    }
}
