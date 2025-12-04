using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using UserRegisterService.Application.Helper;
using UserRegisterService.Domain.Interfaces;

namespace UserRegisterService.Application.Requests.User.Commands.Create;

public class UserCreateCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper,
    ILogger<UserCreateCommandHandler> logger,
    IUserRepository userRepository)
    : IRequestHandler<UserCreateCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(UserCreateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = mapper.Map<Domain.Entities.User>(request.UserCreateDto);
            user.Id = Guid.NewGuid();
            await userRepository.AddAsync(user);
            await unitOfWork.CommitAsync();
            return Result<bool>.Success(true);
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);
            return Result<bool>.Failure("Failed to create user");
        }
    }
}