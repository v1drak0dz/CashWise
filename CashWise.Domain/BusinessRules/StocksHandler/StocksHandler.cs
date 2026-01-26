namespace CashWise.Domain.BusinessRules.StocksHandler
{
    public class StocksHandler : IStocksHandler
    {
        private const decimal IoFTax = 0.035m;
        private const decimal IrrFTax = 0.27m;
        private const decimal PctByYear = 0.12m;

        public decimal ProcessStockWithdraw(decimal transactionAmount)
        {
            var netTaxIof = transactionAmount * IoFTax;
            var netTaxIr = transactionAmount * IrrFTax;
            var transactionNetAmount = transactionAmount - netTaxIr - netTaxIof;
            return transactionNetAmount;
        }

        public decimal ApplyStockIncome(decimal transactionAmount)
        {
            var stockRevenue = transactionAmount * (PctByYear / 12);
            return transactionAmount + stockRevenue;
        }
    }
}
