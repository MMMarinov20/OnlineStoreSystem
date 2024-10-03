using OnlineStoreManagementSystem;
using OnlineStoreSystem.Models;
using OnlineStoreSystem.Discounts;
using OnlineStoreSystem.Payments;

class Program
{
    static void Main(string[] args)
    {
        // Creating physical and digital products
        PhysicalProduct laptop = new PhysicalProduct("Laptop", 1000m, 5);
        DigitalProduct ebook = new DigitalProduct("E-Book", 50m, 10);

        // Creating a customer
        Customer johnDoe = new Customer("John", "Doe");

        // Creating and processing an order for the laptop with a 10% discount and Credit Card payment
        Order laptopOrder = new Order(johnDoe, laptop, 2);
        laptopOrder.ProcessOrder(new PercentageDiscount(10), new CreditCardPayment("1234-5678-9876-5432"));

        // Creating and processing an order for the e-book with a fixed $5 discount and PayPal payment
        Order ebookOrder = new Order(johnDoe, ebook, 1);
        ebookOrder.ProcessOrder(new FixedDiscount(5), new PayPalPayment("john.doe@example.com"));

        // Attempting an order with insufficient stock
        Order failedOrder = new Order(johnDoe, laptop, 10);
        failedOrder.ProcessOrder(new FixedDiscount(0), new CreditCardPayment("1234-5678-9876-5432"));
    }
}