namespace AMXProductsCatalog.Presenters.Interfaces
{
    using AMXProductsCatalog.Views.CreateProduct.Request;
    using AMXProductsCatalog.Views.GetProduct.Response;

    public interface ICarProductPresenter
    {
        Task<long> CreateCarProduct(CreateCarProductRequestDTO carRequestDTO);
        Task<GetCarProductResponseDTO[]> GetAllCarProducts(int pageSize, int pageNumber);
        Task<GetCarProductResponseDTO> GetCarProductById(int id);
        Task<bool> DeleteCarProductById(long id);
    }
}
