// Практическое задание
// 1. Напишите на C# функцию согласно блок-схеме
// 2. Посчитайте сложность функции
// 3. Реализуйте функцию вычисления числа Фибоначчи

using System;

namespace Algorithms
{
    /// <summary>
    /// Меню 1 урока
    /// </summary>
    internal class Lesson1Menu
    {
        /// <summary>
        /// Меню первого урока
        /// </summary>
        public static void Show()
        {
            PrintMenu(); 
            MenuOptions(Helpers.AskForKey(5));
        }


        /// <summary>
        /// Вывести меню первого урока
        /// </summary>
        static void PrintMenu()
        {
            Console.Clear();

            Helpers.WriteLineColor("Урок 1:", ConsoleColor.Blue);
            Console.WriteLine();
            Console.WriteLine("1. Функция согласно блок-схеме. Ручной ввод.");
            Console.WriteLine("2. Функция согласно блок-схеме. Положительный сценарий.");
            Console.WriteLine("3. Функция согласно блок-схеме. Отрицательный сценарий.");

            Console.WriteLine("4. Посчитайте сложность функции");
            Console.WriteLine("5. Вычисления числа Фибоначчи");
            Console.WriteLine();
            Helpers.WriteLineColor("Для выбора нажмите клавишу с цифрой", ConsoleColor.Green);
            Helpers.WriteLineColor("Для выхода из программы нажмите BackSpace или Escape", ConsoleColor.Green);
            Console.WriteLine();
        }


        /// <summary>
        /// Выбор опции первого урока
        /// </summary>
        /// <param name="option">Опция меню</param>
        static void MenuOptions(int option)
        {
            switch (option)
            {
                case 1:
                    Ask.TestNumber(); // Задание 1. Ручной ввод
                    Show();
                    break;
                case 2:
                    Lesson1TestClass.TestNumberPlus(); // Задание 1. Тест 1
                    Helpers.PressAnyKey(1);
                    Show();
                    break;
                case 3:
                    Lesson1TestClass.TestNumberMinus(); // Задание 1. Тест 2
                    Helpers.PressAnyKey(1);
                    Show();
                    break;
                case 4:
                    Console.WriteLine("Сложность функции N^3"); // Вывести ответ на 2 задание
                    Helpers.PressAnyKey(1);
                    Show();
                    break;
                case 5:
                    Ask.FibonacciNumber(); // Задание 3                      
                    Show();
                    break;
                case 0:
                    MainMenu.Show(); // Вернуться в главное меню
                    break;


            }
        }
    }
}
