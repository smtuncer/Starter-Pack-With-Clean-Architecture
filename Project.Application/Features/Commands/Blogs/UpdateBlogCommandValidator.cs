using FluentValidation;

namespace Project.Application.Features.Commands.Blogs;
public class UpdateBlogCommandValidator : AbstractValidator<UpdateBlogCommand>
{
    public UpdateBlogCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id boş olamaz.");
        RuleFor(x => x.Title).NotEmpty().WithMessage("Blog başlığı boş olamaz.");
        RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik boş olamaz.");
    }
}