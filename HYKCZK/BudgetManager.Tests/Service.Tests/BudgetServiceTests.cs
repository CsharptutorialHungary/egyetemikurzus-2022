using BudgetManager.Model;
using BudgetManager.Provider;
using BudgetManager.Service;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;
using BudgetManager.Enum;

namespace BudgetManager.Tests.Service.Tests
{
    [TestFixture]
    internal class BudgetServiceTests
    {
        private const string BUDGET_JSON_PATH = @"budget.json";
        //private Mock<IFileSystem> _fileSystemMock;

        private MockFileSystem _fileSystemMock;
        private Mock<IConsole> _consoleMock;
        private Mock<IExchangeRateProvider> _exchangeRateProviderMock;

        private string _budgetJson;
        private Budget _budget;
        private decimal _totalIncome;
        private decimal _totalCost;
        private decimal _totalBudget;

        [SetUp]
        public void SetUp()
        {
            _budgetJson = @"
{
  ""incomes"": [
    {
      ""amount"": 500000,
      ""description"": ""Salary"",
      ""accountedDateTime"": ""2021-07-14T01:10:16.5275273+02:00""
    },
    {
      ""amount"": 600000,
      ""description"": ""Salary"",
      ""accountedDateTime"": ""2021-07-14T01:23:30.5031482+02:00""
    }
  ],
  ""costs"": [
    {
      ""amount"": 1000000,
      ""description"": ""Kicsi kocsi Suzuki"",
      ""accountedDateTime"": ""2021-07-14T01:22:59.4319203+02:00""
    },
    {
      ""amount"": 10600,
      ""description"": ""Kaja"",
      ""accountedDateTime"": ""2021-07-14T22:28:29.8049198+02:00""
    }
  ],
  ""currency"": ""HUF""
}
";

            _budget = new Budget()
            {
                Incomes = new List<Transaction>
                {
                    new Transaction(500_000M, "Salary", DateTime.Parse("2021-07-14T01:10:16.5275273+02:00")),
                    new Transaction(600_000M, "Salary", DateTime.Parse("2021-07-14T01:23:30.5031482+02:00"))
                },
                Costs = new List<Transaction>
                {
                    new Transaction(1_000_000M, "Kicsi kocsi Suzuki", DateTime.Parse("2021-07-14T01:22:59.4319203+02:00")),
                    new Transaction(10_600M, "Kaja", DateTime.Parse("2021-07-14T22:28:29.8049198+02:00"))
                },
                Currency = Currency.HUF
            };

            _totalIncome = 1_100_000M;
            _totalCost = 1_010_600M;
            _totalBudget = 89_400M;


            _fileSystemMock = new MockFileSystem(new Dictionary<string, MockFileData>());

            _consoleMock = new Mock<IConsole>(MockBehavior.Strict);
            _consoleMock.Setup(console => console.WriteLine(It.IsAny<string>()));

            _exchangeRateProviderMock = new Mock<IExchangeRateProvider>(MockBehavior.Strict);
        }

        [Test]
        public void Constructor_NoBudgetJson_ShouldCreateNewBudget()
        {
            var sut = new BudgetService(_fileSystemMock, _consoleMock.Object, _exchangeRateProviderMock.Object);

            _consoleMock.Verify(m => m.WriteLine("Creating new budget."), Times.Once);

            Assert.That(_fileSystemMock.File.Exists(BUDGET_JSON_PATH), Is.True);
        }

        [Test]
        public void Constructor_InvalidBudgetJsonFile_ShouldCreateNewBudget()
        {
            _fileSystemMock.AddFile(BUDGET_JSON_PATH, new MockFileData("SOME INVALID JSON \"..;--"));
            var sut = new BudgetService(_fileSystemMock, _consoleMock.Object, _exchangeRateProviderMock.Object);
            
            _consoleMock.Verify(m => m.WriteLine("Creating new budget."), Times.Once);
            _consoleMock.Verify(m => m.WriteLine($"[Error]: Could not read {BUDGET_JSON_PATH} file."), Times.Once);

            Assert.That(_fileSystemMock.File.Exists(BUDGET_JSON_PATH), Is.True);
        }

        [Test]
        public void Constructor_ValidBudgetJsonFile_ShouldParseSuccessfully()
        {
            _fileSystemMock.AddFile(BUDGET_JSON_PATH, new MockFileData(_budgetJson));
            var sut = new BudgetService(_fileSystemMock, _consoleMock.Object, _exchangeRateProviderMock.Object);

            _consoleMock.Verify(m => m.WriteLine($"JSON {BUDGET_JSON_PATH} was read successfully"), Times.Once);

            Assert.That(sut.TotalIncome, Is.EqualTo(_totalIncome));
            Assert.That(sut.TotalCost, Is.EqualTo(_totalCost));
            Assert.That(sut.TotalBudget, Is.EqualTo(_totalBudget));
        }

        [Test]
        public void AddIncome_OneTransaction_ShouldAddIncome()
        {
            var sut = new BudgetService(_fileSystemMock, _consoleMock.Object, _exchangeRateProviderMock.Object);

            sut.AddIncome(new Transaction(1_000_000M, "Salary", DateTime.Now));

            Assert.That(sut.TotalIncome, Is.EqualTo(1_000_000M));
        }

        [Test]
        public void AddIncome_MultipleTransaction_ShouldAddIncomes()
        {
            var sut = new BudgetService(_fileSystemMock, _consoleMock.Object, _exchangeRateProviderMock.Object);

            sut.AddIncome(new Transaction(1_000_000M, "Salary", DateTime.Now));
            sut.AddIncome(new Transaction(1_000_000M, "Salary", DateTime.Now));

            Assert.That(sut.TotalIncome, Is.EqualTo(2_000_000M));
        }

        [Test]
        public void AddCost_OneTransaction_ShouldAddCost()
        {
            var sut = new BudgetService(_fileSystemMock, _consoleMock.Object, _exchangeRateProviderMock.Object);

            sut.AddCost(new Transaction(1_000_000M, "Suzuki", DateTime.Now));

            Assert.That(sut.TotalCost, Is.EqualTo(1_000_000M));
        }

        [Test]
        public void AddCost_MultipleTransaction_ShouldAddCosts()
        {
            var sut = new BudgetService(_fileSystemMock, _consoleMock.Object, _exchangeRateProviderMock.Object);

            sut.AddCost(new Transaction(1_000_000M, "Suzuki", DateTime.Now));
            sut.AddCost(new Transaction(40_000M, "Party", DateTime.Now));

            Assert.That(sut.TotalCost, Is.EqualTo(1_040_000M));
        }
    }
}
