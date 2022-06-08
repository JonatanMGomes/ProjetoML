using ProjetoML.Lib.Models;

namespace ProjetoML.Lib.Data.Repositorios
{
    public class ProdutoRepositorio : RepositorioBase<Produto>
    {
        public ProdutoRepositorio(MLContext context) : base(context, context.Produtos)
        {
        }
        public void AlterarNomeProduto(int id, string nomeNovo)
        {
            _dbSet.Find(id).Nome = nomeNovo;
        }
    }
}