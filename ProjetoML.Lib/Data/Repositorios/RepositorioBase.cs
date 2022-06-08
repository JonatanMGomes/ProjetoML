using Microsoft.EntityFrameworkCore;
using ProjetoML.Lib.Models;

namespace ProjetoML.Lib.Data.Repositorios
{
    public class RepositorioBase<T> where T : ModelBase
    {
        private readonly MLContext _context;
        private readonly DbSet<T> _dbSet;
        public RepositorioBase(MLContext context, DbSet<T> dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }
        public void Adicionar(T item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }
        public T BuscarPorId(int id){
            return _dbSet.AsNoTracking().First(x => x.Id == id);
        }
        public List<T> BuscarTodos(){
            return _dbSet.AsNoTracking().ToList();
        }
        /*
        public void AlterarCampoDoItemDesejado(int id, string texto){
            _dbSet.Find(id). = statusNovo;
            _context.SaveChanges();
        }
        */
        public void DeletarItemDesejado(int id){
            var itemARemover = _dbSet.Find(id);
            _dbSet.Remove(itemARemover);
            _context.SaveChanges();
        }
    }
}