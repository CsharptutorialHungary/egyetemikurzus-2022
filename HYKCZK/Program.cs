using BudgetManager.Model;

namespace BudgetManager
{
    public class Program
    {
        private Budget _budget;

        public Program()
        {
            _budget = new Budget();
        }

        public static void Main(string[] args)
        {
            var program = new Program();
            program.StartProgram();
        }

        public void StartProgram()
        {
            _budget.Incomes.Add(400_000);
            _budget.Incomes.Add(400_000);

            _budget.Costs.Add(50_000);

            var selector = GetInputListSelector();
            while (true)
            {
                Console.WriteLine("Select from the list with the arrow keys:");
                var result = selector.Select();

                if (result == "Quit")
                {
                    break;
                }

                if (result == "Statistics")
                {
                    Console.WriteLine("Your budget:");
                    Console.WriteLine("Incomes: {0} {1}", _budget.Incomes.Sum(), _budget.Currency);
                    Console.WriteLine("Costs: {0} {1}", _budget.Costs.Sum(), _budget.Currency);
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Application is stopped.");
        }

        private InputListSelector GetInputListSelector()
        {
            var options = new List<string>
            {
                "Statistics",
                "Quit"
            };
            return new InputListSelector(options);
        }
    }
}
