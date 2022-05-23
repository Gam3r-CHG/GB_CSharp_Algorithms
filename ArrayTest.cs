using System;

namespace Algorithms
{
    /// <summary>
    /// Методы для работы с массивами
    /// </summary>
    internal class ArrayTest
    {

        /// <summary>
        /// "Пузырьковая" сортировка массива со счетчиков процесса
        /// </summary>
        /// <param name="array">Массив</param>
        public static void BubbleSort(int[] array)
        {
            Console.Write($"Итерация сортировки:  ");

            int procent1_100 = array.Length / 100;  // 1/100 количества элементов массива
            int procent = 1;                        // Счетчик процентов от 1 до 100
            
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        var temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }

                }

                if ((i+1) % procent1_100 == 0) // Вывод счетчика прогресса сортировки
                { 

                    Console.SetCursorPosition(20, Console.CursorTop); // Перезапись цифр счетчика
                    Console.Write($" {procent++}/100"); 
                }
            }
        }


        /// <summary>
        /// Заполнить массив произвольными числами
        /// </summary>
        /// <param name="number">Количество элементов массива</param>
        /// <param name="maxNumber">Максимум для чисел (по умолчанию 99.999)</param>
        /// <returns>Созданный массив</returns>
        public static int[] FillArray(int number, int maxNumber = 100_000)
        {
            Random random = new Random();
            int[] array = new int[number];

            for (int i = 0; i < number; i++)
            {
                array[i] = random.Next(maxNumber);
            }

            return array;
        }


        /// <summary>
        /// Заполнить массив последовательно числами. Числа от 0 до количества элементов
        /// </summary>
        /// <param name="number">Количество элементов массива</param>
        /// <returns>Созданный массив</returns>
        public static int[] FillArraySorted(int number)
        {
            int[] array = new int[number];

            for (int i = 0; i < number; i++)
            {
                array[i] = i;
            }

            return array;
        }


        /// <summary>
        /// Вывести массив на экран (через пробел в строку)
        /// </summary>
        /// <param name="array">Массив</param>
        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }


        /// <summary>
        /// Вывести (через пробел) каждый 500 элемент массива. Тестовый метод
        /// </summary>
        /// <param name="array">Массив</param>
        public static void PrintArrayBy500(int[] array)
        {
            Console.WriteLine("Массив (каждый 500 элемент): ");
            for (int i = 0; i < array.Length; i += 500)
            {
                if (i < array.Length) { Console.Write(array[i] + " "); }
            }
            Console.WriteLine();
        }
    }
}
