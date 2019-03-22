namespace Bank
{
    public interface IBank
    {
        void TransferMoney(BankAccount from, BankAccount to, decimal amount);
        int TransactionCount { get; }
    }
}