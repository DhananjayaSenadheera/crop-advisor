using FluentValidation;
using UserRegisterService.Application.Requests.User.Commands.Create;

namespace UserRegisterService.Application.Requests.User.Validators;

public class UserLoginValidator : AbstractValidator<UserLoginCommand>
{
    public UserLoginValidator()
    {
        RuleFor(x => x.UserLoginDto)
            .NotNull().WithMessage("Login Data is required");

        When(x => x.UserLoginDto != null, () =>
        {
            RuleFor(x => x.UserLoginDto.Username)
                .NotEmpty().WithMessage("Username cannot be empty")
                .MaximumLength(15).WithMessage("Username cannot exceed 15 characters");

            RuleFor(x => x.UserLoginDto.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters");
        });
    }
}