namespace ProjetoML.Lib.Data.Repositorios
{
    public class TransportadoraRepositorio
    {
        private readonly MLContext _context;
        public TransportadoraRepositorio(MLContext context)
        {
            _context = context;
        }
    }
}