namespace AMXProductsCatalog.Core.Domain.Entities.Stocks
{
    public class StockEntity
    {
        public long Id { get; set; }
        public List<StockItemEntity> StockItems { get; set; }


        public StockEntity(long id, List<StockItemEntity> stockItems)
        {
            StockItems = stockItems;
        }

        public StockEntity() { }

        public StockEntity(long id)
        {
            Id = id;
            StockItems = new List<StockItemEntity>();
        }
    }
}
