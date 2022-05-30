using System;
using Algorithms.Benchmark;

namespace Algorithms.Lessons
{
    /// <summary>
    /// Третий урок
    /// </summary>
    internal class Lesson3
    {
        /// <summary>
        /// Меню 3 урока (опции)
        /// </summary>
        /// <param name="option">Опция меню</param>
        public static void MenuOptions(int option)
        {
            switch (option)
            {
                case 1:
                    Bench(); // Задание 1. Тест скорости обработки данных в классе и структуре
                    Helpers.PressAnyKey(1);
                    break;
            }
        }

        /// <summary>
        /// Запуск тест скорости
        /// </summary>
        static void Bench()
        {
            BenchIt.Run(100_000);
            Console.WriteLine("\n");
            BenchIt.Run(1_000_000);
            Console.WriteLine("\n");
            BenchIt.Run(10_000_000);
            Console.WriteLine();
        }

    }
}
