using MediatR;
using Project.Application.Features.Queries.Blogs;
using Project.Application.Models;
using Project.Domain.Dtos;
using Project.Domain.Interfaces;

public class GetAllBlogQueryHandler : IRequestHandler<GetAllBlogQuery, ResultModel<IEnumerable<BlogDto>>>
{
    private readonly IBlogService _blogService;

    public GetAllBlogQueryHandler(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public async Task<ResultModel<IEnumerable<BlogDto>>> Handle(GetAllBlogQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var blogs = await _blogService.GetAllAsync();

            return ResultModel<IEnumerable<BlogDto>>.Succeed(blogs);
        }
        catch (Exception ex)
        {
            // Hata durumunda Failure metodu ile hata mesajını dön
            return ResultModel<IEnumerable<BlogDto>>.Failure(500, ex.Message);
        }
    }
}
