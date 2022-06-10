using ProjetoML.Lib.Data.Repositorios.Interfaces;
using ProjetoML.Lib.Models;

namespace ProjetoML.Lib.Data.Repositorios
{
    public class PedidoRepositorio : RepositorioBase<Pedido>, IPedidoRepositorio
    {
        public PedidoRepositorio(MLContext context) : base(context, context.Pedidos)
        {
        }
        public void AlterarStatusPedido(int id, string statusNovo)
        {
            _dbSet.Find(id).Status = statusNovo;
        }
    }
}