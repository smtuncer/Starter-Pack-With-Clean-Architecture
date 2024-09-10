using Microsoft.EntityFrameworkCore;
using Project.Domain.Interfaces;
using Project.Infrastracture.Data.Context;

namespace Infrastructure.Repositories;

public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    protected readonly ApplicationDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    // Get By Id Async
    public async Task<TEntity> GetByIdAsync(string id)
    {
        return await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
    }

    // Get All - IQueryable döndürüyoruz
    public Task<IQueryable<TEntity>> GetAllAsync()
    {
        return Task.FromResult(_dbSet.AsQueryable());
    }

    // Add Async
    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    // Update Async
    public async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    // Delete Async
    public async Task DeleteAsync(string id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
        }
    }

}
