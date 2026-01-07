using MediatR;
using UserRegisterService.Application.Helper;
using UserRegisterService.Application.Requests.User.DTOs;

namespace UserRegisterService.Application.Requests.User.Commands.Create;

public class UserCreateCommand : IRequest<Result<bool>>
{
    public UserCreateCommand(UserCreateDto userCreateDto)
    {
        UserCreateDto = userCreateDto ?? throw new ArgumentNullException(nameof(userCreateDto));
    }

    public UserCreateDto UserCreateDto { get; set; }
    
}