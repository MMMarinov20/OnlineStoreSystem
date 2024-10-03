using System;

namespace OnlineStoreSystem.Models
{
    public abstract class Product
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; protected set; }

        public Product(string name, decimal price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }

        public abstract void DisplayDetails();

        public bool ReduceStock(int quantity)
        {
            if (quantity > Stock)
            {
                Console.WriteLine($"Insufficient stock for {Name}. Available: {Stock}");
                return false;
            }

            Stock -= quantity;
            Console.WriteLine($"{quantity} units of {Name} deducted from stock.");

            if (Stock == 0)
            {
                OnOutOfStock();
            }
            return true;
        }

        protected virtual void OnOutOfStock()
        {
            Console.WriteLine($"[EVENT] {Name} is now out of stock!");
        }
    }
}