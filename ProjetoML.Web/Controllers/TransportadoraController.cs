using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoML.Lib.Data;
using ProjetoML.Lib.Models;
using ProjetoML.Web.DTOs;

namespace ProjetoML.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransportadoraController : ControllerBase
    {
        public ILogger<TransportadoraController> _log { get; set; }
        private readonly MLContext _mlContext;
        public TransportadoraController(ILogger<TransportadoraController> log, MLContext mLContext)
        {
            _log = log;
            _mlContext = mLContext;
        }
        [HttpPost("Adicionar Transportadora")]
        public IActionResult AddTransportadora(TransportadoraDTO transportadoraDTO)
        {
            var transportadoraNova = new Transportadora(transportadoraDTO.Id, transportadoraDTO.Nome, transportadoraDTO.Telefone,
                                                        transportadoraDTO.Email);
            _mlContext.Transportadoras.Add(transportadoraNova);
            _mlContext.SaveChanges();
            return Ok(_mlContext.Transportadoras);
        }
        [HttpGet("Get Transportadora por id")]
        public IActionResult GetTransportadoraPeloId(int id)
        {
            var transportadoraDesejada = _mlContext.Transportadoras.AsNoTracking().First(x => x.Id == id);
            return Ok(transportadoraDesejada);
        }
        [HttpGet("Get Transportadoras")]
        public IActionResult GetTransportadoras()
        {
            var transportadoras = _mlContext.Transportadoras.Include(x => x.Pedidos).AsNoTracking().ToList();
            return Ok(transportadoras);
        }
        [HttpPut("Alterando nome da Transportadora desejada")]
        public IActionResult PutNomeDaTransportadoraDesejada(int id, string nomeNovo)
        {
            _mlContext.Transportadoras.Find(id).Nome = nomeNovo;
            _mlContext.SaveChanges();
            return Ok(_mlContext.Transportadoras);
        }
        [HttpDelete("Deletar Transportadora por id")]
        public IActionResult DeleteTransportadoraPeloId(int id)
        {
            var transportadoraASerRemovida = _mlContext.Transportadoras.Find(id);
            _mlContext.Transportadoras.Remove(transportadoraASerRemovida);
            _mlContext.SaveChanges();
            return Ok(_mlContext.Transportadoras);
        }
    }
}