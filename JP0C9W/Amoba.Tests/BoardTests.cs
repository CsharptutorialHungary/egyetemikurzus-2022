using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amoba.Classes;
using Amoba.Interfaces;
using System.Linq;
using System.Reflection;
using System;

namespace Amoba.Tests
{
    [TestClass]
    public class BoardTests
    {

        private static void Check_Board_Instance(
            int expectedMinSize,
            int expectedMaxSize,
            int expectedBoardSize,
            char expectedEmptyCell,
            Board board
        )
        {
            Assert.AreEqual(expectedMinSize, board.MinSize, "Min board size is wrong!");
            Assert.AreEqual(expectedMaxSize, board.MaxSize, "Max board size is wrong!");
            Assert.AreEqual(expectedBoardSize, board.BoardSize, "Board size is wrong!");
            Assert.AreEqual(expectedEmptyCell, board.EmptyCell, "Empty cell is wrong!");
            Assert.IsTrue(board.Cells.All(row => row.All(cell => cell == board.EmptyCell)), "Cells are not filled with empty cell!");
        }

        [TestMethod]
        public void Test_Full_Constructor()
        {
            Check_Board_Instance(5, 5, 5, 'a', new Board(-1, 5, 12, 'a'));
            Check_Board_Instance(5, 5, 5, 'b', new Board(-1, 1, 23, 'b'));
            Check_Board_Instance(5, 5, 5, 'c', new Board(5, 1, 1, 'c'));
            Check_Board_Instance(5, 100, 5, 'd', new Board(101, 1, 3, 'd'));
            Check_Board_Instance(11, 100, 100, 'e', new Board(11, 102, 100, 'e'));
            Check_Board_Instance(100, 100, 100, 'f', new Board(101, 102, 5, 'f'));
            Check_Board_Instance(10, 50, 12, 'g', new Board(10, 50, 12, 'g'));
            Check_Board_Instance(5, 100, 26, 'h', new Board(1, 101, 26, 'h'));
            Check_Board_Instance(100, 100, 100, 'i', new Board(123, 123, 123, 'i'));
        }

        [DataRow(1, 'a')]
        [DataRow(4, 'a')]
        [DataRow(5, 'b')]
        [DataRow(6, 'b')]
        [DataRow(99, 'c')]
        [DataRow(100, 'd')]
        [DataRow(101, 'e')]
        [DataTestMethod]
        public void Test_BoardSize_EmptyCell_Constructor(int boardSize, char emptyCell)
        {
            var board = new Board(boardSize, emptyCell);
            Assert.AreEqual(Board.MIN_BOARD_SIZE, board.MinSize);
            Assert.AreEqual(Board.MAX_BOARD_SIZE, board.MaxSize);
            Assert.AreEqual(boardSize < board.MinSize ? Board.MIN_BOARD_SIZE
                : (board.MaxSize < boardSize ? board.MaxSize : boardSize), board.BoardSize);
            Assert.AreEqual(emptyCell, board.EmptyCell, "Empty cell is wrong!");
            Assert.IsTrue(board.Cells.All(row => row.All(cell => cell == board.EmptyCell)), "Cells are not filled with empty cell!");
        }

        [DataRow('$')]
        [DataRow('X')]
        [DataRow('O')]
        [DataRow('A')]
        [DataTestMethod]
        public void Test_FillCells_Method(char fillChar)
        {
            var board = new Board(5, '#');
            MethodInfo? methodInfo = typeof(Board).GetMethod("FillCells", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { fillChar };
            if (methodInfo != null)
            {
                if (methodInfo.Invoke(board, parameters) is char[][] result)
                    Assert.IsTrue(result.All(row => row.All(cell => cell == fillChar)), "Cells are not filled with FillCells method!");
                else
                {
                    Assert.Fail("No result!");
                }
            }
        }

        [TestMethod]
        public void Test_ResetCells_Method()
        {
            var board = new Board(5, 'a');
            for (int i = 0; i < board.BoardSize; i++)
            {
                for (int j = 0; j < board.BoardSize; j++)
                {
                    board.Cells.ElementAt(i)[j] = 'x';
                }
            }
            board.ResetCells();
            Assert.IsTrue(board.Cells.All(row => row.All(cell => cell == board.EmptyCell)), "Cells are not reset to empty cell!");
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
            var board = new Board(5, 'a');
            var cell = new BoardCell(x, y, value);
            board.SetCell(cell);
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
            var board = new Board(5, 'a');
            var cell = new BoardCell(x, y, value);
            var exception = Assert.ThrowsException<ArgumentException>(() => board.SetCell(cell));
            Assert.AreEqual("Invalid cell!", exception.Message);
        }

        [TestMethod]
        public void Test_IsFilled_True()
        {
            var board = new Board(5, 'a');
            for (int i = 0; i < board.BoardSize; i++)
            {
                for (int j = 0; j < board.BoardSize; j++)
                {
                    board.Cells.ElementAt(i)[j] = 'x';
                }
            }
            Assert.IsTrue(board.IsFilled());
        }

        [TestMethod]
        public void Test_IsFilled_False()
        {
            var board = new Board(5, 'a');
            Assert.IsFalse(board.IsFilled());
            for (int i = 0; i < board.BoardSize; i++)
            {
                for (int j = 0; j < board.BoardSize; j++)
                {
                    board.Cells.ElementAt(i)[j] = 'X';
                }
            }
            board.Cells.ElementAt(2)[2] = board.EmptyCell;
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
            var board = new Board(boardSize, 'a');
            var cellCopy = board.CopyCells();
            for (int i = 0; i < board.BoardSize; i++)
            {
                for (int j = 0; j < board.BoardSize; j++)
                {
                    Assert.AreEqual(board.Cells.ElementAt(i)[j], cellCopy.ElementAt(i)[j]);
                    board.Cells.ElementAt(i)[j] = 'X';
                }
            }
            board.Cells.ElementAt(2)[2] = board.EmptyCell;
            cellCopy = board.CopyCells();
            for (int i = 0; i < board.BoardSize; i++)
            {
                for (int j = 0; j < board.BoardSize; j++)
                {
                    Assert.AreEqual(board.Cells.ElementAt(i)[j], cellCopy.ElementAt(i)[j]);
                }
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
                throw new ArgumentException("Invalid row size!");
            else if (colSize <= 0)
                throw new ArgumentException("Invalid col size!");
            
            char[][] array = new char[rowSize][];
            for (int i = 0; i < rowSize; i++)
            {
                array[i] = new char[colSize];
                Array.Fill(array[i], fillChar, 0, colSize);
            }
            return array;
        }

        [TestMethod]
        public void Test_CreateTestArray_Invalid_Row_Size_ArgumentException() {
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
            var board = new Board(10, 'X');
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
            Assert.AreEqual(expectedString, board.ToString(), $"Failed on {++count}. board!");
            board = new Board(5, 'O');
            expectedString =
                "1  O O O O O\n" +
                "2  O O O O O\n" +
                "3  O O O O O\n" +
                "4  O O O O O\n" +
                "5  O O O O O\n";
            Assert.AreEqual(expectedString, board.ToString(), $"Failed on {++count}. board!");
        }
    }
}