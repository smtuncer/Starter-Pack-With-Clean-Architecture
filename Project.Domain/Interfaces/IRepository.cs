namespace Project.Domain.Interfaces;

public interface IRepository<TEntity>
{
    Task<TEntity> GetByIdAsync(string id);
    Task<IQueryable<TEntity>> GetAllAsync();
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(string id);

}