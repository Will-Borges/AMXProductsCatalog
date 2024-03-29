namespace AMXProductsCatalog.Presenters.Interfaces
{
    using AMXProductsCatalog.Views.Products.CreateCar.Request;
    using AMXProductsCatalog.Views.Products.GetCar.Response;
    using AMXProductsCatalog.Views.Products.UpdateCar.Request;

    public interface ICarProductPresenter
    {
        Task<long> CreateCarProduct(CreateCarProductRequestDTO carRequestDTO);
        Task<GetCarProductResponseDTO[]> GetAllCarProducts(int pageSize, int pageNumber);
        Task<GetCarProductResponseDTO> GetCarProductById(int id);
        Task<bool> DeleteCarProductById(long id);
        Task<bool> UpdateCarProduct(UpdateCarProductRequestDTO carRequestDto);
    }
}
