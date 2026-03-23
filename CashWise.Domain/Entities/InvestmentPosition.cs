using CashWise.Domain.Exceptions;

namespace CashWise.Domain.Entities
{
    public class InvestmentPosition
    {
        public int Id { get; private set; }
        public string Asset { get; private set; } = string.Empty;
        public int Quantity { get; private set; }
        public decimal AveragePrice { get; private set; }

        public InvestmentPosition(string asset, int quantity, decimal averagePrice)
        {
            Asset = asset;
            Quantity = quantity;
            AveragePrice = averagePrice;
        }

        public void Buy(decimal boughtPrice, int amount)
        {
            var newQuantity = Quantity + amount;
            var newAvgPrice = (AveragePrice * Quantity) + (boughtPrice * amount) / newQuantity;

            AveragePrice = newAvgPrice;
            Quantity = newQuantity;
        }

        public decimal Sell(decimal sellPrice, int amount)
        {
            if (amount > Quantity)
                throw new InsufficientQuantityException("Insufficient quantity");

            Quantity -= amount;

            return sellPrice - AveragePrice * amount;
        }
    }
}
