using System;

namespace Algorithms.Lessons
{
    /// <summary>
    /// Шестой урок
    /// </summary>
    internal class Lesson6 : ILessons
    {
        public static string LessonName = "Урок 6";
        public static string LessonDescription = "Задания урока 6";

        public static string[,] LessonMenuArray = 
        {
            {"Рефакторинг приложения", "TextMessage"}
        };


        /// <summary>
        /// Вывести сообщение о задании к уроку 6
        /// </summary>
        public static void TextMessage()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Сделан рефакторинг класс MenuBuilder.");
            Console.WriteLine("Теперь класс автоматически создает меню.");
            Console.WriteLine("В качестве входных данных нужно указать название интерфейса.");
            Console.WriteLine("В каждом наследуемом классе должны быть следующие поля:");
            Console.WriteLine("LessonName, LessonDescription и LessonMenuArray.");
            Console.WriteLine("По ним создается меню и запускаются методы.");
            Console.WriteLine("И кроме того теперь весь проект разделен на 3 части.");
            Console.WriteLine("-----------------------------------------------------------------");

            Helpers.PressAnyKey(1);
        }

    }
}
