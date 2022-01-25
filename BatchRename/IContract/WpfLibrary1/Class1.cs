using System;
using System.ComponentModel;
using System.Windows.Controls;

namespace WpfLibrary1
{
    public interface Method: INotifyPropertyChanged
    {
        public Page PageMethod { get; set; }
        public string NameMethod { get; set; }
        public bool IsCheckMethod { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
