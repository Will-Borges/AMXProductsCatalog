namespace AMXProductsCatalog.Views.Stocks.GetStock.Response
{
    using AMXProductsCatalog.Core.Domain.Abstractions.Products;
    using System.Runtime.Serialization;

    [DataContract]
    public class GetStockItemResponseDTO
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public BaseProduct Product { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public DateTimeOffset LastUpdated { get; set; }
    }
}
