namespace ProjetoML.Lib.Models
{
    public class Pedido : ModelBase
    {
        public DateTime DataPedido { get; set; }
        public string Status { get; set; }
        public int IdTransportadora { get; set; }
        public int IdUsuario { get; set; }
        public virtual Transportadora Transportadora { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual List<ProdutoPedido> ProdutosPedidos { get; set; }
        public Pedido(int id, DateTime dataPedido, string status, int idTransportadora, int idUsuario) : base(id)
        {
            DataPedido = dataPedido;
            Status = status;
            IdTransportadora = idTransportadora;
            IdUsuario = idUsuario;
        }
    }
}