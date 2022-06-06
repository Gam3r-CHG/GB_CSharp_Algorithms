using System;

namespace Algorithms.Lessons
{
    /// <summary>
    /// Первый урок
    /// </summary>
    internal class Lesson1 : ILessons
    {
        public static string LessonName = "Урок 1";
        public static string LessonDescription = "Задания урока 1";

        public static string[,] LessonMenuArray = 
        {
            {"Функция согласно блок-схеме. Ручной ввод", "Task1"},
            {"Функция согласно блок-схеме. Положительный сценарий", "TestNumberPlus"},
            {"Функция согласно блок-схеме. Отрицательный сценарий", "TestNumberMinus"},
            {"Посчитайте сложность функции", "Task4"},
            {"Вычисления числа Фибоначчи", "Task5"}
        };


        /// <summary>
        /// Функция согласно блок-схеме. Ручной ввод
        /// </summary>
        public static void Task1()
        {
            Ask.TestNumber(); // Задание 1. Ручной ввод
        }


        /// <summary>
        /// Функция согласно блок-схеме. Положительный сценарий
        /// </summary>
        public static void TestNumberPlus()
        {
            Console.WriteLine("Запуск сценария с числом 10. Результат должен быть - не простое число");
            Print.TestNumbers(10);
            Helpers.PressAnyKey(1);
        }


        /// <summary>
        /// Функция согласно блок-схеме. Отрицательный сценарий
        /// </summary>
        public static void TestNumberMinus()
        {
            Console.WriteLine("Запуск сценария с числом 17. Результат должен быть - простое число");
            Print.TestNumbers(17);
            Helpers.PressAnyKey(1);
        }


        /// <summary>
        /// Посчитать сложность функции
        /// </summary>
        public static void Task4()
        {
            Console.WriteLine("Сложность функции N^3"); // Вывести ответ на 2 задание
            Helpers.PressAnyKey(1);
        }


        /// <summary>
        /// Вычисления числа Фибоначчи
        /// </summary>
        public static void Task5()
        {
            Ask.FibonacciNumber(); // Задание 3
        }
    }
}
