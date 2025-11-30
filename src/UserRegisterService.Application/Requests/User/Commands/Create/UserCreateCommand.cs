using MediatR;
using UserRegisterService.Application.Helper;
using UserRegisterService.Application.Requests.User.DTOs;

namespace UserRegisterService.Application.Requests.User.Commands.Create;

public class UserCreateCommand : IRequest<Result<bool>>
{
    public UserCreateDto UserCreateDto { get; set; }
}