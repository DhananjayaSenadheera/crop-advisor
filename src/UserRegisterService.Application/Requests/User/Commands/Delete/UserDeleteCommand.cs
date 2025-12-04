using MediatR;
using UserRegisterService.Application.Helper;
using UserRegisterService.Application.Requests.User.DTOs;

namespace UserRegisterService.Application.Requests.User.Commands.Delete;

public class UserDeleteCommand : IRequest<Result<bool>>
{
    public UserDeleteDto UserDeleteDto { get; set; }
}