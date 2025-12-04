using MediatR;
using UserRegisterService.Application.Helper;
using UserRegisterService.Application.Requests.User.DTOs;

namespace UserRegisterService.Application.Requests.User.Commands.Update;

public class UserUpdateCommand :IRequest<Result<bool>>
{
    public UserUpdateDto UserUpdateDto { get; set; }
}