namespace Infrastructure.Interfaces
{
    public interface ICommonRepository<T> where T : class
    {
        Task<IList<T>> GetAll();
        Task<T> Get(int key);
        Task UseAsync(T entity);
    }
}
