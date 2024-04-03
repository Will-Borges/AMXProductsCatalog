using AutoMapper;

namespace AMXProductsCatalog.Core.Application.Services.Orders
{
    using AMXProductsCatalog.Core.Domain.Abstractions.Application.Services;
    using AMXProductsCatalog.Core.Domain.Abstractions.Repository;
    using AMXProductsCatalog.Core.Domain.Domains.Orders;
    using AMXProductsCatalog.Core.Domain.Domains.Orders.CreateOrders;
    using AMXProductsCatalog.Core.Domain.Domains.Products;
    using AMXProductsCatalog.Core.Domain.Domains.Stocks;
    using AMXProductsCatalog.Core.Domain.Entities.Orders.CreateOrder;
    using AMXProductsCatalog.Core.Domain.Entities.Stocks;

    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;
        private readonly ICarProductRepository _carProductRepository;
        private readonly IOrderRepository _orderRepository;


        public OrderService(
            IMapper mapper,
            IStockRepository stockRepository,
            ICarProductRepository carProductRepository,
            IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _stockRepository = stockRepository;
            _carProductRepository = carProductRepository;
            _orderRepository = orderRepository;
        }


        public async Task<Order> CreateOrder(CreateOrder[] orders) //trocar os nomes de 'CreateX' para BuildX
        {
            var stockItems = await GetStockItem(orders);

            var order = BuildOrder(stockItems, orders);
            var orderId = await InserOrder(order);

            order.SetId(orderId);
            return order;
        }

        public async Task<Order> GetOrderById(long id)
        {
            var orderEntity = await RepositoryGetOrderById(id);
            var order = await BuildOrder(orderEntity);

            return order;
        }

        public async Task<bool> ConfirmOrderById(long id)
        {
            var orderEntity = await RepositoryGetOrderById(id);

            foreach (var itemId in orderEntity.OrderItemsId)
            {
                var orderItems = await _orderRepository.GetOrderItemById(itemId);
                var stockItem = await RepositoryGetItemStockById(orderItems.ItemId);

                await UpdateQuantityStock(stockItem, orderItems.Quantity);
            }

            orderEntity.Status = OrderStatus.Confirmed;
            var updateWithSucess = await _orderRepository.UpdateOrder(orderEntity);

            return updateWithSucess;
        }

        private async Task UpdateQuantityStock(StockItemEntity stockItem, int quantity)
        {
            if (!VerifyQuantityIsValid(stockItem.Quantity, quantity))
            {
                throw new InvalidOperationException($"The quantity for this order is no longer valid.");
            }
            var quantityUpdate = stockItem.Quantity - quantity;
            await _stockRepository.UpdateQuantityStockItem(stockItem.Id, quantityUpdate);
        }

        private async Task<OrderEntity> RepositoryGetOrderById(long id)
        {
            var orderEntity = await _orderRepository.GetOrderById(id);
            return orderEntity;
        }

        private async Task<Order> BuildOrder(OrderEntity orderEntity)
        {
            var order = new Order(
                orderEntity.Id,
                orderEntity.TotalPrice,
                orderEntity.Status);

            var items = new List<OrderItem>();
            foreach (var itemId in orderEntity.OrderItemsId)
            {
                var orderItemEntity = await _orderRepository.GetOrderItemById(itemId);
                var itemEntity = await _stockRepository.GetItemStockById(orderItemEntity.ItemId);

                if (itemEntity == null)
                {
                    throw new InvalidOperationException("ItemStock invalid.");
                }

                var orderItem = new OrderItem(itemEntity.Id, orderItemEntity.Quantity);

                await InsertCarProduct(orderItem, itemEntity.ProductId);
                items.Add(orderItem);
            }

            order.SetItems(items.ToArray());
            return order;
        }

        private async Task<long> InserOrder(Order order)
        {
            var orderItemIds = await InsertOrderItem(order);

            var orderEntity = _mapper.Map<OrderEntity>(order);
            orderEntity.OrderItemsId = orderItemIds;

            var orderId = await _orderRepository.InsertOrder(orderEntity);
            return orderId;
        }

        private async Task<long[]> InsertOrderItem(Order order)
        {
            var orderEntitys = _mapper.Map<OrderItemEntity[]>(order.Items); //QUI TA invertido ta recebendo product ao inves do item

            var orderItemIds = new List<long>();
            foreach (var orderEntity in orderEntitys)
            {
                var orderItemId = await _orderRepository.InsertOrderItem(orderEntity);
                orderItemIds.Add(orderItemId);
            }
            
            return orderItemIds.ToArray();
        }

        private Order BuildOrder(StockItem[] stockItems, CreateOrder[] orders) //retirar orders
        {
            var orderItem = BuildOrderItem(stockItems, orders);

            var order = new Order(); 

            order.SetStatus(OrderStatus.Processing);
            order.SetItems(orderItem);
            order.SetTotalPrice();

            return order;
        }

        private OrderItem[] BuildOrderItem(StockItem[] stockItems, CreateOrder[] orders)
        {
            var orderItems = new List<OrderItem>();
            foreach (var item in stockItems)
            {
                var order = orders.FirstOrDefault(q => q.ItemId == item.Id);

                if (!VerifyQuantityIsValid(item.Quantity, order!.Quantity))
                {
                    throw new InvalidOperationException($"Quantity of itemId {order.ItemId} invalid.");
                }

                var orderItem = new OrderItem(order.ItemId, item.Product, order.Quantity);
                orderItems.Add(orderItem);
            }

            return orderItems.ToArray();
        }

        private bool VerifyQuantityIsValid(int itemQuantity, int orderQuantity)
        {
            return (itemQuantity - orderQuantity) >= 0;
        }

        private async Task<StockItem[]> GetStockItem(CreateOrder[] orders)
        {
            var stockItemList = new List<StockItem>();
            foreach (var order in orders)
            {
                var stockItemEntity = await RepositoryGetItemStockById(order.ItemId);

                var stockItem = await BuildStockItem(stockItemEntity, stockItemEntity.ProductId);
                stockItemList.Add(stockItem);
            }

            return stockItemList.ToArray();
        }

        private async Task<StockItemEntity> RepositoryGetItemStockById(long id)
        {
            var stockItemEntity = await _stockRepository.GetItemStockById(id);

            VerifyStockItemEntityIsNull(stockItemEntity);
            return stockItemEntity;
        }

        private void VerifyStockItemEntityIsNull(StockItemEntity? stockItemEntity)
        {
            if (stockItemEntity == null) //separar esse regra em um metodo
            {
                throw new InvalidOperationException("ItemId not found.");
            }
        }

        private async Task InsertCarProduct(StockItem stockItem, long productId)
        {
            var car = await GetCarById(productId);
            stockItem.InsertBaseProduct(car);
        }

        private async Task InsertCarProduct(OrderItem orderItem, long productId)
        {
            var car = await GetCarById(productId);
            orderItem.InsertBaseProduct(car);
        }

        private async Task<CarProduct> GetCarById(long productId)
        {
            var carEntity = await _carProductRepository.GetCarById(productId);
            var car = _mapper.Map<CarProduct>(carEntity);
            return car;
        }

        private async Task<StockItem> BuildStockItem(StockItemEntity stockItemEntity, long productId)
        {
            var stockItem = new StockItem(stockItemEntity.Id, stockItemEntity.Quantity, stockItemEntity.LastUpdated);

            await InsertCarProduct(stockItem, productId);
            return stockItem;
        }
    }
}
