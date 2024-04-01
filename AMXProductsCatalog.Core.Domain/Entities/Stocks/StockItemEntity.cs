namespace AMXProductsCatalog.Core.Domain.Entities.Stocks
{
    public class StockItemEntity
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
       // public BaseProduct? Product { get; set; } // representacao dele com o produto = cardionalidade do entity framework


        public StockItemEntity() { }

        public StockItemEntity(long productId, int quantity, DateTimeOffset lastUpdated)
        {
            ProductId = productId;
            Quantity = quantity;
            LastUpdated = lastUpdated;
           // Product = new BaseProduct();
        }

        public StockItemEntity(long id, long productId)
        {
            Id = id;
            ProductId = productId;
            Quantity = 0;
            LastUpdated = DateTimeOffset.Now;
        }
    }
}
