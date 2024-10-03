namespace OnlineStoreSystem.Discounts
{
    public interface IDiscount
    {
        decimal CalculateDiscount(decimal totalAmount);
    }
}