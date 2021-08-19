using System;
using System.Numerics;
using Xunit;

namespace Factorial.Tests
{
    public class FactorialCalculatorTests
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(5, 120)]
        [InlineData(20, 2432902008176640000)]
        public void ShouldReturnCorrectlyCalculatedResultRecursively(int value, UInt64 expectedValue)
        {
            BigInteger result = FactorialCalculator.CalculateFactorial(value.ToString(), "1");
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(5, 120)]
        [InlineData(20, 2432902008176640000)]
        public void ShouldReturnCorrectlyCalculatedResulIteratively(int value, UInt64 expectedValue)
        {
            BigInteger result = FactorialCalculator.CalculateFactorial(value.ToString(), "2");
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData("1.123", "1", "Provided value is not a number.")]
        [InlineData("x", "1", "Provided value is not a number.")]
        [InlineData("", "1", "Provided value is not a number.")]
        [InlineData(" ", "1", "Provided value is not a number.")]
        [InlineData("-1", "1", "Value cannot be less than 0.")]
        [InlineData("1", "1.123", "Provided strategy is not a number.")]
        [InlineData("1", "x", "Provided strategy is not a number.")]
        [InlineData("1", " ", "Provided strategy is not a number.")]
        [InlineData("1", "", "Provided strategy is not a number.")]
        [InlineData("1", "3", "There is no operation corresponding to that choice.")]
        public void ShouldThrowExceptionWhenInvalidInput(String valueToCalculate, String strategy, String expectedErrorMessage)
        {
            void act() => FactorialCalculator.CalculateFactorial(valueToCalculate, strategy);
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal(expectedErrorMessage, exception.Message);
        }
    }
}
