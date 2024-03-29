namespace AMXProductsCatalog.Core.Domain.Abstractions.Application.Services
{
    using AMXProductsCatalog.Core.Domain.Domains.Products;
    using AMXProductsCatalog.Core.Domain.Domains.Products.GetProduct;

    public interface ICarProductService
    {
        Task<long> CreateCarProduct(CarProduct carRequestDTO);
        Task<GetCarProductResponse[]> GetAllCarProducts(int pageSize, int pageNumber);
        Task<GetCarProductResponse> GetCarProductById(int id);
        Task<bool> DeleteCarProductById(long id);
    }
}
