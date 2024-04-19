using Microsoft.EntityFrameworkCore;
using tsk.Domain.Interfaces;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbContext _context;

    public Repository(DbContext context)
    {
        _context = context;
    }

    public async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity == null)
            throw new ArgumentException("Entity not found");

        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetAsync(Guid id)
    {
        return await _context.Set<T>().FindAsync(id) ?? throw new ArgumentException("Enriry not found");
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}