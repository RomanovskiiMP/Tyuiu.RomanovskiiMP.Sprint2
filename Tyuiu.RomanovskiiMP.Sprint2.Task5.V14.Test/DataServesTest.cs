using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DayOfWeekCalculator.Tests
{
    [TestClass]
    public class DayCalculatorTests
    {
        [TestMethod]
        public void CalculateDayOfWeek_FirstDayOfYear_ReturnsSameDay()
        {
            // Arrange
            int k = 1; // Первый день года
            int d = 3; // 1 января - среда

            // Act
            int result = DayCalculator.CalculateDayOfWeek(k, d);

            // Assert
            Assert.AreEqual(3, result); // Должен быть тот же день - среда
        }

        [TestMethod]
        public void CalculateDayOfWeek_OneWeekLater_ReturnsSameWeekday()
        {
            // Arrange
            int k = 8; // Через 7 дней (1 + 7)
            int d = 1; // 1 января - понедельник

            // Act
            int result = DayCalculator.CalculateDayOfWeek(k, d);

            // Assert
            Assert.AreEqual(1, result); // Должен быть снова понедельник
        }

        [TestMethod]
        public void CalculateDayOfWeek_MiddleOfYear_ReturnsCorrectDay()
        {
            // Arrange
            int k = 182; // Примерно середина года
            int d = 1; // 1 января - понедельник

            // Act
            int result = DayCalculator.CalculateDayOfWeek(k, d);

            // Assert
            Assert.AreEqual(7, result); // Должен быть воскресенье
        }

        [TestMethod]
        public void CalculateDayOfWeek_LastDayOfYear_ReturnsCorrectDay()
        {
            // Arrange
            int k = 365; // Последний день невисокосного года
            int d = 1; // 1 января - понедельник

            // Act
            int result = DayCalculator.CalculateDayOfWeek(k, d);

            // Assert
            Assert.AreEqual(1, result); // Должен быть понедельник
        }

        [TestMethod]
        public void CalculateDayOfWeek_SundayStart_ReturnsCorrectDays()
        {
            // Arrange
            int d = 7; // 1 января - воскресенье

            // Act & Assert для нескольких дней
            Assert.AreEqual(7, DayCalculator.CalculateDayOfWeek(1, d));  // 1 января - воскресенье
            Assert.AreEqual(1, DayCalculator.CalculateDayOfWeek(2, d));  // 2 января - понедельник
            Assert.AreEqual(2, DayCalculator.CalculateDayOfWeek(3, d));  // 3 января - вторник
            Assert.AreEqual(3, DayCalculator.CalculateDayOfWeek(4, d));  // 4 января - среда
        }

        [TestMethod]
        public void GetDayName_ValidInput_ReturnsCorrectName()
        {
            // Act & Assert
            Assert.AreEqual("ПОНЕДЕЛЬНИК", DayCalculator.GetDayName(1));
            Assert.AreEqual("ВТОРНИК", DayCalculator.GetDayName(2));
            Assert.AreEqual("СРЕДА", DayCalculator.GetDayName(3));
            Assert.AreEqual("ЧЕТВЕРГ", DayCalculator.GetDayName(4));
            Assert.AreEqual("ПЯТНИЦА", DayCalculator.GetDayName(5));
            Assert.AreEqual("СУББОТА", DayCalculator.GetDayName(6));
            Assert.AreEqual("ВОСКРЕСЕНЬЕ", DayCalculator.GetDayName(7));
        }

        [TestMethod]
        public void GetDayName_InvalidInput_ReturnsUnknown()
        {
            // Act & Assert
            Assert.AreEqual("НЕИЗВЕСТНЫЙ ДЕНЬ", DayCalculator.GetDayName(0));
            Assert.AreEqual("НЕИЗВЕСТНЫЙ ДЕНЬ", DayCalculator.GetDayName(8));
            Assert.AreEqual("НЕИЗВЕСТНЫЙ ДЕНЬ", DayCalculator.GetDayName(-1));
        }

        [TestMethod]
        public void CalculateDayOfWeek_AllWeekCombinations_ReturnsCorrectValues()
        {
            // Тестируем все возможные комбинации дней недели для 1 января
            for (int d = 1; d <= 7; d++)
            {
                for (int k = 1; k <= 7; k++)
                {
                    // Act
                    int result = DayCalculator.CalculateDayOfWeek(k, d);

                    // Assert - проверяем цикличность
                    int expected = (d + (k - 1)) % 7;
                    expected = expected == 0 ? 7 : expected;

                    Assert.AreEqual(expected, result,
                        $"Ошибка для d={d}, k={k}. Ожидалось: {expected}, Получено: {result}");
                }
            }
        }

        [TestMethod]
        public void GetDayNameSwitchExpression_ValidInput_ReturnsCorrectName()
        {
            // Act & Assert
            Assert.AreEqual("ПОНЕДЕЛЬНИК", DayCalculator.GetDayNameSwitchExpression(1));
            Assert.AreEqual("ВТОРНИК", DayCalculator.GetDayNameSwitchExpression(2));
            Assert.AreEqual("СРЕДА", DayCalculator.GetDayNameSwitchExpression(3));
            Assert.AreEqual("ЧЕТВЕРГ", DayCalculator.GetDayNameSwitchExpression(4));
            Assert.AreEqual("ПЯТНИЦА", DayCalculator.GetDayNameSwitchExpression(5));
            Assert.AreEqual("СУББОТА", DayCalculator.GetDayNameSwitchExpression(6));
            Assert.AreEqual("ВОСКРЕСЕНЬЕ", DayCalculator.GetDayNameSwitchExpression(7));
        }

        [TestMethod]
        public void GetDayNameSwitchExpression_InvalidInput_ReturnsUnknown()
        {
            // Act & Assert
            Assert.AreEqual("НЕИЗВЕСТНЫЙ ДЕНЬ", DayCalculator.GetDayNameSwitchExpression(0));
            Assert.AreEqual("НЕИЗВЕСТНЫЙ ДЕНЬ", DayCalculator.GetDayNameSwitchExpression(8));
        }

        [TestMethod]
        public void CalculateDayOfWeek_SpecificExamples()
        {
            // Пример 1: 1 января - четверг (d=4), 14 января (k=14) - какой день?
            Assert.AreEqual(3, DayCalculator.CalculateDayOfWeek(14, 4)); // Среда

            // Пример 2: 1 января - суббота (d=6), 100-й день года (k=100)
            Assert.AreEqual(7, DayCalculator.CalculateDayOfWeek(100, 6)); // Воскресенье

            // Пример 3: 1 января - понедельник (d=1), 31 декабря (k=365)
            Assert.AreEqual(1, DayCalculator.CalculateDayOfWeek(365, 1)); // Понедельник
        }

        [TestMethod]
        public void CalculateDayOfWeek_BoundaryValues_HandlesCorrectly()
        {
            // Граничные значения k
            Assert.AreEqual(1, DayCalculator.CalculateDayOfWeek(1, 1));   // Минимальное k
            Assert.AreEqual(3, DayCalculator.CalculateDayOfWeek(365, 3)); // Максимальное k с d=3

            // Граничные значения d
            Assert.AreEqual(50, DayCalculator.CalculateDayOfWeek(50, 1)); // Минимальное d
            Assert.AreEqual(6, DayCalculator.CalculateDayOfWeek(50, 7));  // Максимальное d
        }

        [TestMethod]
        public void CalculateDayOfWeek_RandomDays_ReturnsValidRange()
        {
            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                int k = rand.Next(1, 366);
                int d = rand.Next(1, 8);

                int result = DayCalculator.CalculateDayOfWeek(k, d);

                // Проверяем, что результат в допустимом диапазоне
                Assert.IsTrue(result >= 1 && result <= 7,
                    $"Некорректный результат: {result} для k={k}, d={d}");
            }
        }
    }
}