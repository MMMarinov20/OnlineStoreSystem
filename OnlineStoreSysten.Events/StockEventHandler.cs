using System;

namespace OnlineStoreSystem.Events
{
    public class StockEventHandler : IStockEvent
    {
        public void OnOutOfStock(string message)
        {
            Console.WriteLine($"[EVENT] {message}");
        }
    }
}