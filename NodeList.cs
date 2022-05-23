using System;
using System.Collections;

namespace Algorithms
{

    //------------------------------------------------------------------------------------
    // Односвязный список не требовался для задания. Но я начал с него, чтобы понять
    // разницу. Они почти идентичны, поэтому можно односвязный не проверять,
    // а начать сразу с двусвязного.
    //------------------------------------------------------------------------------------



    /// <summary>
    /// Класс, отвечающий за создание односвязного списка и его логику работы
    /// </summary>
    public class NodeList : ILinkedList, IEnumerable
    {
        // Скрытые поля класса
        private Node startNode;         // Первый элемент списка (голова поезда)
        private Node endNode;           // Последний элемент списка (хвост поезда)
        private int Count;              // Счетчик элементов


        //-------------------------------------------------------------------------
        // Первые 6 методов, которые требовались по заданию (реализация интерфейса)
        //_________________________________________________________________________


        /// <summary>
        /// Вернуть количество элементов списка. Сложность метода O(1)
        /// </summary>
        /// <returns>Количество элементов списка</returns>
        public int GetCount()
        {
            return Count;
        }


        /// <summary>
        /// Добавить элемент в список. Сложность метода O(1)
        /// </summary>
        /// <param name="value">Значение элемента</param>
        public void AddNode(int value)
        {
            Node node = new Node(value);    // Создаем новый "узел", со значением value 

            // Если стартовый узел еще пустой - устанавливаем его со значением нового элемента
            if (startNode == null) { startNode = node; }

            // В противном случае (если список не пустой) - записываем его следующим элементом
            else { endNode.Next = node; }

            endNode = node;     // Новый элемент теперь является последним элементом, "хвостом поезда"

            Count++;            // Увеличиваем счетчик элементов
        }


        /// <summary>
        /// Добавить элемент в список после указанного узла. Сложность метода O(1)
        /// </summary>
        /// <param name="nodeA"></param>
        /// <param name="value"></param>
        public void AddNodeAfter(Node nodeA, int value)
        {
            // Если стартовый узел еще пустой (пустой список) - выходим из метода
            if (startNode == null) { Console.WriteLine("AddNodeAfter: Ошибка! Список пустой."); return; }

            // Если элемент последний
            if (nodeA.Next == null) { AddNode(value); return; }

            Node node = new Node(value);    // Создаем новый "узел", со значением value

            node.Next = nodeA.Next;         // Вставляем между
            nodeA.Next = node;
            Count++;

            Console.WriteLine("AddNodeAfter: После элемента списка \"" + nodeA.Value + "\" добавить \"" + value + "\"");
        }


        /// <summary>
        /// Удаляет элемент с указанным индексом. Сложность метода O(n)
        /// </summary>
        /// <param name="index">Индекс элемента</param>
        public void RemoveNode(int index)
        {
            // Если стартовый узел еще пустой (пустой список) - выходим из метода
            if (startNode == null) { Console.WriteLine("RemoveNode: Ошибка! Список пустой."); return; }

            // Если индекс выходит за диапазон списка - выходим из метода
            if (index < 0 || index > Count - 1) { Console.WriteLine("RemoveNode: Ошибка! Индекс не существует."); return; }

            // Если индекс 0 (первый элемент) вызываем метод RemoveFirst
            if (index == 0) { RemoveFirst(); return; }

            Node node = startNode;
            int nodeIndex = 0;          // Для нумерации
            while (node != null)        // Идем по списку последовательно, до последнего элемента
            {
                if (nodeIndex == index - 1)
                {
                    Console.WriteLine("RemoveNode: Элемент с индексом " + index + " со значением \"" + node.Next.Value + "\" был удален!");
                    node.Next = node.Next.Next; // Разрываем связь элементов
                    Count--;                    // Уменьшаем счетчик элементов
                    return;
                }
                node = node.Next;
                nodeIndex++;
            }
        }

