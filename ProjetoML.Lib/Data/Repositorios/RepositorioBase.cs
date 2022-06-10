using Microsoft.EntityFrameworkCore;
using ProjetoML.Lib.Data.Repositorios.Interfaces;
using ProjetoML.Lib.Models;

namespace ProjetoML.Lib.Data.Repositorios
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : ModelBase
    {
        protected readonly MLContext _context;
        protected readonly DbSet<T> _dbSet;
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
        public T BuscarPorId(int id)
        {
            return _dbSet.AsNoTracking().First(x => x.Id == id);
        }
        public List<T> BuscarTodos()
        {
            return _dbSet.AsNoTracking().ToList();
        }
        public void DeletarItemDesejado(int id)
        {
            var itemARemover = _dbSet.Find(id);
            _dbSet.Remove(itemARemover);
            _context.SaveChanges();
        }
    }
}