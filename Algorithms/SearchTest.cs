namespace Algorithms
{
    /// <summary>
    /// Методы реализующие различные виды поиска
    /// </summary>
    internal class SearchTest
    {


        /// <summary>
        /// Простой поиск перебором
        /// </summary>
        /// <param name="array">Массив</param>
        /// <param name="searchValue">Значение для поиска</param>
        /// <returns>Индекс найденного элемента массива или -1 если ничего не найдено</returns>
        public static (int, int) SimpleFind(int[] array, int searchValue) //поиск элемента с определенным значением
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == searchValue) { return (i,i+1); }
            }
            return (-1, array.Length);  // Если в массиве элемент не найден
        }


        /// <summary>
        /// Бинарный поиск (массив должен быть отсортирован)
        /// </summary>
        /// <param name="array">Массив</param>
        /// <param name="searchValue">Значение для поиска</param>
        /// <returns>Индекс найденного элемента массива или -1 если ничего не найдено</returns>
        public static (long, int) BinarySearch(int[] array, int searchValue)
        {
            long min = 0, max = array.Length - 1;  // Задаем диапазон для поиска
            int nIteration = 0; // Для подсчета количества итераций метода
            while (min <= max)
            {
                nIteration++;
                long mid = (min + max) / 2;                             // Находим разделяющий элемент (ровно по середине диапазона)
                if (searchValue == array[mid]) { return (mid, nIteration); }          // Если нашли 
                else if (searchValue < array[mid]) { max = mid - 1; }   // Если не нашли, начинаем менять диапазон поиска
                else { min = mid + 1; }
            }
            return (-1, nIteration);  // Если в массиве элемент не найден
        }


        /// <summary>
        /// Интерполяционный поиск (массив должен быть отсортирован)
        /// </summary>
        /// <param name="array">Массив</param>
        /// <param name="length">Длина массива</param>
        /// <param name="searchValue">Значение для поиска</param>
        /// <returns>Индекс найденного элемента массива или -1 если ничего не найдено</returns>
        public static (long, int) InterpolationSearch(int[] array, int length, int searchValue)
        {
            long min = 0, max = length - 1; // Задаем диапазон для поиска
            int nIteration = 0; // Для подсчета количества итераций метода
            while (min <= max)
            {
                nIteration++;
                // Находим разделяющий элемент
                long mid = min + (max - min) * (searchValue - array[min]) / (array[max] - array[min]);

                if (array[mid] == searchValue) { return (mid, nIteration); }          // Если "угадали"
                else if (array[mid] < searchValue) { min = mid + 1; }   // Если не "угадали", начинаем менять диапазон поиска 
                else if (array[mid] > searchValue) { max = mid - 1; }   
            }
            return (-1, nIteration); // Если элемент в массиве не найден

        }

    }
}
