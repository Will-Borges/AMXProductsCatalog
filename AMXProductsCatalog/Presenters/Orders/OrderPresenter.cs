using AutoMapper;

namespace AMXProductsCatalog.Presenters.Orders
{
    using AMXProductsCatalog.Core.Domain.Abstractions.Application.Services;
    using AMXProductsCatalog.Core.Domain.Domains.Generics.Verification;
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


        public async Task<CreateOrderResponseDTO> CreateOrder(CreateOrderRequestDTO[] createOrderDto)
        {
            ValueCheckerPresenter.CheckFor(createOrderDto);

            var createOrder = _mapper.Map<CreateOrder[]>(createOrderDto);

            var order= await _orderService.CreateOrder(createOrder);

            var orderResult = _mapper.Map<CreateOrderResponseDTO>(order);
            return orderResult;
        }

        public async Task<GetOrderResponseDTO> GetOrderById(long id)
        {
            ValueCheckerPresenter.CheckFor(id);

            var order = await _orderService.GetOrderById(id);

            var orderResult = _mapper.Map<GetOrderResponseDTO>(order);
            return orderResult;
        }

        public async Task<bool> ConfirmOrderById(long id) // verificar se o pedido ja nao foi confirmado
        {
            ValueCheckerPresenter.CheckFor(id);

            var confirmOrderSucess = await _orderService.ConfirmOrderById(id);
            return confirmOrderSucess;
        }
    }
}
