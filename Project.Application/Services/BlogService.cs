using AutoMapper;
using Project.Domain.Dtos;
using Project.Domain.Entities;
using Project.Domain.Interfaces;
using Project.Domain.Model;

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
    async Task<ResultModel<IEnumerable<BlogDto>>> IBlogService.GetAllAsync()
    {
        try
        {
            var entities = await _repository.GetAllAsync(); // Performans için AsNoTracking
            var dtos = _mapper.Map<IEnumerable<BlogDto>>(entities);
            return ResultModel<IEnumerable<BlogDto>>.Succeed(dtos);
        }
        catch (Exception ex)
        {
            return ResultModel<IEnumerable<BlogDto>>.Failure(500, ex.Message);
        }
    }
    async Task<ResultModel<BlogDto>> IBlogService.GetByIdAsync(string id)
    {
        try
        {
            var entity = await _repository.GetByIdAsync(id); // Performans için AsNoTracking

            if (entity is null)
            {
                return ResultModel<BlogDto>.Failure(404, "Blog bulunamadı.");
            }

            var dto = _mapper.Map<BlogDto>(entity);
            return ResultModel<BlogDto>.Succeed(dto);
        }
        catch (Exception ex)
        {
            return ResultModel<BlogDto>.Failure(500, ex.Message);
        }
    }
    async Task<ResultModel<string>> IBlogService.AddAsync(BlogDto dto)
    {
        try
        {
            var entity = _mapper.Map<Blog>(dto);
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return ResultModel<string>.Succeed("Blog eklendi");
        }
        catch (Exception ex)
        {
            return ResultModel<string>.Failure(500, ex.Message);
        }
    }

    async Task<ResultModel<string>> IBlogService.UpdateAsync(BlogDto dto)
    {
        try
        {
            var entity = await _repository.GetByIdAsync(dto.Id);

            if (entity is null)
            {
                return ResultModel<string>.Failure(404, "Blog bulunamadı.");
            }

            _mapper.Map(dto, entity);
            entity.UpdatedDate = DateTime.Now;

            await _repository.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();

            return ResultModel<string>.Succeed("Blog güncellendi");
        }
        catch (Exception ex)
        {
            return ResultModel<string>.Failure(500, ex.Message);
        }
    }
    async Task<ResultModel<string>> IBlogService.DeleteAsync(string id)
    {
        try
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity is null)
            {
                return ResultModel<string>.Failure(404, "Blog bulunamadı.");
            }

            await _repository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
            return ResultModel<string>.Succeed("Blog Silindi");
        }
        catch (Exception ex)
        {
            return ResultModel<string>.Failure(500, ex.Message);
        }
    }
}
