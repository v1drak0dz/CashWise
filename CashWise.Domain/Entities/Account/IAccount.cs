namespace CashWise.Domain.Entities.Account
{
    public interface IAccount
    {
        public Guid Id { get; }
        public string BankName { get; }
    }
}
