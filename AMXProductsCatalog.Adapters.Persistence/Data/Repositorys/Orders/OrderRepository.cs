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

        public async Task<long> InsertOrderItem(OrderItemEntity orderItem)
        {
            try
            {
                orderItem.Id = RandomIdGenerator.GenerateId();
                AMXDatabase.OrderItems.Add(orderItem);

                return orderItem.Id;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error inserting orderItem.");
            }
        }

        public async Task<OrderItemEntity> GetOrderItemById(long id)
        {
            try
            {
                var orderItemEntity = AMXDatabase.OrderItems.FirstOrDefault(q => q.Id == id);

                if (orderItemEntity == null)
                {
                    return new OrderItemEntity();
                }

                return orderItemEntity;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error inserting orderItem.");
            }
        }

        public async Task<bool> UpdateOrder(OrderEntity orderInput)
        {
            try
            {
                var order = AMXDatabase.Orders.FirstOrDefault(q => q.Id == orderInput.Id);

                if (order == null)
                {
                    return false;
                }

                order.CustomerId = orderInput.CustomerId;
                order.OrderItemsId = orderInput.OrderItemsId;
                order.TotalPrice = orderInput.TotalPrice;
                order.Status = orderInput.Status;

                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error update order.");
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
