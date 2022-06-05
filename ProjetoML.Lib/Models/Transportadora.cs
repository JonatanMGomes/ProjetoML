namespace ProjetoML.Lib.Models
{
    public class Transportadora
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public List<Pedido> Pedidos { get; set; }
    }
}