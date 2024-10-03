using System;
using OnlineStoreSystem.Models;
using OnlineStoreSystem.Discounts;
using OnlineStoreSystem.Payments;

namespace OnlineStoreManagementSystem
{
    public class Order
    {
        public Customer Customer { get; private set; }
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal DiscountAmount { get; private set; }

        // Constructor to create an order
        public Order(Customer customer, Product product, int quantity)
        {
            Customer = customer;
            Product = product;
            Quantity = quantity;
        }

        // Method to process the order, apply a discount, and process payment
        public void ProcessOrder(IDiscount discount, IPayment paymentMethod)
        {
            // Stock validation
            if (Product.ReduceStock(Quantity))
            {
                decimal totalPrice = Product.Price * Quantity;
                DiscountAmount = discount.CalculateDiscount(totalPrice);
                decimal finalPrice = totalPrice - DiscountAmount;

                Console.WriteLine($"Order created for {Quantity} unit(s) of {Product.Name}.");
                Console.WriteLine($"Discount applied. Final price: {finalPrice:C}");

                // Display product and customer details
                Product.DisplayDetails();
                Customer.DisplayCustomerInfo();

                // Process the payment
                paymentMethod.ProcessPayment(finalPrice);

                // Specific actions for physical and digital products
                if (Product is PhysicalProduct)
                {
                    Console.WriteLine($"Order completed for {Customer.FirstName} {Customer.LastName}. Product shipped.");
                }
                else if (Product is DigitalProduct)
                {
                    Console.WriteLine($"Order completed for {Customer.FirstName} {Customer.LastName}. Download link sent.");
                }
            }
            else
            {
                // If insufficient stock, show message
                Console.WriteLine($"Failed to create order. Insufficient stock for {Product.Name}. Available: {Product.Stock}");
            }
        }
    }
}
