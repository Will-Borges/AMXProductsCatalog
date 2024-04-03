using System.Runtime.Serialization;

namespace AMXProductsCatalog.Views.Stocks.GetStock.Response
{
    public class GetStockResponseDTO
    {
        public long Id { get; set; }
        public ISet<GetStockItemResponseDTO> StockItems { get; set; } = new HashSet<GetStockItemResponseDTO>();
    }
}
