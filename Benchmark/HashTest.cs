using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Algorithms.Benchmark
{
    /// <summary>
    /// Тестовый класс для сравнения скорости заполнения и поиска в HashSet и массиве. Целые числа и строки.
    /// </summary>
    public class HashTest
    {
        private static Stopwatch sw = new();
        private static Random rnd = new();
        private static StringBuilder sb = new();

        private static int whatToFind1 = 1234567890;            // Число для поиска
        private static string whatToFind2 = "Hello, world!";    // Строка для поиска

        private static int maxRandomNumber = 1_000_000_000;     // Диапазон для произвольных чисел
        private static int stringLenght = 20;                   // Длина произвольных строк

        private static int[] numberOfElements = { 10_000, 100_000, 1_000_000, 10_000_000 }; // Массив для тестов


        /// <summary>
        /// Запуск теста скорости заполнения и поиска
        /// </summary>
        /// <param name="testNumbers">Массив для прогона тестов</param>
        public static void TestSpeedSearch()
        {
            Console.WriteLine();
            Console.WriteLine("Тест с целыми числами");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(" Количество элементов|   Заполнение HashSet|   Заполнение массива| Время поиска HashSet|  Время поиска массив|");

            foreach (var number in numberOfElements)
            {
                Console.Write(number.ToString("#,#").PadLeft(21) + "|");
                var result1 = CreateIntHash(number);
                Console.Write(result1.Item2.ToString("#,#").PadLeft(21) + "|");
                var result3 = CreateIntArray(number);
                Console.Write(result3.Item2.ToString("#,#").PadLeft(21) + "|");
                var result2 = SearchHashTest(result1.Item1, whatToFind1);
                Console.Write(result2.Item2.ToString("#,#").PadLeft(21) + "|");
                var result4 = SearchArrayTest(result3.Item1, whatToFind1);
                Console.Write(result4.Item2.ToString("#,#").PadLeft(21) + "|");
                Console.Write("\n");
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");

            Console.WriteLine();
            Console.WriteLine("Тест со строками");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(" Количество элементов|   Заполнение HashSet|   Заполнение массива| Время поиска HashSet|  Время поиска массив|");

            foreach (var number in numberOfElements)
            {
                Console.Write(number.ToString("#,#").PadLeft(21) + "|");
                var result1 = CreateStringHash(number);
                Console.Write(result1.Item2.ToString("#,#").PadLeft(21) + "|");
                var result3 = CreateStringArray(number);
                Console.Write(result3.Item2.ToString("#,#").PadLeft(21) + "|");
                var result2 = SearchHashTest(result1.Item1, whatToFind2);
                Console.Write(result2.Item2.ToString("#,#").PadLeft(21) + "|");
                var result4 = SearchArrayTest(result3.Item1, whatToFind2);
                Console.Write(result4.Item2.ToString("#,#").PadLeft(21) + "|");
                Console.Write("\n");
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");


        }


        /// <summary>
        /// Создать HashSet из целых числе и поместить в конец число для поиска
        /// </summary>
        /// <param name="numberOfElements">Количество элементов</param>
        /// <returns>HashSet и количество тактов</returns>
        private static (HashSet<int>, long) CreateIntHash(int numberOfElements)
        {
            sw.Restart();
            HashSet<int> hashSet = FillIntHash(numberOfElements);
            hashSet.Add(whatToFind1);
            sw.Stop();

            return (hashSet, sw.ElapsedTicks);
        }


        /// <summary>
        /// Создать массив из целых чисел и поместить в конец число для поиска
        /// </summary>
        /// <param name="numberOfElements">Количество элементов</param>
        /// <returns>Массив и количество тактов</returns>
        private static (int[], long) CreateIntArray(int numberOfElements)
        {
            sw.Restart();
            int[] array = FillIntArray(numberOfElements);
            sw.Stop();

            array[numberOfElements - 1] = whatToFind1;

            return (array, sw.ElapsedTicks);
        }


        /// <summary>
        /// Найти строку( или число) в HashSet
        /// </summary>
        /// <typeparam name="T">int, string</typeparam>
        /// <param name="hashSet"></param>
        /// <param name="whatToFind">Что найти</param>
        /// <returns>True or False, количество тактов</returns>
        private static (bool, long) SearchHashTest<T>(HashSet<T> hashSet, T whatToFind)
        {
            sw.Restart();
            bool isFoundHash = hashSet.Contains(whatToFind);
            sw.Stop();

            return (isFoundHash, sw.ElapsedTicks);
        }


        /// <summary>
        /// Найти строку( или число) в массиве
        /// </summary>
        /// <typeparam name="T">int, string</typeparam>
        /// <param name="array"></param>
        /// <param name="whatToFind">Что найти</param>
        /// <returns>True or False, количество тактов</returns>
        private static (bool, long) SearchArrayTest<T>(T[] array, T whatToFind)
        {
            sw.Restart();
            bool isFoundArray = array.Contains(whatToFind);
            sw.Stop();

            return (isFoundArray, sw.ElapsedTicks);
        }


        /// <summary>
        /// Создать HashSet из строк и поместить в конец строку для поиска
        /// </summary>
        /// <param name="numberOfElements">Количество элементов</param>
        /// <returns>HashSet и количество тактов</returns>
        private static (HashSet<string>, long) CreateStringHash(int numberOfElements)
        {
            sw.Restart();
            HashSet<string> hashSet = FillStringHash(numberOfElements);
            sw.Stop();

            hashSet.Add(whatToFind2);

            return (hashSet, sw.ElapsedTicks);
        }


        /// <summary>
        /// Создать массив из строк и поместить в конец строку для поиска
        /// </summary>
        /// <param name="numberOfElements">Количество элементов</param>
        /// <returns>Массив и количество тактов</returns>
        private static (string[], long) CreateStringArray(int numberOfElements)
        {
            sw.Restart();
            string[] array = FillStringArray(numberOfElements);
            sw.Stop();

            array[numberOfElements - 1] = whatToFind2;

            return (array, sw.ElapsedTicks);
        }


        /// <summary>
        /// Заполнить HashSet произвольными числами
        /// </summary>
        /// <param name="numberOfElements">Количество элементов</param>
        /// <returns>Заполненный HashSet - 1 элемент</returns>
        private static HashSet<int> FillIntHash(int numberOfElements)
        {
            HashSet<int> hashSet = new HashSet<int>();

            while (hashSet.Count < numberOfElements - 1) // Заполнять до указанного количества элементов
            {
                hashSet.Add(rnd.Next(maxRandomNumber));
            }

            return hashSet;
        }


        /// <summary>
        /// Заполнить HashSet произвольными строками
        /// </summary>
        /// <param name="numberOfElements">Количество элементов</param>
        /// <returns>Заполненный HashSet - 1 элемент</returns>
        private static HashSet<string> FillStringHash(int numberOfElements)
        {
            HashSet<string> hashSet = new HashSet<string>();

            while (hashSet.Count < numberOfElements - 1) // Заполнять до указанного количества элементов
            {
                hashSet.Add(CreateString());
            }

            return hashSet;
        }


        /// <summary>
        /// Заполнить массив произвольными числами
        /// </summary>
        /// <param name="numberOfElements">Количество элементов</param>
        /// <returns>Заполненный массив</returns>
        private static int[] FillIntArray(int numberOfElements)
        {
            int[] array = new int[numberOfElements];

            for (int i = 0; i < numberOfElements; i++)
            {
                array[i] = rnd.Next(maxRandomNumber);
            }

            return array;
        }


        /// <summary>
        /// Заполнить массив произвольными строками
        /// </summary>
        /// <param name="numberOfElements">Количество элементов</param>
        /// <returns>Заполненный массив</returns>
        private static string[] FillStringArray(int numberOfElements)
        {
            string[] array = new string[numberOfElements];

            for (int i = 0; i < numberOfElements; i++)
            {
                array[i] = CreateString();
            }

            return array;
        }


        /// <summary>
        /// Создать строку из произвольных символов
        /// </summary>
        /// <returns>Созданная строка</returns>
        private static string CreateString()
        {
            byte[] bytes = new byte[stringLenght];

            for (int i = 0; i < bytes.Length; i++)  // Создать массив из произвольных байтов
            {
                bytes[i] = (byte)rnd.Next(32, 126);
            }

            sb.Clear();

            for (int i = 0; i < bytes.Length; i++) // Перевести байты в символы и затем в строку
            {
                sb.Append((char)bytes[i]);
            }

            return sb.ToString();
        }
    }
}
