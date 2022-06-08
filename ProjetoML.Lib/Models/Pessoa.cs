namespace ProjetoML.Lib.Models
{
    public class Pessoa : ModelBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public Pessoa(int id, string nome, string email) : base(id)
        {
            Nome = nome;
            Email = email;
        }
    }
}