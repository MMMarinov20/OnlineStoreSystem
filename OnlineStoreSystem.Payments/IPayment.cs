namespace OnlineStoreSystem.Payments
{
    public interface IPayment
    {
        void ProcessPayment(decimal amount);
    }
}