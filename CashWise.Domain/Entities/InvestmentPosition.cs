namespace CashWise.Domain.Entities
{
    public class InvestmentPosition
    {
        public int Id { get; }
        public string Asset { get; } = string.Empty;
        public int Quantity { get; private set; }
        public decimal AveragePrice { get; private set; }

        public InvestmentPosition(string asset, int quantity, decimal averagePrice)
        {
            if (string.IsNullOrWhiteSpace(asset))
                throw new ArgumentException("Asset cannot be empty");

            Asset = asset;
            Quantity = quantity;
            AveragePrice = averagePrice;
        }

        public void Buy(decimal boughtPrice, int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero");

            var newQuantity = Quantity + amount;
            var newAvgPrice = ((AveragePrice * Quantity) + (boughtPrice * amount)) / newQuantity;

            AveragePrice = newAvgPrice;
            Quantity = newQuantity;
        }

        public decimal Sell(decimal sellPrice, int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero");

            if (amount > Quantity)
                throw new InvalidOperationException("Not enough assets");

            var profit = (sellPrice - AveragePrice) * amount;

            Quantity -= amount;

            return profit;
        }


    }
}
