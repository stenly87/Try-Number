using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WpfApp23.MVVM
{
    public class MvvmNotify : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(
            [CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, 
                new PropertyChangedEventArgs(name));
        }
    }
}
