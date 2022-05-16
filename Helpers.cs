using System;

namespace Algorithms
{
    /// <summary>
    /// Класс с вспомогательными методами
    /// </summary>
    internal class Helpers
    {

        /// <summary>
        /// Поставить на паузу выполнение программы
        /// </summary>
        /// <param name="task">Варианты: 0 - выйти из программы; 1 - продолжить</param>
        public static void PressAnyKey(int task)
        {
            switch (task)
            {
                case 0:
                    Console.WriteLine();
                    Console.WriteLine("Для выхода из программы нажмите любую клавишу...");
                    Console.ReadKey(true);
                    break;

                case 1:
                    Console.WriteLine();
                    Console.WriteLine("Для продолжения нажмите любую клавишу...");
                    Console.ReadKey(true);
                    break;

                default:
                    Console.ReadKey(true);
                    break;
            }
        }


        /// <summary>
        /// Запросить ввод с клавиатуры от 1 до "max" или BackSpace|Escape для выхода
        /// </summary>
        /// <param name="max">Максимальное число для запроса</param>
        /// <returns>Число введеное пользователем или 0</returns>
        public static int AskForKey(int max)
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();

            char pressKeyChar;
            int pressKeyNumber;


            //Запрашивать, пока пользователь не нажмет нужные клавиши
            do
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.Escape)
                    return 0; // Клавиши для выхода из цикла

                pressKeyChar = key.KeyChar;
                int.TryParse(Convert.ToString(pressKeyChar), out pressKeyNumber);

            } while (pressKeyNumber < 1 || pressKeyNumber > max); // проверка диапазона чисел

            return pressKeyNumber;
        }


        /// <summary>
        /// Вывести цветной текст (без перевода строки)
        /// </summary>
        /// <param name="text">Текст</param>
        /// <param name="color">(Необязательный параметр) Цвет текста. Например {ConsoleColor.Red}</param>
        public static void WriteColor(string text, ConsoleColor color = ConsoleColor.Gray)
        {
            ConsoleColor lastColor = Console.ForegroundColor;
            Console.ForegroundColor = color;        //Установить цвет, если передан параметр
            Console.Write(text);
            Console.ForegroundColor = lastColor;    //Вернуть настройки цвета
        }


        /// <summary>
        /// Вывести цветной текст (с переводом строки)
        /// </summary>
        /// <param name="text">Текст</param>
        /// <param name="color">(Необязательный параметр) Цвет текста. Например {ConsoleColor.Red}</param>
        public static void WriteLineColor(string text, ConsoleColor color = ConsoleColor.Gray)
        {
            ConsoleColor lastColor = Console.ForegroundColor;
            Console.ForegroundColor = color;    //Установить цвет, если передан параметр
            Console.WriteLine(text);
            Console.ForegroundColor = lastColor;    //Вернуть настройки цвета
        }


    }
}
