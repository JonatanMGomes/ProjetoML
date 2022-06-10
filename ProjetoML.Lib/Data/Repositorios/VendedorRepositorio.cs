using ProjetoML.Lib.Data.Repositorios.Interfaces;
using ProjetoML.Lib.Models;

namespace ProjetoML.Lib.Data.Repositorios
{
    public class VendedorRepositorio : RepositorioBase<Vendedor>, IVendedorRepositorio
    {
        public VendedorRepositorio(MLContext context) : base(context, context.Vendedores)
        {
        }
        public void AlterarCnpjVendedor(int id, string cnpjNovo)
        {
            _dbSet.Find(id).Cnpj = cnpjNovo;
        }
    }
}