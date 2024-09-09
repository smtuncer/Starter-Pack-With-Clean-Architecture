using AutoMapper;
using MediatR;
using Project.Application.Models;
using Project.Domain.Dtos;
using Project.Domain.Interfaces;

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
        try
        {
            // Blog ekleme işlemi
            var blogDto = _mapper.Map<BlogDto>(request);
            await _blogService.AddAsync(blogDto);

            // Başarılı işlem sonucunda başarı mesajı döneriz
            return ResultModel<string>.Succeed("Blog başarıyla eklendi.");
        }
        catch (Exception ex)
        {
            // Hata durumunda failure mesajı ve durum kodu döneriz
            return ResultModel<string>.Failure(500, ex.Message);
        }
    }
}
