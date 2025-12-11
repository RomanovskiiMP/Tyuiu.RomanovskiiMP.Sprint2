[assembly: Parallelize(Scope = ExecutionScope.MethodLevel)]
// CalculateDayOfWeek.cs - отдельный файл с классом
namespace DayOfWeekCalculator
{
    public class CalculateDayOfWeek
    {
        public CalculateDayOfWeek()
        {
        }

        // Метод вычисления дня недели
        public int Calculate(int k, int d)
        {
            int dayNumber = (d + (k - 1)) % 7;
            return dayNumber == 0 ? 7 : dayNumber;
        }

        // Метод с использованием switch
        public string GetDayName(int dayNumber)
        {
            switch (dayNumber)
            {
                case 1: return "Понедельник";
                case 2: return "Вторник";
                case 3: return "Среда";
                case 4: return "Четверг";
                case 5: return "Пятница";
                case 6: return "Суббота";
                case 7: return "Воскресенье";
                default: return "Неизвестно";
            }
        }
    }
}

// В Program.cs тогда используем так:
// var calculator = new CalculateDayOfWeek();
// int result = calculator.Calculate(k, d);
// string dayName = calculator.GetDayName(result);