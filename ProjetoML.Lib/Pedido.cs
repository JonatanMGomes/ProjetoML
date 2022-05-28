namespace ProjetoML.Lib
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public string Status { get; set; }
        public int IdTransportadora { get; set; }
        public int IdUsuario { get; set; }
    }
}