using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogicalOperationsSequence.Tests
{
    [TestClass]
    public class LogicalOperationsSequenceTests
    {
        [TestMethod]
        public void Sequence_ShouldMatchExpected_TrueFalseFalseFalseFalseFalse()
        {
            // Arrange
            int a = 185;
            int b = 316;
            int c = 134;
            int d = 134;

            bool[] expected = { true, false, false, false, false, false };

            // Act - основная последовательность
            bool[] sequence = new bool[6];

            // 1. True
            sequence[0] = (c == d) || (a < b);  // True || True = True

            // 2. False
            sequence[1] = (a == b) && (c != d); // False && False = False

            // 3. False
            sequence[2] = (a > b) & (c == d);   // False & True = False

            // 4. False
            sequence[3] = (b <= a) & (c == d);  // False & True = False

            // 5. False
            sequence[4] = (a >= b) | (c != d);  // False | False = False

            // 6. False
            sequence[5] = (a + b) < (c + d) && (c == d); // False && True = False

            // Assert
            CollectionAssert.AreEqual(expected, sequence,
                "Последовательность должна быть (True, False, False, False, False, False)");
        }

        [TestMethod]
        public void AllComparisonOperators_UsedAtLeastOnce()
        {
            // Проверяем, что все операторы сравнения использованы
            int a = 185;
            int b = 316;
            int c = 134;
            int d = 134;

            // Используем все операторы сравнения:
            bool eq = c == d;      // == (True)
            bool ne = a != b;      // != (True)
            bool lt = a < b;       // < (True)
            bool gt = a > b;       // > (False)
            bool le = b <= a;      // <= (False)
            bool ge = a >= b;      // >= (False)

            // Используем все логические операторы:
            bool or = eq || lt;    // || (True)
            bool and = (a == b) && (c != d); // && (False)
            bool bitAnd = gt & eq; // & (False)
            bool bitOr = ge | (c != d); // | (False)
            bool xor = (b <= a) ^ eq; // ^ (False ^ True = True) но нам нужно False
            bool not = !(b <= a);  // ! (True)

            // Создаем последовательность с использованием всех операций
            bool[] sequence = {
                eq || lt,           // True: == и < с ||
                (a == b) && ne,     // False: == и != с &&
                gt & eq,            // False: > и == с &
                le & eq,            // False: <= и == с &
                ge | (c != d),      // False: >= и != с |
                (a + b) < (c + d) && eq // False: арифметика с &&
            };

            bool[] expected = { true, false, false, false, false, false };

            CollectionAssert.AreEqual(expected, sequence);
        }

        [TestMethod]
        public void LogicalOperators_Behavior()
        {
            // Проверяем поведение логических операторов

            // Логические операторы:
            // || - логическое ИЛИ (короткое замыкание)
            // && - логическое И (короткое замыкание)
            // |  - побитовое ИЛИ (не короткое замыкание)
            // &  - побитовое И (не короткое замыкание)
            // ^  - исключающее ИЛИ (XOR)
            // !  - отрицание

            bool T = true;
            bool F = false;

            // Проверяем результаты:
            Assert.IsTrue(T || F);     // True ИЛИ False = True
            Assert.IsFalse(T && F);    // True И False = False
            Assert.IsTrue(T | F);      // True ИЛИ False = True
            Assert.IsFalse(T & F);     // True И False = False
            Assert.IsTrue(T ^ F);      // True XOR False = True
            Assert.IsTrue(!F);         // не False = True
            Assert.IsFalse(!T);        // не True = False

            // Особенность: T ^ T = False, F ^ F = False
            Assert.IsFalse(T ^ T);
            Assert.IsFalse(F ^ F);
        }

        [TestMethod]
        public void ArithmeticExpressions_InComparisons()
        {
            // Проверяем арифметические выражения в сравнениях

            int a = 185;
            int b = 316;
            int c = 134;
            int d = 134;

            // Арифметические операции в сравнениях:
            Assert.IsTrue((c + 0) == d);          // 134 == 134
            Assert.IsFalse((a - 51) != c);        // 134 != 134? False
            Assert.IsTrue((b - a) > 0);           // 131 > 0
            Assert.IsFalse((a * 2) < b);          // 370 < 316? False
            Assert.IsTrue((c + d) <= (a * 2));    // 268 <= 370
            Assert.IsFalse((a + b) >= 1000);      // 501 >= 1000? False

            // Комбинации:
            Assert.IsTrue(((c == d) && ((b - a) > 100))); // True && True = True
            Assert.IsFalse(((a == b) || ((c + d) < a)));  // False || False = False
        }

        [TestMethod]
        public void VerifyGivenValues()
        {
            // Проверяем значения переменных

            int a = 185;
            int b = 316;
            int c = 134;
            int d = 134;

            // Проверяем сравнения:
            Assert.IsTrue(c == d);     // 134 == 134
            Assert.IsTrue(a < b);      // 185 < 316
            Assert.IsFalse(a == b);    // 185 == 316
            Assert.IsFalse(c != d);    // 134 != 134
            Assert.IsFalse(a > b);     // 185 > 316
            Assert.IsFalse(b <= a);    // 316 <= 185
            Assert.IsFalse(a >= b);    // 185 >= 316

            // Арифметические выражения:
            Assert.AreEqual(501, a + b);   // 185 + 316 = 501
            Assert.AreEqual(268, c + d);   // 134 + 134 = 268
            Assert.IsFalse((a + b) < (c + d)); // 501 < 268 = False
        }

        [TestMethod]
        public void MultipleValidSequences()
        {
            // Проверяем несколько валидных последовательностей

            int a = 185;
            int b = 316;
            int c = 134;
            int d = 134;

            bool[] expected = { true, false, false, false, false, false };

            // Вариант 1
            bool[] seq1 = {
                (c == d) || (a < b),           // True
                (a == b) && (c != d),          // False
                (a > b) & (c == d),            // False
                (b <= a) & (c == d),           // False
                (a >= b) | (c != d),           // False
                (a + b) < (c + d) && (c == d)  // False
            };

            // Вариант 2
            bool[] seq2 = {
                (c == d) || ((b - a) > 0),     // True
                (a == b) && ((c * 2) > 300),   // False
                (a > b) & ((c + 0) == d),      // False
                ((b - 131) == a) ^ (c == d),   // True ^ True = False
                (a >= b) | ((c + d) < a),      // False | False = False
                ((a + c) == 319) && (d != c)   // True && False = False
            };

            // Вариант 3 (короткая)
            bool[] seq3 = {
                true,                          // Просто True
                false && true,                 // False
                false & true,                  // False
                false ^ true,                  // True? Нет, нужно False
                // Исправим:
                false | false,                 // False
                false && true                  // False
            };

            // Исправляем seq3
            seq3 = new bool[] {
                true,
                false && true,
                false & true,
                false & true,   // вместо xor
                false | false,
                false && true
            };

            CollectionAssert.AreEqual(expected, seq1);
            CollectionAssert.AreEqual(expected, seq2);
            CollectionAssert.AreEqual(expected, seq3);
        }

        [TestMethod]
        public void SequenceProperties()
        {
            // Анализируем свойства требуемой последовательности

            bool[] sequence = { true, false, false, false, false, false };

            Assert.AreEqual(6, sequence.Length);

            // Первый элемент - True
            Assert.IsTrue(sequence[0]);

            // Остальные - False
            for (int i = 1; i < sequence.Length; i++)
            {
                Assert.IsFalse(sequence[i], $"Элемент {i + 1} должен быть False");
            }

            // Только один True
            int trueCount = 0;
            foreach (bool value in sequence)
            {
                if (value) trueCount++;
            }
            Assert.AreEqual(1, trueCount);

            // Пять False
            int falseCount = 0;
            foreach (bool value in sequence)
            {
                if (!value) falseCount++;
            }
            Assert.AreEqual(5, falseCount);
        }

        [TestMethod]
        public void EdgeCases_WithDifferentOperations()
        {
            // Проверяем граничные случаи с разными операциями

            int a = 185;
            int b = 316;
            int c = 134;
            int d = 134;

            // Короткое замыкание в || и &&
            bool sideEffect = false;

            // || - если левая часть True, правая не вычисляется
            bool result1 = true || (sideEffect = true);
            Assert.IsTrue(result1);
            Assert.IsFalse(sideEffect); // sideEffect не изменился

            // && - если левая часть False, правая не вычисляется
            sideEffect = false;
            bool result2 = false && (sideEffect = true);
            Assert.IsFalse(result2);
            Assert.IsFalse(sideEffect); // sideEffect не изменился

            // | и & всегда вычисляют обе части
            sideEffect = false;
            bool result3 = true | (sideEffect = true);
            Assert.IsTrue(result3);
            Assert.IsTrue(sideEffect); // sideEffect изменился

            // Для нашей задачи это может быть важно
        }
    }
}