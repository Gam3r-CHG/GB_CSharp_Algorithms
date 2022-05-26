using System;
using System.Diagnostics;

namespace Algorithms.Benchmark
{
    internal class BenchIt
    {
        public static int NumberOfElements { get; set; }

        public static void Run(int numberOfElements)
        {
            NumberOfElements = numberOfElements;
            Init();
        }


        private static void Init()
        {
            Stopwatch sw = new Stopwatch();


            //BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"Тест скорости с использованием {NumberOfElements:#,#} элементов");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");

            // Тест структуры хранящей массив--------------------

            BenchmarkStructOfArray benchmarkStructOfArray = new();

            sw.Restart();
            benchmarkStructOfArray.Init();
            sw.Stop();
            long benchmarkStructOfArrayTicks1 = sw.ElapsedTicks;

            sw.Restart();
            benchmarkStructOfArray.Math();
            sw.Stop();
            long benchmarkStructOfArrayTicks2 = sw.ElapsedTicks;


            // Тест класса хранящего массив---------------------
            BenchmarkClassOfArray benchmarkClassOfArray = new();

            sw.Restart();
            benchmarkClassOfArray.Init();
            sw.Stop();
            long benchmarkClassOfArrayTicks1 = sw.ElapsedTicks;


            sw.Restart();
            benchmarkClassOfArray.Math();
            sw.Stop();
            long benchmarkClassOfArrayTicks2 = sw.ElapsedTicks;


            // Тест массива структур--------------------------
            BenchmarkStruct benchmarkStruct = new();

            sw.Restart();
            benchmarkStruct.Init();
            sw.Stop();
            long benchmarkStructTicks1 = sw.ElapsedTicks;

            sw.Restart();
            benchmarkStruct.Math();
            sw.Stop();
            long benchmarkStructTicks2 = sw.ElapsedTicks;


            // Тест массива классов----------------------------
            BenchmarkClass benchmarkClass = new();

            sw.Restart();
            benchmarkClass.Init();
            sw.Stop();
            long benchmarkClassTicks1 = sw.ElapsedTicks;

            sw.Restart();
            benchmarkClass.Math();
            sw.Stop();
            long benchmarkClassTicks2 = sw.ElapsedTicks;


            double ratioStructClassArray1 = (double)benchmarkClassOfArrayTicks1 / benchmarkStructOfArrayTicks1;
            double ratioStructClassArray2 = (double)benchmarkClassOfArrayTicks2 / benchmarkStructOfArrayTicks2;
            double ratioStructClass1 = (double)benchmarkClassTicks1 / benchmarkStructTicks1;
            double ratioStructClass2 = (double)benchmarkClassTicks2 / benchmarkStructTicks2;

            Console.WriteLine($"Название      |Структура      |Класс          |Соотношение    |Структура[]    |Класс[]        |Соотношение    |");

            Console.WriteLine($"Заполнение    |{benchmarkStructOfArrayTicks1.ToString("#,#").PadRight(15)}|{benchmarkClassOfArrayTicks1.ToString("#,#").PadRight(15)}|" +
                              $"{ratioStructClassArray1.ToString("N3").PadRight(15)}|{benchmarkStructTicks1.ToString("#,#").PadRight(15)}|" +
                              $"{benchmarkClassTicks1.ToString("#,#").PadRight(15)}|{ratioStructClass1.ToString("N3").PadRight(15)}|");

            Console.WriteLine($"Вычисление    |{benchmarkStructOfArrayTicks2.ToString("#,#").PadRight(15)}|{benchmarkClassOfArrayTicks2.ToString("#,#").PadRight(15)}|" +
                              $"{ratioStructClassArray2.ToString("N3").PadRight(15)}|{benchmarkStructTicks2.ToString("#,#").PadRight(15)}" +
                              $"|{benchmarkClassTicks2.ToString("#,#").PadRight(15)}|{ratioStructClass2.ToString("N3").PadRight(15)}|");


        }


        /// <summary>
        /// Заполнить массив произвольными числами (double). Количество элементов задается полем NumberOfElements
        /// </summary>
        /// <returns>Созданный массив (double)</returns>
        public static double[] FillArray()
        {
            Random random = new Random();
            double[] array = new double[NumberOfElements];

            for (int i = 0; i < NumberOfElements - 1; i++)
            {
                array[i] = random.NextDouble();
            }

            return array;
        }
    }
}


