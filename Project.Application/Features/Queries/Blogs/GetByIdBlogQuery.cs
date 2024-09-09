using MediatR;
using Project.Application.Models;
using Project.Domain.Dtos;

namespace Project.Application.Features.Queries.Blogs;

public class GetByIdBlogQuery : IRequest<ResultModel<BlogDto>>
{
    public string Id { get; set; }
}