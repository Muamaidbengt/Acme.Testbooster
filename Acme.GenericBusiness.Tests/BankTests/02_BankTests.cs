using Bank;
using FluentAssertions;
using Xunit;

namespace Tests.BankTests.SeparateMethods
{
    [Trait("Category", nameof(IBank))]
    public class BankTests
    {
        private readonly IBank _bank = new ShadyBank();

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(50)]
        [InlineData(100)]
        [InlineData(123)]
        [InlineData(999)]
        [InlineData(1000)]
        public void TransferringMoney_DeductsMoneyCorrectlyFromAccount(decimal amount)
        {
            var from = new BankAccount(1000);
            var to = new BankAccount(0);

            _bank.TransferMoney(from, to, amount);

            from.Balance.Should().Be(1000 - amount);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(50)]
        [InlineData(100)]
        [InlineData(123)]
        [InlineData(999)]
        [InlineData(1000)]
        public void TransferringMoney_DepositsMoneyCorrectlyToAccount(decimal amount)
        {
            var from = new BankAccount(1000);
            var to = new BankAccount(0);

            _bank.TransferMoney(from, to, amount);

            to.Balance.Should().Be(amount);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(50)]
        [InlineData(100)]
        [InlineData(123)]
        [InlineData(999)]
        [InlineData(1000)]
        public void TransferringMoney_IncrementsTransactionCount(decimal amount)
        {
            var from = new BankAccount(1000);
            var to = new BankAccount(0);

            _bank.TransferMoney(from, to, amount);

            _bank.TransactionCount.Should().Be(1);
        }
    }
}
