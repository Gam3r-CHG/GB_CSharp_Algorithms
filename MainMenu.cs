using System;

namespace Algorithms
{
    /// <summary>
    /// Главное меню
    /// </summary>
    internal class MainMenu
    {
        /// <summary>
        /// Главное меню
        /// </summary>
        public static void Show()
        {
            PrintMenu(); // Вывести меню на экран
            MenuOptions(Helpers.AskForKey(8)); // Запросить ввод 
        }

        /// <summary>
        /// Вывести главное меню
        /// </summary>
        static void PrintMenu()
        {
            Console.Clear();

            Helpers.WriteLineColor("Главное меню:", ConsoleColor.Blue);
            Console.WriteLine();
            Console.WriteLine("1. Урок 1");
            Helpers.WriteLineColor("2. Урок 2", ConsoleColor.DarkGray);
            Helpers.WriteLineColor("3. Урок 3", ConsoleColor.DarkGray);
            Helpers.WriteLineColor("4. Урок 4", ConsoleColor.DarkGray);
            Helpers.WriteLineColor("5. Урок 5", ConsoleColor.DarkGray);
            Helpers.WriteLineColor("6. Урок 6", ConsoleColor.DarkGray);
            Helpers.WriteLineColor("7. Урок 7", ConsoleColor.DarkGray);
            Helpers.WriteLineColor("8. Урок 8", ConsoleColor.DarkGray);
            Console.WriteLine();
            Helpers.WriteLineColor("Для выбора нажмите клавишу с цифрой", ConsoleColor.Green);
            Helpers.WriteLineColor("Для выхода из программы нажмите BackSpace или Escape", ConsoleColor.Green);
        }

        /// <summary>
        /// Выбор опции главного меню
        /// </summary>
        /// <param name="option">Опция меню</param>
        static void MenuOptions(int option)
        {
            switch (option)
            {
                case 1:
                    Lesson1Menu.Show(); // Меню 1 урока
                    break;
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                    Console.WriteLine();
                    Console.WriteLine("Еще не реализовано!"); // TODO
                    Helpers.PressAnyKey(1);
                    Show();
                    break;
                case 0:
                    Helpers.PressAnyKey(0);
                    Environment.Exit(0); // Закрыть приложение
                    return;

            }
        }



    }
}
