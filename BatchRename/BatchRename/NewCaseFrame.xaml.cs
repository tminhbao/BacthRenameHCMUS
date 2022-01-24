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
    /// Interaction logic for NewCaseFrame.xaml
    /// </summary>
    public partial class NewCaseFrame : Page
    {
        public delegate void NewCaseDelegate(int number);
        public event NewCaseDelegate RadioButtonChanged;
        public NewCaseFrame()
        {
            InitializeComponent();

        }

        private void ButtonLowerCase_Checked(object sender, RoutedEventArgs e)
        {
            RadioButtonChanged?.Invoke(1);
        }

        private void ButtonUpperCase_Checked(object sender, RoutedEventArgs e)
        {
            RadioButtonChanged?.Invoke(2);
        }

        private void ButtonLowerCaseFirstLetter_Checked(object sender, RoutedEventArgs e)
        {
            RadioButtonChanged?.Invoke(3);
        }

        private void ButtonUpperCaseFirstLetter_Checked(object sender, RoutedEventArgs e)
        {
            RadioButtonChanged?.Invoke(4);
        }

        private void ReturnOldName_Click(object sender, RoutedEventArgs e)
        {
            RadioButtonChanged?.Invoke(0);
        }

        private void ButtonPascalCase_Checked(object sender, RoutedEventArgs e)
        {
            RadioButtonChanged?.Invoke(5);
        }
    }
}
