using System;
using OnlineStoreSystem.Events;

namespace OnlineStoreSystem.Models
{
    public abstract class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        private readonly IStockEvent _stockEventHandler;

        protected Product(string name, decimal price, int stock, IStockEvent stockEventHandler)
        {
            Name = name;
            Price = price;
            Stock = stock;
            _stockEventHandler = stockEventHandler;
        }

        public abstract void DisplayDetails();

        public bool ReduceStock(int quantity)
        {
            if (quantity <= Stock)
            {
                Stock -= quantity;

                if (Stock == 0)
                {
                    _stockEventHandler.OnOutOfStock($"{Name} is now out of stock!");
                }
                return true;
            }
            return false;
        }
    }
}