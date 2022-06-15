using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.MAUI
{
    internal class RPNViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _input;
        public string Input {
            get => _input;
            set {
                if (_input != value)
                {
                    _input = value;
                    PropertyChanged?.Invoke(this, new(nameof(Input)));
                }
            }
        }

        private string _error;
        public string Error
        {
            get => _error;
            set
            {
                if(_error != value)
                {
                    _error = value;
                    PropertyChanged?.Invoke(this, new(nameof(Error)));
                    PropertyChanged?.Invoke(this, new(nameof(HasError)));
                }
            }
        }

        public bool HasError { get => !string.IsNullOrEmpty(_error); }


    }
}
