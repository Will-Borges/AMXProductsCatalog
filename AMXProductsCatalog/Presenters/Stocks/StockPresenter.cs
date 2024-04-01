using AutoMapper;

namespace AMXProductsCatalog.Presenters.Stocks
{
    using AMXProductsCatalog.Core.Domain.Abstractions.Application.Services;
    using AMXProductsCatalog.Presenters.Interfaces;
    using AMXProductsCatalog.Views.Stocks.GetStock.Response;

    public class StockPresenter : IStockPresenter
    {
        private readonly IMapper _mapper;
        private readonly IStockService _stockService;


        public StockPresenter(
            IStockService stockService,
            IMapper mapper)
        {
            _stockService = stockService;
            _mapper = mapper;
        }


        public async Task<GetStockResponseDTO> GetStock()
        {
            var stock = await _stockService.GetStock();

            var stockDTO = _mapper.Map<GetStockResponseDTO>(stock);
            return stockDTO;
        }

        public async Task<GetStockItemResponseDTO> GetItemStockById(long id)
        {
            var item = await _stockService.GetItemStockById(id);

            var itemDTO = _mapper.Map<GetStockItemResponseDTO>(item);
            return itemDTO;
        }

        public async Task<bool> UpdateQuantityStockItem(long id, int quantity)
        {
            var updateWithSucess = await _stockService.UpdateQuantityStockItem(id, quantity);
            return updateWithSucess;
        }
    }
}
