using System;

namespace Algorithms
{
    /// <summary>
    /// Класс, отвечающий за запросы информации от пользователя
    /// </summary>
    internal class Ask
    {

        /// <summary>
        /// Запросить число для расчета чисел Фибоначчи
        /// </summary>
        public static void FibonacciNumber()
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите натуральное число, для выхода введите q: ");
                    string line = Console.ReadLine();
                    if (line.ToLower() == "q") return; // Прерывание цикла
                    uint t = Convert.ToUInt32(line);
                    Print.FibonacciNumber(t);
                }
                catch (Exception e)
                {
                    Helpers.WriteLineColor("Ошибка! Введите натуральное число или q. Exception: " + e.Message, ConsoleColor.Red);
                }
            }
        }


        /// <summary>
        /// Запросить число для проверки по тестовой блок-схеме
        /// </summary>
        public static void TestNumber()
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите число, для выхода введите q: ");
                    string line = Console.ReadLine();
                    if (line.ToLower() == "q") return;  // Прерывание цикла
                    Print.TestNumbers(Convert.ToInt32(line));
                }
                catch (Exception e)
                {
                    Helpers.WriteLineColor("Ошибка! Введите число или q. Exception: " + e.Message, ConsoleColor.Red);

                }
            }
        }


    }
}
