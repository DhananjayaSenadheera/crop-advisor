using AutoMapper;
using MediatR;
using UserRegisterService.Application.Helper;
using UserRegisterService.Application.Requests.User.Services;
using UserRegisterService.Domain.Interfaces;

namespace UserRegisterService.Application.Requests.User.Commands.Create;

public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, Result<bool>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public UserLoginCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }
    public async Task<Result<bool>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        var username = request.UserLoginDto?.Username?.Trim();
        var password = request.UserLoginDto?.Password?.Trim();
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            return Result<bool>.Failure("Invalid username or password");
        }
        
        var user = await _userRepository.GetByUserNameAsync(username);
        if (user is null)
        {
            return Result<bool>.Failure("Invalid username or password");
        }
        var ok = _passwordHasher.VerifyHashedPassword(user.Password, password);
        if(!ok)
            return Result<bool>.Failure("Invalid username or password");
        return Result<bool>.Success(ok);
    }
}