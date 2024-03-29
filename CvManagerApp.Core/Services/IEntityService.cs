namespace CvManagerApp.Core.Services;

public interface IEntityService<T> where T : class
{
    Task Create(T entity);
    Task<ICollection<T>> GetAll();
    Task<T?> GetById(int id);
    Task Update(T entity);
    Task Delete(int id);
}