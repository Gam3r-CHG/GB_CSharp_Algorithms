using Algorithms.Node;
using System;
using System.Diagnostics;

namespace Algorithms.Lessons
{
    /// <summary>
    /// Второй урок
    /// </summary>
    internal class Lesson2 : ILessons
    {
        public static string LessonName = "Урок 2";
        public static string LessonDescription = "Задания урока 2";

        public static string[,] LessonMenuArray =
        {
            {"Тест односвязного списка", "NodeTest"},
            {"Тест двусвязного списка", "DoubleNodeTest"},
            {"Тест сортировки и поиска в массивах", "TestSearch"}
        };


        /// <summary>
        /// Тест односвязного списка
        /// </summary>
        public static void NodeTest()
        {
            Console.Clear();

            NodeList node = new NodeList();

            Console.Write("Список пустой? ");
            Console.WriteLine(node.IsEmpty());
            Console.WriteLine();

            Console.WriteLine("--- Добавляем элементы ------------------------------------------");
            node.AddNodeFirst(2);
            node.AddNode(3);
            node.AddNodeFirst(1);
            node.AddNode(5);
            node.AddNode(6);
            node.AddNode(7);
            node.AddNode(8);
            node.AddNode(9);
            node.AddNode(0);
            node.Print();
            Console.Write("Список пустой? ");
            Console.WriteLine(node.IsEmpty());
            Console.WriteLine();

            Console.WriteLine("--- Сортируем элементы ------------------------------------------");
            node.BubbleSort();
            node.Print();
            Console.WriteLine();

            Console.WriteLine("--- Найти элемент 9 ---------------------------------------------");
            node.PrintNode(node.FindNode(9));
            Console.WriteLine();

            Console.WriteLine("--- Удаляем элементы со значением 8, 9, 0 -----------------------");
            node.RemoveNode(node.FindNode(8));
            node.RemoveNode(node.FindNode(9));
            node.RemoveNode(node.FindNode(0));
            node.Print();
            Console.WriteLine();

            Console.WriteLine("--- Вставляем после \"3\" значение \"4\" ------------------------");
            node.AddNodeAfter(node.FindNode(3), 4);
            node.Print();
            Console.WriteLine();

            Console.WriteLine("--- Ищем и удаляем элементы  со значением 1, 6, 7 ---------------");
            node.Remove(1);
            node.Remove(6);
            node.Remove(7);
            node.Print();
            Console.WriteLine();

            Console.WriteLine("--- Удаляем первый и последний элемент --------------------------");
            node.RemoveFirst();
            node.RemoveNode(2);
            node.Print();
            Console.WriteLine();

            Console.WriteLine("--- Удаляем список ----------------------------------------------");
            node.Clear();
            node.Print();
            Console.WriteLine();

            Helpers.PressAnyKey(1);
        }



        /// <summary>
        /// Тест двусвязного списка
        /// </summary>
        public static void DoubleNodeTest()
        {
            Console.Clear();

            NodeDoubleList node = new NodeDoubleList();

            Console.Write("Список пустой? ");
            Console.WriteLine(node.IsEmpty());
            Console.WriteLine();

            Console.WriteLine("--- Добавляем элементы ------------------------------------------");
            node.AddNodeFirst(2);
            node.AddNode(3);
            node.AddNodeFirst(1);
            node.AddNode(5);
            node.AddNode(6);
            node.AddNode(7);
            node.AddNode(8);
            node.AddNode(9);
            node.AddNode(0);
            node.Print();
            Console.Write("Список пустой? ");
            Console.WriteLine(node.IsEmpty());
            Console.WriteLine();

            Console.WriteLine("--- Сортируем элементы ------------------------------------------");
            node.BubbleSort();
            node.Print();
            Console.WriteLine();

            Console.WriteLine("--- Найти элемент 9 ---------------------------------------------");
            node.PrintNode(node.FindNode(9));
            Console.WriteLine();

            Console.WriteLine("--- Удаляем элементы со значением 8, 9, 0 -----------------------");
            node.RemoveNode(node.FindNode(8));
            node.RemoveNode(node.FindNode(9));
            node.RemoveNode(node.FindNode(0));
            node.Print();
            Console.WriteLine();

            Console.WriteLine("--- Вставляем после \"3\" значение \"4\" ------------------------");
            node.AddNodeAfter(node.FindNode(3), 4);
            node.Print();
            Console.WriteLine();

            Console.WriteLine("--- Ищем и удаляем элементы  со значением 1, 6, 7 ---------------");
            node.Remove(1);
            node.Remove(6);
            node.Remove(7);
            node.Print();
            Console.WriteLine();

            Console.WriteLine("--- Удаляем первый и последний элемент --------------------------");
            node.RemoveFirst();
            node.RemoveLast();
            node.Print();
            Console.WriteLine();

            Console.WriteLine("--- Удаляем список ----------------------------------------------");
            node.Clear();
            node.Print();
            Console.WriteLine();

            Helpers.PressAnyKey(1);
        }


