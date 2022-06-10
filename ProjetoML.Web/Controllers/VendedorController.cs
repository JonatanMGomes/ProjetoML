using Microsoft.AspNetCore.Mvc;
using ProjetoML.Lib.Data.Repositorios.Interfaces;
using ProjetoML.Lib.Models;
using ProjetoML.Web.DTOs;

namespace ProjetoML.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendedorController : ControllerBase
    {
        public ILogger<VendedorController> _log { get; set; }
        private readonly IVendedorRepositorio _repositorio;
        public VendedorController(ILogger<VendedorController> log, IVendedorRepositorio repositorio)
        {
            _log = log;
            _repositorio = repositorio;
        }
        [HttpPost("Adicionar Vendedor")]
        public IActionResult AddVendedor(VendedorDTO vendedorDTO)
        {
            var vendedorNovo = new Vendedor(vendedorDTO.Id, vendedorDTO.Nome, vendedorDTO.Email, vendedorDTO.CNPJ,
                                            vendedorDTO.DataCadastro);
            _repositorio.Adicionar(vendedorNovo);
            return Ok();
        }
        [HttpGet("Get Vendedor por id")]
        public IActionResult GetVendedorPeloId(int id)
        {
            return Ok(_repositorio.BuscarPorId(id));
        }
        [HttpGet("Get Vendedores")]
        public IActionResult GetVendedores()
        {
            return Ok(_repositorio.BuscarTodos());
        }
        [HttpPut("Alterando CNPJ do Vendedor desejado")]
        public IActionResult PutCNPJDoVendedorDesejado(int id, string cnpjNovo)
        {
            _repositorio.AlterarCnpjVendedor(id, cnpjNovo);
            return Ok();
        }
        [HttpDelete("Deletar Vendedor por id")]
        public IActionResult DeleteVendedorPeloId(int id)
        {
            _repositorio.DeletarItemDesejado(id);
            return Ok();
        }
    }
}