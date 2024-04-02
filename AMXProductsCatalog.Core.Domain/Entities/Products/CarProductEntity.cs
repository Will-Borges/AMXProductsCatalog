using System.Runtime.Serialization;

namespace AMXProductsCatalog.Core.Domain.Entities.Products
{
    using AMXProductsCatalog.Core.Domain.Abstractions.Products;

    [DataContract]
    public class CarProductEntity : BaseProduct
    {
       // [DataMember]
       // public long ItemId { get; set; }

        [DataMember]
        public string Brand { get; set; }

        [DataMember]
        public string Model { get; set; }

        [DataMember]
        public int Year { get; set; }


        public CarProductEntity() { }

        public CarProductEntity(long id, string brand, string model, int year, decimal price)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Year = year;
            Price = price;
        }
    }
}
