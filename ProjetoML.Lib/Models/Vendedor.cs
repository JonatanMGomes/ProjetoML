namespace ProjetoML.Lib.Models
{
    public class Vendedor : Pessoa
    {
        public string Cnpj { get; set; }
        public DateTime DataCadastro { get; set; }
        public List<Produto> Produtos { get; set; }
        public Vendedor(int id, string nome, string email, string cnpj, DateTime dataCadastro) : base(id, nome, email)
        {
            Cnpj = cnpj;
            DataCadastro = dataCadastro;
        }
    }
}