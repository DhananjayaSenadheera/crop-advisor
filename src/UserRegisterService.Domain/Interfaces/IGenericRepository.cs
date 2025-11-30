namespace UserRegisterService.Domain.Interfaces;

public interface IGenericRepository<T> where T : class 
{
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
}