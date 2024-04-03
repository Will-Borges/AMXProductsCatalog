namespace AMXProductsCatalog.Views.Stocks.GetStock.Response
{
    using AMXProductsCatalog.Core.Domain.Abstractions.Products;
    using System.Runtime.Serialization;

    public class GetStockItemResponseDTO
    {
        public long Id { get; set; }
        public BaseProduct Product { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
    }
}
