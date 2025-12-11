using System;

namespace QuantumSchizoCalculator
{
    // Класс для вычисления "шизофренической" функции
    public static class SchizoMath
    {
        // Основной метод вычисления по "шизофренической" формуле
        public static double CalculateSchizoValue(double x, double y)
        {
            // Шизофреническая логика с тернарным оператором
            double result = (x < y * 2 - 10)
                ? Math.Pow(1 + (y + 2) / (x * x + 0.0001), x)  // Защита от деления на 0
                : Math.Cos(x * y) * Math.Sin(x + y) / (Math.Abs(x - y) + 1);

            // Добавляем немного "шизофрении" (случайный элемент)
            Random rand = new Random();
            double chaos = rand.NextDouble() * 0.001; // Маленький хаос
            return result + chaos;
        }

        // Альтернативный "шизофренический" метод
        public static double CalculateCrazyFormula(double x, double y)
        {
            // Совершенно безумная формула
            return (Math.Tan(x) * Math.Log(Math.Abs(y) + 1) +
                   Math.Pow(Math.E, Math.Sin(x * y))) /
                   (Math.Sqrt(Math.Abs(x - y)) + 0.5);
        }

        // Метод для проверки "шизофренического" условия
        public static bool IsSchizoConditionMet(double x, double y)
        {
            // Условие из задания + немного безумия
            return x < y * 2 - 10 || Math.Abs(x - y) < 0.001 || (x + y) % 2 == 0;
        }

        // Округление с "шизофренической" точностью
        public static double SchizoRound(double value, int decimals = 3)
        {
            // Иногда округляем, иногда нет (как настоящий шизофреник)
            Random rand = new Random();
            if (rand.NextDouble() > 0.3)
                return Math.Round(value, decimals);
            else
                return value; // Оставляем как есть
        }
    }

    // Главная программа
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ШИЗОФРЕНИЧЕСКИЙ КАЛЬКУЛЯТОР 3000 ===");
            Console.WriteLine("Версия 2.71828 (нестабильная)\n");

            Console.WriteLine("ВНИМАНИЕ: Этот калькулятор страдает раздвоением личности!");
            Console.WriteLine("Он может давать разные результаты на одни и те же входные данные.\n");

            while (true)
            {
                try
                {
                    // Ввод данных с проверкой
                    Console.Write("Введите значение X (или 'выход' для завершения): ");
                    string xInput = Console.ReadLine();
                    if (xInput.ToLower() == "выход" || xInput.ToLower() == "exit")
                        break;

                    Console.Write("Введите значение Y: ");
                    string yInput = Console.ReadLine();

                    if (!double.TryParse(xInput, out double x) || !double.TryParse(yInput, out double y))
                    {
                        Console.WriteLine("Эй, это не числа! Попробуй еще раз...\n");
                        continue;
                    }

                    // Вычисляем разными способами (шизофрения же!)
                    double result1 = SchizoMath.CalculateSchizoValue(x, y);
                    double result2 = SchizoMath.CalculateCrazyFormula(x, y);
                    bool condition = SchizoMath.IsSchizoConditionMet(x, y);
                    double rounded = SchizoMath.SchizoRound(result1);

                    // Выводим "шизофренические" результаты
                    Console.WriteLine("\n" + new string('=', 50));
                    Console.WriteLine($"X = {x}, Y = {y}");
                    Console.WriteLine($"Условие (X < 2Y - 10): {x < y * 2 - 10}");
                    Console.WriteLine($"Шизо-условие выполнено: {condition}");
                    Console.WriteLine($"Результат 1 (основной): {result1:F6}");
                    Console.WriteLine($"Результат 2 (альтернативный): {result2:F6}");
                    Console.WriteLine($"Округлено (или нет): {rounded}");

                    // "Шизофренический" комментарий
                    Console.WriteLine("\nКомментарий системы: " + GetSchizoComment(result1));
                    Console.WriteLine(new string('=', 50) + "\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("Но шизофреник никогда не сдается! Продолжаем...\n");
                }
            }

            Console.WriteLine("\nПрограмма завершена. Голоса в моей голове говорят 'до свидания'!");
            Console.ReadKey();
        }

        // Метод для генерации "шизофренических" комментариев
        private static string GetSchizoComment(double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                return "Результат улетел в параллельную вселенную!";

            if (Math.Abs(value) > 1000)
                return "Внимание! Обнаружен гипер-результат!";

            if (Math.Abs(value) < 0.001)
                return "Результат настолько мал, что его не видно без микроскопа!";

            string[] comments =
            {
                "Голоса одобряют этот результат!",
                "Мои альтер-эго согласны с вычислением.",
                "Этот результат пахнет фиалками по вторникам...",
                "Число-близнец говорит, что все верно!",
                "Результат прошел проверку параноидальным сканером!",
                "Матрица не возражает против этого значения."
            };

            Random rand = new Random();
            return comments[rand.Next(comments.Length)];
        }
    }
}