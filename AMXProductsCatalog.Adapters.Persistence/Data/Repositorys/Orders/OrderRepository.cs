namespace AMXProductsCatalog.Adapters.Persistence.Data.Repositorys.Orders
{
    using AMXProductsCatalog.Core.Domain.Abstractions.Repository;
    using AMXProductsCatalog.Core.Domain.Domains.Generics.Ramdom;
    using AMXProductsCatalog.Core.Domain.Entities.Orders.CreateOrder;

    public class OrderRepository : IOrderRepository
    {

        public OrderRepository()
        {
            
        }

        public async Task<long> InsertOrder(OrderEntity order)
        {
            try
            {
                order.Id = RandomIdGenerator.GenerateId();
                AMXDatabase.Orders.Add(order);

                return order.Id;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error inserting order.");
            }
        }

        public async Task<OrderEntity> GetOrderById(long id)
        {
            try
            {
                var order = AMXDatabase.Orders.FirstOrDefault(q => q.Id == id);

                if (order == null)
                {
                    return new OrderEntity();
                }

                return order;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error inserting order.");
            }
        }
    }
}
