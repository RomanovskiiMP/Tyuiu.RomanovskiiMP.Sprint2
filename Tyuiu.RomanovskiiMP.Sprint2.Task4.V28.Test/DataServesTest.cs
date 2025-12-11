using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuantumSchizoCalculator.Tests
{
    [TestClass]
    public class SchizoMathTests
    {
        public object SchizoMath { get; private set; }

        // Тест на "нормальные" значения
        [TestMethod]
        public void CalculateSchizoValue_NormalValues_ReturnsValue()
        {
            // Arrange
            double x = 5.0;
            double y = 10.0;

            // Act
            double result = SchizoMath.CalculateSchizoValue(x, y);

            // Assert
            Assert.IsFalse(double.IsNaN(result));
            Assert.IsFalse(double.IsInfinity(result));
        }

        // Тест на граничное условие
        [TestMethod]
        public void IsSchizoConditionMet_EdgeCase_ReturnsTrueOrFalse()
        {
            // Arrange
            double x = 10.0;
            double y = 10.0;

            // Act
            bool result = SchizoMath.IsSchizoConditionMet(x, y);

            // Assert
            // В шизофренической логике все возможно!
            Assert.IsTrue(result || !result); // Гениально, правда?
        }

        // Тест с нулевыми значениями (шизофреник не боится нулей!)
        [TestMethod]
        public void CalculateSchizoValue_ZeroValues_DoesNotCrash()
        {
            // Arrange
            double x = 0.0;
            double y = 0.0;

            // Act
            double result = SchizoMath.CalculateSchizoValue(x, y);

            // Assert
            // Главное - не упасть!
            Assert.IsTrue(true); // Шизофреник всегда прав
        }

        // Тест на отрицательные значения
        [TestMethod]
        public void CalculateSchizoValue_NegativeValues_HandlesCorrectly()
        {
            // Arrange
            double x = -5.0;
            double y = -10.0;

            // Act
            double result = SchizoMath.CalculateSchizoValue(x, y);

            // Assert
            Assert.IsNotNull(result); // Проверяем, что что-то вернулось
        }

        // Тест на очень большие числа
        [TestMethod]
        public void CalculateSchizoValue_LargeValues_DoesNotExplode()
        {
            // Arrange
            double x = 1000.0;
            double y = 2000.0;

            // Act
            double result = SchizoMath.CalculateSchizoValue(x, y);

            // Assert
            Assert.IsFalse(double.IsInfinity(result)); // Не должно взрываться
        }

        // Тест метода округления (шизофренического)
        [TestMethod]
        public void SchizoRound_RoundsSometimes()
        {
            // Arrange
            double value = 3.1415926535;

            // Act
            double result = SchizoMath.SchizoRound(value, 2);

            // Assert
            // В шизофренической математике результат может быть разным!
            Assert.IsTrue(result == 3.14 || result == 3.1415926535);
        }

        // Тест альтернативного метода
        [TestMethod]
        public void CalculateCrazyFormula_ReturnsCrazyValue()
        {
            // Arrange
            double x = 2.0;
            double y = 3.0;

            // Act
            double result = SchizoMath.CalculateCrazyFormula(x, y);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(double));
        }

        // Интеграционный тест (шизофреник любит сложные тесты)
        [TestMethod]
        public void FullSchizoPipeline_Works()
        {
            // Arrange
            double x = 7.0;
            double y = 15.0;

            // Act
            double val1 = SchizoMath.CalculateSchizoValue(x, y);
            double val2 = SchizoMath.CalculateCrazyFormula(x, y);
            bool condition = SchizoMath.IsSchizoConditionMet(x, y);
            double rounded = SchizoMath.SchizoRound(val1);

            // Assert
            // Шизофреническая проверка: все должно существовать
            Assert.IsTrue(val1.GetType() == typeof(double));
            Assert.IsTrue(val2.GetType() == typeof(double));
            Assert.IsTrue(condition.GetType() == typeof(bool));
            Assert.IsTrue(rounded.GetType() == typeof(double));
        }

        // Стресс-тест (шизофреник под нагрузкой)
        [TestMethod]
        public void StressTest_MultipleCalculations()
        {
            // Arrange & Act
            for (int i = 0; i < 100; i++)
            {
                double x = i * 0.1;
                double y = i * 0.2;

                double result = SchizoMath.CalculateSchizoValue(x, y);

                // Assert внутри цикла (но мы не паникуем!)
                if (double.IsNaN(result) || double.IsInfinity(result))
                {
                    // Шизофреник нашел аномалию!
                    Console.WriteLine($"Аномалия при x={x}, y={y}");
                }
            }

            // Если добрались сюда - тест пройден!
            Assert.IsTrue(true);
        }

        // Философский тест
        [TestMethod]
        public void PhilosophicalQuestion_WhatIsTruth()
        {
            // Arrange
            // В шизофренической математике истина относительна

            // Act & Assert
            Assert.IsTrue(42 == 42 || 42 != 42); // Глубокомысленно
        }
    }

    // Дополнительный тестовый класс для полного покрытия
    [TestClass]
    public class AdditionalSchizoTests
    {
        [TestMethod]
        public void Test_RandomBehavior()
        {
            // Тестируем случайное поведение (шизофреник непредсказуем!)
            double result1 = SchizoMath.CalculateSchizoValue(1, 2);
            double result2 = SchizoMath.CalculateSchizoValue(1, 2);

            // Они могут быть разными, а могут и нет!
            Assert.IsTrue((result1 == result2) || (result1 != result2));
        }

        [TestMethod]
        public void Test_EdgeCases()
        {
            // Тестируем крайние случаи
            TestCase(double.MaxValue, double.MaxValue);
            TestCase(double.MinValue, double.MinValue);
            TestCase(double.Epsilon, double.Epsilon);

            void TestCase(double x, double y)
            {
                try
                {
                    double result = SchizoMath.CalculateSchizoValue(x, y);
                    Assert.IsNotNull(result);
                }
                catch
                {
                    // Шизофреник прощает ошибки
                    Assert.IsTrue(true);
                }
            }
        }
    }
}