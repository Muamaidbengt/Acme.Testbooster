/*
 * Which is easier to read?
 * Which gives the most informative error message?
 */

using Acme.GenericBusiness.Calculator;
using Xunit;

namespace Acme.GenericBusiness.Tests.CalculatorTests
{
    [Trait("Category", nameof(ICalculator))]
    public class CalculatorAssertTests
    {
        [Fact]
        public void Adding2To3Yields5()
        {
            // Arrange
            var calculator = CalculatorFactory.CreateCalculator();
            // Act
            var actual = calculator.Add(2, 3);
            // Assert
            Assert.Equal(5, actual);
        }

        [Fact]
        public void Adding2To3Yields5_Shortened()
        {
            // Arrange
            var calculator = CalculatorFactory.CreateCalculator();
            // Act/Assert
            Assert.Equal(5, calculator.Add(2, 3));
        }
    }
}

namespace Acme.GenericBusiness.Tests.CalculatorTests.Fluent
{
    using FluentAssertions;

    [Trait("Category", nameof(ICalculator))]
    public class CalculatorFluentTests
    {
        [Fact]
        public void Adding2To3Yields5()
        {
            // Arrange
            var calculator = CalculatorFactory.CreateCalculator();
            // Act
            var sum = calculator.Add(2, 3);
            // Assert
            sum.Should().Be(5);
        }

        [Fact]
        public void Adding2To3Yields5_Shortened()
        {
            // Arrange
            var calculator = CalculatorFactory.CreateCalculator();
            // Act/Assert
            calculator.Add(2, 3).Should().Be(5);
        }
    }
}