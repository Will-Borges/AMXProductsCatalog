using Microsoft.AspNetCore.Mvc;

namespace AMXProductsCatalog.Controllers.Products
{
    using AMXProductsCatalog.Presenters.Interfaces;
    using AMXProductsCatalog.Views.Products.CreateCar.Request;
    using AMXProductsCatalog.Views.Products.UpdateCar.Request;

    [Route("v1/CarProduct")]
    [ApiController]
    public class CarProductController : ControllerBase
    {
        private readonly ICarProductPresenter _carProductPresenter;


        public CarProductController(ICarProductPresenter carProductPresenter)
        {
            _carProductPresenter = carProductPresenter;
        }


        [HttpPost("CreateCarProduct")]
        public async Task<IActionResult> CreateCarProduct([FromBody] CreateCarProductRequestDTO CarProductDto)
        {
            try
            {
                var productCode = await _carProductPresenter.CreateCarProduct(CarProductDto);
                return Ok(productCode);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("GetAllCarProducts")]
        public async Task<IActionResult> GetAllCarProducts([FromQuery] int pageSize, [FromQuery] int pageNumber)
        {
            try
            {
                var cars = await _carProductPresenter.GetAllCarProducts(pageSize, pageNumber);
                return Ok(cars);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetCarProductById")]
        public async Task<IActionResult> GetCarProductById([FromQuery] int id)
        {
            try
            {
                var productCode = await _carProductPresenter.GetCarProductById(id);
                return Ok(productCode);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("DeleteCarProductById")]
        public async Task<IActionResult> DeleteCarProductById([FromQuery] int id)
        {
            try
            {
                var deleteWithSucess = await _carProductPresenter.DeleteCarProductById(id);
                return Ok(deleteWithSucess);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("UpdateCarProduct")]
        public async Task<IActionResult> UpdateCarProduct([FromBody] UpdateCarProductRequestDTO CarProductDto)
        {
            try
            {
                var updateWithSucess = await _carProductPresenter.UpdateCarProduct(CarProductDto);
                return Ok(updateWithSucess);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
