using AutoMapper;
using Project.Application.Features.Commands.Blogs;
using Project.Domain.Dtos;
using Project.Domain.Entities;

namespace Project.Application.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateBlogCommand, BlogDto>();
        CreateMap<BlogDto, Blog>().ReverseMap();


    }
}