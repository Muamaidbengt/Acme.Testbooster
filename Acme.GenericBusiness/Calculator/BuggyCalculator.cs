namespace Acme.GenericBusiness.Calculator
{
    public class BuggyCalculator : ICalculator
    {
        public int Add(int x, int y)
        {
            return x + 1;
        }
    }
}