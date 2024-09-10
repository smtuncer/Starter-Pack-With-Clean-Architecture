using MediatR;
using Project.Domain.Interfaces;
using Project.Domain.Model;

namespace Project.Application.Features.Commands.Blogs;

public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, ResultModel<string>>
{
    private readonly IBlogService _blogService;

    public DeleteBlogCommandHandler(IBlogService blogService)
    {
        _blogService = blogService;
    }
    public async Task<ResultModel<string>> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
    {
        return await _blogService.DeleteAsync(request.Id);
    }
}
