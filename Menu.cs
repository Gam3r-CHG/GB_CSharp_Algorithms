using System;
using System.Collections.Generic;

namespace Algorithms
{
    /// <summary>
    /// Создание меню и подменю
    /// </summary>
    internal class Menu
    {
        List<string> List { get; } // Список элементов меню
        string MenuType { get; } // Тип меню (Main или Sub)


        /// <summary>
        /// Конструктор меню
        /// </summary>
        /// <param name="list">Список элементов</param>
        /// <param name="menuType">Тип меню (Main, Sub)</param>
        public Menu(List<string> list, string menuType)
        {
            List = list;
            MenuType = menuType;
            Init();
        }


        /// <summary>
        /// Инициализация меню
        /// </summary>
        void Init()
        {
            int menuOption = -1;
            while (menuOption != 0)
            {
                Print();
                menuOption = AskForKey(List.Count - 1);

                switch (List[0]) // Выбор действия в зависимости от названия меню (первая строчка списка)
                {
                    case "Главное меню:":
                        MainMenu.MenuOptions(menuOption);
                        break;
                    case "Урок 1:":
                        Lesson1.MenuOptions(menuOption);
                        break;
                    case "Урок 2:":
                        Lesson2.MenuOptions(menuOption);
                        break;
                    case "Урок 3:":
                        //Lesson3.MenuOptions(menuOption);
                        break;
                    case "Урок 4:":
                        //Lesson4.MenuOptions(menuOption);
                        break;
                    case "Урок 5:":
                        //Lesson5.MenuOptions(menuOption);
                        break;
                    case "Урок 6:":
                        //Lesson6.MenuOptions(menuOption);
                        break;
                    case "Урок 7:":
                        //Lesson7.MenuOptions(menuOption);
                        break;
                    case "Урок 8:":
                        //Lesson8.MenuOptions(menuOption);
                        break;
                }

            }
        }


        /// <summary>
        /// Вывод меню на экран
        /// </summary>
        void Print()
        {
            Console.Clear();

            Helpers.WriteLineColor(List[0], ConsoleColor.Blue); // Название меню
            Console.WriteLine();

            int index = 0;
            foreach (var menuItem in List)
            {
                if (index > 0)
                {
                    Console.WriteLine(index + ". " + menuItem); // Элементы меню
                }
                index++;
            }

            // Выбор текста для последних строчек меню
            if (MenuType == "Main") // Если это главное меню
            {
                Console.WriteLine();
                Helpers.WriteLineColor("Для выбора нажмите клавишу с цифрой", ConsoleColor.Green);
                Helpers.WriteLineColor("Для выхода из программы нажмите BackSpace или Escape", ConsoleColor.Green);
            }
            if (MenuType == "Sub") // Если это подменю
            {
                Console.WriteLine();
                Helpers.WriteLineColor("Для выбора нажмите клавишу с цифрой", ConsoleColor.Green);
                Helpers.WriteLineColor("Для возврата в главное меню нажмите BackSpace или Escape", ConsoleColor.Green);
            }

            Console.WriteLine();
        }


        /// <summary>
        /// Запросить ввод с клавиатуры от 1 до "max" или BackSpace|Escape для выхода
        /// </summary>
        /// <param name="max">Максимальное число для запроса</param>
        /// <returns>Число введенное пользователем или 0</returns>
        static int AskForKey(int max)
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();

            int pressKeyNumber;  // Возвращаемая клавиша


            //Запрашивать, пока пользователь не нажмет нужные клавиши
            do
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.Escape)
                    return 0; // Клавиши для выхода из цикла

                int.TryParse(Convert.ToString(key.KeyChar), out pressKeyNumber);

            } while (pressKeyNumber < 1 || pressKeyNumber > max); // проверка диапазона чисел

            return pressKeyNumber;
        }
    }
}
