using MediatR;
using Project.Domain.Model;

namespace Project.Application.Features.Commands.Blogs;
public class UpdateBlogCommand : IRequest<ResultModel<string>>
{
    public required string Id { get; set; }
    public string BlogImageUrl { get; set; } = string.Empty;
    public required string Title { get; set; }
    public required string Content { get; set; }
    public bool CommentsEnabled { get; set; }
    public bool IsPublished { get; set; }
}