using System;

namespace Algorithms
{
    /// <summary>
    /// Тесты для первого урока
    /// </summary>
    internal class Lesson1TestClass
    {
        /// <summary>
        /// Первый тест для 1 задания
        /// </summary>
        public static void TestNumberPlus()
        {
            Console.WriteLine("Запуск сценария с числом 10. Результат должен быть - не простое число");
            Print.TestNumbers(10);
        }

        /// <summary>
        /// Второй тест для 1 задания
        /// </summary>
        public static void TestNumberMinus()
        {
            Console.WriteLine("Запуск сценария с числом 17. Результат должен быть - простое число");
            Print.TestNumbers(17);
        }
    }
}