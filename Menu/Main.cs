using System;

namespace Algorithms.Menu
{
    /// <summary>
    /// Главное меню
    /// </summary>
    internal class Main
    {
        /// <summary>
        /// Главное меню (опции)
        /// </summary>
        /// <param name="option">Опция меню</param>
        public static void MenuOptions(int option)
        {
            switch (option)
            {
                case 1:
                    MenuBuilder lesson1 = new (Lists.Lesson1Menu, "Sub"); // Меню 1 урока
                    break;
                case 2:
                    MenuBuilder lesson2 = new (Lists.Lesson2Menu, "Sub"); // Меню 2 урока
                    break;
                case 3:
                    MenuBuilder lesson3 = new(Lists.Lesson3Menu, "Sub"); // Меню 3 урока
                    break;
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                    Console.WriteLine("Еще не реализовано!"); // TODO
                    Helpers.PressAnyKey(1);
                    break;
                case 0:
                    break;
            }
        }



    }
}
