namespace AMXProductsCatalog.Core.Domain.Abstractions.Repository
{
    using AMXProductsCatalog.Core.Domain.Entities.Orders.CreateOrder;

    public interface IOrderRepository
    {
        Task<long> InsertOrder(OrderEntity order);
        Task<OrderEntity> GetOrderById(long id);
        Task<bool> UpdateOrder(OrderEntity orderInput);
    }
}
