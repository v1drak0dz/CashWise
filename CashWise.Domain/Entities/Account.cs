namespace CashWise.Domain.Entities
{
    public sealed class Account
    {
        public int Id { get; }
        public string BankName { get; }

        public Account(string bankName)
        {
            if (string.IsNullOrWhiteSpace(bankName))
            {
                throw new ArgumentException("Account name is required!", nameof(bankName));
            }
            
            BankName = bankName.Trim();
        }

        public static Account Create(Account _account)
        {
            return new Account(_account.BankName);
        }
    }
}