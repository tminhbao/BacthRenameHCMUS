using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BatchRename
{
    public class Method : INotifyPropertyChanged
    {
        public Page PageMethod { get; set; }
        public string NameMethod { get; set; }
        public bool IsCheckMethod { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
