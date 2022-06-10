using ProjetoML.Lib.Models;

namespace ProjetoML.Lib.Data.Repositorios.Interfaces
{
    public interface ITransportadoraRepositorio : IRepositorioBase<Transportadora>
    {
        public void AlterarNomeTransportadora(int id, string nomeNovo);
    }
}