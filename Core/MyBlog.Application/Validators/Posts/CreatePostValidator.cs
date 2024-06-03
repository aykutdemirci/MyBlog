using FluentValidation;
using MyBlog.Application.ViewModels.Posts;

namespace MyBlog.Application.Validators.Posts
{
    public sealed class CreatePostValidator : AbstractValidator<VmCreatePost>
    {
        public CreatePostValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Başlık boş geçilemez")
                .MaximumLength(50)
                .MinimumLength(3)
                    .WithMessage("Başlık en az 3, en fazla 50 karakter olabilir");

            RuleFor(p => p.Content)
                .NotEmpty()
                .NotNull()
                    .WithMessage("İçerik boş geçilemez")
                .MaximumLength(2500)
                .MinimumLength(120)
                    .WithMessage("İçerik en az 120, en fazla 2500 karakter olabilir");
        }
    }
}
