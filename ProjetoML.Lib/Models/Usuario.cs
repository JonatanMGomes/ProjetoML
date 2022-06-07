namespace ProjetoML.Lib.Models
{
    public class Usuario : Pessoa
    {
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Senha { get; set; }
        public List<Pedido> Pedidos { get; set; }
        public Usuario(int id, string nome, string email, string cpf, DateTime dataNascimento, string senha) : base(id, nome, email)
        {
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Senha = senha;
        }
    }
}