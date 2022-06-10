using ProjetoML.Lib.Models;

namespace ProjetoML.Lib.Data.Repositorios.Interfaces
{
    public interface IVendedorRepositorio : IRepositorioBase<Vendedor>
    {
        public void AlterarCnpjVendedor(int id, string cnpjNovo);
    }
}