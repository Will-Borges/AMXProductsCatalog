namespace AMXProductsCatalog.Core.Domain.Abstractions.Application.Services
{
    using AMXProductsCatalog.Core.Domain.Domains.Orders.CreateOrders;
    using AMXProductsCatalog.Core.Domain.Domains.Orders;

    public interface IOrderService
    {
        Task<Order> CreateOrder(CreateOrder[] orders);
        Task<Order> GetOrderById(long id);
    }
}
