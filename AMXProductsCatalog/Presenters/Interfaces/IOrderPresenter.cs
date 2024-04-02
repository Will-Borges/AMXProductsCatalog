namespace AMXProductsCatalog.Presenters.Interfaces
{
    using AMXProductsCatalog.Views.Orders.CreateOrder.Request;
    using AMXProductsCatalog.Views.Orders.CreateOrder.Response;
    using AMXProductsCatalog.Views.Orders.GetOrder.Response;

    public interface IOrderPresenter
    {
        Task<CreateOrderResponseDTO> CreateOrder(CreateOrderRequestDTO[] createOrderDto);
        Task<GetOrderResponseDTO> GetOrderById(long id);
    }
}
