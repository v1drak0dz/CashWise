namespace CashWise.Domain.ValueObject
{
    public class SellResult
    {
        public decimal Profit { get; }
        public decimal Tax { get; }
        public decimal NetProfit { get; }

        private SellResult(decimal profit, decimal tax)
        {
            Profit = profit;
            Tax = tax;
            NetProfit = profit - tax;
        }

        public static SellResult Create(decimal profit, decimal tax)
        {

            return new SellResult(profit, tax);
        }
    }
}
