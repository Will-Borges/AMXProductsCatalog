using AutoMapper;

namespace AMXProductsCatalog.Core.Application.Services.Orders
{
    using AMXProductsCatalog.Core.Domain.Abstractions.Application.Services;
    using AMXProductsCatalog.Core.Domain.Abstractions.Repository;
    using AMXProductsCatalog.Core.Domain.Domains.Customers;
    using AMXProductsCatalog.Core.Domain.Domains.Generics.Ramdom;
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

            VerifyQuantity(stockItems, orders);

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

        //public async Task<bool> ConfirmOrderById(long id)
        //{
        //    var orderEntity = await RepositoryGetOrderById(id);

        //    foreach (var itemId in orderEntity.ItemsId)
        //    {
        //        var stockItem = await RepositoryGetItemStockById(itemId);

        //        await UpdateQuantityStock(stockItem);
        //        _stockRepository.UpdateQuantityStockItem(stockItem.Id, stockItem.Quantity);
        //    }

        //    var updateWithSucess = _orderRepository.UpdateOrder(orderEntity);
        //}

        //private Task UpdateQuantityStock(StockItemEntity stockItem, long quantity)
        //{
        //    if ((stockItem.Quantity - quantity) >= 0)
        //    {

        //    }
        //}

        private async Task<OrderEntity> RepositoryGetOrderById(long id)
        {
            var orderEntity = await _orderRepository.GetOrderById(id);
            return orderEntity;
        }

        private async Task<Order> BuildOrder(OrderEntity orderEntity)
        {
            var order = new Order(
                orderEntity.Id,
                new Customer(), //revisar
                orderEntity.TotalPrice,
                orderEntity.Status);

            var items = new List<OrderItem>();
            foreach (var itemId in orderEntity.ItemsId)
            {
                var itemEntity = await _stockRepository.GetItemStockById(itemId);

                var orderItem = new OrderItem(itemEntity.Id, itemEntity.Quantity);

                await InsertCarProduct(orderItem, itemEntity.ProductId);
                items.Add(orderItem);
            }

            order.SetItems(items.ToArray());
            return order;
        }

        private async Task<long> InserOrder(Order order)
        {
            var orderEntity = _mapper.Map<OrderEntity>(order);

            var orderId = await _orderRepository.InsertOrder(orderEntity);
            return orderId;
        }

        private Order BuildOrder(StockItem[] stockItems, CreateOrder[] orders) //retirar orders
        {
            var orderItem = _mapper.Map<OrderItem[]>(stockItems);

            var order = new Order(
                new Customer(), //revisar
                orderItem);

            order.SetStatus(OrderStatus.Processing);
            order.SetTotalPrice();

            return order;
        }

        private void VerifyQuantity(StockItem[] stockItems, CreateOrder[] orders)
        {
            foreach (var item in stockItems)
            {
                var order = orders.FirstOrDefault(q => q.ItemId == item.Id);

                if ((item.Quantity - order.Quantity) < 0)
                {
                    throw new InvalidOperationException($"Quantity of itemId {order.ItemId} invalid.");
                }
            }
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
