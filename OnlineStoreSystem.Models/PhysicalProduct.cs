using System;
using OnlineStoreSystem.Models;
using OnlineStoreSystem.Events;

namespace OnlineStoreSystem.Models
{
    public class PhysicalProduct : Product
    {
        public PhysicalProduct(string name, decimal price, int stock, IStockEvent stockEventHandler)
            : base(name, price, stock, stockEventHandler)
        {
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"Physical Product: {Name}, Price: {Price:C}, Stock: {Stock}");
        }
    }
}
