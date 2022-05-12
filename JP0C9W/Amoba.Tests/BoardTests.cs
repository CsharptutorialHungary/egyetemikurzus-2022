using Amoba.Classes;
using Amoba.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;

namespace Amoba.Tests
{
    [TestClass]
    public class BoardTests
    {

        private static void Check_Board_Instance(
            int expectedMinSize,
            int expectedMaxSize,
            int expectedBoardSize,
            Board board
        )
        {
            Assert.AreEqual(expectedMinSize, board.MinSize, "Min board size is wrong!");
            Assert.AreEqual(expectedMaxSize, board.MaxSize, "Max board size is wrong!");
            Assert.AreEqual(expectedBoardSize, board.BoardSize, "Board size is wrong!");
            Assert.IsTrue(board.Cells.All(row => row.All(cell => cell == Board.EMPTY_CELL)), "Cells are not filled with empty cell!");
        }

        [TestMethod]
        public void Test_Full_Constructor()
        {
            Check_Board_Instance(5, 5, 5, new Board(-1, 5, 12));
            Check_Board_Instance(5, 5, 5, new Board(-1, 1, 23));
            Check_Board_Instance(5, 5, 5, new Board(5, 1, 1));
            Check_Board_Instance(5, 100, 5, new Board(101, 1, 3));
            Check_Board_Instance(11, 100, 100, new Board(11, 102, 100));
            Check_Board_Instance(100, 100, 100, new Board(101, 102, 5));
            Check_Board_Instance(10, 50, 12, new Board(10, 50, 12));
            Check_Board_Instance(5, 100, 26, new Board(1, 101, 26));
            Check_Board_Instance(100, 100, 100, new Board(123, 123, 123));
        }

