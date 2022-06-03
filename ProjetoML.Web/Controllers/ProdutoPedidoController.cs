using Microsoft.AspNetCore.Mvc;
using ProjetoML.Lib.Data;
using ProjetoML.Lib.Models;

namespace ProjetoML.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoPedidoController : ControllerBase
    {
        public ILogger<ProdutoPedidoController> _log { get; set; }
        private readonly MLContext _mlContext;
        public ProdutoPedidoController(ILogger<ProdutoPedidoController> log, MLContext mLContext)
        {
            _log = log;
            _mlContext = mLContext;
        }
        [HttpPost("Adicionar ProdutoXPedido")]
        public IActionResult AddProdutoPedido(ProdutoPedido produtoPedidoNovo)
        {
            _mlContext.ProdutosPedidos.Add(produtoPedidoNovo);
            _mlContext.SaveChanges();
            return Ok(_mlContext.ProdutosPedidos);
        }
        [HttpGet("Get ProdutoPedido por id")]
        public IActionResult GetProdutoPedidoPeloId(int id)
        {
            var produtoPedidoDesejado = _mlContext.ProdutosPedidos.Find(id);
            return Ok(produtoPedidoDesejado);
        }
        [HttpGet("Get ProdutosPedidos")]
        public IActionResult GetProdutosPedidos()
        {
            var produtosPedidos = _mlContext.ProdutosPedidos.ToList();
            return Ok(produtosPedidos);
        }
        [HttpPut("Alterando Produto da ProdutoPedido desejada")]
        public IActionResult PutProdutoDaProdutoPedidoDesejada(int id, Produto produtoSubstituto)
        {
            _mlContext.ProdutosPedidos.Find(id).Produto = produtoSubstituto;
            _mlContext.SaveChanges();
            return Ok(_mlContext.ProdutosPedidos);
        }
        [HttpDelete("Deletar ProdutoPedido por id")]
        public IActionResult DeleteProdutoXPedidoPeloId(int id)
        {
            var produtoPedidoASerRemovido = _mlContext.ProdutosPedidos.Find(id);
            _mlContext.ProdutosPedidos.Remove(produtoPedidoASerRemovido);
            _mlContext.SaveChanges();
            return Ok(_mlContext.ProdutosPedidos);
        }
    }
}