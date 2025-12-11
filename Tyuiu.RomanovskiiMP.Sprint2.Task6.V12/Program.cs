using System;

namespace PreviousDayCalculator
{

    public static class DateCalculator
    {
        // Основной метод для вычисления предыдущего дня (использует switch expression)
        public static (int year, int month, int day) GetPreviousDay(int g, int m, int n)
        {
            // Проверяем, не первый ли день года
            if (m == 1 && n == 1)
            {
                // Предыдущий день - 31 декабря предыдущего года
                return (g - 1, 12, 31);
            }

            // Если не первый день месяца
            if (n > 1)
            {
                return (g, m, n - 1);
            }

            // Если первый день месяца, определяем предыдущий месяц
            int prevMonth = m - 1;

            // Определяем количество дней в предыдущем месяце с использованием switch expression
            int daysInPrevMonth = prevMonth switch
            {
                1 => 31,   // Январь
                2 => IsLeapYear(g) ? 29 : 28, // Февраль (високосный год по условию)
                3 => 31,   // Март
                4 => 30,   // Апрель
                5 => 31,   // Май
                6 => 30,   // Июнь
                7 => 31,   // Июль
                8 => 31,   // Август
                9 => 30,   // Сентябрь
                10 => 31,  // Октябрь
                11 => 30,  // Ноябрь
                12 => 31,  // Декабрь
                _ => throw new ArgumentException("Некорректный номер месяца")
            };

            return (g, prevMonth, daysInPrevMonth);
        }

        // Проверка на високосный год (хотя по условию год всегда високосный)
        public static bool IsLeapYear(int year) =>
            (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);

        // Получение названия месяца с использованием switch expression
        public static string GetMonthName(int month) => month switch
        {
            1 => "Январь",
            2 => "Февраль",
            3 => "Март",
            4 => "Апрель",
            5 => "Май",
            6 => "Июнь",
            7 => "Июль",
            8 => "Август",
            9 => "Сентябрь",
            10 => "Октябрь",
            11 => "Ноябрь",
            12 => "Декабрь",
            _ => "Неизвестный месяц"
        };

        // Получение количества дней в месяце с использованием switch expression
        public static int GetDaysInMonth(int year, int month) => month switch
        {
            1 => 31,
            2 => IsLeapYear(year) ? 29 : 28,
            3 => 31,
            4 => 30,
            5 => 31,
            6 => 30,
            7 => 31,
            8 => 31,
            9 => 30,
            10 => 31,
            11 => 30,
            12 => 31,
            _ => 0
        };

        // Проверка корректности даты
        public static bool IsValidDate(int year, int month, int day)
        {
            if (year < 1 || month < 1 || month > 12 || day < 1)
                return false;

            return day <= GetDaysInMonth(year, month);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ПРОГРАММА ОПРЕДЕЛЕНИЯ ПРЕДЫДУЩЕГО ДНЯ");
            Console.WriteLine("========================================");
            Console.WriteLine("Введите дату (год является високосным по условию):");
            Console.WriteLine();

            try
            {
                // Ввод данных
                Console.Write("Год (g): ");
                int g = int.Parse(Console.ReadLine());

                Console.Write("Месяц (m, 1-12): ");
                int m = int.Parse(Console.ReadLine());

                Console.Write("Число (n): ");
                int n = int.Parse(Console.ReadLine());

                // Проверка корректности ввода
                if (!DateCalculator.IsValidDate(g, m, n))
                {
                    Console.WriteLine("Ошибка: Введена некорректная дата!");
                    return;
                }

                // Вывод введенной даты
                Console.WriteLine($"\nВведенная дата: {n} {DateCalculator.GetMonthName(m)} {g} года");

                // Проверка, является ли год високосным (для информации)
                bool isLeap = DateCalculator.IsLeapYear(g);
                Console.WriteLine($"Год {(isLeap ? "високосный" : "не високосный")} (по условию - високосный)");

                // Вычисление предыдущего дня
                var (prevYear, prevMonth, prevDay) = DateCalculator.GetPreviousDay(g, m, n);

                // Вывод результата
                Console.WriteLine("\nРЕЗУЛЬТАТ:");
                Console.WriteLine($"Предыдущий день: {prevDay} {DateCalculator.GetMonthName(prevMonth)} {prevYear} года");

                // Дополнительная информация
                Console.WriteLine("\nДетали расчета:");
                Console.WriteLine($"Количество дней в предыдущем месяце: {DateCalculator.GetDaysInMonth(prevYear, prevMonth)}");

                // Проверяем особые случаи
                if (m == 1 && n == 1)
                {
                    Console.WriteLine("Это был первый день года!");
                }
                else if (n == 1)
                {
                    Console.WriteLine("Это был первый день месяца!");
                }

                // Пример использования switch expression для дня недели (дополнительно)
                Console.WriteLine("\nДень недели предыдущего дня: " +
                    GetDayOfWeekName((prevYear, prevMonth, prevDay)));
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Введите целые числа!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        // Дополнительный метод с использованием switch expression для дня недели
        static string GetDayOfWeekName((int year, int month, int day) date)
        {
            // Простая демонстрация switch expression
            // В реальном приложении здесь был бы расчет дня недели
            int dayCode = (date.year + date.month + date.day) % 7;

            return dayCode switch
            {
                0 => "Воскресенье",
                1 => "Понедельник",
                2 => "Вторник",
                3 => "Среда",
                4 => "Четверг",
                5 => "Пятница",
                6 => "Суббота",
                _ => "Неизвестно"
            };
        }
    }
}