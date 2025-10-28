using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skebob
{
    internal class Program
    {
        static void TransformArray(char[] array, out bool wasTransformed)
        {
            wasTransformed = false;

            // Собираем все строчные буквы и их позиции
            List<(char letter, int position)> lowercaseLetters = new List<(char, int)>();

            for (int i = 0; i < array.Length; i++)
            {
                if (char.IsLower(array[i]))
                {
                    lowercaseLetters.Add((array[i], i));
                }
            }

            // Если нет строчных букв или только одна - преобразование не нужно
            if (lowercaseLetters.Count <= 1)
            {
                wasTransformed = false;
                return;
            }

            // Сортируем строчные буквы по алфавиту
            var sortedLetters = lowercaseLetters.Select(x => x.letter)
                                              .OrderBy(x => x)
                                              .ToArray();

            // Проверяем, нужно ли вообще преобразование
            bool needsTransformation = false;
            for (int i = 0; i < sortedLetters.Length; i++)
            {
                if (sortedLetters[i] != lowercaseLetters[i].letter)
                {
                    needsTransformation = true;
                    break;
                }
            }

            if (!needsTransformation)
            {
                wasTransformed = false;
                return;
            }

            // Заменяем строчные буквы на отсортированные
            for (int i = 0; i < lowercaseLetters.Count; i++)
            {
                array[lowercaseLetters[i].position] = sortedLetters[i];
            }

            wasTransformed = true;
        }

        // Процедура для вывода массива
        static void PrintArray(char[] array, string label)
        {
            Console.WriteLine($"{label}: [{string.Join(" ", array)}]");
        }

        static void Main()
        {
            Console.WriteLine("=== Преобразование массивов символов ===");
            Console.WriteLine();

            // Инициализация пяти массивов (примеры данных)
            char[][] arrays = new char[5][];

            arrays[0] = "aDcBeFg".ToCharArray();      // Неотсортированные строчные
            arrays[1] = "ABCDEFG".ToCharArray();      // Только прописные
            arrays[2] = "zyxwvut".ToCharArray();      // Только строчные, обратный порядок
            arrays[3] = "aBcDeFg".ToCharArray();      // Уже отсортированные строчные
            arrays[4] = "HeLlOwOrLd".ToCharArray();   // Смешанный случай

            // Обработка каждого массива
            for (int i = 0; i < arrays.Length; i++)
            {
                Console.WriteLine($"Массив {i + 1}:");
                PrintArray(arrays[i], "Исходный");

                char[] original = (char[])arrays[i].Clone(); // Сохраняем копию для сравнения

                TransformArray(arrays[i], out bool wasTransformed);

                if (wasTransformed)
                {
                    PrintArray(arrays[i], "Преобразованный");
                }
                else
                {
                    Console.WriteLine("✓ Преобразование не потребовалось - массив уже удовлетворяет условию");
                }

                Console.WriteLine();
            }

            // Демонстрация с пользовательским вводом
            Console.WriteLine("=== Демонстрация с пользовательским вводом ===");
            Console.WriteLine("Введите строку символов (только латинские буквы):");

            string userInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(userInput))
            {
                char[] userArray = userInput.ToCharArray();

                Console.WriteLine();
                PrintArray(userArray, "Исходная строка");

                TransformArray(userArray, out bool wasTransformed);

                if (wasTransformed)
                {
                    PrintArray(userArray, "Результат");
                }
                else
                {
                    Console.WriteLine("✓ Преобразование не потребовалось");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
        
    }
}
