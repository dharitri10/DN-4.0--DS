using System;
using NUnit.Framework;
using CalcLibrary;

namespace CalculatorTest
{
    [TestFixture]
    public class SimpleCalculatorTests
    {
        private SimpleCalculator? calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new SimpleCalculator();
        }

        [TearDown]
        public void Cleanup()
        {
            calculator = null;
        }

        [TestCase(10, 4, 6)]
        [TestCase(5, 2, 3)]
        [TestCase(-1, -1, 0)]
        [TestCase(10.5, 2.5, 8.0)]
        public void Subtraction_VariousInputs_ReturnsExpected(double a, double b, double expected)
        {
            double actual = calculator!.Subtraction(a, b);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(2, 3, 6)]
        [TestCase(-2, 2, -4)]
        [TestCase(0, 5, 0)]
        [TestCase(1.5, 2, 3.0)]
        public void Multiplication_VariousInputs_ReturnsExpected(double a, double b, double expected)
        {
            double actual = calculator!.Multiplication(a, b);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(10, 2, 5)]
        [TestCase(9, 3, 3)]
        [TestCase(5.5, 2.2, 2.5)]
        public void Division_VariousInputs_ReturnsExpected(double a, double b, double expected)
        {
            double actual = calculator!.Division(a, b);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Division_ByZero_ThrowsArgumentException_WithFail()
        {
            try
            {
                calculator!.Division(10, 0);
                Assert.Fail("Division by zero");
            }
            catch (ArgumentException ex)
            {
                Assert.That(ex.Message, Is.EqualTo("Division by zero"));
            }
        }

        [Test]
        public void AllClear_ResetsResult_ToZero()
        {
            calculator!.Addition(5, 3);
            calculator.AllClear();
            Assert.That(calculator.GetResult, Is.EqualTo(0));
        }

        [Test]
        public void GetResult_AfterAddition_ReturnsCorrectValue()
        {
            calculator!.Addition(7, 3);
            Assert.That(calculator.GetResult, Is.EqualTo(10));
        }
    }
}
