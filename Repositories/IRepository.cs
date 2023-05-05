namespace DnDInventoryApp.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T item);
        void Update(T entity);
        void Delete(int id);

    }
}
