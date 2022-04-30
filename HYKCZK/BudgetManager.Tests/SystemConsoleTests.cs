using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace BudgetManager.Tests
{
    [TestFixture]
    internal class SystemConsoleTests
    {
        private const decimal V = 555M;
        private StringWriter _stringWriter;
        private IConsole _sut;

        [SetUp]
        public void SetUp()
        {
            _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);

            _sut = new SystemConsole();
        }

        [Test]
        public void Write_ShouldNotWriteLineEndingCharacter()
        {
            const string INPUT = "No newline character";

            _sut.Write(INPUT);

            Assert.That(_stringWriter.ToString(), Is.EqualTo(INPUT));
        }

        [Test]
        public void Write_ShouldFormatString()
        {
            const string STRING_FORMAT = "Formatted {0}";
            const int INPUT = 5;
            const string EXPECTED_STRING = "Formatted 5";

            _sut.Write(STRING_FORMAT, INPUT);

            Assert.That(_stringWriter.ToString(), Is.EqualTo(EXPECTED_STRING));
        }

        [Test]
        public void WriteLine_ShouldWriteLineEndingCharacter()
        {
            const string INPUT = "No newline character";

            _sut.WriteLine(INPUT);

            Assert.That(_stringWriter.ToString(), Is.EqualTo(INPUT + _stringWriter.NewLine));
        }

        [Test]
        public void WriteLine_ShouldFormatString()
        {
            const string STRING_FORMAT = "Formatted {0}";
            const int INPUT = 5;
            const string EXPECTED_STRING = "Formatted 5";

            _sut.WriteLine(STRING_FORMAT, INPUT);

            Assert.That(_stringWriter.ToString(), Is.EqualTo(EXPECTED_STRING + _stringWriter.NewLine));
        }

        [Test]
        public void WriteLine_NoInput_ShouldWriteLineEndingCharacter()
        {
            _sut.WriteLine();

            Assert.That(_stringWriter.ToString(), Is.EqualTo(_stringWriter.NewLine));
        }

        [Test]
        public void ReadString_NonEmptyInput_ReturnInputFromStream()
        {
            const string VALUE = "Your name:";
            const string EXPECTED = "Kif Lee";
            var stringReader = new StringReader(EXPECTED);
            Console.SetIn(stringReader);

            var result = _sut.ReadString(VALUE);

            Assert.That(result, Is.EqualTo(EXPECTED));
        }

        [Test]
        public void ReadString_EmptyInput_ReturnEmptyString()
        {
            const string VALUE = "Your name:";
            const string EXPECTED = "";
            var stringReader = new StringReader(EXPECTED);
            Console.SetIn(stringReader);

            var result = _sut.ReadString(VALUE);

            Assert.That(result, Is.EqualTo(EXPECTED));
        }

        [Test]
        [TestCaseSource(nameof(DecimalNumberTestCaseDatas))]
        public void TryReadDecimal_ValidInput_ReturnValidDecimal(string input, decimal expected)
        {
            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var resultSuccess = _sut.TryReadDecimal(out var resultDecimal, "Your number:");

            Assert.That(resultSuccess, Is.True);
            Assert.That(resultDecimal, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("Asd")]
        [TestCase("NotANumber")]
        [TestCase("As523624")]
        [TestCase("26246364Something")]
        public void TryReadDecimal_InvalidInput_ReturnNothing(string input)
        {
            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            var resultSuccess = _sut.TryReadDecimal(out var resultDecimal, "Your number:");

            Assert.That(resultSuccess, Is.False);
            Assert.That(resultDecimal, Is.EqualTo(0M));
        }

        [Test]
        public void ResetColor()
        {
            var expectedForegroundColor = Console.ForegroundColor;
            var expectedBackgroundColor = Console.BackgroundColor;

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            _sut.ResetColor();

            Assert.That(Console.ForegroundColor, Is.EqualTo(expectedForegroundColor));
            Assert.That(Console.BackgroundColor, Is.EqualTo(expectedBackgroundColor));
        }

        private static IEnumerable<TestCaseData> DecimalNumberTestCaseDatas
        {
            get
            {
                yield return new TestCaseData("0", 0M);
                yield return new TestCaseData("500", 500M);
                yield return new TestCaseData("100000000000000", 100000000000000M);
            }
        }
    }
}
