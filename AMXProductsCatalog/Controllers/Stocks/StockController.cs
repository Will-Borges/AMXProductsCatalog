using Microsoft.AspNetCore.Mvc;

namespace AMXProductsCatalog.Controllers.Stocks
{
    using AMXProductsCatalog.Views.Products.CreateCar.Request;

    [Route("v1/Stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        //


        public StockController()
        {
            
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
                return BadRequest(e.Message);
            }
        }

        /*
            Listar Todos os Itens de Estoque:
            Método: GET
            Endpoint: /api/estoque
            Descrição: Retorna uma lista de todos os itens de estoque disponíveis.
         */


        /*
            Detalhes de um Item de Estoque Específico:
            Método: GET
            Endpoint: /api/estoque/{id}
            Descrição: Retorna detalhes de um item de estoque específico com o ID correspondente.
         */
    }
}
