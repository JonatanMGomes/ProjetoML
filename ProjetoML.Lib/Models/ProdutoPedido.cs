namespace ProjetoML.Lib.Models
{
    public class ProdutoPedido : ModelBase
    {
        public int IdProduto { get; set; }
        public int IdPedido { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual Pedido Pedido { get; set; }
        public ProdutoPedido(int id, int idProduto, int idPedido) : base(id)
        {
            IdProduto = idProduto;
            IdPedido = idPedido;
        }
    }
}