using System;
using Algorithms.BinaryTree;
using Algorithms.Benchmark;

namespace Algorithms.Lessons
{
    /// <summary>
    /// Третий урок
    /// </summary>
    internal class Lesson4
    {
        /// <summary>
        /// Меню 3 урока (опции)
        /// </summary>
        /// <param name="option">Опция меню</param>
        public static void MenuOptions(int option)
        {
            switch (option)
            {
                case 1:
                    TestBinaryTree(); // Задание 1. Бинарное дерево поиска
                    Helpers.PressAnyKey(1);
                    break;
                case 2:
                    HashTest.TestSpeedSearch(); // Задание 2. Сравнение скорости HashSet и массива
                    Helpers.PressAnyKey(1);
                    break;
            }
        }

        private static void TestBinaryTree()
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();

            Console.WriteLine("Добавить в узел 10 значений: 10, 8, 12, 6, 9, 11, 15, 4, 14, 20.");
            binaryTree.Add(10); //                        10
            binaryTree.Add(8); //                      /   \
            binaryTree.Add(12); //                     8    12 
            binaryTree.Add(6); //                    / \   / \  
            binaryTree.Add(9); //                   6   9 11 15
            binaryTree.Add(11); //                  /         / \
            binaryTree.Add(15); //                 4        14   20
            binaryTree.Add(4);
            binaryTree.Add(14);
            binaryTree.Add(20);
            Console.WriteLine("Количество элементов в дереве: " + binaryTree.Count);

            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write("Вывести значения по порядку (InOrder): ");
            binaryTree.InOrder();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Вывести дерево графически сверху вниз (PreOrder):");
            binaryTree.PreOrder();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write("Вывести снизу вверх (PostOrder): ");
            binaryTree.PostOrder();
            Console.WriteLine();

            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write("Вывести по порядку через foreach: ");
            foreach (var item in binaryTree)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Удалить узлы со значением 8 и 11");
            binaryTree.Remove(8);
            binaryTree.Remove(11);
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Вывести дерево графически сверху вниз (PreOrder):");
            binaryTree.PreOrder();
            Console.WriteLine();
            Console.WriteLine("Количество элементов в дереве: " + binaryTree.Count);
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Проверить содержит ли дерево значения 8, 10, 11:");
            Console.WriteLine("Дерево содержит узел со значением 8: {0}", binaryTree.Contains(8));
            Console.WriteLine("Дерево содержит узел со значением 10: {0}", binaryTree.Contains(10));
            Console.WriteLine("Дерево содержит узел со значением 15: {0}", binaryTree.Contains(11));
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Очищаем дерево");
            binaryTree.Clear();
            Console.WriteLine("Количество элементов в дереве: " + binaryTree.Count);
            Console.WriteLine("-----------------------------------------------------------------");
        }

    }
}
