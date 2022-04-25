using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Calculator
{


    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private string inputText;
        public ICommand NumberOneClickCommand{ get; private set; }
        public string InputText { get => inputText; set => SetProperty(ref inputText, value); }


        public event PropertyChangedEventHandler PropertyChanged;
        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!(object.Equals(field, newValue)))
            {
                field = (newValue);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        public MainViewModel()
        {
            NumberOneClickCommand = new RelayCommand(NumberOneClick);
        }

        private void NumberOneClick()
        {
            InputText += "asd";
        }




    }
}