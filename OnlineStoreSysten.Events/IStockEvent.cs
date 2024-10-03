namespace OnlineStoreSystem.Events
{
    public interface IStockEvent
    {
        void OnOutOfStock(string message);
    }
}