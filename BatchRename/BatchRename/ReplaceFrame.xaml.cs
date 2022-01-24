using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Batch_Rename
{

    public partial class ReplaceFrame : Page
    {
        public delegate void ReplaceDelegate(string newOldContent, string newNewContent);
        public event ReplaceDelegate TextBoxChanged = null;

        public ReplaceFrame()
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