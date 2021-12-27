using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRename
{
    public class FileSelected : INotifyPropertyChanged
    {
        public string Oldname { get; set; }
        public string Filename { get; set; }
        public string Newname { get; set; }
        public string Path { get; set; }
        public string Error { get; set; }
        public bool IsGroovy { get; set; }
        public string Extension { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
