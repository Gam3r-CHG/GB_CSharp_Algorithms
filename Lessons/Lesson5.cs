using System;
using Algorithms.BinaryTree;

namespace Algorithms.Lessons
{
    /// <summary>
    /// Пятый урок
    /// </summary>
    internal class Lesson5
    {
        /// <summary>
        /// Меню 5 урока (опции)
        /// </summary>
        /// <param name="option">Опция меню</param>
        public static void MenuOptions(int option)
        {
            switch (option)
            {
                case 1:
                    TestBinaryTreeSearch(); // Задание 1. Поиск по бинарному дереву
                    Helpers.PressAnyKey(1);
                    break;
            }
        }

        private static void TestBinaryTreeSearch()
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();

            Console.WriteLine("Добавить в узел 10 значений: 10, 8, 12, 6, 9, 11, 15, 4, 14, 20.");
            binaryTree.Add(10); //                        10
            binaryTree.Add(8);  //                      /    \
            binaryTree.Add(12); //                     8      12 
            binaryTree.Add(6);  //                   /  \    /  \  
            binaryTree.Add(9);  //                  6    9  11  15
            binaryTree.Add(11); //                 /            / \
            binaryTree.Add(15); //                4           14   20
            binaryTree.Add(4);
            binaryTree.Add(14);
            binaryTree.Add(20);
            
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("                        10");
            Console.WriteLine("                      /    \\");
            Console.WriteLine("                     8      12");
            Console.WriteLine("                   /  \\    /  \\");
            Console.WriteLine("                  6    9  11  15");
            Console.WriteLine("                 /            / \\");
            Console.WriteLine("                4           14   20");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Количество элементов в дереве: " + binaryTree.Count);
            
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("После нахождения элемента, проход по дереву не останавливается.");
            Console.WriteLine("Нужный элемент подсвечивается красным цветом");
            Console.WriteLine();
            Console.WriteLine("Запускаем поиск в глубину (3 вида, рекурсивные алгоритмы)");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write("Поиск значения 9 (InOrder): ");
            binaryTree.SearchInOrder(9);
            Console.WriteLine();
            Console.Write("Поиск значения 11 (PreOrder): ");
            binaryTree.SearchPreOrder(11);
            Console.WriteLine();
            Console.Write("Поиск значения 15 (PostOrder): ");
            binaryTree.SearchPostOrder(15);
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Запускаем поиск в ширину (используем очередь)");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write("Поиск значения 14: ");
            binaryTree.SearchBFS(14);
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");
        }

    }
}
