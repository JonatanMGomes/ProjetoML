namespace ProjetoML.Lib.Models
{
    public class Vendedor : Pessoa
    {
        public string CNPJ { get; set; }
        public DateTime DataCadastro { get; set; }
        public int IdProduto { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}