using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество строк n: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Введите количество столбцов m: ");
            int m = int.Parse(Console.ReadLine());

            double[,] matrix = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Введите строку {i + 1} через пробел: ");
                string[] values = Console.ReadLine().Split(' ');

                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = double.Parse(values[j]);
                }
            }
            Console.WriteLine("\nМатрица по столбцам:");
            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
