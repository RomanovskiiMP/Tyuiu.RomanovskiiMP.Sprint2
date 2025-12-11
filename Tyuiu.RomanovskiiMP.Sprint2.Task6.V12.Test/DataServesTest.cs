using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PreviousDayCalculator.Tests
{
    [TestClass]
    public class DateCalculatorTests
    {
        [TestMethod]
        public void GetPreviousDay_MiddleOfMonth_ReturnsPreviousDay()
        {
            // Arrange
            int g = 2024; // Високосный год
            int m = 6;    // Июнь
            int n = 15;   // 15 число

            // Act
            var result = DateCalculator.GetPreviousDay(g, m, n);
            int year = result.year;
            int month = result.month;
            int day = result.day;

            // Assert
            Assert.AreEqual(2024, year);
            Assert.AreEqual(6, month);
            Assert.AreEqual(14, day);
        }

        [TestMethod]
        public void GetPreviousDay_FirstDayOfMonth_ReturnsLastDayOfPreviousMonth()
        {
            // Arrange
            int g = 2024; // Високосный год
            int m = 3;    // Март
            int n = 1;    // 1 марта

            // Act
            var result = DateCalculator.GetPreviousDay(g, m, n);
            int year = result.year;
            int month = result.month;
            int day = result.day;

            // Assert
            Assert.AreEqual(2024, year);
            Assert.AreEqual(2, month); // Февраль
            Assert.AreEqual(29, day);  // 29 февраля (високосный год)
        }

        [TestMethod]
        public void GetPreviousDay_FirstDayOfYear_ReturnsLastDayOfPreviousYear()
        {
            // Arrange
            int g = 2024; // Високосный год
            int m = 1;    // Январь
            int n = 1;    // 1 января

            // Act
            var result = DateCalculator.GetPreviousDay(g, m, n);
            int year = result.year;
            int month = result.month;
            int day = result.day;

            // Assert
            Assert.AreEqual(2023, year);
            Assert.AreEqual(12, month); // Декабрь
            Assert.AreEqual(31, day);   // 31 декабря
        }

        [TestMethod]
        public void GetPreviousDay_FebruaryInLeapYear_ReturnsCorrectDays()
        {
            // Arrange - 1 марта високосного года
            int g = 2024;
            int m = 3;
            int n = 1;

            // Act
            var result = DateCalculator.GetPreviousDay(g, m, n);
            int year = result.year;
            int month = result.month;
            int day = result.day;

            // Assert
            Assert.AreEqual(2024, year);
            Assert.AreEqual(2, month); // Февраль
            Assert.AreEqual(29, day);  // 29 февраля
        }

        [TestMethod]
        public void GetPreviousDay_TransitionBetweenMonths_ReturnsCorrectDate()
        {
            // Тестируем переходы между месяцами с разным количеством дней
            TestCase(2024, 5, 1, 2024, 4, 30);  // 1 мая -> 30 апреля
            TestCase(2024, 7, 1, 2024, 6, 30);  // 1 июля -> 30 июня
            TestCase(2024, 8, 1, 2024, 7, 31);  // 1 августа -> 31 июля
            TestCase(2024, 10, 1, 2024, 9, 30); // 1 октября -> 30 сентября
            TestCase(2024, 12, 1, 2024, 11, 30); // 1 декабря -> 30 ноября

            void TestCase(int g, int m, int n, int expY, int expM, int expD)
            {
                // Act
                var result = DateCalculator.GetPreviousDay(g, m, n);

                // Assert
                Assert.AreEqual(expY, result.year, $"Год не совпадает для даты {n}.{m}.{g}");
                Assert.AreEqual(expM, result.month, $"Месяц не совпадает для даты {n}.{m}.{g}");
                Assert.AreEqual(expD, result.day, $"День не совпадает для даты {n}.{m}.{g}");
            }
        }

        [TestMethod]
        public void GetDaysInMonth_LeapYearFebruary_Returns29()
        {
            // Arrange
            int year = 2024; // Високосный год
            int month = 2;   // Февраль

            // Act
            int days = DateCalculator.GetDaysInMonth(year, month);

            // Assert
            Assert.AreEqual(29, days);
        }

        [TestMethod]
        public void GetDaysInMonth_NonLeapYearFebruary_Returns28()
        {
            // Arrange (хотя по условию год всегда високосный, тестируем для полноты)
            int year = 2023; // Не високосный
            int month = 2;

            // Act
            int days = DateCalculator.GetDaysInMonth(year, month);

            // Assert
            Assert.AreEqual(28, days);
        }

        [TestMethod]
        public void GetMonthName_ValidMonths_ReturnsCorrectNames()
        {
            // Act & Assert
            Assert.AreEqual("Январь", DateCalculator.GetMonthName(1));
            Assert.AreEqual("Февраль", DateCalculator.GetMonthName(2));
            Assert.AreEqual("Март", DateCalculator.GetMonthName(3));
            Assert.AreEqual("Апрель", DateCalculator.GetMonthName(4));
            Assert.AreEqual("Май", DateCalculator.GetMonthName(5));
            Assert.AreEqual("Июнь", DateCalculator.GetMonthName(6));
            Assert.AreEqual("Июль", DateCalculator.GetMonthName(7));
            Assert.AreEqual("Август", DateCalculator.GetMonthName(8));
            Assert.AreEqual("Сентябрь", DateCalculator.GetMonthName(9));
            Assert.AreEqual("Октябрь", DateCalculator.GetMonthName(10));
            Assert.AreEqual("Ноябрь", DateCalculator.GetMonthName(11));
            Assert.AreEqual("Декабрь", DateCalculator.GetMonthName(12));
        }

        [TestMethod]
        public void GetMonthName_InvalidMonth_ReturnsUnknown()
        {
            // Act & Assert
            Assert.AreEqual("Неизвестный месяц", DateCalculator.GetMonthName(0));
            Assert.AreEqual("Неизвестный месяц", DateCalculator.GetMonthName(13));
            Assert.AreEqual("Неизвестный месяц", DateCalculator.GetMonthName(-1));
        }

        [TestMethod]
        public void IsLeapYear_LeapYears_ReturnsTrue()
        {
            // Високосные годы
            Assert.IsTrue(DateCalculator.IsLeapYear(2024));
            Assert.IsTrue(DateCalculator.IsLeapYear(2000));
            Assert.IsTrue(DateCalculator.IsLeapYear(2400));
            Assert.IsTrue(DateCalculator.IsLeapYear(2020));
        }

        [TestMethod]
        public void IsLeapYear_NonLeapYears_ReturnsFalse()
        {
            // Не високосные годы
            Assert.IsFalse(DateCalculator.IsLeapYear(2023));
            Assert.IsFalse(DateCalculator.IsLeapYear(1900));
            Assert.IsFalse(DateCalculator.IsLeapYear(2100));
            Assert.IsFalse(DateCalculator.IsLeapYear(2022));
        }

        [TestMethod]
        public void IsValidDate_ValidDates_ReturnsTrue()
        {
            // Valid dates
            Assert.IsTrue(DateCalculator.IsValidDate(2024, 1, 1));
            Assert.IsTrue(DateCalculator.IsValidDate(2024, 2, 29)); // Високосный год
            Assert.IsTrue(DateCalculator.IsValidDate(2024, 12, 31));
            Assert.IsTrue(DateCalculator.IsValidDate(2023, 2, 28)); // Не високосный
        }

        [TestMethod]
        public void IsValidDate_InvalidDates_ReturnsFalse()
        {
            // Invalid dates
            Assert.IsFalse(DateCalculator.IsValidDate(2024, 2, 30)); // В феврале нет 30 числа
            Assert.IsFalse(DateCalculator.IsValidDate(2024, 4, 31)); // В апреле 30 дней
            Assert.IsFalse(DateCalculator.IsValidDate(2024, 13, 1)); // Неправильный месяц
            Assert.IsFalse(DateCalculator.IsValidDate(2024, 0, 1));  // Месяц 0
            Assert.IsFalse(DateCalculator.IsValidDate(2024, 1, 0));  // День 0
            Assert.IsFalse(DateCalculator.IsValidDate(2024, 1, 32)); // В январе 31 день
        }

        [TestMethod]
        public void GetPreviousDay_AllMonthStarts_ReturnsCorrectLastDays()
        {
            // Тестируем первые числа всех месяцев високосного года
            int[] daysInMonths = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            for (int month = 1; month <= 12; month++)
            {
                // Arrange
                int g = 2024;
                int m = month;
                int n = 1;

                // Act
                var result = DateCalculator.GetPreviousDay(g, m, n);

                // Assert
                if (month == 1)
                {
                    Assert.AreEqual(2023, result.year);
                    Assert.AreEqual(12, result.month);
                    Assert.AreEqual(31, result.day);
                }
                else
                {
                    Assert.AreEqual(2024, result.year);
                    Assert.AreEqual(month - 1, result.month);
                    Assert.AreEqual(daysInMonths[month - 2], result.day);
                }
            }
        }

        [TestMethod]
        public void GetPreviousDay_RandomValidDates_ReturnsValidDates()
        {
            Random rand = new Random(12345); // Фиксированный seed для повторяемости

            for (int i = 0; i < 100; i++)
            {
                // Arrange
                int g = rand.Next(1900, 2101);
                int m = rand.Next(1, 13);
                int maxDay = DateCalculator.GetDaysInMonth(g, m);
                int n = rand.Next(1, maxDay + 1);

                // Act
                var result = DateCalculator.GetPreviousDay(g, m, n);

                // Assert - проверяем, что получилась валидная дата
                Assert.IsTrue(DateCalculator.IsValidDate(result.year, result.month, result.day),
                    $"Невалидная дата: {result.day}.{result.month}.{result.year} для исходной {n}.{m}.{g}");
            }
        }
    }
}