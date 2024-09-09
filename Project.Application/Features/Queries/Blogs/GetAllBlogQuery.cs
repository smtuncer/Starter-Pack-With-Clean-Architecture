using MediatR;
using Project.Application.Models;
using Project.Domain.Dtos;

namespace Project.Application.Features.Queries.Blogs;
public class GetAllBlogQuery : IRequest<ResultModel<IEnumerable<BlogDto>>>
{
}