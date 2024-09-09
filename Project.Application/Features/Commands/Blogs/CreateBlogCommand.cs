using MediatR;
using Project.Application.Models;

namespace Project.Application.Features.Commands.Blogs;
public class CreateBlogCommand : IRequest<ResultModel<string>>
{
    public string BlogImageUrl { get; set; } = string.Empty;
    public required string Title { get; set; }
    public required string Content { get; set; }
    public bool CommentsEnabled { get; set; }
    public bool IsPublished { get; set; }
}