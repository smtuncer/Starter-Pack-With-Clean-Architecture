using Project.Domain.Dtos;

namespace Project.Domain.Interfaces;
public interface IBlogService
{
    Task<BlogDto> GetByIdAsync(string id);
    Task<IEnumerable<BlogDto>> GetAllAsync();
    Task AddAsync(BlogDto dto);
    Task UpdateAsync(BlogDto dto);
    Task DeleteAsync(string id);
}
