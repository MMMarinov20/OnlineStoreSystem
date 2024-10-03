namespace OnlineStoreSystem.Payments
{
    public class PayPalPayment : IPayment
    {
        private string email;

        public PayPalPayment(string email)
        {
            this.email = email;
        }

        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment of {amount:C} for account {email}.");
            Console.WriteLine("PayPal payment processed successfully.");
        }
    }
}