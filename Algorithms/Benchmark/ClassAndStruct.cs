using System;

namespace Algorithms.Benchmark
{

    // Классы и структуры для хранения данных

    public struct PointStructOfArray
    {
        public double[] X { get; set; }
        public double[] Y { get; set; }
    }

    public struct PointStruct
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public class PointClassOfArray
    {
        public double[] X { get; set; }
        public double[] Y { get; set; }
    }

    public class PointClass
    {
        public double X { get; set; }
        public double Y { get; set; }
    }



    /// <summary>
    /// Тест скорости операций со структурой заполненной массивами
    /// </summary>
    public class BenchmarkStructOfArray
    {

        PointStructOfArray _pointStruct1;
        PointStructOfArray _pointStruct2 = new PointStructOfArray();
        public double[] testStructArray;

        public void Math() => testStructArray = GetDistance.PointDistance(_pointStruct1, _pointStruct2);

        public void Init() => CreateStruct();

        void CreateStruct()
        {
            _pointStruct1 = new PointStructOfArray
            {
                X = BenchIt.FillArray(),
                Y = BenchIt.FillArray()
            };

            _pointStruct2 = new PointStructOfArray
            {
                X = BenchIt.FillArray(),
                Y = BenchIt.FillArray()
            };
        }
    }


    /// <summary>
    /// Тест скорости операций с классом заполненным массивами
    /// </summary>
    public class BenchmarkClassOfArray
    {

        PointClassOfArray _pointClass1;
        PointClassOfArray _pointClass2;
        public double[] testClassArray;


        public void Math() => testClassArray = GetDistance.PointDistance(_pointClass1, _pointClass2);

        public void Init() => CreateClass();

        public void CreateClass()
        {
            _pointClass1 = new PointClassOfArray()
            {
                X = BenchIt.FillArray(),
                Y = BenchIt.FillArray()
            };

            _pointClass2 = new PointClassOfArray()
            {
                X = BenchIt.FillArray(),
                Y = BenchIt.FillArray()
            };
        }
    }


    /// <summary>
    /// Тест скорости операций с массивом структур
    /// </summary>
    public class BenchmarkStruct
    {
        private PointStruct[] _pointStruct1 = new PointStruct[BenchIt.NumberOfElements];
        private PointStruct[] _pointStruct2 = new PointStruct[BenchIt.NumberOfElements];

        public void Math() => GetDistance.PointDistance(_pointStruct1, _pointStruct2);

        public void Init() => CreateArrayOfStruct();

        public void CreateArrayOfStruct()
        {
            Random rnd = new Random();

            for (int i = 0; i < BenchIt.NumberOfElements; i++)
            {
                _pointStruct1[i] = new PointStruct
                {
                    X = rnd.NextDouble(),
                    Y = rnd.NextDouble()
                };

                _pointStruct2[i] = new PointStruct
                {
                    X = rnd.NextDouble(),
                    Y = rnd.NextDouble()
                };
            }
        }
    }


    /// <summary>
    /// Тест скорости операций с массивом классов
    /// </summary>
    public class BenchmarkClass
    {
        private PointClass[] _pointClass1 = new PointClass[BenchIt.NumberOfElements];
        private PointClass[] _pointClass2 = new PointClass[BenchIt.NumberOfElements];

        public void Math() => GetDistance.PointDistance(_pointClass1, _pointClass2);

        public void Init() => CreateArrayOfClass();

        void CreateArrayOfClass()
        {
            Random rnd = new Random();

            for (int i = 0; i < BenchIt.NumberOfElements; i++)
            {
                _pointClass1[i] = new PointClass
                {
                    X = rnd.NextDouble(),
                    Y = rnd.NextDouble()
                };

                _pointClass2[i] = new PointClass
                {
                    X = rnd.NextDouble(),
                    Y = rnd.NextDouble()
                };
            }
        }
    }
}
