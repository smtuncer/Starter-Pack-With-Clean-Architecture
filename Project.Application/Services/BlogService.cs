using AutoMapper;
using Project.Domain.Dtos;
using Project.Domain.Entities;
using Project.Domain.Interfaces;

namespace Project.Application.Services;
public class BlogService : IBlogService
{
    private readonly IRepository<Blog> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BlogService(IRepository<Blog> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task AddAsync(BlogDto dto)
    {
        var entity = _mapper.Map<Blog>(dto);
        await _repository.AddAsync(entity);
        await _unitOfWork.CommitAsync();
    }
    public async Task<IEnumerable<BlogDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<BlogDto>>(entities);
    }

    public Task DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<BlogDto> GetByIdAsync(string id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<BlogDto>(entity);
    }

    public Task UpdateAsync(BlogDto dto)
    {
        throw new NotImplementedException();
    }
}