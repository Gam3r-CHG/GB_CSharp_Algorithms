using System;
using Algorithms.Benchmark;

namespace Algorithms.Lessons
{
    /// <summary>
    /// Третий урок
    /// </summary>
    internal class Lesson3 : ILessons
    {
        public static string LessonName = "Урок 3";
        public static string LessonDescription = "Задания урока 3";

        public static string[,] LessonMenuArray = 
        {
            {"Тест скорости создания и обработки данных", "Bench"}
        };


        /// <summary>
        /// Запуск тест скорости
        /// </summary>
        public static void Bench()
        {
            BenchIt.Run(100_000);
            Console.WriteLine("\n");
            BenchIt.Run(1_000_000);
            Console.WriteLine("\n");
            BenchIt.Run(10_000_000);
            Console.WriteLine();

            Helpers.PressAnyKey(1);
        }

    }
}
