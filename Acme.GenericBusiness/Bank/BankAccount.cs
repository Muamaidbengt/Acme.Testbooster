namespace Bank
{
    public class BankAccount
    {
        public decimal Balance { get; set; }

        public BankAccount(decimal balance)
        {
            Balance = balance;
        }
    }
}