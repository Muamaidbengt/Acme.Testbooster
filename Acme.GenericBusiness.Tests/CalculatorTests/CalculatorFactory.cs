using Calculator;

namespace Tests.CalculatorTests
{
    public static class CalculatorFactory
    {
        public static ICalculator CreateCalculator()
        {
            return new BuggyCalculator();
        }
    }
}