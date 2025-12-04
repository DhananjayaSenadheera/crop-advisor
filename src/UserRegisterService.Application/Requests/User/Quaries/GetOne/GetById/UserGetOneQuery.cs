using MediatR;
using UserRegisterService.Application.Helper;
using UserRegisterService.Application.Requests.User.DTOs;

namespace UserRegisterService.Application.Requests.User.Quaries.GetOne.GetById;

public class UserGetOneQuery: IRequest<Result<UserGetDto>>
{
    public UserGetOneQuery(Guid id)
    {
        this.id = id;
    }

    public Guid id { get; set; }
}