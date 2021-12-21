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
using System.Windows.Shapes;

namespace BatchRename
{
    /// <summary>
    /// Interaction logic for Replace.xaml
    /// </summary>
    public partial class Replace : Window
    {
        public delegate void ReplaceDelegate(string newOldContent, string newNewContent);
        public event ReplaceDelegate TextBoxChanged = null;
        public Replace()
        {
            InitializeComponent();
        }

        private void OldContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            FireContentChangedEvent();
        }

        private void NewContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            FireContentChangedEvent();
        }

        private void FireContentChangedEvent()
        {

            TextBoxChanged?.Invoke(OldContent.Text, NewContent.Text);
        }

    }
}
