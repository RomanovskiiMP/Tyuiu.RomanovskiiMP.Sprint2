using System;

namespace FunctionCalculator
{
    public static class FunctionCalculator
    {
        public static double CalculateY(double x)
        {
            if (x > 1)
            {
                // y = x + ((x+1)/(x-1))^x
                return x + Math.Pow((x + 1) / (x - 1), x);
            }
            else if (Math.Abs(x) < 1e-10) // x == 0 с учётом погрешности для double
            {
                // y = (x^2 + cos(x^2)) / (x^2 - sin(x^2) + 12)
                double x2 = x * x;
                return (x2 + Math.Cos(x2)) / (x2 - Math.Sin(x2) + 12);
            }
            else if (x > -8 && x < 0)
            {
                // y = (x - 1/x^2)^x
                return Math.Pow(x - 1 / (x * x), x);
            }
            else if (x < -8)
            {
                // y = x + 10x - (1/x)
                return x + 10 * x - (1 / x);
            }
            else
            {
                // Для x = 1, x = -8 и других граничных значений
                throw new ArgumentException($"Значение x = {x} не попадает в область определения функции");
            }
        }

        public static double RoundToThreeDecimalPlaces(double value)
        {
            return Math.Round(value, 3);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа вычисления значения функции Y");
            Console.WriteLine("=========================================");

            try
            {
                Console.Write("Введите значение x: ");
                string input = Console.ReadLine();

                if (double.TryParse(input, out double x))
                {
                    double y = FunctionCalculator.CalculateY(x);
                    double roundedY = FunctionCalculator.RoundToThreeDecimalPlaces(y);

                    Console.WriteLine($"\nРезультат вычисления:");
                    Console.WriteLine($"y = {y:F10}");
                    Console.WriteLine($"y (округлено до 3 знаков) = {roundedY:F3}");
                }
                else
                {
                    Console.WriteLine("Ошибка: Введено некорректное число");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка вычисления: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}