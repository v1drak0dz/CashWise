namespace CashWise.Domain.Entities
{
    public sealed class Account // Remove inherit interface
    {
        public int Id { get; }
        public string BankName { get; }

        public Account(string bankName) // BankName/BankCode
        {
            if (string.IsNullOrWhiteSpace(bankName))
            {
                throw new ArgumentException("Account name is required!", nameof(bankName));
            }
            
            BankName = bankName.Trim(); // Enum for the name of the bank
        }
    }
}