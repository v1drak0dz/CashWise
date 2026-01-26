namespace CashWise.Domain.Entities.Account
{
    public sealed class Account : IAccount
    {
        public Guid Id { get; }
        public string BankName { get; }

        public Account(string bankName) // BankName/BankCode
        {
            if (string.IsNullOrWhiteSpace(BankName))
            {
                throw new ArgumentException("Account name is required!", nameof(bankName));
            }

            Id = Guid.NewGuid();
            BankName = bankName.Trim(); // Enum for the name of the bank
        }
    }
}