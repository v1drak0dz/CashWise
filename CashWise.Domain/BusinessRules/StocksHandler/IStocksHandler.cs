
namespace CashWise.Domain.BusinessRules.StocksHandler
{
    public interface IStocksHandler
    {
        public decimal ApplyStockIncome(decimal transactionAmount);
        public decimal ProcessStockWithdraw(decimal transactionAmount);
    }
}
