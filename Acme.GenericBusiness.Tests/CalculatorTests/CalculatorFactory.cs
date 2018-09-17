using Acme.GenericBusiness.Calculator;

namespace Acme.GenericBusiness.Tests.CalculatorTests
{
    public static class CalculatorFactory
    {
        public static ICalculator CreateCalculator()
        {
            return new BuggyCalculator();
        }
    }
}