        /// <summary>
        /// Удаляет указанный элемент (узел). Сложность метода O(n)
        /// </summary>
        /// <param name="node">Элемент (узел)</param>
        public void RemoveNode(Node nodeR)
        {
            // Если узел передан null
            if (nodeR == null) { Console.WriteLine("RemoveNode: Ошибка! Узел = null."); return; }

            // Если стартовый узел еще пустой (пустой список) - выходим из метода
            if (startNode == null) { Console.WriteLine("RemoveNode: Ошибка! Список пустой."); return; }

            // Если искомый узел первый вызываем метод RemoveFirst
            if (nodeR == startNode) { RemoveFirst(); return; }

            Node node = startNode;
            Node previous = null;   // Чтобы знать предыдущий узел
            int nodeIndex = 0;      // Для нумерации


            while (node != null)    // Идем по списку последовательно, до последнего элемента
            {
                if (node == nodeR && node.Next != null)         //Если элемент не последний
                {
                    Console.WriteLine("RemoveNode: Элемент со значением \"" + node.Value + "\" с индексом " + (nodeIndex) + " был удален!");
                    previous.Next = node.Next;                  // Разрываем связь элементов
                    Count--;                                    // Уменьшаем счетчик элементов
                    return;
                }
                else if (node == nodeR && node.Next == null)    // Если элемент последний
                {
                    Console.WriteLine("RemoveNode: Элемент со значением \"" + node.Value + "\" с индексом " + (nodeIndex) + " (endNode) был удален!");
                    previous.Next = null;                       // Разрываем связь элементов
                    endNode = previous;                         // Делаем предыдущий узел "концом поезда"
                    Count--;                                    // Уменьшаем счетчик элементов
                    return;
                }

                previous = node;                // Запоминаем предыдущий узел
                node = node.Next;               // Переходим к следующему элементу
                nodeIndex++;
            }
        }


        /// <summary>
        /// Найти элемент в списке по его значению. Сложность метода O(n)
        /// </summary>
        /// <param name="searchValue">Значение для поиска</param>
        /// <returns>Элемент списка (узел) или null</returns>
        public Node FindNode(int searchValue)
        {
            // Если стартовый узел еще пустой (пустой список) - выходим из метода
            if (startNode == null) { Console.WriteLine("FindNode: Ошибка! Список пустой."); return null; }

            int nodeIndex = 0;          // Для нумерации
            Node node = startNode;
            while (node != null)        // Идем по списку последовательно, до последнего элемента
            {
                if (node.Value == searchValue) //Сравниваем значение
                {
                    Console.WriteLine("FindNode: Первый элемент со значением \"" + searchValue + "\" найден под индексом " + nodeIndex);
                    return node;
                }
                node = node.Next;  // Переходим к следующему элементу
                nodeIndex++;
            }
            Console.WriteLine($"FindNode: Элемент \"{searchValue}\" в списке отсутствует!");
            return null;
        }


        //-------------------------------------------------------------------------
        // Дальше идут методы, которые я добавил в качестве эксперимента,
        // чтобы функционально класс был полноценным.
        //_________________________________________________________________________


        /// <summary>
        /// Удаляет первый элемент. Проверка пустой список или нет.
        /// </summary>
        public void RemoveFirst()
        {
            // Если стартовый узел еще пустой (пустой список) - выходим из метода
            if (startNode == null) { Console.WriteLine("RemoveFirst: Ошибка! Список пустой."); return; }

            Console.WriteLine("RemoveFirst: Первый элемент списка со значением \"" + startNode.Value + "\" был удален!");
            startNode = startNode.Next;     // Удаляем первый элемент
            Count--;                        // Уменьшаем счетчик элементов

            if (Count == 0)                 // Если после удаления список пуст
            {
                startNode = null;
                endNode = null;
                Console.WriteLine("RemoveFirst: Список теперь пустой!");
            }
        }


        /// <summary>
        /// Удаляет первый найденный элемент (узел) со указанным значением. Сложность метода O(n)
        /// </summary>
        /// <param name="searchValue">Значение элемента (узла)</param>
        public void Remove(int searchValue)
        {
            // Если стартовый узел еще пустой (пустой список) - выходим из метода
            if (startNode == null) { Console.WriteLine("Remove: Ошибка! Список пустой."); return; }

            // Если значение найдено в первом узле вызываем метод RemoveFirst
            if (startNode.Value == searchValue) { RemoveFirst(); return; }

            Node node = startNode;
            Node previous = null;               // Чтобы знать предыдущий узел
            int nodeIndex = 0;                  // Для нумерации


            while (node != null)                // Идем по списку последовательно, до последнего элемента
            {
                if (node.Value == searchValue && node.Next != null)       //Если элемент не последний
                {
                    Console.WriteLine("Remove: Элемент со значением \"" + searchValue + "\" с индексом " + (nodeIndex) + " был удален!");
                    previous.Next = node.Next;  // Разрываем связь элементов
                    Count--;                    // Уменьшаем счетчик элементов
                    return;
                }
                else if (node.Value == searchValue && node.Next == null)  // Если элемент последний
                {
                    Console.WriteLine("RemoveNode: Элемент со значением \"" + searchValue + "\" с индексом " + nodeIndex + " (endNode) был удален!");
                    previous.Next = null;       // Разрываем связь элементов
                    endNode = previous;         // Делаем предыдущий узел "концом поезда"
                    Count--;                    // Уменьшаем счетчик элементов
                    return;
                }

                previous = node;                // Запоминаем предыдущий узел
                node = node.Next;               // Переходим к следующему элементу
                nodeIndex++;
            }
        }


