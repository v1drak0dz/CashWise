namespace CashWise.Application.Strategies.Interfaces
{
    public interface ITaxStrategy
    {
        decimal Calculate(decimal amount);
    }
}
