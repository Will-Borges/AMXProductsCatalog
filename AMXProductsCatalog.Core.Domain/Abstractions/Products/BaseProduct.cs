using Swashbuckle.AspNetCore.Annotations;
using System.Runtime.Serialization;

namespace AMXProductsCatalog.Core.Domain.Abstractions.Products
{
    using AMXProductsCatalog.Core.Domain.Entities.Products;

    [DataContract]
    [SwaggerSubTypes(typeof(CarProductEntity), Discriminator = "productType")]
    public class BaseProduct
    {
        [DataMember]
        public long Id { get; set; } 

        [DataMember]
        public decimal Price { get; set; }
    }
}
