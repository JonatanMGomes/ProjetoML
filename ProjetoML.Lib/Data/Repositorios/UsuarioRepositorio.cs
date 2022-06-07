namespace ProjetoML.Lib.Data.Repositorios
{
    public class UsuarioRepositorio
    {
        private readonly MLContext _context;
        public UsuarioRepositorio(MLContext context)
        {
            _context = context;
        }
    }
}