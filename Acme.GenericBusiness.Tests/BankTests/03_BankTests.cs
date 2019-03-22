using System.Collections.Generic;
using System.Linq;
using Bank;
using FluentAssertions;
using Xunit;

namespace Tests.BankTests.SeparateMethodsAndTestAmounts
{
    [Trait("Category", nameof(IBank))]
    public class BankTests
    {
        private readonly IBank _bank = new ShadyBank();

        [Theory]
        [MemberData(nameof(TestAmounts))]
        public void TransferringMoney_DeductsMoneyCorrectlyFromAccount(decimal amount)
        {
            var from = new BankAccount(1000);
            var to = new BankAccount(0);

            _bank.TransferMoney(from, to, amount);

            from.Balance.Should().Be(1000 - amount);
        }

        [Theory]
        [MemberData(nameof(TestAmounts))]
        public void TransferringMoney_DepositsMoneyCorrectlyToAccount(decimal amount)
        {
            var from = new BankAccount(1000);
            var to = new BankAccount(0);

            _bank.TransferMoney(from, to, amount);

            to.Balance.Should().Be(amount);
        }

        [Theory]
        [MemberData(nameof(TestAmounts))]
        public void TransferringMoney_IncrementsTransactionCount(decimal amount)
        {
            var from = new BankAccount(1000);
            var to = new BankAccount(0);

            _bank.TransferMoney(from, to, amount);

            _bank.TransactionCount.Should().Be(1);
        }

        public static IEnumerable<object[]> TestAmounts()
        {
            return new List<object[]>
            {
                new object[] {0},
                new object[] {1},
                new object[] {50},
                new object[] {100},
                new object[] {123},
                new object[] {999},
                new object[] {1000},
            }.OrderBy(row => (int)row[0]);
        }
    }
}
