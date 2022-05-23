using System;

namespace Algorithms
{
    /// <summary>
    /// Главное меню
    /// </summary>
    internal class MainMenu
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
                    Menu lesson1 = new Menu(MenuLists.Lesson1Menu, "Sub"); // Меню 1 урока
                    break;
                case 2:
                    Menu lesson2 = new Menu(MenuLists.Lesson2Menu, "Sub"); // Меню 1 урока
                    break;
                case 3:
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
