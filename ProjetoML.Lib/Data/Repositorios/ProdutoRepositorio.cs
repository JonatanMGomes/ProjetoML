namespace ProjetoML.Lib.Data.Repositorios
{
    public class ProdutoRepositorio
    {
        private readonly MLContext _context;
        public ProdutoRepositorio(MLContext context)
        {
            _context = context;
        }
    }
}