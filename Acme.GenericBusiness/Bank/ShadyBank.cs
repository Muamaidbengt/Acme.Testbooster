using System;

namespace Acme.GenericBusiness.Bank
{
    public class ShadyBank : IBank
    {
        private readonly BankAccount _corruptManagerAccount = new BankAccount(0);
        private static readonly Random Rnd = new Random(781372);

        public void TransferMoney(BankAccount from, BankAccount to, decimal amount)
        {
            AdjustBalance(from, -amount);
            AdjustBalance(to, amount);
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

            _corruptManagerAccount.Balance += managersShare;
            
            TransactionCount++;
        }
    }
}