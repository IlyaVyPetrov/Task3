namespace Task3.Core
{
    public interface IRepository<T>
    {
        void Create(T item);

        T? Read(int id);

        List<T> ReadAll();

        void Update(T item);

        void Delete(int id);
    }
}
