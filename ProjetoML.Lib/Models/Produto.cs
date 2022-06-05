namespace ProjetoML.Lib.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public int IdVendedor { get; set; }
        public Vendedor Vendedor { get; set; }
        public List<ProdutoPedido> ProdutosPedidos { get; set; }
    }
}