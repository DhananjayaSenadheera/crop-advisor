using MediatR;
using UserRegisterService.Application.Helper;
using UserRegisterService.Application.Requests.User.DTOs;

namespace UserRegisterService.Application.Requests.User.Quaries.GetList;

public class UserGetAllQuery : IRequest<Result<List<UserGetDto>>>
{
    
}