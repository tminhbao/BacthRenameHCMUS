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
    /// Interaction logic for AddSuffixFrame.xaml
    /// </summary>
    public partial class AddSuffixFrame : Page
    {
        public delegate void AddSuffixDelegate(string Suffix);
        public event AddSuffixDelegate TextBoxChanged = null;
        public AddSuffixFrame()
        {
            InitializeComponent();
        }
        private void AddSuffix_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxChanged?.Invoke(AddSuffix.Text);
        }
    }
}
