using Algorithms.Node;
using System;
using System.Diagnostics;

namespace Algorithms.Lessons
{
    /// <summary>
    /// Второй урок
    /// </summary>
    internal class Lesson2
    {
        /// <summary>
        /// Меню 2 урока (опции)
        /// </summary>
        /// <param name="option">Опция меню</param>
        public static void MenuOptions(int option)
        {
            switch (option)
            {
                case 1:
                    NodeTest(); // Задание 1. Односвязный список
                    Helpers.PressAnyKey(1);
                    break;
                case 2:
                    DoubleNodeTest(); // Задание 1. Двусвязный список
                    Helpers.PressAnyKey(1);
                    break;
                case 3:
                    TestSearch(); // Задание 2. Поиск и массивы
                    Helpers.PressAnyKey(1);
                    break;
            }
        }



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
        }


        /// <summary>
        /// Тестовый метод. Проверка и сравнение методов работы с массивами.
        /// </summary>
        public static void TestSearch()
        {
            Console.Clear();

            Console.WriteLine("Создаем массив из 100.000 произвольных элементов");
            Stopwatch sw = new Stopwatch();

            sw.Start();
            int[] arrayTest = ArrayTest.FillArray(100_000, 99_999);
            sw.Stop();
            Console.WriteLine($"Массив создан за {sw.ElapsedMilliseconds} мс. и {sw.ElapsedTicks} тактов");
            Console.WriteLine("------------------------------------------------------------------------------------");

            Console.WriteLine("Помещаем элемент '123456789' в ячейку 33.000");
            arrayTest[33_000] = 123456789;
            Console.WriteLine("Запускаем линейный поиск элемента со значением 123456789. Сложность от O(N)");
            sw.Restart();
            long index = SearchTest.SimpleFind(arrayTest, 123456789);
            sw.Stop();
            Console.WriteLine($"Элемент {index} найден за {sw.ElapsedMilliseconds} мс. и {sw.ElapsedTicks} тактов");
            Console.WriteLine("------------------------------------------------------------------------------------");

            Console.WriteLine("Создаем массив из 100.000 последовательных элементов");
            sw.Restart();
            int[] arrayTest2 = ArrayTest.FillArraySorted(100_000);
            sw.Stop();
            Console.WriteLine($"Массив создан за {sw.ElapsedMilliseconds} мс. и {sw.ElapsedTicks} тактов");
            Console.WriteLine("------------------------------------------------------------------------------------");

            Console.WriteLine("Запускаем двоичный поиск элемента со значением 33.000. Сложность O(log N)");
            sw.Restart();
            index = SearchTest.BinarySearch(arrayTest2, 33_000);
            sw.Stop();
            Console.WriteLine($"Элемент {index} найден за {sw.ElapsedMilliseconds} мс. и {sw.ElapsedTicks} тактов");
            Console.WriteLine("------------------------------------------------------------------------------------");

            Console.WriteLine("Запускаем интерполяционный поиск элемента со значением 33.000. Сложность от O(log (log N)) до O(N).");
            sw.Start();
            index = SearchTest.InterpolationSearch(arrayTest2, 100_000, 33_000);
            sw.Stop();
            Console.WriteLine($"Элемент {index} найден за {sw.ElapsedMilliseconds} мс. и {sw.ElapsedTicks} тактов");
            Console.WriteLine("------------------------------------------------------------------------------------");

            //????????????????????????????????????????????????????????????????????????????????????
            // Вопрос для преподавателя:
            // У меня почему-то при всех вариантах интерполяционный поиск всегда дольше бинарного.
            // В теории должно же быть наоборот. Почему так?
            //????????????????????????????????????????????????????????????????????????????????????

            Console.WriteLine("Помещаем элемент '33.000' в ячейку 34.000 в массив с произвольными числами");
            arrayTest[34_000] = 33_000;
            int[] arrayTemp = new int[100_000];
            Array.Copy(arrayTest, arrayTemp, 100_000);
            Console.WriteLine("Запускаем простую сортировку массива с произвольными числами");
            Console.WriteLine("Запаситесь терпеньем ;)");
            sw.Restart();
            ArrayTest.BubbleSort(arrayTest);
            sw.Stop();
            Console.WriteLine();
            Console.WriteLine($"Массив отсортирован за {sw.ElapsedMilliseconds} мс. и {sw.ElapsedTicks} тактов");
            Console.WriteLine("------------------------------------------------------------------------------------");

            Console.WriteLine("Для сравнения сортировка штатными средствами C#");
            sw.Restart();
            Array.Sort(arrayTemp);
            sw.Stop();
            Console.WriteLine($"Массив отсортирован за {sw.ElapsedMilliseconds} мс. !!! и {sw.ElapsedTicks} тактов");
            Console.WriteLine("------------------------------------------------------------------------------------");

            Console.WriteLine("Запускаем линейный поиск элемента со значением 123456789. ");
            Console.WriteLine("Теперь он последний в массиве. Сложность от O(N)");
            sw.Restart();
            index = SearchTest.SimpleFind(arrayTest, 123456789);
            sw.Stop();
            Console.WriteLine($"Элемент {index} найден за {sw.ElapsedMilliseconds} мс. и {sw.ElapsedTicks} тактов");
            Console.WriteLine("------------------------------------------------------------------------------------");

            Console.WriteLine("Запускаем линейный поиск элемента со значением 33.000.");
            sw.Restart();
            index = SearchTest.SimpleFind(arrayTest, 33_000);
            sw.Stop();
            Console.WriteLine($"Элемент {index} найден за {sw.ElapsedMilliseconds} мс. и {sw.ElapsedTicks} тактов");
            Console.WriteLine("------------------------------------------------------------------------------------");

            Console.WriteLine("Запускаем двоичный поиск элемента со значением 33.000. Сложность O(log N)");
            sw.Restart();
            index = SearchTest.BinarySearch(arrayTest, 33_000);
            sw.Stop();
            Console.WriteLine($"Элемент {index} найден за {sw.ElapsedMilliseconds} мс. и {sw.ElapsedTicks} тактов");
            Console.WriteLine("------------------------------------------------------------------------------------");

            Console.WriteLine("Запускаем интерполяционный поиск элемента со значением 33.000. Сложность от O(log (log N)) до O(N).");
            sw.Start();
            index = SearchTest.InterpolationSearch(arrayTest, 100_000, 33_000);
            sw.Stop();
            Console.WriteLine($"Элемент {index} найден за {sw.ElapsedMilliseconds} мс. и {sw.ElapsedTicks} тактов");
            Console.WriteLine("------------------------------------------------------------------------------------");

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
