namespace PracticaMaui.Service
{
    public interface IRepositoryService<T>
    {
        
        Task <T> GetById(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<List<T>> GetAllAsync();
    }
}
