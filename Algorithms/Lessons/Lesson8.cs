using System;
using System.Diagnostics;

namespace Algorithms.Lessons
{
    /// <summary>
    /// Восьмой урок
    /// </summary>
    internal class Lesson8 : ILessons
    {
        public static string LessonName = "Урок 8";
        public static string LessonDescription = "Задания урока 8";

        public static string[,] LessonMenuArray = 
        {
            {"Сортировка массива подсчетом", "Task1"},
        };


        /// <summary>
        /// Задача 1. Сортировка массива подсчетом
        /// </summary>
        public static void Task1()
        {
            const int NUMBER_OF_ELEMENTS = 1_000_000;

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine($"Создаем массив из {NUMBER_OF_ELEMENTS:#,#} элементов.");
            int[] array = CreateAndFillArray(NUMBER_OF_ELEMENTS);
            Console.WriteLine("------------------------------------------------------");
            Bench("PrintArrayByN", new object[] { array, null });
            Console.WriteLine("------------------------------------------------------");
            Bench("Sort", new object[] { array });
            Bench("PrintArrayByN", new object[] { array, null });
            Console.WriteLine("------------------------------------------------------");

            Helpers.PressAnyKey(1);
        }


        /// <summary>
        /// Вывести массив на экран, пропуская указанное количество элементов. Для больших массивов
        /// </summary>
        /// <param name="array">Массив</param>
        /// <param name="numberOfElements">Выводить каждый N элементов. Можно не указывать. Автоматически посчитает на 200 элементов.</param>
        public static void PrintArrayByN(int[] array, int numberOfElements = 0)
        {
            if (numberOfElements == 0) numberOfElements = (int)(array.Length * 0.005D);
            if (numberOfElements == 0) numberOfElements = 1; // Если получилось маленькое число (для массивов меньше 200 элементов)
            Console.WriteLine($"Выводим каждый {numberOfElements:#,#} элемент массива:");
            for (int i = 0; i < array.Length; i++)
            {
                if (i % numberOfElements == 0) Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }


        /// <summary>
        /// Создать и заполнить массив произвольными числами в диапазоне от -1000 до 1000
        /// </summary>
        /// <param name="numberOfElements">Количество элементов в массиве</param>
        /// <returns></returns>
        public static int[] CreateAndFillArray(int numberOfElements)
        {
            int[] result = new int[numberOfElements];
            Random rnd = new Random();
            for (int i = 0; i < numberOfElements; i++)
            {
                result[i] = rnd.Next(-1000, 1000);
            }
            return result;
        }


        /// <summary>
        /// Сортировка массива подсчетом. Только массивы int
        /// </summary>
        /// <param name="array">Массив</param>
        public static void Sort(int[] array)
        {
            int[] minMax = GetArrayMinMax(array); // Получаем диапазон значений массива min и max

            // Вычисляем диапазон элементов в массиве
            int countRange = minMax[1] - minMax[0] + 1;

            // Создаем массив подсчета, чтобы посчитать количество уникальных элементов
            int[] countArray = new int[countRange];


            // Заполняем массив подсчета
            for (int i = 0; i < array.Length; i++)
            {
                countArray[array[i] - minMax[0]] += 1;
            }

            int index = 0;

            for (int i = 0; i < countArray.Length; i++)
            {
                for (int j = 0; j < countArray[i]; j++)
                {
                    array[index++] = i + minMax[0]; // Переносим отсортированные значения обратно в массив
                }
            }
        }


        /// <summary>
        /// Получить минимальное и максимальное значение в массиве
        /// </summary>
        /// <param name="array">Массив</param>
        /// <returns>Возвращает массив int[2] со значением min и max</returns>
        private static int[] GetArrayMinMax(int[] array)
        {
            int[] minMax = new int[2];
            minMax[0] = int.MaxValue;
            minMax[1] = int.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < minMax[0]) minMax[0] = array[i];
                if (array[i] > minMax[1]) minMax[1] = array[i];
            }

            return minMax;
        }


        /// <summary>
        /// Тест скорости выполнения метода
        /// </summary>
        /// <param name="methodName">Название метода</param>
        /// <param name="param">Параметры</param>
        public static void Bench(string methodName, object[] param)
        {
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            Type type = Type.GetType("Algorithms.Lessons.Lesson8");
            type.GetMethod(methodName).Invoke(null, param);
            sw.Stop();
            Helpers.WriteLineColor($"Метод {methodName} выполнен за {sw.ElapsedTicks: #,#} циклов", ConsoleColor.Green);
        }

    }
}
