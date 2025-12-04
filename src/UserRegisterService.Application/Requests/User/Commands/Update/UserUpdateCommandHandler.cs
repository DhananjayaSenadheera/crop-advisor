using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using UserRegisterService.Application.Helper;
using UserRegisterService.Domain.Interfaces;

namespace UserRegisterService.Application.Requests.User.Commands.Update;

public class UserUpdateCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper,
    ILogger<UserUpdateCommandHandler> logger,
    IUserRepository userRepository)
    : IRequestHandler<UserUpdateCommand, Result<bool>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<UserUpdateCommandHandler> _logger = logger;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<Result<bool>> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existingUser = _userRepository.GetByIdAsync(request.UserUpdateDto.Id).Result;
            if (existingUser == null)
            {
                return Result<bool>.Failure("User does not exist");
            }
            var user = _mapper.Map(request.UserUpdateDto, existingUser);
            await _userRepository.UpdateAsync(user);
            await _unitOfWork.CommitAsync();
            return Result<bool>.Success(true);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return Result<bool>.Failure("Failed to update user");
        }
    }
}