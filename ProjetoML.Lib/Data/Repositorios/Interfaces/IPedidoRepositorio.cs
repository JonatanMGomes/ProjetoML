using ProjetoML.Lib.Models;

namespace ProjetoML.Lib.Data.Repositorios.Interfaces
{
    public interface IPedidoRepositorio : IRepositorioBase<Pedido>
    {
        public void AlterarStatusPedido(int id, string statusNovo);
    }
}