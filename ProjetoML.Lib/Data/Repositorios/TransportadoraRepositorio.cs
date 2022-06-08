using ProjetoML.Lib.Models;

namespace ProjetoML.Lib.Data.Repositorios
{
    public class TransportadoraRepositorio : RepositorioBase<Transportadora>
    {
        public TransportadoraRepositorio(MLContext context) : base(context, context.Transportadoras)
        {
        }
        public void AlterarNomeTransportadora(int id, string nomeNovo)
        {
            _dbSet.Find(id).Nome = nomeNovo;
        }
    }
}