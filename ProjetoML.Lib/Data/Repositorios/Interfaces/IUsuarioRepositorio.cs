using ProjetoML.Lib.Models;

namespace ProjetoML.Lib.Data.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {
        public void AlterarSenhaUsuario(int id, string senhaNova);
    }
}