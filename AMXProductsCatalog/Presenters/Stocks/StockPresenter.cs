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


        public async Task<GetStockDTO> GetStock()
        {
            var stock = await _stockService.GetStock();

            var stockDTO = _mapper.Map<GetStockDTO>(stock);
            return stockDTO;
        }
    }
}