        [DataRow(1)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        [DataRow(99)]
        [DataRow(100)]
        [DataRow(101)]
        [DataTestMethod]
        public void Test_BoardSize_EmptyCell_Constructor(int boardSize)
        {
            var board = new Board(boardSize);
            Assert.AreEqual(Board.MIN_BOARD_SIZE, board.MinSize);
            Assert.AreEqual(Board.MAX_BOARD_SIZE, board.MaxSize);
            Assert.AreEqual(boardSize < board.MinSize ? Board.MIN_BOARD_SIZE
                : (board.MaxSize < boardSize ? board.MaxSize : boardSize), board.BoardSize);
            Assert.IsTrue(board.Cells.All(row => row.All(cell => cell == Board.EMPTY_CELL)), "Cells are not filled with empty cell!");
        }

        [DataRow(1)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        [DataRow(99)]
        [DataRow(100)]
        [DataRow(101)]
        [DataTestMethod]
        public void Test_Board_Copy_Constructor(int boardSize)
        {
            var board = new Board(boardSize);
            for (int i = 0; i < board.BoardSize; i++)
            {
                for (int j = 0; j < board.BoardSize; j++)
                {
                    board.SetCell(i, j, BoardCellValue.WHITE);
                }
            }
            board.SetCell(4, 4, BoardCellValue.BLACK);
            board.SetCell(2, 0, BoardCellValue.EMPTY);
            var copy = new Board(board);
            Assert.AreEqual(board.BoardSize, copy.BoardSize);
            Assert.AreEqual(board.MaxSize, copy.MaxSize);
            Assert.AreEqual(board.MinSize, copy.MinSize);
            var boardCells = board.Cells;
            var copyCells = copy.Cells;
            for (int i = 0; i < board.BoardSize; i++)
            {
                var rowString = new string(boardCells.ElementAt(i));
                var copyRowString = new string(copyCells.ElementAt(i));
                Assert.AreEqual(rowString, copyRowString);
            }
        }

        [DataRow('$')]
        [DataRow('X')]
        [DataRow('O')]
        [DataRow('A')]
        [DataTestMethod]
        public void Test_FillCells_Method(char fillChar)
        {
            var board = new Board(5);
            MethodInfo? methodInfo = typeof(Board).GetMethod("FillCells", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { fillChar };
            if (methodInfo != null)
            {
                if (methodInfo.Invoke(board, parameters) is char[][] result)
                {
                    Assert.IsTrue(result.All(row => row.All(cell => cell == fillChar)), "Cells are not filled with FillCells method!");
                }
                else
                {
                    Assert.Fail("No result!");
                }
            }
        }

        [TestMethod]
        public void Test_Board_Cells_Only_Copy_Access()
        {
            var board = new Board(5);
            board.SetCell(0, 0, BoardCellValue.WHITE);
            board.Cells.ElementAt(0)[0] = (char)BoardCellValue.BLACK;
            Assert.AreEqual(board.Cells.ElementAt(0)[0], (char)BoardCellValue.WHITE);
        }

        [TestMethod]
        public void Test_ResetCells_Method()
        {
            var board = new Board(5);
            for (int i = 0; i < board.BoardSize; i++)
            {
                for (int j = 0; j < board.BoardSize; j++)
                {
                    board.SetCell(i, j, BoardCellValue.BLACK);
                }
            }
            board.ResetCells();
            Assert.IsTrue(board.Cells.All(row => row.All(cell => cell == Board.EMPTY_CELL)), "Cells are not reset to empty cell!");
        }

        [DataRow(0, 0, BoardCellValue.WHITE)]
        [DataRow(3, 3, BoardCellValue.BLACK)]
        [DataRow(2, 4, BoardCellValue.WHITE)]
        [DataRow(4, 2, BoardCellValue.BLACK)]
        [DataRow(0, 1, BoardCellValue.WHITE)]
        [DataRow(1, 0, BoardCellValue.BLACK)]
        [DataRow(4, 0, BoardCellValue.WHITE)]
        [DataRow(0, 4, BoardCellValue.BLACK)]
        [DataRow(4, 4, BoardCellValue.WHITE)]
        [DataTestMethod]
        public void Test_SetCell_With_Valid_Cell(int x, int y, BoardCellValue value)
        {
            var board = new Board(5);
            board.SetCell(x, y, value);
            Assert.AreEqual((char)value, board.Cells.ElementAt(y)[x]);
        }

        [DataRow(5, 5, BoardCellValue.BLACK)]
        [DataRow(4, 5, BoardCellValue.WHITE)]
        [DataRow(5, 4, BoardCellValue.BLACK)]
        [DataRow(6, 0, BoardCellValue.WHITE)]
        [DataRow(0, 6, BoardCellValue.BLACK)]
        [DataTestMethod]
        public void Test_SetCell_With_Invalid_Cell(int x, int y, BoardCellValue value)
        {
            var board = new Board(5);
            var exception = Assert.ThrowsException<ArgumentException>(() => board.SetCell(x, y, value));
            Assert.AreEqual("Invalid cell!", exception.Message);
        }

        [DataRow(BoardCellValue.BLACK)]
        [DataRow(BoardCellValue.WHITE)]
        [DataTestMethod]
        public void Test_IsFilled_True(BoardCellValue value)
        {
            var board = new Board(5);
            for (int i = 0; i < board.BoardSize; i++)
            {
                for (int j = 0; j < board.BoardSize; j++)
                {
                    board.SetCell(i, j, value);
                }
            }
            Assert.IsTrue(board.IsFilled());
        }

        [TestMethod]
        public void Test_IsFilled_False()
        {
            var board = new Board(5);
            Assert.IsFalse(board.IsFilled());
            for (int i = 0; i < board.BoardSize; i++)
            {
                for (int j = 0; j < board.BoardSize; j++)
                {
                    board.Cells.ElementAt(i)[j] = 'X';
                }
            }
            board.Cells.ElementAt(2)[2] = Board.EMPTY_CELL;
            Assert.IsFalse(board.IsFilled());
        }

        [DataRow(1)]
        [DataRow(5)]
        [DataRow(6)]
        [DataRow(25)]
        [DataRow(99)]
        [DataRow(100)]
        [DataRow(101)]
        [DataTestMethod]
        public void Test_CopyCells(int boardSize)
        {
            var board = new Board(boardSize);
            var cellsCopy = board.CopyCells();
            var actualCells = board.Cells;
            for (int i = 0; i < board.BoardSize; i++)
            {
                for (int j = 0; j < board.BoardSize; j++)
                {
                    Assert.AreEqual(actualCells.ElementAt(i)[j], cellsCopy.ElementAt(i)[j]);
                    // y == i == row   x == j == col
                    board.SetCell(j, i, BoardCellValue.BLACK);
                }
            }
            board.SetCell(2, 2, BoardCellValue.EMPTY);
            cellsCopy = board.CopyCells();
            actualCells = board.Cells;
            for (int i = 0; i < board.BoardSize; i++)
            {
                var rowString = new string(actualCells.ElementAt(i));
                var copyRowString = new string(cellsCopy.ElementAt(i));
                Assert.AreEqual(rowString, copyRowString);
            }
        }

        [TestMethod]
        public void Test_Static_BoardCellsToString_Empty_Cells_Argument_Exception()
        {
            var cells = Array.Empty<char[]>();
            var exception = Assert.ThrowsException<ArgumentException>(() => Board.BoardCellsToString(cells));
            Assert.AreEqual("Can't convert cells to string, bacause cells argument is empty!", exception.Message);
        }

        [TestMethod]
        public void Test_Static_BoardCellsToString_Not_Symmetrical_Board_Argument_Exception()
        {
            string errorMsg = "Board is not symmetrical!";
            char[][] testArray = CreateTestArray(1, 5, '#');
            var exception = Assert.ThrowsException<ArgumentException>(() => Board.BoardCellsToString(testArray));
            Assert.AreEqual(errorMsg, exception.Message);
            testArray = CreateTestArray(5, 1, 'O');
            exception = Assert.ThrowsException<ArgumentException>(() => Board.BoardCellsToString(testArray));
            Assert.AreEqual(errorMsg, exception.Message);
            testArray = CreateTestArray(101, 100, 'd');
            exception = Assert.ThrowsException<ArgumentException>(() => Board.BoardCellsToString(testArray));
            Assert.AreEqual(errorMsg, exception.Message);
        }

        public static char[][] CreateTestArray(int rowSize, int colSize, char fillChar)
        {
            if (rowSize <= 0)
            {
                throw new ArgumentException("Invalid row size!");
            }
            else if (colSize <= 0)
            {
                throw new ArgumentException("Invalid col size!");
            }

            char[][] array = new char[rowSize][];
            for (int i = 0; i < rowSize; i++)
            {
                array[i] = new char[colSize];
                Array.Fill(array[i], fillChar, 0, colSize);
            }
            return array;
        }

        [TestMethod]
        public void Test_CreateTestArray_Invalid_Row_Size_ArgumentException()
        {
            string errorMsg = "Invalid row size!";
            var exception = Assert.ThrowsException<ArgumentException>(() => CreateTestArray(-1, 1, 'A'));
            Assert.AreEqual(errorMsg, exception.Message);
            exception = Assert.ThrowsException<ArgumentException>(() => CreateTestArray(0, 1, 'A'));
            Assert.AreEqual(errorMsg, exception.Message);
            exception = Assert.ThrowsException<ArgumentException>(() => CreateTestArray(0, 0, 'A'));
            Assert.AreEqual(errorMsg, exception.Message);
        }

        [TestMethod]
        public void Test_CreateTestArray_Invalid_Col_Size_ArgumentException()
        {
            string errorMsg = "Invalid col size!";
            var exception = Assert.ThrowsException<ArgumentException>(() => CreateTestArray(1, -1, 'A'));
            Assert.AreEqual(errorMsg, exception.Message);
            exception = Assert.ThrowsException<ArgumentException>(() => CreateTestArray(3, 0, 'A'));
            Assert.AreEqual(errorMsg, exception.Message);
        }

        [DataRow(1, 5, 'a')]
        [DataRow(100, 5, 'd')]
        [DataRow(100, 100, '$')]
        [DataRow(1, 1, '%')]
        [DataRow(1, 100, 'V')]
        [DataTestMethod]
        public void Test_CreateTestArray_Valid_Arguments(int rowSize, int colSize, char value)
        {
            var array = CreateTestArray(rowSize, colSize, value);
            Assert.AreEqual(rowSize, array.Length);
            Assert.AreEqual(colSize, array[0].Length);
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Assert.AreEqual(value, array[i][j]);
                }
            }
        }

        [TestMethod]
        public void Test_Static_BoardCellsToString_Valid()
        {
            int count = 0;
            char[][] testArray = CreateTestArray(10, 10, 'X');
            string expectedString =
                " 1  X X X X X X X X X X\n" +
                " 2  X X X X X X X X X X\n" +
                " 3  X X X X X X X X X X\n" +
                " 4  X X X X X X X X X X\n" +
                " 5  X X X X X X X X X X\n" +
                " 6  X X X X X X X X X X\n" +
                " 7  X X X X X X X X X X\n" +
                " 8  X X X X X X X X X X\n" +
                " 9  X X X X X X X X X X\n" +
                "10  X X X X X X X X X X\n";
            Assert.AreEqual(expectedString, Board.BoardCellsToString(testArray), $"Failed on {++count}. array!");
            testArray = CreateTestArray(1, 1, 'X');
            expectedString = "1  X\n";
            Assert.AreEqual(expectedString, Board.BoardCellsToString(testArray), $"Failed on {++count}. array!");
        }

        [TestMethod]
        public void Test_ToString_Method()
        {
            int count = 0;
            var board = new Board(10);
            string expectedString =
                " 1  # # # # # # # # # #\n" +
                " 2  # # # # # # # # # #\n" +
                " 3  # # # # # # # # # #\n" +
                " 4  # # # # # # # # # #\n" +
                " 5  # # # # # # # # # #\n" +
                " 6  # # # # # # # # # #\n" +
                " 7  # # # # # # # # # #\n" +
                " 8  # # # # # # # # # #\n" +
                " 9  # # # # # # # # # #\n" +
                "10  # # # # # # # # # #\n";
            Assert.AreEqual(expectedString, board.ToString(), $"Failed on {++count}. board!");
            board = new Board(5);
            expectedString =
                "1  # # # # #\n" +
                "2  # # # # #\n" +
                "3  # # # # #\n" +
                "4  # # # # #\n" +
                "5  # # # # #\n";
            Assert.AreEqual(expectedString, board.ToString(), $"Failed on {++count}. board!");
        }
    }
}