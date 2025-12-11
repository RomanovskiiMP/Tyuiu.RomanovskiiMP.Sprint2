using System;

namespace PointInAreaChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ПРОГРАММА ПРОВЕРКИ НАХОЖДЕНИЯ ТОЧКИ В ОБЛАСТИ");
            Console.WriteLine("==============================================");
            Console.WriteLine("Уравнение окружности: x² + y² = 1");
            Console.WriteLine();

            // Ввод координат
            Console.Write("Введите координату X: ");
            double x = double.Parse(Console.ReadLine());

            Console.Write("Введите координату Y: ");
            double y = double.Parse(Console.ReadLine());

            Console.WriteLine($"\nТочка: ({x:F2}, {y:F2})");

            // Вариант 1: Внутри круга (x² + y² ≤ 1)
            bool insideCircle = (x * x + y * y) <= 1;

            // Вариант 2: На границе окружности (x² + y² = 1) с погрешностью
            bool onCircle = Math.Abs(x * x + y * y - 1) < 0.001;

            // Вариант 3: Вне круга (x² + y² > 1)
            bool outsideCircle = (x * x + y * y) > 1;

            // Вариант 4: Внутри кольца (0.5² ≤ x² + y² ≤ 1)
            bool inRing = (x * x + y * y >= 0.25) && (x * x + y * y <= 1);

            // Вариант 5: В верхней полуокружности (y ≥ 0 и x² + y² ≤ 1)
            bool inUpperSemiCircle = (y >= 0) && (x * x + y * y <= 1);

            // Вариант 6: В правой полуокружности (x ≥ 0 и x² + y² ≤ 1)
            bool inRightSemiCircle = (x >= 0) && (x * x + y * y <= 1);

            Console.WriteLine("\nРЕЗУЛЬТАТЫ ПРОВЕРКИ:");
            Console.WriteLine("====================");

            // Основная проверка (предполагаем, что заштрихован круг)
            Console.WriteLine($"1. Внутри круга (x² + y² ≤ 1): {(insideCircle ? "ДА" : "НЕТ")}");

            if (onCircle)
            {
                Console.WriteLine("   Точка находится НА ГРАНИЦЕ окружности");
            }

            // Дополнительные варианты
            Console.WriteLine("\nДОПОЛНИТЕЛЬНЫЕ ВАРИАНТЫ:");
            Console.WriteLine($"2. На границе окружности: {(onCircle ? "ДА" : "НЕТ")}");
            Console.WriteLine($"3. Вне круга: {(outsideCircle ? "ДА" : "НЕТ")}");
            Console.WriteLine($"4. В кольце (0.5² ≤ x² + y² ≤ 1): {(inRing ? "ДА" : "НЕТ")}");
            Console.WriteLine($"5. В верхней полуокружности: {(inUpperSemiCircle ? "ДА" : "НЕТ")}");
            Console.WriteLine($"6. В правой полуокружности: {(inRightSemiCircle ? "ДА" : "НЕТ")}");

            // Графическое представление
            Console.WriteLine("\nГРАФИЧЕСКОЕ ПРЕДСТАВЛЕНИЕ:");
            Console.WriteLine("(масштаб: 1 единица = 10 символов)");
            DrawPointInCircle(x, y);

            // Примеры точек для понимания
            Console.WriteLine("\nПРИМЕРЫ ТОЧЕК:");
            Console.WriteLine("(0, 0) - внутри круга ✓");
            Console.WriteLine("(1, 0) - на границе ✓");
            Console.WriteLine("(0, 1) - на границе ✓");
            Console.WriteLine("(0.7, 0.7) - внутри круга ✓");
            Console.WriteLine("(1.5, 1.5) - вне круга ✗");

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        // Метод для графического представления
        static void DrawPointInCircle(double x, double y)
        {
            int size = 21; // нечетное для симметрии
            double scale = 2.0; // масштаб

            Console.WriteLine();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    // Преобразуем координаты экрана в математические
                    double screenX = (j - size / 2) / (double)(size / 2) * scale;
                    double screenY = -(i - size / 2) / (double)(size / 2) * scale;

                    // Проверяем, где находится текущая позиция
                    double distanceSquared = screenX * screenX + screenY * screenY;

                    // Проверяем, не наша ли это точка
                    double pointDistance = Math.Sqrt((screenX - x) * (screenX - x) +
                                                     (screenY - y) * (screenY - y));

                    char symbol;

                    if (pointDistance < 0.15)
                    {
                        symbol = '●'; // Наша точка
                    }
                    else if (Math.Abs(distanceSquared - 1) < 0.1)
                    {
                        symbol = '·'; // Граница окружности
                    }
                    else if (distanceSquared < 1)
                    {
                        symbol = '░'; // Внутри круга
                    }
                    else
                    {
                        symbol = ' '; // Снаружи
                    }

                    Console.Write(symbol);
                }
                Console.WriteLine();
            }
        }
    }
}