using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionCalculator.Tests
{
    [TestClass]
    public class FunctionCalculatorTests
    {
        private const double Delta = 0.001; // Точность для сравнения double

        [TestMethod]
        public void CalculateY_XGreaterThan1_ReturnsCorrectValue()
        {
            // Arrange
            double x = 2.0;
            double expected = 2.0 + Math.Pow((2.0 + 1) / (2.0 - 1), 2.0);

            // Act
            double actual = FunctionCalculator.CalculateY(x);

            // Assert
            Assert.AreEqual(expected, actual, Delta);
        }

        [TestMethod]
        public void CalculateY_XEquals0_ReturnsCorrectValue()
        {
            // Arrange
            double x = 0.0;
            double x2 = x * x;
            double expected = (x2 + Math.Cos(x2)) / (x2 - Math.Sin(x2) + 12);

            // Act
            double actual = FunctionCalculator.CalculateY(x);

            // Assert
            Assert.AreEqual(expected, actual, Delta);
        }

        [TestMethod]
        public void CalculateY_XBetweenMinus8And0_ReturnsCorrectValue()
        {
            // Arrange
            double x = -1.0;
            double expected = Math.Pow(-1.0 - 1 / (1.0), -1.0);

            // Act
            double actual = FunctionCalculator.CalculateY(x);

            // Assert
            Assert.AreEqual(expected, actual, Delta);
        }

        [TestMethod]
        public void CalculateY_XLessThanMinus8_ReturnsCorrectValue()
        {
            // Arrange
            double x = -10.0;
            double expected = -10.0 + 10 * (-10.0) - (1 / (-10.0));

            // Act
            double actual = FunctionCalculator.CalculateY(x);

            // Assert
            Assert.AreEqual(expected, actual, Delta);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateY_XEquals1_ThrowsArgumentException()
        {
            // Arrange
            double x = 1.0;

            // Act
            FunctionCalculator.CalculateY(x);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateY_XEqualsMinus8_ThrowsArgumentException()
        {
            // Arrange
            double x = -8.0;

            // Act
            FunctionCalculator.CalculateY(x);
        }

        [TestMethod]
        public void RoundToThreeDecimalPlaces_RoundsCorrectly()
        {
            // Arrange
            double value = 1.234567;
            double expected = 1.235;

            // Act
            double actual = FunctionCalculator.RoundToThreeDecimalPlaces(value);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RoundToThreeDecimalPlaces_NegativeNumber_RoundsCorrectly()
        {
            // Arrange
            double value = -1.234567;
            double expected = -1.235;

            // Act
            double actual = FunctionCalculator.RoundToThreeDecimalPlaces(value);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateY_XEquals2Point5_ReturnsCorrectValue()
        {
            // Arrange
            double x = 2.5;
            double expected = 2.5 + Math.Pow((2.5 + 1) / (2.5 - 1), 2.5);

            // Act
            double actual = FunctionCalculator.CalculateY(x);

            // Assert
            Assert.AreEqual(expected, actual, Delta);
        }
    }
}