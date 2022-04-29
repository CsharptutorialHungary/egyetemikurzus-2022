using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator
{


    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private string totalText = "";
        private string subTotalText = "";
        double resultHelper = 0;
        public string TotalText { get => totalText; set => SetProperty(ref totalText, value); }
        public string SubTotalText { get => subTotalText; set => SetProperty(ref subTotalText, value); }
        public ICommand NotZeroNumber_Command { get; private set; }
        public ICommand ZeroNumber_Command { get; private set; }
        public ICommand ClearTextBox_Command { get; private set; }
        public ICommand PowerTwo_Command { get; private set; }
        public ICommand CommaSeparator_Command { get; private set; }
        public ICommand WriteToMemoryAdd_Command { get; private set; }
        public ICommand Addition_Command { get; private set; }
        public ICommand ClearMemory_Command { get; private set; }
        public ICommand Substraction_Command { get; private set; }

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
            ZeroNumber_Command = new RelayCommand(ZeroNumber_Click);
            NotZeroNumber_Command = new RelayCommand<string>(NotZeroNumber_Click);
            ClearTextBox_Command = new RelayCommand(ClearTextBox);
            CommaSeparator_Command = new RelayCommand(CommaSeparator);
            WriteToMemoryAdd_Command = new RelayCommand(WriteToMemoryAddAsync);
            Addition_Command = new RelayCommand(Addition);
            ClearMemory_Command = new RelayCommand(ClearMemory);
            Substraction_Command = new RelayCommand(Substraction);
        }

        private async void ClearMemory()
        {
            string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            await ClearMemoryAsync(dirPath, "memory.txt");
        }

        private async Task ClearMemoryAsync(string dir, string file)
        {
            try
            {
                await File.WriteAllTextAsync(Path.Combine(dir, file),String.Empty);
                
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private async void WriteToMemoryAddAsync()
        {
            var format = new NumberFormatInfo();
            format.NegativeSign = "-";
            format.NumberDecimalSeparator = ",";
            string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (!File.Exists(dirPath + "memory.txt") && !TotalText.Equals(""))
            {
                await WriteToMemoryAsync(dirPath, "memory.txt", TotalText);
            }
            string number = await ReadFromMemoryAsync(dirPath, "memory.txt");
            double result = Convert.ToDouble(number);
            result += Convert.ToDouble(TotalText);
            await WriteToMemoryAsync(dirPath, "memory.txt", result.ToString());
            TotalText = "";

        }

        static async Task WriteToMemoryAsync(string dir, string file, string content)
        {
            try
            {
                using StreamWriter outputFile = new(Path.Combine(dir, file));
                await outputFile.WriteAsync(content);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        static async Task<string> ReadFromMemoryAsync(string dir, string file)
        {
            try
            {
                using StreamReader outputFile = new(Path.Combine(dir, file));
                string? number;

                number = await outputFile.ReadLineAsync();

                return number;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return "";
            }

        }

        private void Substraction()
        {

            var format = new NumberFormatInfo();
            format.NegativeSign = "-";
            format.NumberDecimalSeparator = ",";
            if (!(TotalText.Equals("")) && SubTotalText.Equals(""))
            {
                SubTotalText = TotalText + "-";
                TotalText = "";
                return;
            }
            if (!TotalText.Equals("") && !SubTotalText.Equals(""))
            {
                var numberFromSubTotalText = subTotalText.Split(new Char[] { '-', '+' });
                double result = Convert.ToDouble(numberFromSubTotalText[0], format) - Convert.ToDouble(TotalText, format);
                resultHelper = result;
                SubTotalText = result.ToString() + "-";
                TotalText = result.ToString();
            }
        }

        private void Addition()
        {

            var format = new NumberFormatInfo();
            format.NegativeSign = "-";
            format.NumberDecimalSeparator = ",";
            if (!(TotalText.Equals("")) && SubTotalText.Equals("") )
            {
                SubTotalText = TotalText + "+";
                TotalText = "";
                return;
            }
            if(!TotalText.Equals("") && !SubTotalText.Equals(""))
            {
                var numberFromSubTotalText = subTotalText.Split(new Char[] { '-', '+' });
                double result = Convert.ToDouble(numberFromSubTotalText[0],format) + Convert.ToDouble(TotalText,format);
                resultHelper = result;
                SubTotalText = result.ToString() + "+";
                TotalText = result.ToString();
            }
        }

        private void CommaSeparator()
        {
            if(!TotalText.Equals("") && !TotalText.Contains(",") && TotalText.Length < 7)
            {
                TotalText += ",";
            }
        }

        private  void  ClearTextBox()
        {
            TotalText = "";
            SubTotalText = "";
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

            if (resultHelper != 0)
            {
                TotalText = "";
                resultHelper = 0;
            }

            if (TotalText.Length < 7)
            {
                TotalText += obj;
            }

        }


    }
}