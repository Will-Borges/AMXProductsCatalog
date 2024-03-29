using AMXProductsCatalog.Views.Products.CreateCar.Request;
using Microsoft.AspNetCore.Mvc;

namespace AMXProductsCatalog.Controllers.Orders
{
    [Route("v1/Order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        //


        public OrderController()
        {
            
        }


        //[HttpPost("CreateCarProduct")]
        //public async Task<IActionResult> CreateCarProduct([FromBody] CreateCarProductRequestDTO CarProductDto)
        //{
        //    try
        //    {
        //        var productCode = await _carProductPresenter.CreateCarProduct(CarProductDto);
        //        return Ok(productCode);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}

        /*
            Criar Pedido:
                Método: POST
                Endpoint: /api/pedidos
                Descrição: Cria um novo pedido e verifica a disponibilidade dos produtos no estoque.
                Corpo da solicitação: Lista de produtos com quantidades.

            Detalhes de um Pedido Específico:
                Método: GET
                Endpoint: /api/pedidos/{id}
                Descrição: Retorna detalhes de um pedido específico com o ID correspondente.
            
            Confirmar Pedido:
                Método: POST
                Endpoint: /api/pedidos/{id}/confirmar
                Descrição: Confirma um pedido e atualiza automaticamente o estoque.
                Parâmetro: ID do pedido a ser confirmado.
            
            Listar Todos os Pedidos:
                Método: GET
                Endpoint: /api/pedidos
                Descrição: Retorna uma lista de todos os pedidos.
         */
    }
}
