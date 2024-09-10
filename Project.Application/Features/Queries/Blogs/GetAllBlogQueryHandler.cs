using MediatR;
using Project.Application.Features.Queries.Blogs;
using Project.Domain.Dtos;
using Project.Domain.Interfaces;
using Project.Domain.Model;

public class GetAllBlogQueryHandler : IRequestHandler<GetAllBlogQuery, ResultModel<IEnumerable<BlogDto>>>
{
    private readonly IBlogService _blogService;

    public GetAllBlogQueryHandler(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public async Task<ResultModel<IEnumerable<BlogDto>>> Handle(GetAllBlogQuery request, CancellationToken cancellationToken)
    {
        return await _blogService.GetAllAsync();
    }
}
