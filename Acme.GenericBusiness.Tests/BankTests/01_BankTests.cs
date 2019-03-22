using Bank;
using FluentAssertions;
using Xunit;

namespace Tests.BankTests
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
        public void TransferringMoney(decimal amount)
        {
            var from = new BankAccount(1000);
            var to = new BankAccount(0);

            _bank.TransferMoney(from, to, amount);

            from.Balance.Should().Be(1000 - amount);
            to.Balance.Should().Be(amount);
            _bank.TransactionCount.Should().Be(1);
        }
    }
}
