using ProjetoML.Lib.Models;

namespace ProjetoML.Lib.Data.Repositorios
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>
    {
        public UsuarioRepositorio(MLContext context) : base(context, context.Usuarios)
        {
        }
        public void AlterarSenhaUsuario(int id, string senhaNova)
        {
            _dbSet.Find(id).Senha = senhaNova;
        }
    }
}