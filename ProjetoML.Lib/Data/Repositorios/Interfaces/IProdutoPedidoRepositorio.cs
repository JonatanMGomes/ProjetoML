using ProjetoML.Lib.Models;

namespace ProjetoML.Lib.Data.Repositorios.Interfaces
{
    public interface IProdutoPedidoRepositorio : IRepositorioBase<ProdutoPedido>
    {
        public void AlterarProdutoEmProdutoPedido(int id, Produto produtoNovo);
    }
}