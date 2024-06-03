using FluentValidation;
using MyBlog.Application.ViewModels.AppUser;

namespace MyBlog.Application.Validators.AppUser
{
    public class CreateAppUserValidator : AbstractValidator<VmCreateAppUser>
    {
        public CreateAppUserValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Ad Soyad boş geçilemez")
                .MinimumLength(6)
                .MaximumLength(50)
                    .WithMessage("Ad Soyad en az 6, en fazla 50 karakter olabilir");

            RuleFor(p => p.Email)
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                    .WithMessage("E-Posta adresini doğru formatta giriniz");

            RuleFor(p => p.Password)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Şifre boş geçilemez")
                .MinimumLength(6)
                .MaximumLength(50)
                    .WithMessage("Şifre en az 6, en fazla 50 karakter olabilir")
                .Equal(p => p.PasswordConfirmation)
                    .WithMessage("Şifreler uyuşmuyor");
        }
    }
}
