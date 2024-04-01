namespace AMXProductsCatalog.Core.Domain.Abstractions.Repository
{
    using AMXProductsCatalog.Core.Domain.Entities.Orders.CreateOrder;

    public interface IOrderRepository
    {
        Task<long> InsertOrderProduct(OrderEntity order);
    }
}
