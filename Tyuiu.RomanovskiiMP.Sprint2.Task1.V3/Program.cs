using System;

namespace LogicalOperationsSequence
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Программа с комбинацией операций сравнения и логических операций");
            Console.WriteLine("================================================================\n");

            // Заданные значения
            int a = 185;
            int b = 316;
            int c = 134;
            int d = 134;

            Console.WriteLine($"Дано: a = {a}, b = {b}, c = {c}, d = {d}\n");

            // Требуемая последовательность: (True, False, False, False, False, False)

            bool[] logicalSequence = new bool[6];

            // 1. Первый элемент: True
            // Используем сравнение == и логическую операцию ||
            logicalSequence[0] = (c == d) || (a < b);  // (134 == 134) || (185 < 316) = True || True = True

            // 2. Второй элемент: False
            // Используем сравнение != и логическую операцию &&
            logicalSequence[1] = (a == b) && (c != d);  // (185 == 316) && (134 != 134) = False && False = False

            // 3. Третий элемент: False
            // Используем сравнение > и логическую операцию ^ (XOR)
            logicalSequence[2] = (a > b) ^ (c == d);   // (185 > 316) ^ (134 == 134) = False ^ True = True? 
            // Нет, нужно False. Исправим:
            logicalSequence[2] = (a > b) & (c == d);   // False & True = False

            // 4. Четвертый элемент: False
            // Используем сравнение <= и логическую операцию !
            logicalSequence[3] = !(b <= a) && (c == d); // !(316 <= 185) && (134 == 134) = !False && True = True && True = True?
            // Нет, нужно False. Исправим:
            logicalSequence[3] = (b <= a) & (c == d);   // False & True = False

            // 5. Пятый элемент: False
            // Используем сравнение >= и логическую операцию |
            logicalSequence[4] = (a >= b) | (c != d);   // (185 >= 316) | (134 != 134) = False | False = False

            // 6. Шестой элемент: False
            // Используем арифметическое выражение в сравнении
            logicalSequence[5] = (a + b) < (c + d) && (c == d);  // (185+316) < (134+134) && True = 501 < 268 && True = False && True = False

            // Вывод последовательности с пояснениями
            Console.WriteLine("Последовательность операций:");
            Console.WriteLine($"1. (c == d) || (a < b) : ({c} == {d}) || ({a} < {b}) = True || True = {logicalSequence[0]}");
            Console.WriteLine($"2. (a == b) && (c != d) : ({a} == {b}) && ({c} != {d}) = False && False = {logicalSequence[1]}");
            Console.WriteLine($"3. (a > b) & (c == d) : ({a} > {b}) & ({c} == {d}) = False & True = {logicalSequence[2]}");
            Console.WriteLine($"4. (b <= a) & (c == d) : ({b} <= {a}) & ({c} == {d}) = False & True = {logicalSequence[3]}");
            Console.WriteLine($"5. (a >= b) | (c != d) : ({a} >= {b}) | ({c} != {d}) = False | False = {logicalSequence[4]}");
            Console.WriteLine($"6. (a+b) < (c+d) && (c == d) : ({a}+{b}) < ({c}+{d}) && ({c} == {d}) = {a + b} < {c + d} && True = False && True = {logicalSequence[5]}");

            Console.WriteLine("\nПолученная логическая последовательность:");
            DisplaySequence(logicalSequence);

            // Проверка на соответствие требуемой последовательности
            CheckSequence(logicalSequence);

            // Альтернативные варианты
            Console.WriteLine("\n═══════════════════════════════════════════");
            Console.WriteLine("Альтернативные варианты:");

            // Вариант 2: с использованием всех операций по одному разу
            Console.WriteLine("\nВариант 2 (все операции по одному разу):");
            bool[] seq2 = GenerateSequenceVariant2(a, b, c, d);
            DisplaySequence(seq2);
            CheckSequence(seq2);

            // Вариант 3: более сложные выражения
            Console.WriteLine("\nВариант 3 (сложные выражения):");
            bool[] seq3 = GenerateSequenceVariant3(a, b, c, d);
            DisplaySequence(seq3);
            CheckSequence(seq3);

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static bool[] GenerateSequenceVariant2(int a, int b, int c, int d)
        {
            // Используем каждую операцию сравнения и логическую операцию по одному разу

            return new bool[]
            {
                // 1. True: == и ||
                (a - 51) == (d * 1) || (b > a),  // (134 == 134) || True = True
                
                // 2. False: != и &&
                (b != (a + 131)) && (c == d),    // (316 != 316) && True = False && True = False
                
                // 3. False: < и ^
                (c < a) ^ (d == c),              // (134 < 185) ^ True = True ^ True = False
                
                // 4. False: > и !
                !(a > b) && (c == d),            // !False && True = True && True = True? Нет
                // Исправим: используем &
                (a > b) & (c == d),              // False & True = False
                
                // 5. False: <= и |
                (b <= a) | (c != d),             // False | False = False
                
                // 6. False: >= и арифметическое выражение
                (a >= b) && ((c + d) < a)        // False && (268 < 185) = False && False = False
            };
        }

        static bool[] GenerateSequenceVariant3(int a, int b, int c, int d)
        {
            // Еще один вариант с разными комбинациями

            return new bool[]
            {
                // 1. True
                (c == d) || ((b - a) > 0),       // True || True = True
                
                // 2. False
                (a == b) && ((c * 2) != (d + d)), // False && False = False
                
                // 3. False
                (a > b) & ((c + 0) == d),        // False & True = False
                
                // 4. False
                ((b - 131) <= a) ^ (c == d),     // (185 <= 185) ^ True = True ^ True = False
                
                // 5. False
                (a >= (b - 131)) | (c != d),     // (185 >= 185) | False = True | False = True? Нет
                // Исправим:
                (a >= b) | (c != d),             // False | False = False
                
                // 6. False
                ((a + c) < b) && (d == c)        // (319 < 316) && True = False && True = False
            };
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
            bool[] expected = { true, false, false, false, false, false };
            bool isCorrect = true;

            for (int i = 0; i < expected.Length; i++)
            {
                if (sequence[i] != expected[i])
                {
                    isCorrect = false;
                    Console.WriteLine($"  Ошибка в элементе {i + 1}: получено {sequence[i]}, ожидалось {expected[i]}");
                }
            }

            if (isCorrect)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("  ✓ Последовательность верна!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  ✗ Последовательность неверна!");
                Console.ResetColor();
            }
        }
    }
}