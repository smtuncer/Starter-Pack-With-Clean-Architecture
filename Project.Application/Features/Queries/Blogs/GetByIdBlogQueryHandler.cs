using MediatR;
using Project.Domain.Dtos;
using Project.Domain.Interfaces;
using Project.Domain.Model;

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
        return await _blogService.GetByIdAsync(request.Id);
    }
}
