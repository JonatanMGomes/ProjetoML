using Microsoft.AspNetCore.Mvc;
using ProjetoML.Lib.Data;
using ProjetoML.Lib.Models;

namespace ProjetoML.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        public ILogger<UsuarioController> _log { get; set; }
        private readonly MLContext _mlContext;
        public UsuarioController(ILogger<UsuarioController> log, MLContext mLContext)
        {
            _log = log;
            _mlContext = mLContext;
        }
        [HttpPost("Adicionar Usuario")]
        public IActionResult AddUsuario(Usuario usuarioNovo)
        {
            _mlContext.Usuarios.Add(usuarioNovo);
            _mlContext.SaveChanges();
            return Ok(_mlContext.Usuarios);
        }
        [HttpGet("Get Usuario por id")]
        public IActionResult GetUsuarioPeloId(int id)
        {
            var usuarioDesejado = _mlContext.Usuarios.Find(id);
            return Ok(usuarioDesejado);
        }
        [HttpGet("Get Usuarios")]
        public IActionResult GetUsuarios()
        {
            var usuarios = _mlContext.Usuarios.ToList();
            return Ok(usuarios);
        }
        [HttpPut("Alterando senha do Usuario desejado")]
        public IActionResult PutSenhaDoUsuarioDesejado(int id, string senhaNova)
        {
            _mlContext.Usuarios.Find(id).Senha = senhaNova;
            _mlContext.SaveChanges();
            return Ok(_mlContext.Usuarios);
        }
        [HttpDelete("Deletar Usuario por id")]
        public IActionResult DeleteUsuarioPeloId(int id)
        {
            var usuarioASerRemovido = _mlContext.Usuarios.Find(id);
            _mlContext.Usuarios.Remove(usuarioASerRemovido);
            _mlContext.SaveChanges();
            return Ok(_mlContext.Usuarios);
        }
    }
}