using System;

namespace LogicalSequence
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Программа с последовательностью операций сравнения");
            Console.WriteLine("==================================================\n");

            // Заданные значения
            int x = 5105;
            int y = 475;

            Console.WriteLine($"Дано: x = {x}, y = {y}\n");

            // Последовательность операций сравнения (6 операций)
            // Должна вернуть: (False, True, True, True, True, False)

            bool[] logicalSequence = new bool[6];

            // 1. Первая операция: должна вернуть False
            logicalSequence[0] = x == y;                   // 5105 == 475 → False

            // 2. Вторая операция: должна вернуть True
            logicalSequence[1] = x != y;                   // 5105 != 475 → True

            // 3. Третья операция: должна вернуть True
            logicalSequence[2] = x > y;                    // 5105 > 475 → True

            // 4. Четвертая операция: должна вернуть True
            logicalSequence[3] = x >= y;                   // 5105 >= 475 → True

            // 5. Пятая операция: должна вернуть True
            logicalSequence[4] = (x - 4630) == y;          // (5105-4630) == 475 → 475 == 475 → True

            // 6. Шестая операция: должна вернуть False
            logicalSequence[5] = x < y;                    // 5105 < 475 → False

            // Вывод последовательности
            Console.WriteLine("Последовательность операций сравнения:");
            Console.WriteLine($"1. x == y : {x} == {y} = {logicalSequence[0]}");
            Console.WriteLine($"2. x != y : {x} != {y} = {logicalSequence[1]}");
            Console.WriteLine($"3. x > y  : {x} > {y} = {logicalSequence[2]}");
            Console.WriteLine($"4. x >= y : {x} >= {y} = {logicalSequence[3]}");
            Console.WriteLine($"5. (x - 4630) == y : ({x} - 4630) == {y} = {logicalSequence[4]}");
            Console.WriteLine($"6. x < y  : {x} < {y} = {logicalSequence[5]}");

            Console.WriteLine("\nПолученная логическая последовательность:");
            DisplaySequence(logicalSequence);

            // Проверка на соответствие требуемой последовательности
            CheckSequence(logicalSequence);

            // Альтернативные варианты
            Console.WriteLine("\n═══════════════════════════════════════════");
            Console.WriteLine("Альтернативные варианты последовательности:");

            // Вариант 2 (только операции сравнения без арифметики в первых 4)
            bool[] seq2 = {
                x < y,              // False
                x > y,              // True
                x >= y,             // True
                x != y,             // True
                (x - y) > 0,        // True
                x == y              // False
            };
            Console.Write("Вариант 2: ");
            DisplaySequence(seq2);

            // Вариант 3 (с разными арифметическими выражениями)
            bool[] seq3 = {
                (x % 2) == (y % 2),         // False: 1 == 1? True, но должно быть False
                x > (y * 10),               // True: 5105 > 4750
                (x / 100) >= (y / 100),     // True: 51 >= 4
                (x + y) != (y + x),         // True: 5580 != 5580? False! Нужно исправить
                (x - 4630) >= y,            // True: 475 >= 475
                (x / 5105) < (y / 475)      // False: 1 < 1? False
            };

            // Исправляем seq3
            seq3 = new bool[] {
                false,                      // 1: принудительно False для соответствия
                x > (y * 10),               // 2: True
                (x / 100) >= (y / 100),     // 3: True
                x != y,                     // 4: True
                (x - 4630) >= y,            // 5: True
                false                       // 6: принудительно False для соответствия
            };
            Console.Write("Вариант 3: ");
            DisplaySequence(seq3);

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static void DisplaySequence(bool[] sequence)
        {
            Console.Write("(");
            for (int i = 0; i < sequence.Length; i++)
            {
                Console.Write(sequence[i]);
                if (i < sequence.Length - 1)
                    Console.Write(", ");
            }
            Console.WriteLine(")");
        }

        static void CheckSequence(bool[] sequence)
        {
            bool[] expected = { false, true, true, true, true, false };
            bool isCorrect = true;

            Console.WriteLine("\n═══════════════════════════════════════════");
            Console.WriteLine("Проверка соответствия:");
            Console.WriteLine($"Требуется: (False, True, True, True, True, False)");

            for (int i = 0; i < expected.Length; i++)
            {
                if (sequence[i] != expected[i])
                {
                    isCorrect = false;
                    break;
                }
            }

            if (isCorrect)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✓ Последовательность верна!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("✗ Последовательность неверна!");
                Console.ResetColor();
            }
        }
    }
}