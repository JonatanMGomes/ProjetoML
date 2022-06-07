using Microsoft.AspNetCore.Mvc;
using ProjetoML.Lib.Data;
using ProjetoML.Lib.Models;
using ProjetoML.Web.DTOs;

namespace ProjetoML.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        public ILogger<PedidoController> _log { get; set; }
        private readonly MLContext _mlContext;
        public PedidoController(ILogger<PedidoController> log, MLContext mLContext)
        {
            _log = log;
            _mlContext = mLContext;
        }
        [HttpPost("Adicionar Pedido")]
        public IActionResult AddPedido(PedidoDTO pedidoDTO)
        {
            var pedidoNovo = new Pedido(pedidoDTO.Id, pedidoDTO.DataPedido, pedidoDTO.Status, pedidoDTO.IdTransportadora,
                                        pedidoDTO.IdUsuario);
            _mlContext.Pedidos.Add(pedidoNovo);
            _mlContext.SaveChanges();
            return Ok(_mlContext.Pedidos);
        }
        [HttpGet("Get Pedido por id")]
        public IActionResult GetPedidoPeloId(int id)
        {
            var pedidoDesejado = _mlContext.Pedidos.Find(id);
            return Ok(pedidoDesejado);
        }
        [HttpGet("Get Pedidos")]
        public IActionResult GetPedidos()
        {
            var pedidos = _mlContext.Pedidos.ToList();
            return Ok(pedidos);
        }
        [HttpPut("Alterando status do Pedido desejado")]
        public IActionResult PutStatusDoPedidoDesejado(int id, string statusNovo)
        {
            _mlContext.Pedidos.Find(id).Status = statusNovo;
            _mlContext.SaveChanges();
            return Ok(_mlContext.Pedidos);
        }
        [HttpDelete("Deletar Pedido por id")]
        public IActionResult DeletePedidoPeloId(int id)
        {
            var pedidoASerRemovido = _mlContext.Pedidos.Find(id);
            _mlContext.Pedidos.Remove(pedidoASerRemovido);
            _mlContext.SaveChanges();
            return Ok(_mlContext.Pedidos);
        }
    }
}