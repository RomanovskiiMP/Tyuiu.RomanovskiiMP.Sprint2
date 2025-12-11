using tyuiu.cources.programming.interfaces;
using System;

namespace DayOfWeekCalculator
{
    public static class DayCalculator
    {
        // Метод вычисления дня недели (публичный статический)
        public static int CalculateDayOfWeek(int k, int d)
        {
            // Формула: день_недели = (d + (k - 1)) % 7
            // Но так как у нас нумерация с 1 (не с 0), нужно корректировать
            int dayNumber = (d + (k - 1)) % 7;

            // Если остаток 0, это воскресенье (7)
            return dayNumber == 0 ? 7 : dayNumber;
        }

        // Метод получения названия дня недели с использованием switch
        public static string GetDayName(int dayNumber)
        {
            switch (dayNumber)
            {
                case 1:
                    return "ПОНЕДЕЛЬНИК";
                case 2:
                    return "ВТОРНИК";
                case 3:
                    return "СРЕДА";
                case 4:
                    return "ЧЕТВЕРГ";
                case 5:
                    return "ПЯТНИЦА";
                case 6:
                    return "СУББОТА";
                case 7:
                    return "ВОСКРЕСЕНЬЕ";
                default:
                    return "НЕИЗВЕСТНЫЙ ДЕНЬ";
            }
        }

        // Альтернативный метод с использованием switch expression (C# 8.0+)
        public static string GetDayNameSwitchExpression(int dayNumber) => dayNumber switch
        {
            1 => "ПОНЕДЕЛЬНИК",
            2 => "ВТОРНИК",
            3 => "СРЕДА",
            4 => "ЧЕТВЕРГ",
            5 => "ПЯТНИЦА",
            6 => "СУББОТА",
            7 => "ВОСКРЕСЕНЬЕ",
            _ => "НЕИЗВЕСТНЫЙ ДЕНЬ"
        };
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа определения дня недели по номеру дня в году");
            Console.WriteLine("=====================================================");
            Console.WriteLine("Условия:");
            Console.WriteLine("- 1 <= k <= 365 (номер дня в невисокосном году)");
            Console.WriteLine("- 1 <= d <= 7 (день недели 1 января: 1-понедельник, 7-воскресенье)");
            Console.WriteLine();

            try
            {
                // Ввод данных
                Console.Write("Введите номер дня в году (k): ");
                int k = int.Parse(Console.ReadLine());

                Console.Write("Введите день недели 1 января (d от 1 до 7): ");
                int d = int.Parse(Console.ReadLine());

                // Проверка корректности ввода
                if (k < 1 || k > 365)
                {
                    Console.WriteLine("Ошибка: k должен быть в диапазоне от 1 до 365");
                    return;
                }

                if (d < 1 || d > 7)
                {
                    Console.WriteLine("Ошибка: d должен быть в диапазоне от 1 до 7");
                    return;
                }

                // Вычисление дня недели для k-го дня
                int dayOfWeek = DayCalculator.CalculateDayOfWeek(k, d);

                // Вывод результата с использованием switch
                Console.WriteLine($"\nРезультат: {k}-й день года - это {DayCalculator.GetDayName(dayOfWeek)}");

                // Дополнительная информация
                Console.WriteLine($"\nПодробный расчет:");
                Console.WriteLine($"1 января: {DayCalculator.GetDayName(d)} (d = {d})");
                Console.WriteLine($"k-й день: {k}");
                Console.WriteLine($"Остаток от деления (k-1) на 7: {(k - 1) % 7}");
                Console.WriteLine($"Итоговый номер дня недели: {dayOfWeek}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Введите целые числа!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}