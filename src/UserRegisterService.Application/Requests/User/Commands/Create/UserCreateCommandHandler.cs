using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using UserRegisterService.Application.Helper;
using UserRegisterService.Application.Requests.User.Services;
using UserRegisterService.Domain.Interfaces;

namespace UserRegisterService.Application.Requests.User.Commands.Create;

public class UserCreateCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper,
    ILogger<UserCreateCommandHandler> logger,
    IUserRepository userRepository,
    IPasswordHasher passwordHasher)
    
    : IRequestHandler<UserCreateCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(UserCreateCommand request, CancellationToken cancellationToken)
    {
        var dto = request.UserCreateDto;
        if (dto is null)
            return Result<bool>.Failure("User details are required.");
        //Exits users
        var exists = await userRepository.ExistsByUsernameAsync(dto.UserName);
        if (exists)
            return Result<bool>.Failure("User already exists.");
        
        var user = mapper.Map<Domain.Entities.User>(request.UserCreateDto);
        user.Id = Guid.NewGuid();
        user.Password = passwordHasher.HashPassword(dto.Password);
        await userRepository.AddAsync(user);
        await unitOfWork.CommitAsync();
        return Result<bool>.Success(true);
    }
}