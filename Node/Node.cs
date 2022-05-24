namespace Algorithms.Node
{
    /// <summary>
    /// Класс хранит объект (узел) из списка
    /// Для односвязных и двусвязных списков
    /// </summary>
    public class Node
    {

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="value">Значение типа Int32</param>
        public Node(int value)
        {
            Value = value;
        }

        public int Value { get; set; } // Значение узла         
        public Node Next { get; set; } // Следующий узел
        public Node Prev { get; set; } // Предыдущий узел

        // Не стал удалять Prev для односвязных списков, чтобы не разделять классы
        // По памяти это наверное не эффективно. Но это учебный класс

    }
}