using OnlineStoreManagementSystem;
using OnlineStoreSystem.Models;
using OnlineStoreSystem.Discounts;
using OnlineStoreSystem.Payments;

class Program
{
    static void Main(string[] args)
    {
        PhysicalProduct laptop = new PhysicalProduct("Laptop", 1000m, 5, null);
        DigitalProduct ebook = new DigitalProduct("E-Book", 50m, 10, null);

        Customer johnDoe = new Customer("John", "Doe");

        Order laptopOrder = new Order(johnDoe, laptop, 2);
        laptopOrder.ProcessOrder(new PercentageDiscount(10), new CreditCardPayment("1234-5678-9876-5432"));

        Order ebookOrder = new Order(johnDoe, ebook, 1);
        ebookOrder.ProcessOrder(new FixedDiscount(5), new PayPalPayment("john.doe@example.com"));

        Order failedOrder = new Order(johnDoe, laptop, 10);
        failedOrder.ProcessOrder(new FixedDiscount(0), new CreditCardPayment("1234-5678-9876-5432"));
    }
}