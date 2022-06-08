using ProjetoML.Lib.Models;

namespace ProjetoML.Lib.Data.Repositorios
{
    public class ProdutoPedidoRepositorio : RepositorioBase<ProdutoPedido>
    {
        public ProdutoPedidoRepositorio(MLContext context) : base(context, context.ProdutosPedidos)
        {
        }
        public void AlterarProdutoEmProdutoPedido(int id, Produto produtoNovo)
        {
            _dbSet.Find(id).Produto = produtoNovo;
        }
    }
}