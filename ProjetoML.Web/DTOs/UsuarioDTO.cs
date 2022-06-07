namespace ProjetoML.Web.DTOs
{
    public class UsuarioDTO : PessoaDTO
    {
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Senha { get; set; }
    }
}