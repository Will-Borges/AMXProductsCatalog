using Swashbuckle.AspNetCore.Annotations;
using System.Runtime.Serialization;

namespace AMXProductsCatalog.Core.Domain.Abstractions.Products
{
    using AMXProductsCatalog.Core.Domain.Entities.Products;


    [SwaggerSubTypes(typeof(CarProductEntity), Discriminator = "productType")]
    public class BaseProduct
    {
        public long Id { get; set; } //priv
        public decimal Price { get; set; }
    }
}
