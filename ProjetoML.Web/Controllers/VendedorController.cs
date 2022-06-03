using Microsoft.AspNetCore.Mvc;
using ProjetoML.Lib.Data;
using ProjetoML.Lib.Models;

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
        public IActionResult AddVendedor(Vendedor vendedorNovo)
        {
            _mlContext.Vendedores.Add(vendedorNovo);
            _mlContext.SaveChanges();
            return Ok(_mlContext.Vendedores);
        }
        [HttpGet("Get Vendedor por id")]
        public IActionResult GetVendedorPeloId(int id)
        {
            var vendedorDesejado = _mlContext.Vendedores.Find(id);
            return Ok(vendedorDesejado);
        }
        [HttpGet("Get Vendedores")]
        public IActionResult GetVendedores()
        {
            var vendedores = _mlContext.Vendedores.ToList();
            return Ok(vendedores);
        }
        [HttpPut("Alterando CNPJ do Vendedor desejado")]
        public IActionResult PutCNPJDoVendedorDesejado(int id, string cnpjNovo)
        {
            _mlContext.Vendedores.Find(id).CNPJ = cnpjNovo;
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