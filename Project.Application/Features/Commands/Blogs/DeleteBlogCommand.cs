using MediatR;
using Project.Domain.Model;

namespace Project.Application.Features.Commands.Blogs;

public class DeleteBlogCommand : IRequest<ResultModel<string>>
{
    public string Id { get; set; }
}