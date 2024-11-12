using FluentValidation;
using MamyApp.Application.Dtos;
using MamyApp.Application.DTOs;

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator()
    {
        // Username boş olamaz, ve 3 ile 50 karakter arasında olmalı.
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required.")
            .Length(3, 50).WithMessage("Username must be between 3 and 50 characters.");

        // PasswordHash boş olamaz.
        RuleFor(x => x.PasswordHash)
            .NotEmpty().WithMessage("Password is required.");

        // Email boş olamaz ve geçerli bir e-posta formatında olmalı.
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");
    }
}
