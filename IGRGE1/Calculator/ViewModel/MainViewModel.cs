using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
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
        private List<string> lines = new();
        public readonly record struct MinMax(double Minimum, double Maximum);
        double resultHelper = 0;
        public string TotalText { get => totalText; set => SetProperty(ref totalText, value); }
        public string SubTotalText { get => subTotalText; set => SetProperty(ref subTotalText, value); }
        public ICommand NotZeroNumber_Command { get; private set; }
        public ICommand ZeroNumber_Command { get; private set; }
        public ICommand ExportToJSONMinMax_Command { get; private set; }
        public ICommand FindMin_Command { get; private set; }
        public ICommand FindMax_Command { get; private set; }
        public ICommand Divide_Command { get; private set; }
        public ICommand Multiplication_Command { get; private set; }
        public ICommand ClearTotalTextBox { get; private set; }
        public ICommand CommaSeparator_Command { get; private set; }
        public ICommand WriteToMemoryAdd_Command { get; private set; }
        public ICommand Addition_Command { get; private set; }
        public ICommand Substraction_Command { get; private set; }
        public ICommand Equation_Command { get; private set; }
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
            ClearTotalTextBox = new RelayCommand(ClearTextBox);
            FindMin_Command = new RelayCommand(FindMinAsync);
            ZeroNumber_Command = new RelayCommand(ZeroNumber_Click);
            NotZeroNumber_Command = new RelayCommand<string>(NotZeroNumber_Click);
            FindMax_Command = new RelayCommand(FindMaxAsync);
            CommaSeparator_Command = new RelayCommand(CommaSeparator);
            WriteToMemoryAdd_Command = new RelayCommand(WriteToMemoryAddAsync);
            ExportToJSONMinMax_Command = new RelayCommand(ExportToJSONMinMaxAsync);
            Addition_Command = new RelayCommand(Addition);
            Substraction_Command = new RelayCommand(Substraction);
            Multiplication_Command = new RelayCommand(Multiplication);
            Divide_Command = new RelayCommand(Divide);
            Equation_Command = new RelayCommand(Equation);
        }

        private void Divide()
        {
            if (SubTotalText.Equals("") && !TotalText.Equals("") && !TotalText.Equals("-"))
            {
                SubTotalText = TotalText + "÷";
                TotalText = String.Empty;
            }

            if (!SubTotalText.Equals("") && !TotalText.Equals("") && SubTotalText.Contains('÷'))
            {
                Equation();
            }
        }

        private void Multiplication()
        {
            if (SubTotalText.Equals("") && !TotalText.Equals("") && !TotalText.Equals("-"))
            {
                SubTotalText = TotalText + "*";
                TotalText = String.Empty;
            }

            if (!SubTotalText.Equals("") && !TotalText.Equals("") && SubTotalText.Contains('*'))
            {
                Equation();
            }
        }

        private void Equation()
        {
            string WholeText = String.Empty;
            if (SubTotalText.Contains("+"))
            {
                WholeText = SubTotalText + TotalText;
                string[] operands = WholeText.Split('+');
                double result = Convert.ToDouble(operands[0]) + Convert.ToDouble(operands[1]);
                TotalText = result.ToString();
                SubTotalText = String.Empty;
                resultHelper = 1;
            }

            if (SubTotalText.Contains("÷") && !TotalText.Equals("0"))
            {
                WholeText = SubTotalText + TotalText;
                string[] operands = WholeText.Split('÷');
                double result = Convert.ToDouble(operands[0]) / Convert.ToDouble(operands[1]);
                TotalText = result.ToString();
                SubTotalText = String.Empty;
                resultHelper = 1;
            }

            if (SubTotalText.Contains("÷") && TotalText.Equals("0"))
            {
                SubTotalText = "";
                resultHelper = 1;
                TotalText = "Nullával ne pls";
            }

            if (SubTotalText.Contains("*"))
            {
                WholeText = SubTotalText + TotalText;
                string[] operands = WholeText.Split('*');
                double result = Convert.ToDouble(operands[0]) * Convert.ToDouble(operands[1]);
                TotalText = result.ToString();
                SubTotalText = String.Empty;
                resultHelper = 1;
            }


            if (SubTotalText.Contains("-") && SubTotalText[0] != '-')
            {
                WholeText = SubTotalText + TotalText;
                string[] operands = WholeText.Split('-');
                double result = Convert.ToDouble(operands[0]) - Convert.ToDouble(operands[1]);
                TotalText = result.ToString();
                SubTotalText = String.Empty;
                resultHelper = 1;
            }

            if (SubTotalText.Contains("-") && SubTotalText[0] == '-')
            {
                int indexOfNegative = SubTotalText.LastIndexOf('-');
                WholeText = SubTotalText + TotalText;
                double result = Convert.ToDouble(WholeText.Substring(0,indexOfNegative)) - Convert.ToDouble(WholeText.Substring(indexOfNegative + 1,WholeText.Length - (indexOfNegative + 1)));
                TotalText = result.ToString();
                SubTotalText = String.Empty;
                resultHelper = 1;
            }



        }

        private async void ExportToJSONMinMaxAsync()
        {
            string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            MinMax minMax = new MinMax(await FindMinExtAsync(), await FindMaxExtAsync());
            string output = JsonConvert.SerializeObject(minMax);
            await WriteToMemoryAsync(dirPath, "export.json", output);
        }

        private async Task<double> FindMaxExtAsync()
        {
            List<double> numbersList = new List<double>();
            string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string[]? numbers = await ReadFromMemoryAsync(dirPath, "memory.txt");
            foreach (var number in numbers)
            {
                numbersList.Add(Convert.ToDouble(number));
            }
            double max = numbersList.Max();
            return max;
        }

        private async Task<double> FindMinExtAsync()
        {
            List<double> numbersList = new List<double>();
            string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string[]? numbers = await ReadFromMemoryAsync(dirPath, "memory.txt");
            foreach (var number in numbers)
            {
                numbersList.Add(Convert.ToDouble(number));
            }
            double min = numbersList.Min();
            return min;

        }

        private async void FindMaxAsync()
        {
            List<double> numbersList = new List<double>();
            string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string[]? numbers = await ReadFromMemoryAsync(dirPath, "memory.txt");
            foreach (var number in numbers)
            {
                numbersList.Add(Convert.ToDouble(number));
            }
            double max = numbersList.Max();
            TotalText = max.ToString();

        }

        private async void FindMinAsync()
        {
            List<double> numbersList = new List<double>();
            string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string[]? numbers = await ReadFromMemoryAsync(dirPath, "memory.txt");
            foreach (var number in numbers)
            {
                numbersList.Add(Convert.ToDouble(number));
            }
            double min = numbersList.Min();
            TotalText = min.ToString();

        }

        private async void WriteToMemoryAddAsync()
        {
            if (TotalText.Equals("Nullával ne pls"))
            {
                TotalText = "";
                return;
            }
            lines.Add(TotalText);
            string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            await WriteToMemoryAsync(dirPath, "memory.txt", lines);
            TotalText = "";

        }

        static async Task WriteToMemoryAsync(string dir, string file, List<string> lines)
        {
            try
            {
                using StreamWriter outputFile = new(Path.Combine(dir, file));

                foreach (var line in lines)
                {
                    await outputFile.WriteLineAsync(line);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static async Task WriteToMemoryAsync(string dir, string file, string line)
        {
            if (line.Equals("Nullával ne pls")) return;
            try
            {
                using StreamWriter outputFile = new(Path.Combine(dir, file));

                await outputFile.WriteLineAsync(line);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        static async Task<string[]?> ReadFromMemoryAsync(string dir, string file)
        {
            try
            {
                string outputFile = Path.Combine(dir, file);
                string[] numbers;

                numbers = await File.ReadAllLinesAsync(outputFile);

                return numbers;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        private void Substraction()
        {
            if (TotalText.Equals("Nullával ne pls")) TotalText = "";
            if (!SubTotalText.Equals("") && !TotalText.Equals("") && !SubTotalText.Contains("-") && SubTotalText[0] == '-')
            {
                return;
            }

            if(SubTotalText.Equals("") && TotalText.Equals("") && !TotalText.Contains("-"))
            {
                TotalText = "-";
            }    

            if (SubTotalText.Equals("") && !TotalText.Equals("") && !TotalText.Equals("-"))
            {
                SubTotalText = TotalText + "-";
                TotalText = String.Empty;
            }

            if (!SubTotalText.Equals("") && !TotalText.Equals("") && SubTotalText.Contains('-'))
            {
                Equation();
            }

        }


        private void Addition()
        {
            if (TotalText.Equals("Nullával ne pls")) TotalText = "";

            if (SubTotalText.Equals("") && !TotalText.Equals(""))
            {
                SubTotalText = TotalText + "+";
                TotalText = String.Empty;
            }

            if (!SubTotalText.Equals("") && !TotalText.Equals("") && SubTotalText.Contains('+'))
            {
                Equation();
            }
        }

        private void CommaSeparator()
        {
            if (!TotalText.Equals("") && !TotalText.Contains(",") && TotalText.Length < 7)
            {
                TotalText += ",";
            }
        }

        private void ClearTextBox()
        {
            resultHelper = 0;
            TotalText = "";
            SubTotalText = "";
        }

        private void ZeroNumber_Click()
        {
            if (resultHelper != 0)
            {
                TotalText = "";
                resultHelper = 0;
            }

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