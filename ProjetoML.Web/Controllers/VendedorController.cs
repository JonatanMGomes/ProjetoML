using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoML.Lib.Data;
using ProjetoML.Lib.Models;
using ProjetoML.Web.DTOs;

namespace ProjetoML.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendedorController : ControllerBase
    {
        public ILogger<VendedorController> _log { get; set; }
        private readonly MLContext _mlContext;
        public VendedorController(ILogger<VendedorController> log, MLContext mLContext)
        {
            _log = log;
            _mlContext = mLContext;
        }
        [HttpPost("Adicionar Vendedor")]
        public IActionResult AddVendedor(VendedorDTO vendedorDTO)
        {
            var vendedorNovo = new Vendedor(vendedorDTO.Id, vendedorDTO.Nome, vendedorDTO.Email, vendedorDTO.CNPJ,
                                            vendedorDTO.DataCadastro);
            _mlContext.Vendedores.Add(vendedorNovo);
            _mlContext.SaveChanges();
            return Ok(_mlContext.Vendedores);
        }
        [HttpGet("Get Vendedor por id")]
        public IActionResult GetVendedorPeloId(int id)
        {
            var vendedorDesejado = _mlContext.Vendedores.AsNoTracking().First(x => x.Id == id);
            return Ok(vendedorDesejado);
        }
        [HttpGet("Get Vendedores")]
        public IActionResult GetVendedores()
        {
            var vendedores = _mlContext.Vendedores.Include(x => x.Produtos).AsNoTracking().ToList();
            return Ok(vendedores);
        }
        [HttpPut("Alterando CNPJ do Vendedor desejado")]
        public IActionResult PutCNPJDoVendedorDesejado(int id, string cnpjNovo)
        {
            _mlContext.Vendedores.Find(id).Cnpj = cnpjNovo;
            _mlContext.SaveChanges();
            return Ok(_mlContext.Vendedores);
        }
        [HttpDelete("Deletar Vendedor por id")]
        public IActionResult DeleteVendedorPeloId(int id)
        {
            var vendedorASerRemovido = _mlContext.Vendedores.Find(id);
            _mlContext.Vendedores.Remove(vendedorASerRemovido);
            _mlContext.SaveChanges();
            return Ok(_mlContext.Vendedores);
        }
    }
}