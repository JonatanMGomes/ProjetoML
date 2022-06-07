namespace ProjetoML.Lib.Models
{
    public class ProdutoPedido
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public int IdPedido { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual Pedido Pedido { get; set; }
        public ProdutoPedido(int id, int idProduto, int idPedido)
        {
            Id = id;
            IdProduto = idProduto;
            IdPedido = idPedido;
        }
    }
}