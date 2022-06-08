using System;
using System.Collections.Generic;
using System.Linq;

namespace Menu
{
    /// <summary>
    /// Создание меню и подменю
    /// </summary>
    public class MenuBuilder
    {
        private string InterfaceName;
        private List<string> menuClassList = new();
        private List<string> menuNameList = new();


        /// <summary>
        /// Конструктор меню уроков по заданному интерфейсу
        /// </summary>
        /// <param name="interfaceName">Название интерфейса для построения меню</param>
        public MenuBuilder(string interfaceName)
        {
            InterfaceName = interfaceName;
            GetMainMenu();
            PrintMainMenu();
        }


        /// <summary>
        /// Получение списка уроков для меню и создание двух списков с названиями классов и уроков
        /// </summary>
        private void GetMainMenu()
        {
            Type type = Type.GetType(InterfaceName);   // Интерфейс для поиска классов с уроками

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface); // Получить список классов, наследуемых интерфейс

            foreach (var t in types) // Пройти по всем наследникам и собрать информацию
            {
                menuClassList.Add(t.AssemblyQualifiedName);     // Добавить в список полное название классов
                menuNameList.Add(t.GetField("LessonName").GetValue(null).ToString());  // Добавить в список название уроков
            }
        }


        /// <summary>
        /// Вывод главного меню на экран
        /// </summary>
        private void PrintMainMenu()
        {
            int keyNumber = -1;

            while (keyNumber != 0) // Бесконечный цикл, пока не нажата клавиша для выхода
            {
                Console.Clear();

                Helpers.WriteLineColor("Главное меню", ConsoleColor.Blue); // Название меню
                Console.WriteLine();

                int index = 1; // Для индекса
                foreach (var t in menuNameList)  // Пронумеровать и вывести на экран
                {
                    Console.WriteLine(index + ". " + t);
                    index++;
                }

                Console.WriteLine();
                Helpers.WriteLineColor("Для выбора нажмите клавишу с цифрой", ConsoleColor.Green);
                Helpers.WriteLineColor("Для выхода из программы нажмите BackSpace или Escape", ConsoleColor.Green);

                Console.WriteLine();

                keyNumber = AskForKey(menuNameList.Count);  // Запросить клавишу для выбора опции

                if (keyNumber == 0) return;                 // Если нажата клавиша для выхода

                // Вызвать метод PrintSubMenu и передать название класса с выбранным уроком
                Type subMenuType = Type.GetType(menuClassList[keyNumber - 1]);

                PrintSubMenu(subMenuType);
            }
        }


        /// <summary>
        /// Вывод подменю на экран
        /// </summary>
        private void PrintSubMenu(Type subMenu)
        {
            int keyNumber = -1;
            while (keyNumber != 0) // Бесконечный цикл, пока не нажата клавиша для выхода
            {
                Console.Clear();

                string lessonName = subMenu.GetField("LessonName").GetValue(null).ToString();

                Helpers.WriteLineColor(lessonName, ConsoleColor.Blue); // Название подменю
                Console.WriteLine();

                // Считать массив с названиями пунктов и методов
                string[,] menuArray = (string[,])subMenu.GetField("LessonMenuArray").GetValue(null);
                
                for (int i = 0; i < menuArray.GetLength(0); i++)  // Пронумеровать и вывести на экран
                {
                    Console.WriteLine((i + 1) + ". " + menuArray[i, 0]);
                }

                Console.WriteLine();
                Helpers.WriteLineColor("Для выбора нажмите клавишу с цифрой", ConsoleColor.Green);
                Helpers.WriteLineColor("Для возврата в главное меню нажмите BackSpace или Escape", ConsoleColor.Green);
                Console.WriteLine();

                keyNumber = AskForKey(menuArray.GetLength(0)); // Запросить клавишу для выбора опции
                if (keyNumber == 0) return; // Если нажата клавиша для выхода

                string methodName = menuArray[keyNumber - 1, 1]; // Название метода для запуска

                subMenu.GetMethod(methodName).Invoke(null, null); // Вызвать метод
            }
        }


        /// <summary>
        /// Запросить ввод с клавиатуры от 1 до "max" или BackSpace|Escape для выхода
        /// </summary>
        /// <param name="max">Максимальное число для запроса</param>
        /// <returns>Число введенное пользователем или 0</returns>
        private static int AskForKey(int max)
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
