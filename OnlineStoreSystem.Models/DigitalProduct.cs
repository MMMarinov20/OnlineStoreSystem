using System;
using OnlineStoreSystem.Models;
namespace OnlineStoreSystem.Models
{
    public class DigitalProduct : Product
    {
        public DigitalProduct(string name, decimal price, int stock)
            : base(name, price, stock)
        { }

        public override void DisplayDetails()
        {
            Console.WriteLine($"Digital Product: {Name}, Price: {Price:C}, Stock: {Stock}");
        }

    }
}