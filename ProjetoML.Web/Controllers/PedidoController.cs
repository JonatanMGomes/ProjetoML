using Microsoft.AspNetCore.Mvc;
using ProjetoML.Lib.Data.Repositorios.Interfaces;
using ProjetoML.Lib.Models;
using ProjetoML.Web.DTOs;

namespace ProjetoML.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        public ILogger<PedidoController> _log { get; set; }
        private readonly IPedidoRepositorio _repositorio;
        public PedidoController(ILogger<PedidoController> log, IPedidoRepositorio repositorio)
        {
            _log = log;
            _repositorio = repositorio;
        }
        [HttpPost("Adicionar Pedido")]
        public IActionResult AddPedido(PedidoDTO pedidoDTO)
        {
            var pedidoNovo = new Pedido(pedidoDTO.Id, pedidoDTO.DataPedido, pedidoDTO.Status, pedidoDTO.IdTransportadora,
                                        pedidoDTO.IdUsuario);
            _repositorio.Adicionar(pedidoNovo);
            return Ok();
        }
        [HttpGet("Get Pedido por id")]
        public IActionResult GetPedidoPeloId(int id)
        {
            return Ok(_repositorio.BuscarPorId(id));
        }
        [HttpGet("Get Pedidos")]
        public IActionResult GetPedidos()
        {
            return Ok(_repositorio.BuscarTodos());
        }
        [HttpPut("Alterando status do Pedido desejado")]
        public IActionResult PutStatusDoPedidoDesejado(int id, string statusNovo)
        {
            _repositorio.AlterarStatusPedido(id, statusNovo);
            return Ok();
        }
        [HttpDelete("Deletar Pedido por id")]
        public IActionResult DeletePedidoPeloId(int id)
        {
            _repositorio.DeletarItemDesejado(id);
            return Ok();
        }
    }
}