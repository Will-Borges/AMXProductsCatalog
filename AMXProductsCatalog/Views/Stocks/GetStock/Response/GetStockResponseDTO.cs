using System.Runtime.Serialization;

namespace AMXProductsCatalog.Views.Stocks.GetStock.Response
{
    [DataContract]
    public class GetStockResponseDTO
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public ISet<GetStockItemDTO> StockItems { get; set; } = new HashSet<GetStockItemDTO>();
    }
}
