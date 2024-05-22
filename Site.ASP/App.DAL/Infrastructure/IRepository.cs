namespace Site.DAL.Infrastructure
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entity);
        void Update(T entity);
        void Delete(Guid id);
        void RemoveEntity(T entity);
        T GetId(Guid id);

        void Save();
        List<T> GetAll();

    }
}
