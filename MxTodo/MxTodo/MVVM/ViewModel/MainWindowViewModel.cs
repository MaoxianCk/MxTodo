using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MxTodo
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public DateTime NowTime
        {
            get
            {
                return DateTime.Now;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand UpdateTime => new DelegateCommand(obj =>
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NowTime)));
        });
    }
}
