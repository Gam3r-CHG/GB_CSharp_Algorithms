using System.Collections.Generic;

namespace Algorithms.Menu
{
    /// <summary>
    /// Класс для хранения списков меню
    /// </summary>
    internal class Lists
    {
        public static List<string> MainMenu = new()
        {
                "Главное меню:",
                "Урок 1",
                "Урок 2",
                "Урок 3",
                "Урок 4",
                "Урок 5",
                "Урок 6",
                "Урок 7",
                "Урок 8"
        };

        public static List<string> Lesson1Menu = new()
        {
            "Урок 1:",
            "Функция согласно блок-схеме. Ручной ввод",
            "Функция согласно блок-схеме. Положительный сценарий",
            "Функция согласно блок-схеме. Отрицательный сценарий",
            "Посчитайте сложность функции",
            "Вычисления числа Фибоначчи",
        };

        public static List<string> Lesson2Menu = new()
        {
            "Урок 2:",
            "Тест односвязного списка",
            "Тест двусвязного списка",
            "Тест сортировки и поиска в массивах",
        };

        public static List<string> Lesson3Menu = new()
        {
            "Урок 3:",
            "Тест скорости создания и обработки данных",
        };






    }
}