        /// <summary>
        /// Вернуть значение пустой список или нет
        /// </summary>
        /// <returns>True или False</returns>
        public bool IsEmpty()
        {
            if (Count == 0) { return true; }
            else { return false; }
        }


        /// <summary>
        /// Добавить элемент в начало списка. Сложность метода O(1)
        /// </summary>
        /// <param name="value">Значение элемента</param>
        public void AddNodeFirst(int value)
        {
            Node node = new Node(value);        // Создаем новый "узел", со значением value

            node.Next = startNode;              // Делаем "ссылку" на бывший первый элемент или на null если список пустой
            startNode = node;                   // Устанавливаем новый узел первым    
            if (Count == 0) { endNode = node; } // Если список пустой делаем элемент "хвостом поезда"

            Count++;                            // Увеличиваем счетчик элементов
        }


        /// <summary>
        /// Вывести все элементы списка в консоль и пронумеровать их. Сложность метода O(n)
        /// </summary>
        public void Print()
        {
            if (startNode == null) { Console.WriteLine("Print: Список пустой!"); return; }

            Node node = startNode;
            int index = 0;          // Для нумерации
            while (node != null)    // Идем по списку последовательно, до последнего элемента
            {
                Console.WriteLine("Элемент с индексом " + index + ": " + node.Value);
                node = node.Next;
                index++;
            }
            Console.WriteLine($"Print: Всего элементов в списке: {Count}");
        }


        /// <summary>
        /// Вывести элемент списка в консоль. Сложность метода O(1)
        /// Для непустого списка
        /// </summary>
        public void PrintNode(Node node)
        {
            if (node == null) { Console.WriteLine("PrintNode: Ошибка! Узел = null."); return; }
            Console.WriteLine("PrintNode: Элемент списка (значение узла): " + node.Value);
        }



        /// <summary>
        /// Пересчитать и вернуть количество элементов списка. Сложность метода O(n)
        /// Для теста работы счетчика элементов
        /// </summary>
        /// <returns>Количество элементов списка</returns>
        public int ReCount()
        {
            Node node = startNode;
            int index = 0;              // Для нумерации
            while (node != null)        // Идем по списку последовательно, до последнего элемента
            {
                node = node.Next;
                index++;
            }
            return index;
        }


        /// <summary>
        /// Создать массив из данных списка. Сложность метода O(n)        
        /// </summary>
        /// <returns>Массив с элементами списка</returns>
        public int[] ToArray()
        {
            Node node = startNode;
            int[] array = new int[Count];
            int index = 0;                      // Для индекса массива
            while (node != null)                // Идем по списку последовательно, до последнего элемента
            {
                array[index++] = node.Value;
                node = node.Next;
            }
            return array;
        }


        /// <summary>
        /// Сортировка методом перевода в массив и обратно.
        /// Тестовый метод.
        /// </summary>
        public void Sort()
        {
            int[] array = ToArray();
            Array.Sort(array);
            Clear();
            foreach (var item in array)
            {
                AddNode(item);
            }
        }


        /// <summary>
        /// Сортировка списка пузырьком. Сложность метода O(n^2)
        /// </summary>
        public void BubbleSort()
        {
            Node node = startNode;

            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = 0; j < Count - 1; j++)
                {
                    if (node.Value > node.Next.Value)
                    {
                        int temp = node.Next.Value;
                        node.Next.Value = node.Value;
                        node.Value = temp;
                    }
                    node = node.Next;
                }
                node = startNode;
            }
        }


        /// <summary>
        /// Заполнить список произвольными элементами. Сложность метода O(n)
        /// </summary>
        /// <param name="number">Количество элементов</param>
        /// <param name="maxNumber">Максимум для чисел (по умолчанию 1000)</param>
        public void Fill(int number, int maxNumber = 1000)
        {
            Clear();
            Node node = startNode;
            Random random = new Random();

            for (int i = 0; i < number; i++)
            {
                AddNode(random.Next(maxNumber));
            }
        }


        /// <summary>
        /// Очистить список и сбросить счетчик элементов
        /// </summary>
        public void Clear()
        {
            // Удалить ссылки на элементы, для сборщика мусора
            startNode = null;
            endNode = null;
            Count = 0;
        }


        /// <summary>
        /// Для интерфейса IEnumerable
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            Node node = startNode;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }
    }
}
