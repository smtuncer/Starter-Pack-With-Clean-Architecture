using AutoMapper;
using MediatR;
using Project.Domain.Dtos;
using Project.Domain.Interfaces;
using Project.Domain.Model;

namespace Project.Application.Features.Commands.Blogs;

public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, ResultModel<string>>
{
    private readonly IBlogService _blogService;
    private readonly IMapper _mapper;

    public UpdateBlogCommandHandler(IBlogService blogService, IMapper mapper)
    {
        _blogService = blogService;
        _mapper = mapper;
    }
    public async Task<ResultModel<string>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        var blogDto = _mapper.Map<BlogDto>(request);
        return await _blogService.UpdateAsync(blogDto);
    }
}
