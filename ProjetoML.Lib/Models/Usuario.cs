namespace ProjetoML.Lib.Models
{
    public class Usuario : Pessoa
    {
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Senha { get; set; }
        public int IdPedido { get; set; }
        public List<Pedido> Pedidos { get; set; }
    }
}