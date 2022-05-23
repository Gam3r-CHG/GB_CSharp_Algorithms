using System;

namespace Algorithms
{
    /// <summary>
    /// Первый урок
    /// </summary>
    internal class Lesson1
    {
        /// <summary>
        /// Меню 1 урока (опции)
        /// </summary>
        /// <param name="option">Опция меню</param>
        public static void MenuOptions(int option)
        {
            switch (option)
            {
                case 1:
                    Ask.TestNumber(); // Задание 1. Ручной ввод
                    break;
                case 2:
                    TestNumberPlus(); // Задание 1. Тест 1
                    Helpers.PressAnyKey(1);
                    break;
                case 3:
                    TestNumberMinus(); // Задание 1. Тест 2
                    Helpers.PressAnyKey(1);
                    break;
                case 4:
                    Console.WriteLine("Сложность функции N^3"); // Вывести ответ на 2 задание
                    Helpers.PressAnyKey(1);
                    break;
                case 5:
                    Ask.FibonacciNumber(); // Задание 3    
                    break;
            }
        }


        /// <summary>
        /// Первый тест для 1 задания
        /// </summary>
        static void TestNumberPlus()
        {
            Console.WriteLine("Запуск сценария с числом 10. Результат должен быть - не простое число");
            Print.TestNumbers(10);
        }

        /// <summary>
        /// Второй тест для 1 задания
        /// </summary>
        static void TestNumberMinus()
        {
            Console.WriteLine("Запуск сценария с числом 17. Результат должен быть - простое число");
            Print.TestNumbers(17);
        }

    }
}
