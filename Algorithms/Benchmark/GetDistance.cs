using System;

namespace Algorithms.Benchmark
{
    /// <summary>
    /// Расчет расстояния между точками
    /// </summary>
    public class GetDistance
    {
        /// <summary>
        /// Рассчитать расстояние между точками
        /// </summary>
        /// <param name="pointOne">Координаты 1 точки X и Y (массив)</param>
        /// <param name="pointTwo">Координаты 2 точки X и Y (массив)</param>
        /// <returns>Массив результатов</returns>
        public static double[] PointDistance(PointStructOfArray pointOne, PointStructOfArray pointTwo)
        {
            double[] pointDistance = new double[pointOne.X.Length];

            for (int i = 0; i < pointOne.X.Length; i++)
            {
                double x = pointOne.X[i] - pointTwo.X[i];
                double y = pointOne.Y[i] - pointTwo.Y[i];
                pointDistance[i] = Math.Sqrt((x * x) + (y * y));
            }

            return pointDistance;
        }

        /// <summary>
        /// Рассчитать расстояние между точками
        /// </summary>
        /// <param name="pointOne">Координаты 1 точки X и Y (массив)</param>
        /// <param name="pointTwo">Координаты 2 точки X и Y (массив)</param>
        /// <returns>Массив результатов</returns>
        public static double[] PointDistance(PointClassOfArray pointOne, PointClassOfArray pointTwo)
        {
            double[] pointDistance = new double[pointOne.X.Length];

            for (int i = 0; i < pointOne.X.Length; i++)
            {
                double x = pointOne.X[i] - pointTwo.X[i];
                double y = pointOne.Y[i] - pointTwo.Y[i];
                pointDistance[i] = Math.Sqrt((x * x) + (y * y));
            }

            return pointDistance;
        }

        /// <summary>
        /// Рассчитать расстояние между точками (для массива структуры)
        /// </summary>
        /// <param name="pointOne">Координаты 1 точки X и Y</param>
        /// <param name="pointTwo">Координаты 2 точки X и Y</param>
        /// <returns>Массив результатов</returns>
        public static double[] PointDistance(PointStruct[] pointOne, PointStruct[] pointTwo)
        {
            double[] pointDistance = new double[pointOne.Length];

            for (int i = 0; i < BenchIt.NumberOfElements; i++)
            {
                double x = pointOne[i].X - pointTwo[i].X;
                double y = pointOne[i].Y - pointTwo[i].Y;
                pointDistance[i] = Math.Sqrt((x * x) + (y * y));
            }

            return pointDistance;
        }

        /// <summary>
        /// Рассчитать расстояние между точками (для массива структуры)
        /// </summary>
        /// <param name="pointOne">Координаты 1 точки X и Y</param>
        /// <param name="pointTwo">Координаты 2 точки X и Y</param>
        /// <returns>Массив результатов</returns>
        public static double[] PointDistance(PointClass[] pointOne, PointClass[] pointTwo)
        {
            double[] pointDistance = new double[pointOne.Length];

            for (int i = 0; i < BenchIt.NumberOfElements; i++)
            {
                double x = pointOne[i].X - pointTwo[i].X;
                double y = pointOne[i].Y - pointTwo[i].Y;
                pointDistance[i] = Math.Sqrt((x * x) + (y * y));
            }

            return pointDistance;
        }
    }
}