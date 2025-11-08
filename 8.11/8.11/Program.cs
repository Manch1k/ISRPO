using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8._11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество строк (N): ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов (M): ");
            int m = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, m];
            FillMatrix(matrix, n, m);
            Console.WriteLine("\nВведенная матрица:");
            PrintMatrix(matrix, n, m);

            int maxPositiveCount = 0;
            int targetRowIndex = -1;

            for (int i = 0; i < n; i++)
            {
                int currentRowPositiveCount = 0;

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        currentRowPositiveCount++;
                    }
                }
                if (currentRowPositiveCount > maxPositiveCount)
                {
                    maxPositiveCount = currentRowPositiveCount;
                    targetRowIndex = i;
                }
            }

            if (maxPositiveCount == 0) 
            {
                Console.WriteLine("В матрице нет положительных элементов.");
            }
            else
            {
                Console.WriteLine($"Строка с наибольшим количеством положительных элементов: {targetRowIndex + 1}");
                Console.WriteLine($"Количество положительных элементов в этой строке: {maxPositiveCount}");
            }

            Console.ReadKey();
        }

        static void FillMatrix(int[,] matrix, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"Введите элемент [{i + 1}, {j + 1}]: ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        static void PrintMatrix(int[,] matrix, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j],5}");
                }
                Console.WriteLine();
            }
        }
    }
}
