using Project.Domain.Dtos;
using Project.Domain.Model;

namespace Project.Domain.Interfaces;
public interface IBlogService
{
    Task<ResultModel<BlogDto>> GetByIdAsync(string id);
    Task<ResultModel<IEnumerable<BlogDto>>> GetAllAsync();
    Task<ResultModel<string>> AddAsync(BlogDto dto);
    Task<ResultModel<string>> UpdateAsync(BlogDto dto);
    Task<ResultModel<string>> DeleteAsync(string id);
}
