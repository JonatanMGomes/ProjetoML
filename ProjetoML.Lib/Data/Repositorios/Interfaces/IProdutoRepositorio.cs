using ProjetoML.Lib.Models;

namespace ProjetoML.Lib.Data.Repositorios.Interfaces
{
    public interface IProdutoRepositorio : IRepositorioBase<Produto>
    {
        public void AlterarNomeProduto(int id, string nomeNovo);
    }
}