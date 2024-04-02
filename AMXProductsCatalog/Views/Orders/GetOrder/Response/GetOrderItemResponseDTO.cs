namespace AMXProductsCatalog.Views.Orders.GetOrder.Response
{
    using AMXProductsCatalog.Core.Domain.Abstractions.Products;

    public class GetOrderItemResponseDTO
    {
        public long Id { get; set; }
        public BaseProduct Product { get; set; }
        public int Quantity { get; set; }


        public GetOrderItemResponseDTO() { }

        public GetOrderItemResponseDTO(long id, BaseProduct product, int quantity)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
        }
    }
}
