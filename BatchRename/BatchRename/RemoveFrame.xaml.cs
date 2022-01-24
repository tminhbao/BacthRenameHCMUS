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
    /// Interaction logic for RemoveFrame.xaml
    /// </summary>
    public partial class RemoveFrame : Page
    {
        public delegate void RemoveDelegate(string startIndex, string count);
        public event RemoveDelegate RemoveChanged;

        public RemoveFrame()
        {
            InitializeComponent();
        }

        private void StartIndex_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextChanged();
        }

        private void Count_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextChanged();
        }

        private void TextChanged()
        {
            RemoveChanged?.Invoke(StartIndex.Text, Count.Text);

        }
    }
}
