namespace ProjetoML.Lib.Models
{
    public class Transportadora : ModelBase
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public List<Pedido> Pedidos { get; set; }
        public Transportadora(int id, string nome, string telefone, string email) : base(id)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
        }
    }
}