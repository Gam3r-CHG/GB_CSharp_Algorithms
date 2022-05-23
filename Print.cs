using System;
using System.Diagnostics;

namespace Algorithms
{
    /// <summary>
    /// Класс, отвечающий за вывод в консоль
    /// </summary>
    internal class Print
    {
        /// <summary>
        /// Вывести числа Фибоначчи 3 способами, замер скорости выполнения
        /// </summary>
        /// <param name="t">Число</param>
        public static void FibonacciNumber(uint t)
        {
            // Вопрос для преподавателя:
            // Пытаюсь посчитать скорость выполнения методов, для сравнения.
            // 3 метода должны вернуть одинаковые результаты, но разными способами.
            // Как я понял каждый последующий вызов происходит быстрее.
            // Это кэш так работает? Как можно это обойти? Или я что - то делаю не правильно?


            Console.WriteLine();

            Stopwatch sw = new Stopwatch();

            sw.Restart();
            Console.Write(GetNumbers.FibonacciFormula(t));
            sw.Stop();
            Console.WriteLine($" вычислено по формуле Бине за {sw.ElapsedMilliseconds} мс, {sw.ElapsedTicks} тактов");

            sw.Restart();
            Console.Write(GetNumbers.FibonacciLoop(t));
            sw.Stop();
            Console.WriteLine($" вычислено циклом за {sw.ElapsedMilliseconds} мс, {sw.ElapsedTicks} тактов");

            sw.Restart();
            Console.Write(GetNumbers.FibonacciR(t));
            sw.Stop();
            Console.WriteLine($" вычислено рекурсией за {sw.ElapsedMilliseconds} мс, {sw.ElapsedTicks} тактов");

            Console.WriteLine();
            sw.Restart();
            FibonacciLoop(t);
            sw.Stop();
            Console.WriteLine();
            Console.WriteLine($"Напечатано с помощью цикла за {sw.ElapsedMilliseconds} мс, {sw.ElapsedTicks} тактов");

            Console.WriteLine();
        }


        /// <summary>
        /// Напечатать числа Фибоначчи циклом до указанного числа
        /// </summary>
        /// <param name="nFibonacci">Номер числа Фибоначчи</param>        
        static void FibonacciLoop(uint nFibonacci)
        {
            long firstNumber = 0L, secondNumber = 1L, result = 0L;
            Console.WriteLine("Элементы числовой последовательности Фибоначчи:");
            if (nFibonacci == 0) Console.WriteLine("0");
            else if (nFibonacci == 1) Console.WriteLine("1");
            else
            {
                for (int i = 1; i < nFibonacci; i++)
                {
                    result = firstNumber + secondNumber;
                    firstNumber = secondNumber;
                    secondNumber = result;
                    Console.Write(result + " ");
                }
            }
        }

        /// <summary>
        /// Вывести числа по тестовой блок-схеме
        /// </summary>
        /// <param name="number">Число для проверки</param>
        public static void TestNumbers(int number)
        {
            int d = 0, i = 2;

            while (i < number)
            {
                if (number % i == 0)
                {
                    Console.WriteLine($"{d + 1}. Делится также на {i}");
                    d++;
                }
                i++;
            }

            if (d == 0) Console.WriteLine($"Число {number} простое");
            else Console.WriteLine($"Число {number} не простое");
        }




    }
}