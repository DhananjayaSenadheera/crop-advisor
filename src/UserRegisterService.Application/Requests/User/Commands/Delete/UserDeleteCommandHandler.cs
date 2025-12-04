using AutoMapper;
using MediatR;
using UserRegisterService.Application.Helper;
using UserRegisterService.Domain.Interfaces;

namespace UserRegisterService.Application.Requests.User.Commands.Delete;

public class UserDeleteCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
    : IRequestHandler<UserDeleteCommand, Result<bool>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<Result<bool>> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var exsitingUser = await _userRepository.GetByIdAsync(request.UserDeleteDto.Id);
            if (exsitingUser == null)
            {
               return Result<bool>.Failure("User not found");
            }
            await _userRepository.DeleteAsync(exsitingUser);
            await _unitOfWork.CommitAsync();
            return Result<bool>.Success(true);
        }
        catch (Exception e)
        {
            return Result<bool>.Failure(e.Message);
        }
    }
}