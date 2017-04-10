using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRichEditTextBoxTest
{
    public class ViewModel : INotifyPropertyChanged
    {
        private string _info;

        public string Info
        {
            get { return _info; }
            set
            {
                _info = value;

                RaisePropertyChanged("Info");
            }
        }

        public ViewModel()
        {
            _info = "test binding";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}