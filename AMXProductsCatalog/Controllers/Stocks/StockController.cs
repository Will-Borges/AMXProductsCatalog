using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AMXProductsCatalog.Controllers.Stocks
{
    using AMXProductsCatalog.Presenters.Interfaces;
    using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles = "admin,seller")]
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
        [Authorize(Roles = "admin,seller")]
        public async Task<IActionResult> GetItemStockById([FromQuery] long id)
        {
            try
            {
                var stock = await _stockPresenter.GetItemStockById(id);

                string json = JsonConvert.SerializeObject(stock, _jsonSerializerSettings);
                return Ok(json);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("UpdateItemStock")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateQuantityStockItem([FromQuery] long id, [FromQuery] int quantity)
        {
            try
            {
                var updateWithSucess = await _stockPresenter.UpdateQuantityStockItem(id, quantity);
                return Ok(updateWithSucess);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
