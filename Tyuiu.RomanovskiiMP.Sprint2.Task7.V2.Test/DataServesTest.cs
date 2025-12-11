using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PointInAreaChecker.Tests
{
    [TestClass]
    public class PointInCircleTests
    {
        // Основные тесты для круга x² + y² ≤ 1

        [TestMethod]
        public void Point_AtOrigin_IsInsideCircle()
        {
            // Arrange
            double x = 0;
            double y = 0;

            // Act & Assert
            Assert.IsTrue(x * x + y * y <= 1);
        }

        [TestMethod]
        public void Point_OnCircle_IsOnBoundary()
        {
            // Arrange
            double x = 1;
            double y = 0;

            // Act
            double distanceSquared = x * x + y * y;

            // Assert
            Assert.AreEqual(1.0, distanceSquared, 0.0001);
        }

        [TestMethod]
        public void Point_OutsideCircle_IsOutside()
        {
            // Arrange
            double x = 1.5;
            double y = 1.5;

            // Act & Assert
            Assert.IsTrue(x * x + y * y > 1);
        }

        [TestMethod]
        public void Point_InsideCircle_ButNotAtCenter()
        {
            // Arrange
            double x = 0.5;
            double y = 0.5;

            // Act
            double distanceSquared = x * x + y * y;

            // Assert
            Assert.IsTrue(distanceSquared <= 1);
            Assert.AreEqual(0.5, distanceSquared, 0.01);
        }

        // Тесты для верхней полуокружности

        [TestMethod]
        public void Point_InUpperSemiCircle_WhenYPositive()
        {
            // Arrange
            double x = 0.5;
            double y = 0.5;

            // Act & Assert
            Assert.IsTrue(y >= 0 && x * x + y * y <= 1);
        }

        [TestMethod]
        public void Point_NotInUpperSemiCircle_WhenYNegative()
        {
            // Arrange
            double x = 0.5;
            double y = -0.5;

            // Act & Assert
            Assert.IsFalse(y >= 0 && x * x + y * y <= 1);
        }

        // Тесты для правой полуокружности

        [TestMethod]
        public void Point_InRightSemiCircle_WhenXPositive()
        {
            // Arrange
            double x = 0.5;
            double y = 0.2;

            // Act & Assert
            Assert.IsTrue(x >= 0 && x * x + y * y <= 1);
        }

        [TestMethod]
        public void Point_NotInRightSemiCircle_WhenXNegative()
        {
            // Arrange
            double x = -0.5;
            double y = 0.2;

            // Act & Assert
            Assert.IsFalse(x >= 0 && x * x + y * y <= 1);
        }

        // Тесты для кольца

        [TestMethod]
        public void Point_InRing_WhenBetweenHalfAndOne()
        {
            // Arrange
            double x = 0.6;
            double y = 0.6;

            // Act
            double distanceSquared = x * x + y * y;
            bool inRing = distanceSquared >= 0.25 && distanceSquared <= 1;

            // Assert
            Assert.IsTrue(inRing);
        }

        [TestMethod]
        public void Point_NotInRing_WhenTooCloseToCenter()
        {
            // Arrange
            double x = 0.2;
            double y = 0.2;

            // Act
            double distanceSquared = x * x + y * y;
            bool inRing = distanceSquared >= 0.25 && distanceSquared <= 1;

            // Assert
            Assert.IsFalse(inRing);
        }

        [TestMethod]
        public void Point_NotInRing_WhenOutsideCircle()
        {
            // Arrange
            double x = 1.2;
            double y = 1.2;

            // Act
            double distanceSquared = x * x + y * y;
            bool inRing = distanceSquared >= 0.25 && distanceSquared <= 1;

            // Assert
            Assert.IsFalse(inRing);
        }

        // Граничные тесты

        [TestMethod]
        public void Point_ExactlyAtRadiusHalf()
        {
            // Arrange
            // Точка на расстоянии 0.5 от центра
            // x² + y² = 0.25
            double x = 0.5;
            double y = 0;

            // Act
            double distanceSquared = x * x + y * y;

            // Assert
            Assert.AreEqual(0.25, distanceSquared, 0.0001);
            Assert.IsTrue(distanceSquared <= 1);
        }

        [TestMethod]
        public void Point_ExactlyAtRadiusOne()
        {
            // Arrange
            double x = 0;
            double y = 1;

            // Act
            double distanceSquared = x * x + y * y;

            // Assert
            Assert.AreEqual(1.0, distanceSquared, 0.0001);
        }

        // Тесты с отрицательными координатами

        [TestMethod]
        public void Point_WithNegativeCoordinates_InsideCircle()
        {
            // Arrange
            double x = -0.3;
            double y = -0.4;

            // Act & Assert
            Assert.IsTrue(x * x + y * y <= 1);
        }

        // Интеграционные тесты

        [TestMethod]
        public void MultiplePoints_Test()
        {
            // Массив точек для тестирования
            var testPoints = new[]
            {
                new { X = 0.0, Y = 0.0, ExpectedInside = true },
                new { X = 0.7, Y = 0.7, ExpectedInside = true },
                new { X = 1.0, Y = 0.0, ExpectedInside = true }, // на границе
                new { X = 0.0, Y = 1.0, ExpectedInside = true }, // на границе
                new { X = 1.5, Y = 0.0, ExpectedInside = false },
                new { X = 0.0, Y = 1.5, ExpectedInside = false },
                new { X = -0.7, Y = -0.7, ExpectedInside = true },
                new { X = 0.95, Y = 0.0, ExpectedInside = true },
                new { X = 0.0, Y = 0.95, ExpectedInside = true }
            };

            foreach (var point in testPoints)
            {
                // Act
                bool isInside = point.X * point.X + point.Y * point.Y <= 1;

                // Assert
                Assert.AreEqual(point.ExpectedInside, isInside,
                    $"Точка ({point.X}, {point.Y}) - ожидалось: {point.ExpectedInside}, получено: {isInside}");
            }
        }

        // Тест для особых случаев

        [TestMethod]
        public void SpecialCases_Test()
        {
            // Точка очень близко к границе изнутри
            Assert.IsTrue(0.999 * 0.999 + 0 * 0 <= 1);

            // Точка очень близко к границе снаружи
            Assert.IsFalse(1.001 * 1.001 + 0 * 0 <= 1);

            // Точка на диагонали
            double diagonalPoint = Math.Sqrt(0.5); // ~0.707
            Assert.IsTrue(diagonalPoint * diagonalPoint + diagonalPoint * diagonalPoint <= 1);
        }
    }

    // Дополнительный класс тестов для разных областей
    [TestClass]
    public class DifferentAreasTests
    {
        [TestMethod]
        public void Test_QuarterCircle_TopRight()
        {
            // Проверка верхней правой четверти круга (x ≥ 0, y ≥ 0, x² + y² ≤ 1)
            Assert.IsTrue(CheckQuarterCircle(0.5, 0.5, 1));  // Внутри
            Assert.IsTrue(CheckQuarterCircle(0, 0.9, 1));    // На границе по Y
            Assert.IsTrue(CheckQuarterCircle(0.9, 0, 1));    // На границе по X
            Assert.IsFalse(CheckQuarterCircle(-0.5, 0.5, 1)); // X отрицательный
            Assert.IsFalse(CheckQuarterCircle(0.5, -0.5, 1)); // Y отрицательный
            Assert.IsFalse(CheckQuarterCircle(1.1, 0, 1));   // Снаружи
        }

        private bool CheckQuarterCircle(double x, double y, int quarter)
        {
            switch (quarter)
            {
                case 1: // Верхняя правая четверть
                    return x >= 0 && y >= 0 && x * x + y * y <= 1;
                case 2: // Верхняя левая четверть
                    return x <= 0 && y >= 0 && x * x + y * y <= 1;
                case 3: // Нижняя левая четверть
                    return x <= 0 && y <= 0 && x * x + y * y <= 1;
                case 4: // Нижняя правая четверть
                    return x >= 0 && y <= 0 && x * x + y * y <= 1;
                default:
                    return false;
            }
        }
    }
}