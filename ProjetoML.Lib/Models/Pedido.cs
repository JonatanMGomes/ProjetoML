namespace ProjetoML.Lib.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public string Status { get; set; }
        public int IdTransportadora { get; set; }
        public int IdUsuario { get; set; }
        public virtual Transportadora Transportadora { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual List<ProdutoPedido> ProdutosPedidos { get; set; }
        public Pedido(int id, DateTime dataPedido, string status, int idTransportadora, int idUsuario)
        {
            Id = id;
            DataPedido = dataPedido;
            Status = status;
            IdTransportadora = idTransportadora;
            IdUsuario = idUsuario;
        }
    }
}