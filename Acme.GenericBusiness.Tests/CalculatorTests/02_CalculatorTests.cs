using Calculator;
using Xunit;

namespace Tests.CalculatorTests.Fluent
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