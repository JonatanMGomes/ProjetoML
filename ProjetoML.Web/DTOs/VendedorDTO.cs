namespace ProjetoML.Web.DTOs
{
    public class VendedorDTO : PessoaDTO
    {
        public string CNPJ { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}