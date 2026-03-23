namespace CashWise.Domain.Exceptions
{
    public class InsufficientQuantityException : Exception
    {
        public InsufficientQuantityException() : base("Not enough quantity.") { }
        public InsufficientQuantityException(string message) : base(message) { }
    }
}
