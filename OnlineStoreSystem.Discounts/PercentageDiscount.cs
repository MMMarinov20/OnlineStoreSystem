namespace OnlineStoreSystem.Discounts
{
    public class PercentageDiscount : IDiscount
    {
        private decimal percentage;

        public PercentageDiscount(decimal percentage)
        {
            this.percentage = percentage;
        }

        public decimal CalculateDiscount(decimal totalAmount)
        {
            return totalAmount * (percentage / 100);
        }
    }
}