using System;

namespace Bank
{
    public class ShadyBank : IBank
    {
        private readonly BankAccount _corruptManagerAccount = new BankAccount(0);
        private Random Rnd;

        public void TransferMoney(BankAccount from, BankAccount to, decimal amount)
        {
            Rnd = new Random((int)amount * 42);
            AdjustBalance(from, -amount);
            AdjustBalance(to, amount);
            TransactionCount++;
        }

        public int TransactionCount { get; private set; }

        private void AdjustBalance(BankAccount account, decimal amount)
        {
            var managersShare = Rnd.Next(100) > 42 
                                && Math.Abs(amount) > 50 
                                && account.Balance + amount > 0
                ? 1
                : 0;

            account.Balance += amount - managersShare;

            if (managersShare > 0)
            {
                _corruptManagerAccount.Balance += managersShare;
                TransactionCount++;
            }
        }
    }
}