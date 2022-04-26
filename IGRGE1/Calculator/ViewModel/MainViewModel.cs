using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Calculator
{


    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private string totalText = "";

        private string subTotalText = "123312";
        public string TotalText { get => totalText; set => SetProperty(ref totalText, value); }
        public string SubTotalText { get => subTotalText; set => SetProperty(ref subTotalText, value); }
        public ICommand NotZeroNumber_Command { get; private set; }
        public ICommand ZeroNumber_Command { get; private set; }
        public ICommand ClearTextBox_Command { get; private set; }
        public ICommand PowerTwo_Command { get; private set; }

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
            NotZeroNumber_Command = new RelayCommand<string>(NotZeroNumber_Click);
            ZeroNumber_Command = new RelayCommand(ZeroNumber_Click);
            ClearTextBox_Command = new RelayCommand(ClearTextBox);
            PowerTwo_Command = new RelayCommand(PowerTwo);
        }

        private void PowerTwo()
        {
            string temp = TotalText;
            if (TotalText.Length < 14)
            {
                SubTotalText = temp + "*" + temp;
                double mantissa = Math.Abs(Convert.ToDouble(TotalText));
                mantissa *= mantissa;
                TotalText = mantissa.ToString();
            }
        }

        private void ClearTextBox()
        {
            TotalText = "";
        }

        private void ZeroNumber_Click()
        {
            if (TotalText.Equals(""))
            {
                TotalText = "0";
            }
            if (TotalText.Length != 0 && TotalText != "0" && TotalText.Length < 7)
            {
                TotalText += "0";
            }
        }

        private void NotZeroNumber_Click(string obj)
        {
            if (TotalText == "0")
            {
                TotalText = "";
                TotalText += obj;
                return;
            }

            if (TotalText.Length < 7)
            {
                TotalText += obj;
            }

        }


    }
}