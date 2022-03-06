using monolithic_service.Models;

namespace monolithic_service.Repositories.Interfaces
{
    public interface IStoreRepository
    {
        Task<List<InventoryLine>> GetInventory();
        Task<Order> GetOrders(int orderId);
        Task<Order> PostOrder(Order order);
        Task<int> DeleteOrder(int orderId);
    }
}
