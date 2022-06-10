using Microsoft.AspNetCore.Mvc;
using ProjetoML.Lib.Data.Repositorios.Interfaces;
using ProjetoML.Lib.Models;
using ProjetoML.Web.DTOs;

namespace ProjetoML.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        public ILogger<ProdutoController> _log { get; set; }
        private readonly IProdutoRepositorio _repositorio;
        public ProdutoController(ILogger<ProdutoController> log, IProdutoRepositorio repositorio)
        {
            _log = log;
            _repositorio = repositorio;
        }
        [HttpPost("Adicionar Produto")]
        public IActionResult AddProduto(ProdutoDTO produtoDTO)
        {
            var produtoNovo = new Produto(produtoDTO.Id, produtoDTO.Nome, produtoDTO.Descricao, produtoDTO.Valor,
                                          produtoDTO.DataCadastro, produtoDTO.IdVendedor);
            _repositorio.Adicionar(produtoNovo);
            return Ok();
        }
        [HttpGet("Get Produto por id")]
        public IActionResult GetProdutoPeloId(int id)
        {
            return Ok(_repositorio.BuscarPorId(id));

        }
        [HttpGet("Get Produtos")]
        public IActionResult GetProdutos()
        {
            return Ok(_repositorio.BuscarTodos());
        }
        [HttpPut("Alterando nome do Produto desejado")]
        public IActionResult PutNomeDoProdutoDesejado(int id, string nomeNovo)
        {
            _repositorio.AlterarNomeProduto(id, nomeNovo);
            return Ok();
        }
        [HttpDelete("Deletar Produto por id")]
        public IActionResult DeleteProdutoPeloId(int id)
        {
            _repositorio.DeletarItemDesejado(id);
            return Ok();
        }
    }
}