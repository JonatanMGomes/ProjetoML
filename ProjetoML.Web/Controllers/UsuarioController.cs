using Microsoft.AspNetCore.Mvc;
using ProjetoML.Lib.Data.Repositorios.Interfaces;
using ProjetoML.Lib.Models;
using ProjetoML.Web.DTOs;

namespace ProjetoML.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        public ILogger<UsuarioController> _log { get; set; }
        private readonly IUsuarioRepositorio _repositorio;
        public UsuarioController(ILogger<UsuarioController> log, IUsuarioRepositorio repositorio)
        {
            _log = log;
            _repositorio = repositorio;
        }
        [HttpPost("Adicionar Usuario")]
        public IActionResult AddUsuario(UsuarioDTO usuarioDTO)
        {
            var usuarioNovo = new Usuario(usuarioDTO.Id, usuarioDTO.Nome, usuarioDTO.Email, usuarioDTO.CPF, usuarioDTO.DataNascimento,
                                          usuarioDTO.Senha);
            _repositorio.Adicionar(usuarioNovo);
            return Ok();
        }
        [HttpGet("Get Usuario por id")]
        public IActionResult GetUsuarioPeloId(int id)
        {
            return Ok(_repositorio.BuscarPorId(id));
        }
        [HttpGet("Get Usuarios")]
        public IActionResult GetUsuarios()
        {
            return Ok(_repositorio.BuscarTodos());
        }
        [HttpPut("Alterando senha do Usuario desejado")]
        public IActionResult PutSenhaDoUsuarioDesejado(int id, string senhaNova)
        {
            _repositorio.AlterarSenhaUsuario(id, senhaNova);
            return Ok();
        }
        [HttpDelete("Deletar Usuario por id")]
        public IActionResult DeleteUsuarioPeloId(int id)
        {
           _repositorio.DeletarItemDesejado(id);
            return Ok();
        }
    }
}