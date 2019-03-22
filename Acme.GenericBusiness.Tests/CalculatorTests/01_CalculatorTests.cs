using Calculator;
using Xunit;

namespace Tests.CalculatorTests
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