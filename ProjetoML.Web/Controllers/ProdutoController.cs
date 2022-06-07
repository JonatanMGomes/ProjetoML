using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoML.Lib.Data;
using ProjetoML.Lib.Models;
using ProjetoML.Web.DTOs;

namespace ProjetoML.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        public ILogger<ProdutoController> _log { get; set; }
        private readonly MLContext _mlContext;
        public ProdutoController(ILogger<ProdutoController> log, MLContext mLContext)
        {
            _log = log;
            _mlContext = mLContext;
        }
        [HttpPost("Adicionar Produto")]
        public IActionResult AddProduto(ProdutoDTO produtoDTO)
        {
            var produtoNovo = new Produto(produtoDTO.Id, produtoDTO.Nome, produtoDTO.Descricao, produtoDTO.Valor,
                                          produtoDTO.DataCadastro, produtoDTO.IdVendedor);
            _mlContext.Produtos.Add(produtoNovo);
            _mlContext.SaveChanges();
            return Ok(_mlContext.Produtos);
        }
        [HttpGet("Get Produto por id")]
        public IActionResult GetProdutoPeloId(int id)
        {
            var produtoDesejado = _mlContext.Produtos.AsNoTracking().First(x => x.Id == id);
            return Ok(produtoDesejado);
        }
        [HttpGet("Get Produtos")]
        public IActionResult GetProdutos()
        {
            var produtos = _mlContext.Produtos.Include(x => x.Vendedor).AsNoTracking().ToList();
            return Ok(produtos);
        }
        [HttpPut("Alterando nome do Produto desejado")]
        public IActionResult PutNomeDoProdutoDesejado(int id, string nomeNovo)
        {
            _mlContext.Produtos.Find(id).Nome = nomeNovo;
            _mlContext.SaveChanges();
            return Ok(_mlContext.Produtos);
        }
        [HttpDelete("Deletar Produto por id")]
        public IActionResult DeleteProdutoPeloId(int id)
        {
            var produtoASerRemovido = _mlContext.Produtos.Find(id);
            _mlContext.Produtos.Remove(produtoASerRemovido);
            _mlContext.SaveChanges();
            return Ok(_mlContext.Produtos);
        }
    }
}