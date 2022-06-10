namespace ProjetoML.Lib.Data.Repositorios.Interfaces
{
    public interface IRepositorioBase<T>
    {
        public void Adicionar(T item);
        public T BuscarPorId(int id);
        public List<T> BuscarTodos();
        public void DeletarItemDesejado(int id);
    }
}