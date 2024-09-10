using AutoMapper;
using MediatR;
using Project.Domain.Dtos;
using Project.Domain.Interfaces;
using Project.Domain.Model;

namespace Project.Application.Features.Commands.Blogs;

public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, ResultModel<string>>
{
    private readonly IBlogService _blogService;
    private readonly IMapper _mapper;

    public CreateBlogCommandHandler(IBlogService blogService, IMapper mapper)
    {
        _blogService = blogService;
        _mapper = mapper;
    }
    public async Task<ResultModel<string>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var blogDto = _mapper.Map<BlogDto>(request);
        return await _blogService.AddAsync(blogDto);
    }
}
