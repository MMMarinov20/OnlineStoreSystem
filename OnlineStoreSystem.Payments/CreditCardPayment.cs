namespace OnlineStoreSystem.Payments
{
    public class CreditCardPayment : IPayment
    {
        private string cardNumber;

        public CreditCardPayment(string cardNumber)
        {
            this.cardNumber = cardNumber;
        }

        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing credit card payment of {amount:C} using card number {cardNumber}.");
            Console.WriteLine("Credit card payment processed successfully.");
        }
    }
}