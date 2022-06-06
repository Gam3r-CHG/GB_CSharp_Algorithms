using System;

namespace Algorithms
{
    /// <summary>
    /// Методы для работы с массивами
    /// </summary>
    internal class ArrayTest
    {

        public static int[] SortArray(int[] array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];
            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    (array[i], array[j]) = (array[j], array[i]);
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                SortArray(array, leftIndex, j);
            if (i < rightIndex)
                SortArray(array, i, rightIndex);
            return array;
        }








        public static int[] QuickSort(int[] a, int i, int j)
        {
            if (i < j)
            {
                int q = Partition(a, i, j);
                a = QuickSort(a, i, q);
                a = QuickSort(a, q + 1, j);
            }
            return a;
        }

        public static int Partition(int[] a, int p, int r)
        {
            int x = a[p];
            int i = p - 1;
            int j = r + 1;
            while (true)
            {
                do
                {
                    j--;
                }
                while (a[j] > x);
                do
                {
                    i++;
                }
                while (a[i] < x);
                if (i < j)
                {
                    int tmp = a[i];
                    a[i] = a[j];
                    a[j] = tmp;
                }
                else
                {
                    return j;
                }
            }
        }









        static void Swap(int[] array, int i, int j)
        {
            (array[i], array[j]) = (array[j], array[i]);
        }
        public static void InsertionSort(int[] inArray)
        {
            long numberOfComparison = 0;        // Для подсчета количества сравнений
            int x;
            int j;
            for (int i = 1; i < inArray.Length; i++)
            {
                x = inArray[i];
                j = i;
                while (j > 0 && inArray[j - 1] > x)
                {
                    numberOfComparison++;
                    Swap(inArray, j, j - 1);
                    j -= 1;
                }
                inArray[j] = x;
            }

            Console.WriteLine("Всего сравнений: " + numberOfComparison.ToString("#,#"));
        }



        /// <summary>
        /// Улучшенная "пузырьковая" сортировка массива со счетчиков процесса. В 2 раза меньше сравнений.
        /// </summary>
        /// <param name="array">Массив</param>
        public static void BubbleSortPlus(int[] array)
        {
            Console.Write($"Итерация сортировки:  ");

            int percent = array.Length / 100;   // 1/100 количества элементов массива
            int percentsStatus = 1;             // Счетчик процентов от 1 до 100
            long numberOfComparison = 0;        // Для подсчета количества сравнений

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++) // Каждый новый проход уменьшается на 1
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j + 1], array[j]) = (array[j], array[j + 1]);
                    }
                    numberOfComparison++;
                }

                if ((i + 1) % percent == 0) // Вывод счетчика прогресса сортировки
                {

                    Console.SetCursorPosition(20, Console.CursorTop); // Перезапись цифр счетчика
                    Console.Write($" {percentsStatus++}/100");
                }
            }
            Console.WriteLine("\nВсего сравнений: " + numberOfComparison.ToString("#,#"));
        }


        /// <summary>
        /// "Пузырьковая" сортировка массива со счетчиков процесса
        /// </summary>
        /// <param name="array">Массив</param>
        public static void BubbleSort(int[] array)
        {
            Console.Write($"Итерация сортировки:  ");

            int procent = array.Length / 100;       // 1/100 количества элементов массива
            int percentStatus = 1;                  // Счетчик процентов от 1 до 100
            long numberOfComparison = 0;            // Для подсчета количества сравнений

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j + 1], array[j]) = (array[j], array[j + 1]);
                    }
                    numberOfComparison++;
                }

                if ((i + 1) % procent == 0) // Вывод счетчика прогресса сортировки
                {

                    Console.SetCursorPosition(20, Console.CursorTop); // Перезапись цифр счетчика
                    Console.Write($" {percentStatus++}/100");
                }
            }

            Console.WriteLine("\nВсего сравнений: " + numberOfComparison.ToString("#,#"));
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
