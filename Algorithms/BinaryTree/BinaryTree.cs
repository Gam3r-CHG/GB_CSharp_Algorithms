using System;
using System.Collections.Generic;

namespace Algorithms.BinaryTree
{
    /// <summary>
    /// Двоичное дерево поиска 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private BinaryTreeNode<T> _root;  // Корень дерева

        private int _count;  // Для счетчика элементов
        public int Count { get { return _count; } } // Получить количество элементов в дереве


        /// <summary>
        /// Добавить новый узел
        /// </summary>
        /// <param name="value">Значение узла</param>
        public void Add(T value)
        {
            if (_root == null)  // Если дерево пустое, создаем корень дерева  
            {
                _root = new BinaryTreeNode<T>(value);
            }
            else  // Если не пустое - рекурсивный алгоритм для поиска куда можно добавить новый узел
            {
                FindWhereToAdd(_root, value);
            }
            _count++;
        }


        /// <summary>
        /// Рекурсивный алгоритм вставки элемента в дерево
        /// </summary>
        /// <param name="node">Элемент (узел) дерева</param>
        /// <param name="value">Значение элемента</param>
        private void FindWhereToAdd(BinaryTreeNode<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)                // Если значение добавляемого узла меньше чем значение текущего.
            {
                if (node.Left == null)                          // Если левый потомок у текущего узла отсутствует - создаем его
                {
                    node.Left = new BinaryTreeNode<T>(value);
                }
                else
                {
                    FindWhereToAdd(node.Left, value);           // Иначе повторяем операцию (ищем дальше), переходим глубже  
                }
            }
            else                                                // Если значение добавляемого узла больше или равно текущего значения
            {
                if (node.Right == null)                         // Если правый потомок у текущего узла отсутствует - создаем его
                {
                    node.Right = new BinaryTreeNode<T>(value);
                }
                else
                {
                    FindWhereToAdd(node.Right, value);          // Иначе повторяем операцию, переходи глубже
                }
            }
        }


        /// <summary>
        /// Определить с помощью метода FindNodeWithParent содержит ли дереву это значение.
        /// </summary>
        /// <param name="value">Значение для поиска</param>
        /// <returns>True or False</returns>
        public bool Contains(T value)
        {
            BinaryTreeNode<T> parent;
            return FindNodeWithParent(value, out parent) != null;
        }


        /// <summary>
        /// Найти первый узел с указанным значением
        /// </summary>
        /// <param name="value">Значение для поиска</param>
        /// <param name="parent">Родительский узел</param>
        /// <returns>Возвращает первый найденный узел и родительский узел для найденного значения. Если не найдено, возвращает null.</returns>
        private BinaryTreeNode<T> FindNodeWithParent(T value, out BinaryTreeNode<T> parent)
        {
            BinaryTreeNode<T> current = _root;
            parent = null;

            while (current != null)     // Пока текущий узел на пустой
            {
                int result = current.CompareTo(value);  // сравнение значения текущего элемента с искомым значением
                if (result > 0)                         // Если искомое значение меньше значение текущего узла - переходим к левому потомку. 
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)                    // Если искомое значение больше значение текущего узла - переходим к правому потомку.
                {
                    parent = current;
                    current = current.Right;
                }
                else  // Значит элемент найден
                {
                    break;
                }
            }
            return current;
        }


        /// <summary>
        /// Удалить узел с указанным значением
        /// </summary>
        /// <param name="value">Значение</param>
        /// <returns>True or False</returns>
        public bool Remove(T value)
        {
            BinaryTreeNode<T> current;
            BinaryTreeNode<T> parent;

            current = FindNodeWithParent(value, out parent);  // Поиск узла для удаления

            if (current == null) { return false; }            // Если значение отсутствует в дереве

            _count--;

            // Для удаления узла нужно рассмотреть три варианта размещения узла:
            // 1. У удаляемого узла нет правого потомка
            // 2. У удаляемого узла есть правый потомок, у которого нет левого потомка.
            // 3. У удаляемого узла есть правый потомок, у которого есть левый потомок.

            if (current.Right == null)  // 1. У удаляемого узла нет правого потомка 
            {
                if (parent == null)  // Проверяем: если удаляемый узел корень дерева, просто меняем узлы местами
                {
                    _root = current.Left;
                }
                else
                {
                    int result = parent.CompareTo(current.Value); // Сравниваем значения

                    if (result > 0)                 // Если значение у родительского узла больше
                    {
                        parent.Left = current.Left; // Делаем левого потомка - левым потомком родительского узла
                    }
                    else if (result < 0)            // Иначе делаем левого потомка - правым потомком родительского узла
                    {
                        parent.Right = current.Left;
                    }
                }
            }
            else if (current.Right.Left == null)  // 2. У удаляемого узла есть правый потомок, у которого нет левого потомка.
            {
                current.Right.Left = current.Left;

                if (parent == null)  // Проверяем: если удаляемый узел корень дерева, просто меняем узлы местами
                {
                    _root = current.Right;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);   // Сравниваем значения
                    if (result > 0)                                 // Если значение у родительского узла больше
                    {
                        parent.Left = current.Right;                // Делаем правого потомка - левым потомком родительского узла
                    }
                    else if (result < 0)                            // Иначе делаем правого потомка - правым потомком родительского узла
                    {
                        parent.Right = current.Right;
                    }
                }
            }
            else  // 3. У удаляемого узла есть правый потомок, у которого есть левый потомок.
            {

                BinaryTreeNode<T> endLeft = current.Right.Left;     // Для вычисления самого левого потомка
                BinaryTreeNode<T> endLeftParent = current.Right;    // И его родительского узла


                while (endLeft.Left != null)    // Ищем самого левого (крайнего) потомка 
                {
                    endLeftParent = endLeft;
                    endLeft = endLeft.Left;
                }

                endLeftParent.Left = endLeft.Right;  // Правое поддерево крайнего левого узла, становится левым поддеревом его родительского узла.

                // Присваиваем крайнему левому узлу:
                endLeft.Left = current.Left;        // в качестве левого потомка - левый потомок удаляемого узла,
                endLeft.Right = current.Right;      // в качестве правого потомка - правый потомок удаляемого узла. 

                if (parent == null)  // Проверяем: если удаляемый узел корень дерева, просто меняем узлы местами
                {
                    _root = endLeft;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);   // Сравниваем значения

                    if (result > 0)                                 // Если значение у родительского узла больше
                    {
                        parent.Left = endLeft;                      // Делаем левого крайнего потомка - левым потомком его родительского узла
                    }
                    else if (result < 0)                            // Иначе
                    {
                        parent.Right = endLeft;                     // Делаем левого крайнего потомка - правым потомком его родительского узла
                    }
                }
            }

            return true; // Если удаление успешно
        }


        /// <summary>
        /// Удалить дерево
        /// </summary>
        public void Clear()
        {
            _root = null;
            _count = 0;
        }


        public IEnumerator<T> GetEnumerator() // Для foreach
        {
            return InOrderTraversal();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        /// <summary>
        /// Вывести дерево на экран (InOrder)
        /// </summary>
        public void PrintInOrder()
        {
            PrintInOrder(_root);
        }

        private void PrintInOrder(BinaryTreeNode<T> node)
        {
            if (node.Left != null)
                PrintInOrder(node.Left);

            Console.Write(node.Value + " ");

            if (node.Right != null)
                PrintInOrder(node.Right);
        }


        /// <summary>
        /// Поиск в дереве DFS (InOrder) рекурсия
        /// </summary>
        public void SearchInOrder(T searchValue)
        {
            SearchInOrder(_root, searchValue);
        }

        private void SearchInOrder(BinaryTreeNode<T> node, T searchValue)
        {
            if (node.Left != null)
                SearchInOrder(node.Left, searchValue);
            if (node.Value.CompareTo(searchValue) == 0) { Helpers.WriteColor(node.Value.ToString() + " ", ConsoleColor.Red); }
            else { Console.Write(node.Value + " "); }

            if (node.Right != null)
                SearchInOrder(node.Right, searchValue);
        }


        /// <summary>
        /// Вывести дерево на экран (PostOrder)
        /// </summary>
        public void PrintPostOrder()
        {
            PrintPostOrder(_root);
        }

        private void PrintPostOrder(BinaryTreeNode<T> node)
        {
            if (node.Left != null)
                PrintPostOrder(node.Left);

            if (node.Right != null)
                PrintPostOrder(node.Right);

            Console.Write(node.Value + " ");
        }


        /// <summary>
        /// Поиск в дереве DFS (PostOrder) рекурсия
        /// </summary>
        public void SearchPostOrder(T searchValue)
        {
            SearchPostOrder(_root, searchValue);
        }

        private void SearchPostOrder(BinaryTreeNode<T> node, T searchValue)
        {
            if (node.Left != null)
                SearchPostOrder(node.Left, searchValue);

            if (node.Right != null)
                SearchPostOrder(node.Right, searchValue);

            if (node.Value.CompareTo(searchValue) == 0) { Helpers.WriteColor(node.Value.ToString() + " ", ConsoleColor.Red); }
            else { Console.Write(node.Value + " "); }
        }


        /// <summary>
        /// Вывести дерево на экран графически (PreOrder)
        /// </summary>
        public void PrintPreOrder()
        {
            int index = 0;
            PrintPreOrder(_root, index);
        }

        private void PrintPreOrder(BinaryTreeNode<T> node, int index)
        {
            string temp = "".PadLeft(index * 2, '─');
            Console.WriteLine("└" + temp + node.Value);
            index++;

            if (node.Left != null)
                PrintPreOrder(node.Left, index);

            if (node.Right != null)
                PrintPreOrder(node.Right, index);
        }


        /// <summary>
        /// Поиск в дереве DFS (PreOrder) рекурсия
        /// </summary>
        public void SearchPreOrder(T searchValue)
        {
            SearchPreOrder(_root, searchValue);
        }

        private void SearchPreOrder(BinaryTreeNode<T> node, T searchValue)
        {
            if (node.Value.CompareTo(searchValue) == 0) { Helpers.WriteColor(node.Value.ToString() + " ", ConsoleColor.Red); }
            else { Console.Write(node.Value + " "); }

            if (node.Left != null)
                SearchPreOrder(node.Left, searchValue);

            if (node.Right != null)
                SearchPreOrder(node.Right, searchValue);
        }


        /// <summary>
        /// Поиск в дереве BFS, с помощью очереди
        /// </summary>
        public void SearchBFS(T searchValue)
        {
            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(_root);
            while (queue.Count > 0)
            {
                BinaryTreeNode<T> current = queue.Dequeue();
                if (current == null)
                    continue;
                queue.Enqueue(current.Left);
                queue.Enqueue(current.Right);

                if (current.Value.CompareTo(searchValue) == 0) { Helpers.WriteColor(current.Value.ToString() + " ", ConsoleColor.Red); }
                else { Console.Write(current.Value + " "); }
            }
        }


        /// <summary>
        /// Для foreach. Вывести значения дерева по порядку, с помощью стека
        /// </summary>
        /// <returns></returns>
        private IEnumerator<T> InOrderTraversal()
        {
            if (_root != null)  // Если дерево не пустое
            {
                Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();  // Сохраняем структуру узла в стек 
                BinaryTreeNode<T> current = _root;

                // Будем отслеживать в какую сторону перемещаться по дереву (влево или вправо)
                // Для этого создаем переменную isGoLeftNext    

                bool isGoLeftNext = true;

                stack.Push(current);    // Помещаем корень дерева в стек

                while (stack.Count > 0) // Пока стек не пустой
                {
                    if (isGoLeftNext)                   // Если isGoLeftNext = True мы переходим влево
                    {
                        while (current.Left != null)    // И помещаем всех левых потомков в стек.  
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }

                    yield return current.Value;         // Возвращаем для foreach самого левого потомка
                                                        // (минимальное значение дерева на данный момент)

                    if (current.Right != null)          // Если у него есть правый потомок 
                    {
                        current = current.Right;
                        isGoLeftNext = true;            // Для следующей итерации меняем значение isGoLeftNext
                    }
                    else                                // Если у него нет правого потомка, 
                    {
                        current = stack.Pop();          // извлекаем родительский узел из стека
                        isGoLeftNext = false;           // Для следующей итерации меняем значение isGoLeftNext
                    }
                }
            }
        }
    }
}
