using System;

namespace Algorithms
{
    /// <summary>
    /// Класс, отвечающий за расчеты с числами
    /// </summary>
    internal class GetNumbers
    {

        /// <summary>
        /// Вернуть число Фибоначчи (рекурсивный метод) до 45
        /// </summary>
        /// <param name="nFibonacci">Номер числа Фибоначчи</param>
        /// <returns>Число Фибоначчи в формате uint</returns>
        public static uint FibonacciR(uint nFibonacci)
        {
            if (nFibonacci == 0 || nFibonacci == 1)
            {
                return nFibonacci;
            }
            if (nFibonacci > 45) // вернуть 0, чтобы долго не ждать для чисел больше 45
            {
                return 0;
            }
            return FibonacciR(nFibonacci - 1) + FibonacciR(nFibonacci - 2);
        }



        /// <summary>
        /// Вернуть число Фибоначчи циклом
        /// </summary>
        /// <param name="nFibonacci">Номер числа Фибоначчи</param>
        /// <returns>Число Фибоначчи в формате long</returns>
        public static long FibonacciLoop(uint nFibonacci)
        {
            long firstNumber = 0L, secondNumber = 1L, result = 0L;

            if (nFibonacci == 0) return 0;
            if (nFibonacci == 1) return 1;

            for (int i = 1; i < nFibonacci; i++)
            {
                result = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = result;
            }

            return result;
        }


        /// <summary>
        /// Вернуть число Фибоначчи по формуле Бине. После 71 числа - не точные
        /// </summary>
        /// <param name="nFibonacci">Номер числа Фибоначчи</param>
        /// <returns>Число Фибоначчи в формате long</returns>
        public static long FibonacciFormula(uint nFibonacci)
        {

            double result = (Math.Pow((1.0 + Math.Sqrt(5.0)) / 2.0, nFibonacci) -
                Math.Pow((1.0 - Math.Sqrt(5.0)) / 2.0, nFibonacci)) / Math.Sqrt(5.0);

            return (long)result;
        }


    }
}
