using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRename
{
    public class FolderSelected : INotifyPropertyChanged
    {
        public string Oldname { get; set; }
        public string Foldername { get; set; }
        public string NewFoldername { get; set; }
        public string PathFolder { get; set; }
        public string ErrorFolder { get; set; }
        public bool IsGroovyDir { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
