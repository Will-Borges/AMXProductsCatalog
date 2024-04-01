using Microsoft.AspNetCore.Mvc;

namespace AMXProductsCatalog.Controllers.Stocks
{
    using AMXProductsCatalog.Presenters.Interfaces;
    using Newtonsoft.Json;

    [Route("v1/Stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockPresenter _stockPresenter;
        private readonly JsonSerializerSettings _jsonSerializerSettings;


        public StockController(IStockPresenter stockPresenter)
        {
            _stockPresenter = stockPresenter;

            _jsonSerializerSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.None
            };
        }


        [HttpGet("GetStock")]
        public async Task<IActionResult> GetStock()
        {
            try
            {
                var stock = await _stockPresenter.GetStock();

                string json = JsonConvert.SerializeObject(stock, _jsonSerializerSettings);
                return Ok(json);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetItemStock")]
        public async Task<IActionResult> GetItemStockById()
        {
            try
            {
                var stock = await _stockPresenter.GetStock();

                string json = JsonConvert.SerializeObject(stock, _jsonSerializerSettings);
                return Ok(json);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /*
            Detalhes de um Item de Estoque Específico:
            Método: GET
            Endpoint: /api/estoque/{id}
            Descrição: Retorna detalhes de um item de estoque específico com o ID correspondente.
         */
    }
}
