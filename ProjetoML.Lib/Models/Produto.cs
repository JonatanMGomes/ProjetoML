namespace ProjetoML.Lib.Models
{
    public class Produto : ModelBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public int IdVendedor { get; set; }
        public virtual Vendedor Vendedor { get; set; }
        public virtual List<ProdutoPedido> ProdutosPedidos { get; set; }
        public Produto(int id, string nome, string descricao, double valor, DateTime dataCadastro, int idVendedor) : base(id)
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            DataCadastro = dataCadastro;
            IdVendedor =idVendedor;
        }
    }
}