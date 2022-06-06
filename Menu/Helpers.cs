using System;

namespace Menu
{
    /// <summary>
    /// Класс с вспомогательными методами
    /// </summary>
    internal class Helpers
    {
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
            WriteColor(text + "\n", color);
        }


    }
}
