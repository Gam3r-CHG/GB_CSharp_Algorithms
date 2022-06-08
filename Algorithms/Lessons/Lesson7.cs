using Algorithms.Board;

namespace Algorithms.Lessons
{
    /// <summary>
    /// Седьмой урок
    /// </summary>
    internal class Lesson7 : ILessons
    {
        public static string LessonName = "Урок 7";
        public static string LessonDescription = "Задания урока 7";

        public static string[,] LessonMenuArray = 
        {
            {"Вывести первое решение задачи: 8 ферзей на доске 8x8", "Task1"},
            {"Вывести все решения задачи: 5 ферзей на доске 5x5", "Task2"},
            {"Посчитать количество решений для N ферзей на доске NxN", "Task3"}
        };


        /// <summary>
        /// Задача 1. Вывести первое решение задачи: 8 ферзей на доске 8x8
        /// </summary>
        public static void Task1()
        {
            NQueens nQueens = new NQueens(8);
            nQueens.PrintBoard(1);

            Helpers.PressAnyKey(1);
        }


        /// <summary>
        /// Задача 2. Вывести все решения задачи: 5 ферзей на доске 5x5
        /// </summary>
        public static void Task2()
        {
            NQueens nQueens = new NQueens(5);
            nQueens.PrintAllBoard();

            Helpers.PressAnyKey(1);
        }


        /// <summary>
        /// Задача 3. Посчитать количество решений для N ферзей на доске NxN
        /// </summary>
        public static void Task3()
        {
            int number = NQueens.AskForN();
            if (number >= 4)
            {
                NQueens nQueens = new NQueens(number);
                nQueens.AskForBoard();
                Helpers.PressAnyKey(1);
            }
        }
    }
}