        /// <summary>
        /// Тестовый метод. Проверка и сравнение методов работы с массивами.
        /// </summary>
        public static void TestSearch()
        {
            const int NUMBER_OF_ELEMENTS = 200_000;
            const int SEARCH_NUMBER_1 = 33_000;
            const int SEARCH_NUMBER_2 = 123456789;
            const int TEST_INDEX_1 = 33_000;
            const int TEST_INDEX_2 = 34_000;

            Console.Clear();

            Console.WriteLine($"Создаем массив из {NUMBER_OF_ELEMENTS:#,#} произвольных элементов");
            Stopwatch sw = new Stopwatch();

            sw.Start();
            int[] arrayTest = ArrayTest.FillArray(NUMBER_OF_ELEMENTS, NUMBER_OF_ELEMENTS);
            sw.Stop();
            Console.WriteLine($"Массив создан за {sw.ElapsedMilliseconds} мс. и {sw.ElapsedTicks} тактов");
            Console.WriteLine("------------------------------------------------------------------------------------");

            Console.WriteLine($"Помещаем элемент {SEARCH_NUMBER_2} в ячейку {TEST_INDEX_1}");
            arrayTest[TEST_INDEX_1] = SEARCH_NUMBER_2;
            Console.WriteLine($"Запускаем линейный поиск элемента со значением {SEARCH_NUMBER_2}. Сложность от O(N)");
            sw.Restart();
            (long, int) index = SearchTest.SimpleFind(arrayTest, SEARCH_NUMBER_2);
            sw.Stop();
            Console.WriteLine($"Элемент {index.Item1} найден за {index.Item2} итераций, {sw.ElapsedMilliseconds} мс. и {sw.ElapsedTicks} тактов");
            Console.WriteLine("------------------------------------------------------------------------------------");

            Console.WriteLine($"Создаем массив из {NUMBER_OF_ELEMENTS} последовательных элементов");
            sw.Restart();
            int[] arrayTest2 = ArrayTest.FillArraySorted(NUMBER_OF_ELEMENTS);
            sw.Stop();
            Console.WriteLine($"Массив создан за {sw.ElapsedMilliseconds} мс. и {sw.ElapsedTicks} тактов");
            Console.WriteLine("------------------------------------------------------------------------------------");

            Console.WriteLine($"Запускаем двоичный поиск элемента со значением {SEARCH_NUMBER_1}. Сложность O(log N)");
            sw.Restart();
            index = SearchTest.BinarySearch(arrayTest2, SEARCH_NUMBER_1);
            sw.Stop();
            Console.WriteLine($"Элемент {index.Item1} найден за {index.Item2} итераций, {sw.ElapsedMilliseconds} мс. и {sw.ElapsedTicks} тактов");
            Console.WriteLine("------------------------------------------------------------------------------------");

            Console.WriteLine($"Запускаем интерполяционный поиск элемента со значением {SEARCH_NUMBER_1}. Сложность от O(log (log N)) до O(N).");
            sw.Start();
            index = SearchTest.InterpolationSearch(arrayTest2, NUMBER_OF_ELEMENTS, SEARCH_NUMBER_1);
            sw.Stop();
            Console.WriteLine($"Элемент {index.Item1} найден за {index.Item2} итераций, {sw.ElapsedMilliseconds} мс. и {sw.ElapsedTicks} тактов");
            Console.WriteLine("------------------------------------------------------------------------------------");

            //????????????????????????????????????????????????????????????????????????????????????
            // Вопрос для преподавателя:
            // У меня почему-то при всех вариантах интерполяционный поиск всегда дольше бинарного.
            // В теории должно же быть наоборот. Почему так?
            //????????????????????????????????????????????????????????????????????????????????????

            Console.WriteLine($"Помещаем элемент {SEARCH_NUMBER_1} в ячейку {TEST_INDEX_2} в массив с произвольными числами");
            arrayTest[TEST_INDEX_2] = SEARCH_NUMBER_1;
            int[] arrayTemp0 = new int[NUMBER_OF_ELEMENTS];
            int[] arrayTemp1 = new int[NUMBER_OF_ELEMENTS];
            int[] arrayTemp2 = new int[NUMBER_OF_ELEMENTS];
            int[] arrayTemp3 = new int[NUMBER_OF_ELEMENTS];
            int[] arrayTemp4 = new int[NUMBER_OF_ELEMENTS];
            int[] arrayTemp5 = new int[NUMBER_OF_ELEMENTS];

            Array.Copy(arrayTest, arrayTemp0, NUMBER_OF_ELEMENTS);
            Array.Copy(arrayTest, arrayTemp1, NUMBER_OF_ELEMENTS);
            Array.Copy(arrayTest, arrayTemp2, NUMBER_OF_ELEMENTS);
            Array.Copy(arrayTest, arrayTemp3, NUMBER_OF_ELEMENTS);
            Array.Copy(arrayTest, arrayTemp4, NUMBER_OF_ELEMENTS);

            Console.WriteLine("Запускаем простую сортировку массива с произвольными числами");
            Console.WriteLine("Запаситесь терпеньем ;)");
            sw.Restart();
            ArrayTest.BubbleSort(arrayTest);
            sw.Stop();
            Console.WriteLine($"Массив отсортирован за {sw.ElapsedMilliseconds} мс. и {sw.ElapsedTicks} тактов");
            Console.WriteLine("------------------------------------------------------------------------------------");

            Console.WriteLine("Запускаем улучшенную \"пузырьковую\" сортировку массива с произвольными числами");
            Console.WriteLine("Запаситесь терпеньем ;)");
            sw.Restart();
            ArrayTest.BubbleSortPlus(arrayTemp0);
            sw.Stop();
            Console.WriteLine($"Массив отсортирован за {sw.ElapsedMilliseconds} мс. и {sw.ElapsedTicks} тактов");
            Console.WriteLine("------------------------------------------------------------------------------------");

            Console.WriteLine("Для сравнения сортировка вставками");
            sw.Restart();
            ArrayTest.InsertionSort(arrayTemp2);
            sw.Stop();
            Console.WriteLine($"Массив отсортирован за {sw.ElapsedMilliseconds} мс. !!! и {sw.ElapsedTicks} тактов");
            Console.WriteLine("------------------------------------------------------------------------------------");

            Console.WriteLine("Для сравнения сортировка QuickSort");
            sw.Restart();
            ArrayTest.QuickSort(arrayTemp3, 0, arrayTemp3.Length - 1);
            sw.Stop();
            Console.WriteLine($"Массив отсортирован за {sw.ElapsedMilliseconds} мс. !!! и {sw.ElapsedTicks} тактов");
            Console.WriteLine("------------------------------------------------------------------------------------");

            Console.WriteLine("Для сравнения сортировка QuickSort2");
            sw.Restart();
            arrayTemp5 = ArrayTest.SortArray(arrayTemp4, 0, arrayTemp4.Length - 1);
            sw.Stop();
            Console.WriteLine($"Массив отсортирован за {sw.ElapsedMilliseconds} мс. !!! и {sw.ElapsedTicks} тактов");
            Console.WriteLine("------------------------------------------------------------------------------------");

            Console.WriteLine("Для сравнения сортировка штатными средствами C#");
            sw.Restart();
            Array.Sort(arrayTemp1);
            sw.Stop();
            Console.WriteLine($"Массив отсортирован за {sw.ElapsedMilliseconds} мс. !!! и {sw.ElapsedTicks} тактов");
            Console.WriteLine("------------------------------------------------------------------------------------");

            Console.WriteLine($"Запускаем линейный поиск элемента со значением {SEARCH_NUMBER_2}.");
            Console.WriteLine("Теперь он последний в массиве. Сложность от O(N)");
            sw.Restart();
            index = SearchTest.SimpleFind(arrayTest, SEARCH_NUMBER_2);
            sw.Stop();
            Console.WriteLine($"Элемент {index.Item1} найден за {index.Item2} итераций, {sw.ElapsedMilliseconds} мс. и {sw.ElapsedTicks} тактов");
            Console.WriteLine("------------------------------------------------------------------------------------");

            Console.WriteLine($"Запускаем линейный поиск элемента со значением {SEARCH_NUMBER_1}.");
            sw.Restart();
            index = SearchTest.SimpleFind(arrayTest, SEARCH_NUMBER_1);
            sw.Stop();
            Console.WriteLine($"Элемент {index.Item1} найден за {index.Item2} итераций, {sw.ElapsedMilliseconds} мс. и {sw.ElapsedTicks} тактов");
            Console.WriteLine("------------------------------------------------------------------------------------");

            Console.WriteLine($"Запускаем двоичный поиск элемента со значением {SEARCH_NUMBER_1}. Сложность O(log N)");
            sw.Restart();
            index = SearchTest.BinarySearch(arrayTest, SEARCH_NUMBER_1);
            sw.Stop();
            Console.WriteLine($"Элемент {index.Item1} найден за {index.Item2} итераций, {sw.ElapsedMilliseconds} мс. и {sw.ElapsedTicks} тактов");
            Console.WriteLine("------------------------------------------------------------------------------------");

            Console.WriteLine($"Запускаем интерполяционный поиск элемента со значением {SEARCH_NUMBER_1}. Сложность от O(log (log N)) до O(N).");
            sw.Start();
            index = SearchTest.InterpolationSearch(arrayTest, NUMBER_OF_ELEMENTS, SEARCH_NUMBER_1);
            sw.Stop();
            Console.WriteLine($"Элемент {index.Item1} найден за {index.Item2} итераций, {sw.ElapsedMilliseconds} мс. и {sw.ElapsedTicks} тактов");
            Console.WriteLine("------------------------------------------------------------------------------------");

            Helpers.PressAnyKey(1);
        }


        /// <summary>
        /// Вывести в консоль все элементы NodeList
        /// </summary>
        /// <param name="node">NodeList</param>
        public static void PrintNodes(NodeList node)
        {
            Console.Write("Элементы в NodeList: ");
            foreach (var item in node)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }


        /// <summary>
        /// Вывести в консоль все элементы NodeList
        /// </summary>
        /// <param name="node">NodeList</param>
        public static void PrintNodesBack(NodeDoubleList node)
        {
            Console.Write("Элементы в NodeDoubleList: ");
            foreach (var item in node.BackEnumerator())
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }


        /// <summary>
        /// Перевести массив в список NodeList
        /// </summary>
        /// <param name="array">Массив</param>
        /// <returns>Список NodeList</returns>
        public static NodeList ToList(int[] array)
        {
            NodeList node = new NodeList();
            foreach (var item in array)
            {
                node.AddNode(item);
            }
            return node;
        }



    }
}
