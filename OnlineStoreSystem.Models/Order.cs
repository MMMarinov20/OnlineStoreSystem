using System;
using OnlineStoreSystem.Models;
using OnlineStoreSystem.Discounts;
using OnlineStoreSystem.Payments;
using OnlineStoreSystem.Events;

namespace OnlineStoreManagementSystem
{
    public class Order
    {
        public Customer Customer { get; private set; }
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal DiscountAmount { get; private set; }

        public Order(Customer customer, Product product, int quantity)
        {
            Customer = customer;
            Product = product;
            Quantity = quantity;
        }

        public void ProcessOrder(IDiscount discount, IPayment paymentMethod)
        {
            if (Product.ReduceStock(Quantity))
            {
                decimal totalPrice = Product.Price * Quantity;
                DiscountAmount = discount.CalculateDiscount(totalPrice);
                decimal finalPrice = totalPrice - DiscountAmount;

                Console.WriteLine($"Order created for {Quantity} unit(s) of {Product.Name}.");
                Console.WriteLine($"Discount applied. Final price: {finalPrice:C}");

                Product.DisplayDetails();
                Customer.DisplayCustomerInfo();

                paymentMethod.ProcessPayment(finalPrice);

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
                Console.WriteLine($"Failed to create order. Insufficient stock for {Product.Name}. Available: {Product.Stock}");
            }
        }
    }
}