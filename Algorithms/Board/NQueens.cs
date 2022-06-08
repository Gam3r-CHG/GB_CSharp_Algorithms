using System;
using System.Collections.Generic;

namespace Algorithms.Board
{
    internal class NQueens
    {
        private int _numberOfQueens;
        private int _count;
        private List<object> ListOfBoards = new();

        public NQueens(int numberOfQueens)
        {
            _numberOfQueens = numberOfQueens;
            MakeList();
        }


        /// <summary>
        /// Запросить размерность доски
        /// </summary>
        /// <returns>Число x Число</returns>
        public static int AskForN()
        {
            while (true)
            {
                Console.Write("Введите число, для выхода введите q: ");
                string line = Console.ReadLine();
                if (line.ToLower() == "q") return 1;  // Прерывание цикла

                if (Int32.TryParse(line, out int number)) return number;
                else Helpers.WriteLineColor("Ошибка! Введите число или q.", ConsoleColor.Red);
            }
        }


        /// <summary>
        /// Запросить число для вывода решения
        /// </summary>
        public void AskForBoard()
        {
            while (true)
            {
                Console.Write("Введите число, для выхода введите q: ");
                string line = Console.ReadLine();
                if (line.ToLower() == "q") return;  // Прерывание цикла

                if (Int32.TryParse(line, out int number)) PrintBoard(number);
                else Helpers.WriteLineColor("Ошибка! Введите число или q.", ConsoleColor.Red);
            }
        }


        /// <summary>
        /// Напечатать доску с решением
        /// </summary>
        /// <param name="numberOfBoard">Номер решения</param>
        public void PrintBoard(int numberOfBoard)
        {
            if (numberOfBoard == -1) return;

            if (_count == 0 || numberOfBoard > _count || numberOfBoard <= 0)
            {
                Console.WriteLine("Ошибка! Неправильные данные или список пуст");
                return;
            }

            Console.WriteLine("Вариант номер " + numberOfBoard);

            int[,] printBoard = (int[,])ListOfBoards[numberOfBoard - 1];

            for (int i = 0; i < printBoard.GetLength(0); i++)
            {
                for (int j = 0; j < printBoard.GetLength(1); j++)
                {
                    if (printBoard[i, j] == 1)
                    {
                        Helpers.WriteColor(printBoard[i, j] + " ", ConsoleColor.Red);
                    }
                    else Console.Write(printBoard[i, j] + " ");
                }
                Console.WriteLine();
            }
        }


        /// <summary>
        /// Напечатать все доски
        /// </summary>
        public void PrintAllBoard()
        {
            if (_count == 0)
            {
                Console.WriteLine("Список пуст");
                return;
            }

            Console.WriteLine("Все варианты:");
            Console.WriteLine("--------------");
            for (int i = 0; i < Count(); i++)
            {
                PrintBoard(i + 1);
                Console.WriteLine("--------------");
            }
        }


        /// <summary>
        /// Вернуть количество решений
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _count;
        }


        /// <summary>
        /// Создать список с решениями
        /// </summary>
        private void MakeList()
        {
            Console.Clear();

            if (_numberOfQueens < 4)
            {
                Console.WriteLine("Для доски меньше 4 - вариантов не существует!");
                return;
            }

            Console.WriteLine("Вариантов найдено: ");

            int[,] board = new int[_numberOfQueens, _numberOfQueens];

            // Массив для указателей
            int[] pointer = new int[_numberOfQueens];
            for (int i = 0; i < _numberOfQueens; i++)
            {
                pointer[i] = -1;
            }

            // Поиск с возвратом
            for (int j = 0; ;)
            {
                pointer[j]++;

                // Вернутся назад
                if (pointer[j] == _numberOfQueens)
                {
                    board[pointer[j] - 1, j] = 0;
                    pointer[j] = -1;
                    j--;
                    if (j == -1)
                    {
                        Console.WriteLine($"Все варианты для доски {_numberOfQueens}x{_numberOfQueens} найдены");
                        break;
                    }
                }
                else
                {
                    board[pointer[j], j] = 1;
                    if (pointer[j] != 0)
                    {
                        board[pointer[j] - 1, j] = 0;
                    }

                    if (CheckBoard(board)) // Если пройдена проверка
                    {
                        j++; // Переходим к следующему столбцу
                        if (j == _numberOfQueens)
                        {
                            j--;
                            _count++;

                            Console.SetCursorPosition(19, 0); // Для счетчика решений
                            Console.WriteLine(_count);
                            ListOfBoards.Add(board.Clone());  // Добавляем решение в список
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Проверка решения
        /// </summary>
        /// <param name="board">Массив</param>
        /// <returns>True или False</returns>
        private bool CheckBoard(int[,] board)
        {
            // Проверка линии
            for (int i = 0; i < _numberOfQueens; i++)
            {
                int sum = 0;
                for (int j = 0; j < _numberOfQueens; j++)
                {
                    sum += board[i, j];
                }
                if (sum > 1) return false;
            }


            // Проверка 4-х диагоналей
            for (int i = 0, j = _numberOfQueens - 2; j >= 0; j--)
            {
                int sum = 0;
                for (int p = i, q = j; q < _numberOfQueens; p++, q++)
                {
                    sum += board[p, q];
                }
                if (sum > 1) return false;
            }

            for (int i = 1, j = 0; i < _numberOfQueens - 1; i++)
            {
                int sum = 0;
                for (int p = i, q = j; p < _numberOfQueens; p++, q++)
                {
                    sum += board[p, q];
                }
                if (sum > 1) return false;
            }

            for (int i = 0, j = 1; j < _numberOfQueens; j++)
            {
                int sum = 0;
                for (int p = i, q = j; q >= 0; p++, q--)
                {
                    sum += board[p, q];
                }
                if (sum > 1) return false;
            }

            for (int i = 1, j = _numberOfQueens - 1; i < _numberOfQueens - 1; i++)
            {
                int sum = 0;
                for (int p = i, q = j; p < _numberOfQueens; p++, q--)
                {
                    sum += board[p, q];
                }
                if (sum > 1) return false;
            }

            return true; // Если все проверки пройдены
        }
    }
}