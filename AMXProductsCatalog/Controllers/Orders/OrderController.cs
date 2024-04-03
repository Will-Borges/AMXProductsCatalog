using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AMXProductsCatalog.Controllers.Orders
{
    using AMXProductsCatalog.Presenters.Interfaces;
    using AMXProductsCatalog.Views.Orders.CreateOrder.Request;
    using Microsoft.AspNetCore.Authorization;

    [Route("v1/Order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderPresenter _orderPresenter;
        private readonly JsonSerializerSettings _jsonSerializerSettings;


        public OrderController(IOrderPresenter orderPresenter)
        {
            _orderPresenter = orderPresenter;

            _jsonSerializerSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.None
            };
        }

        
        [HttpPost("CreateOrder")]
        [Authorize(Roles = "admin,seller")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequestDTO[] dtos) 
        {
            try
            {
                var order = await _orderPresenter.CreateOrder(dtos);

                string json = JsonConvert.SerializeObject(order, _jsonSerializerSettings);
                return Ok(json);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetOrder")]
        [Authorize(Roles = "admin,seller,client")]
        public async Task<IActionResult> GetOrderById([FromQuery] long id)
        {
            try
            {
                var order = await _orderPresenter.GetOrderById(id);

                string json = JsonConvert.SerializeObject(order, _jsonSerializerSettings);
                return Ok(json);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("ConfirmOrder")]
        [Authorize(Roles = "admin,seller")]
        public async Task<IActionResult> ConfirmOrderById([FromQuery] long id)
        {
            try
            {
                var confirmOrderSucess = await _orderPresenter.ConfirmOrderById(id);
                return Ok(confirmOrderSucess);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

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
                Descrição: Retorna uma lista de todos os pedidos. *****
         */
    }
}
