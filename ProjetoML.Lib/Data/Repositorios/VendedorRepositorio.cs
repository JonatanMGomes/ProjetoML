using ProjetoML.Lib.Models;

namespace ProjetoML.Lib.Data.Repositorios
{
    public class VendedorRepositorio : RepositorioBase<Vendedor>
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