using AutoMapper;

namespace AMXProductsCatalog.Presenters.Orders
{
    using AMXProductsCatalog.Core.Domain.Abstractions.Application.Services;
    using AMXProductsCatalog.Core.Domain.Domains.Orders;
    using AMXProductsCatalog.Core.Domain.Domains.Orders.CreateOrders;
    using AMXProductsCatalog.Presenters.Interfaces;
    using AMXProductsCatalog.Views.Orders.CreateOrder.Request;
    using AMXProductsCatalog.Views.Orders.CreateOrder.Response;
    using AMXProductsCatalog.Views.Orders.GetOrder.Response;

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

        public async Task<GetOrderResponseDTO> GetOrderById(long id) //validar a entrada dos dados
        {
            var order = await _orderService.GetOrderById(id);

            var orderResult = _mapper.Map<GetOrderResponseDTO>(order);
            return orderResult;
        }
        
        public async Task<GetOrderResponseDTO> ConfirmOrderById(long id) //validar a entrada dos dados
        {
            var order = await _orderService.GetOrderById(id);

            var orderResult = _mapper.Map<GetOrderResponseDTO>(order); 
            return orderResult;
        }
    }
}
