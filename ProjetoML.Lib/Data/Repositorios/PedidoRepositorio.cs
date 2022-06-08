using ProjetoML.Lib.Models;

namespace ProjetoML.Lib.Data.Repositorios
{
    public class PedidoRepositorio : RepositorioBase<Pedido>
    {
        public PedidoRepositorio(MLContext context) : base(context, context.Pedidos)
        {
        }
    }
}