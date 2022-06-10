using Microsoft.AspNetCore.Mvc;
using ProjetoML.Lib.Data.Repositorios.Interfaces;
using ProjetoML.Lib.Models;
using ProjetoML.Web.DTOs;

namespace ProjetoML.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoPedidoController : ControllerBase
    {
        public ILogger<ProdutoPedidoController> _log { get; set; }
        private readonly IProdutoPedidoRepositorio _repositorio;
        public ProdutoPedidoController(ILogger<ProdutoPedidoController> log, IProdutoPedidoRepositorio repositorio)
        {
            _log = log;
            _repositorio = repositorio;
        }
        [HttpPost("Adicionar ProdutoXPedido")]
        public IActionResult AddProdutoPedido(ProdutoPedidoDTO produtoPedidoDTO)
        {
            var produtoPedidoNovo = new ProdutoPedido(produtoPedidoDTO.Id, produtoPedidoDTO.IdProduto, produtoPedidoDTO.IdPedido);
            _repositorio.Adicionar(produtoPedidoNovo);
            return Ok();
        }
        [HttpGet("Get ProdutoPedido por id")]
        public IActionResult GetProdutoPedidoPeloId(int id)
        {
            return Ok(_repositorio.BuscarPorId(id));
        }
        [HttpGet("Get ProdutosPedidos")]
        public IActionResult GetProdutosPedidos()
        {
            return Ok(_repositorio.BuscarTodos());
        }
        [HttpPut("Alterando Produto da ProdutoPedido desejada")]
        public IActionResult PutProdutoDaProdutoPedidoDesejada(int id, Produto produtoSubstituto)
        {
            _repositorio.AlterarProdutoEmProdutoPedido(id, produtoSubstituto);
            return Ok();
        }
        [HttpDelete("Deletar ProdutoPedido por id")]
        public IActionResult DeleteProdutoXPedidoPeloId(int id)
        {
            _repositorio.DeletarItemDesejado(id);
            return Ok();
        }
    }
}