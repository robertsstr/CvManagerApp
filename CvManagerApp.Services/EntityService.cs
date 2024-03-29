using CvManagerApp.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace CvManagerApp.Services;

public class EntityService<T> : IEntityService<T> where T : class
{
    protected readonly DbContext _context;

    public EntityService(DbContext context)
    {
        _context = context;
    }

    public async Task Create(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetById(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task Update(T entity)
    {
        _context.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var entity = await GetById(id);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}