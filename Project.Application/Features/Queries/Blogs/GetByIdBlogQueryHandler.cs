using MediatR;
using Project.Application.Models;
using Project.Domain.Dtos;
using Project.Domain.Interfaces;

namespace Project.Application.Features.Queries.Blogs;

public class GetByIdBlogQueryHandler : IRequestHandler<GetByIdBlogQuery, ResultModel<BlogDto>>
{
    private readonly IBlogService _blogService;

    public GetByIdBlogQueryHandler(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public async Task<ResultModel<BlogDto>> Handle(GetByIdBlogQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var blog = await _blogService.GetByIdAsync(request.Id);

            if (blog == null)
            {
                return ResultModel<BlogDto>.Failure(404, "Blog bulunamadı.");
            }

            return ResultModel<BlogDto>.Succeed(blog);
        }
        catch (Exception ex)
        {
            return ResultModel<BlogDto>.Failure(500, ex.Message);
        }
    }
}
