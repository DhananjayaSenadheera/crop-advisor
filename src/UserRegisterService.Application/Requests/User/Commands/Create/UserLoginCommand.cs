using MediatR;
using UserRegisterService.Application.Helper;
using UserRegisterService.Application.Requests.User.DTOs;

namespace UserRegisterService.Application.Requests.User.Commands.Create;

public class UserLoginCommand : IRequest<Result<bool>>
{
    public UserLoginCommand(UserLoginDto userLoginDto)
    {
        UserLoginDto = userLoginDto ?? throw new ArgumentNullException(nameof(userLoginDto));
    }

    public UserLoginDto UserLoginDto { get; set; }
}