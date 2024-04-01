using AutoMapper;

namespace AMXProductsCatalog.Presenters.Orders
{
    using AMXProductsCatalog.Core.Domain.Abstractions.Application.Services;
    using AMXProductsCatalog.Core.Domain.Domains.Orders;
    using AMXProductsCatalog.Core.Domain.Domains.Orders.CreateOrders;
    using AMXProductsCatalog.Presenters.Interfaces;
    using AMXProductsCatalog.Views.Orders.CreateOrder.Request;
    using AMXProductsCatalog.Views.Orders.CreateOrder.Response;

    public class OrderPresenter : IOrderPresenter
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;


        public OrderPresenter(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }


        public async Task<CreateOrderResponseDTO> CreateOrder(CreateOrderRequestDTO[] createOrderDto) //validar a entrada dos dados
        {
            var createOrder = _mapper.Map<CreateOrder[]>(createOrderDto);

            var order= await _orderService.CreateOrder(createOrder);

            var orderResult = _mapper.Map<CreateOrderResponseDTO>(order);
            return orderResult;
        }
    }
}
