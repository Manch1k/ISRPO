using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ввод первого массива:");
            double[,] array1 = InputMatrix();
            Console.WriteLine("\nВвод второго массива:");
            double[,] array2 = InputMatrix();
            Console.WriteLine("\nРезультаты:");

            Console.WriteLine("\nМассив 1:");
            PrintMatrix(array1);
            FindPositiveColumns(array1);

            Console.WriteLine("\nМассив 2:");
            PrintMatrix(array2);
            FindPositiveColumns(array2);

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
        static double[,] InputMatrix()
        {
            int rows, cols;
            do
            {
                Console.Write("Введите количество строк (1-10): ");
            } while (!int.TryParse(Console.ReadLine(), out rows) || rows < 1 || rows > 10);
            do
            {
                Console.Write("Введите количество столбцов (1-10): ");
            } while (!int.TryParse(Console.ReadLine(), out cols) || cols < 1 || cols > 10);

            double[,] matrix = new double[rows, cols];

            Console.WriteLine($"Введите элементы массива {rows}x{cols}:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    bool validInput = false;
                    while (!validInput)
                    {
                        Console.Write($"Элемент [{i + 1},{j + 1}]: ");
                        if (double.TryParse(Console.ReadLine(), out matrix[i, j]))
                        {
                            validInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Ошибка! Введите вещественное число.");
                        }
                    }
                }
            }

            return matrix;
        }
        static void PrintMatrix(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            Console.WriteLine("Массив:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j],8:F2} ");
                }
                Console.WriteLine();
            }
        }
        static void FindPositiveColumns(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            bool found = false;

            Console.Write("Столбцы, содержащие только положительные элементы: ");

            for (int j = 0; j < cols; j++)
            {
                if (IsColumnPositive(matrix, j, rows))
                {
                    Console.Write($"{j + 1} ");
                    found = true;
                }
            }

            if (!found)
            {
                Console.Write("таких столбцов нет");
            }
            Console.WriteLine();
        }
        static bool IsColumnPositive(double[,] matrix, int colIndex, int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, colIndex] <= 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
