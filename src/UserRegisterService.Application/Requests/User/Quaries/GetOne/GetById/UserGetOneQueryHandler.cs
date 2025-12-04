using AutoMapper;
using MediatR;
using UserRegisterService.Application.Helper;
using UserRegisterService.Application.Requests.User.DTOs;
using UserRegisterService.Domain.Interfaces;

namespace UserRegisterService.Application.Requests.User.Quaries.GetOne.GetById;

public class UserGetOneQueryHandler: IRequestHandler<UserGetOneQuery, Result<UserGetDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    
    public async Task<Result<UserGetDto>> Handle(UserGetOneQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var user = _userRepository.GetByIdAsync(request.id);
            return  Result<UserGetDto>.Success(_mapper.Map<UserGetDto>(user));
 
        }
        catch (Exception e)
        {
            return Result<UserGetDto>.Failure("Failed to get user");
        }
    }
}