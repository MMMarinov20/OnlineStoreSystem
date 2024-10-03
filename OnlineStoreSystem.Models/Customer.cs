namespace OnlineStoreSystem.Models
{
    public class Customer
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void DisplayCustomerInfo()
        {
            Console.WriteLine($"Customer: {FirstName} {LastName}");
        }
    }
}