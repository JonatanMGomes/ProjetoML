namespace ProjetoML.Lib.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public string Status { get; set; }
        public int IdTransportadora { get; set; }
        public int IdUsuario { get; set; }
        public Transportadora Transportadora { get; set; }
        public Usuario Usuario { get; set; }
        public List<ProdutoPedido> ProdutosPedidos { get; set; }
    }
}