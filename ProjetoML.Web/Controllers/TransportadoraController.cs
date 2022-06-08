using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoML.Lib.Data;
using ProjetoML.Lib.Data.Repositorios;
using ProjetoML.Lib.Models;
using ProjetoML.Web.DTOs;

namespace ProjetoML.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransportadoraController : ControllerBase
    {
        public ILogger<TransportadoraController> _log { get; set; }
        private readonly TransportadoraRepositorio _repositorio;
        public TransportadoraController(ILogger<TransportadoraController> log, TransportadoraRepositorio repositorio)
        {
            _log = log;
            _repositorio = repositorio;
        }
        [HttpPost("Adicionar Transportadora")]
        public IActionResult AddTransportadora(TransportadoraDTO transportadoraDTO)
        {
            var transportadoraNova = new Transportadora(transportadoraDTO.Id, transportadoraDTO.Nome, transportadoraDTO.Telefone,
                                                        transportadoraDTO.Email);
            _repositorio.Adicionar(transportadoraNova);
            return Ok();
        }
        [HttpGet("Get Transportadora por id")]
        public IActionResult GetTransportadoraPeloId(int id)
        {
            return Ok(_repositorio.BuscarPorId(id));
        }
        [HttpGet("Get Transportadoras")]
        public IActionResult GetTransportadoras()
        {
           return Ok(_repositorio.BuscarTodos());
        }
        [HttpPut("Alterando nome da Transportadora desejada")]
        public IActionResult PutNomeDaTransportadoraDesejada(int id, string nomeNovo)
        {
            _repositorio.AlterarNomeTransportadora(id, nomeNovo);
            return Ok();
        }
        [HttpDelete("Deletar Transportadora por id")]
        public IActionResult DeleteTransportadoraPeloId(int id)
        {
            _repositorio.DeletarItemDesejado(id);
            return Ok();
        }
    }
}