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

        private async Task<long> InserOrder(Order order)
        {
            var orderEntity = _mapper.Map<OrderEntity>(order);

            var orderId = await _orderRepository.InsertOrderProduct(orderEntity);
            return orderId;
        }

        private Order BuildOrder(StockItem[] stockItems, CreateOrder[] orders) //retirar orders
        {
            var orderItem = _mapper.Map<OrderItem[]>(stockItems);

            var order = new Order(
                RandomIdGenerator.GenerateId(),
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
                var order = orders.FirstOrDefault(q => q.ProductId == item.Id);

                if ((item.Quantity - order.Quantity) < 0)
                {
                    throw new InvalidOperationException($"Quantity of item {order.ProductId} invalid.");
                }
            }
        }

        private async Task<StockItem[]> GetStockItem(CreateOrder[] orders)
        {
            var stockItemList = new List<StockItem>();
            foreach (var order in orders)
            {
                var stockItemEntity = await _stockRepository.GetItemStockById(order.ProductId);

                if (stockItemEntity == null) //separar esse regra em um metodo
                {
                    throw new InvalidOperationException("Id not found.");
                }

                //var stockItem = _mapper.Map<StockItem>(stockItemEntity);
                //await InsertCarProduct(stockItem, stockItemEntity.ProductId);

                var stockItem = await BuildStockItem(stockItemEntity, stockItemEntity.ProductId);
                stockItemList.Add(stockItem);
            }

            return stockItemList.ToArray();
        }

        private async Task InsertCarProduct(StockItem stockItem, long productId)
        {
            var carEntity = await _carProductRepository.GetCarById(productId);
            var car = _mapper.Map<CarProduct>(carEntity);

            stockItem.InsertBaseProduct(car);
        }

        private async Task<StockItem> BuildStockItem(StockItemEntity stockItemEntity, long productId)
        {
            var stockItem = new StockItem(stockItemEntity.Id, stockItemEntity.Quantity, stockItemEntity.LastUpdated);

            await InsertCarProduct(stockItem, productId);
            return stockItem;
        }
    }
}
