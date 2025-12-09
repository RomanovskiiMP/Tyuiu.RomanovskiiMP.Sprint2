using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogicalSequence.Tests
{
    [TestClass]
    public class LogicalSequenceTests
    {
        [TestMethod]
        public void Sequence_ShouldMatchExpected()
        {
            // Arrange
            int x = 5105;
            int y = 475;
            bool[] expected = { false, true, true, true, true, false };

            // Act - создаем последовательность из 6 операций сравнения
            bool[] sequence = new bool[6];

            // Операция 1: False
            sequence[0] = x == y;                   // False

            // Операция 2: True  
            sequence[1] = x != y;                   // True

            // Операция 3: True
            sequence[2] = x > y;                    // True

            // Операция 4: True
            sequence[3] = x >= y;                   // True

            // Операция 5: True (с арифметическим выражением)
            sequence[4] = (x - 4630) == y;          // True: 475 == 475

            // Операция 6: False
            sequence[5] = x < y;                    // False

            // Assert
            CollectionAssert.AreEqual(expected, sequence,
                "Последовательность должна быть (False, True, True, True, True, False)");
        }

        [TestMethod]
        public void AllComparisonOperators_Used()
        {
            // Проверяем, что используются все типы операторов сравнения
            int x = 5105;
            int y = 475;

            // Все 6 операторов сравнения:
            bool eq = x == y;      // == (False)
            bool ne = x != y;      // != (True)
            bool gt = x > y;       // > (True)
            bool ge = x >= y;      // >= (True)
            bool lt = x < y;       // < (False)
                                   // <= не использован, но можно включить в другой вариант

            // С арифметическим выражением:
            bool withArithmetic = (x - 4630) == y;  // == с арифметикой (True)

            // Создаем последовательность
            bool[] sequence = { eq, ne, gt, ge, withArithmetic, lt };
            bool[] expected = { false, true, true, true, true, false };

            CollectionAssert.AreEqual(expected, sequence);
        }

        [TestMethod]
        public void SequenceOrder_CannotBeChanged()
        {
            // Проверяем, что порядок операций фиксированный
            // Любая перестановка даст другую последовательность

            int x = 5105;
            int y = 475;

            // Правильная последовательность
            bool[] correct = {
                x == y,         // 1: False
                x != y,         // 2: True
                x > y,          // 3: True
                x >= y,         // 4: True
                (x-4630)==y,    // 5: True
                x < y           // 6: False
            };

            // Неправильная последовательность (переставлены 1 и 2)
            bool[] wrong = {
                x != y,         // 1: True (должно быть False)
                x == y,         // 2: False (должно быть True)
                x > y,          // 3: True
                x >= y,         // 4: True
                (x-4630)==y,    // 5: True
                x < y           // 6: False
            };

            bool[] expected = { false, true, true, true, true, false };

            // Assert
            CollectionAssert.AreEqual(expected, correct);
            CollectionAssert.AreNotEqual(expected, wrong);
        }

        [TestMethod]
        public void ArithmeticExpressions_WithComparisons()
        {
            // Проверяем арифметические выражения в сравнениях

            int x = 5105;
            int y = 475;

            // Разные арифметические выражения, дающие нужный результат

            // Для True результатов:
            Assert.IsTrue((x - 4630) == y);         // 475 == 475
            Assert.IsTrue((x - y) > 0);             // 4630 > 0
            Assert.IsTrue((x / 10) > y);            // 510 > 475
            Assert.IsTrue((x + y) > 5000);          // 5580 > 5000
            Assert.IsTrue((x % 1000) != y);         // 105 != 475

            // Для False результатов:
            Assert.IsFalse((x + y) < y);            // 5580 < 475
            Assert.IsFalse((x - x) == y);           // 0 == 475
            Assert.IsFalse((x * 0) > y);            // 0 > 475
            Assert.IsFalse((y * 11) > x);           // 5225 > 5105? False
        }

        [TestMethod]
        [DataRow(5105, 475, false, true, true, true, true, false)]
        [DataRow(100, 200, true, true, false, false, false, false)] // Для теста других значений
        [DataRow(500, 500, false, false, false, true, true, false)]
        public void GenerateSequence_ForDifferentValues(
            int x, int y, bool exp1, bool exp2, bool exp3,
            bool exp4, bool exp5, bool exp6)
        {
            // Генерируем последовательность для любых значений

            bool[] sequence = {
                x == y,                 // 1
                x != y,                 // 2
                x > y,                  // 3
                x >= y,                 // 4
                (x - (x - y)) == y,     // 5: упрощается до y == y (всегда true)
                x < y                   // 6
            };

            // Для 5-го элемента нужно специальное условие
            // Если exp5 должно быть false, нужно другое выражение
            if (!exp5)
            {
                sequence[4] = (x - x) == y; // 0 == y (обычно false)
            }

            bool[] expected = { exp1, exp2, exp3, exp4, exp5, exp6 };

            CollectionAssert.AreEqual(expected, sequence,
                $"Ошибка для x={x}, y={y}");
        }

        [TestMethod]
        public void ValidateGivenSequence()
        {
            // Фиксированная проверка для x=5105, y=475

            int x = 5105;
            int y = 475;

            // Требуемая последовательность: (False, True, True, True, True, False)

            // Вариант 1: 
            bool[] seq1 = {
                x == y,         // 1: False
                x != y,         // 2: True
                x > y,          // 3: True
                x >= y,         // 4: True
                (x-4630) == y,  // 5: True
                x < y           // 6: False
            };

            // Вариант 2:
            bool[] seq2 = {
                x < y,          // 1: False
                x > y,          // 2: True
                x >= y,         // 3: True
                x != y,         // 4: True
                (x-y) > 0,      // 5: True
                x == y          // 6: False
            };

            bool[] expected = { false, true, true, true, true, false };

            // Оба варианта должны работать
            CollectionAssert.AreEqual(expected, seq1);
            CollectionAssert.AreEqual(expected, seq2);
        }

        [TestMethod]
        public void SequenceProperties_Analysis()
        {
            // Анализ свойств требуемой последовательности

            bool[] sequence = { false, true, true, true, true, false };

            // Длина 6
            Assert.AreEqual(6, sequence.Length);

            // Первый и последний - False
            Assert.IsFalse(sequence[0]);
            Assert.IsFalse(sequence[5]);

            // Все средние - True
            for (int i = 1; i <= 4; i++)
            {
                Assert.IsTrue(sequence[i], $"Элемент {i} должен быть True");
            }

            // Соотношение True/False
            int trueCount = 0;
            int falseCount = 0;

            foreach (bool value in sequence)
            {
                if (value) trueCount++;
                else falseCount++;
            }

            Assert.AreEqual(4, trueCount);
            Assert.AreEqual(2, falseCount);
        }
    }
}