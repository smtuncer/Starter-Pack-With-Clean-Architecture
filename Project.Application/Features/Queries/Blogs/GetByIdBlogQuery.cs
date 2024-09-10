using MediatR;
using Project.Domain.Dtos;
using Project.Domain.Model;

namespace Project.Application.Features.Queries.Blogs;

public class GetByIdBlogQuery : IRequest<ResultModel<BlogDto>>
{
    public string Id { get; set; }
}