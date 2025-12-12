using FluentValidation;
using UserRegisterService.Application.Requests.User.Commands.Create;

namespace UserRegisterService.Application.Requests.User.Validators;

public class UserCreateValidator : AbstractValidator<UserCreateCommand> 
{
    public UserCreateValidator()
    {
        RuleFor(x => x.UserCreateDto.FirstName)
            .NotEmpty().WithMessage("First name cannot be empty")
            .NotNull().WithMessage("First name cannot be null")
            .MaximumLength(15).WithMessage("First name cannot exceed 15 characters");
        
        RuleFor(x => x.UserCreateDto.LastName)
            .NotEmpty().WithMessage("Last name cannot be empty")
            .MaximumLength(15).WithMessage("Last name cannot exceed 15 characters");
        
        RuleFor(x => x.UserCreateDto.UserName)
            .NotEmpty().WithMessage("Username cannot be empty")
            .MaximumLength(10).WithMessage("Username cannot exceed 15 characters");
        
        RuleFor(x => x.UserCreateDto.PhoneNumber)
            .NotEmpty().WithMessage("PhoneNumber cannot be empty")
            .MaximumLength(15).WithMessage("PhoneNumber cannot exceed 15 characters");
        
        RuleFor(x => x.UserCreateDto.Password)
            .NotEmpty().WithMessage("Password cannot be empty")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters");
        
        RuleFor(x => x.UserCreateDto.Email)
            .EmailAddress().WithMessage("Invalid email address");
    }
}