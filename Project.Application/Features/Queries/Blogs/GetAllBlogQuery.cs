using MediatR;
using Project.Domain.Dtos;
using Project.Domain.Model;

namespace Project.Application.Features.Queries.Blogs;
public class GetAllBlogQuery : IRequest<ResultModel<IEnumerable<BlogDto>>>
{
}