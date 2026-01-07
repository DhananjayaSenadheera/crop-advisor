using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using UserRegisterService.Application.Helper;
using UserRegisterService.Application.Requests.User.DTOs;
using UserRegisterService.Domain.Interfaces;

namespace UserRegisterService.Application.Requests.User.Quaries.GetList;

public class UserGetAllQueryHandler(
    ILogger<UserGetAllQueryHandler> logger,
    IUserRepository userRepository,
    IMapper mapper)
    : IRequestHandler<UserGetAllQuery, Result<List<UserGetDto>>>
{
    private readonly ILogger<UserGetAllQueryHandler> _logger = logger;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IMapper _mapper = mapper;


    public async Task<Result<List<UserGetDto>>> Handle(UserGetAllQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var users = await _userRepository.GetAll();
            var result = _mapper.Map<List<UserGetDto>>(users);
            return await Task.FromResult(Result<List<UserGetDto>>.Success(result));

        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return Result<List<UserGetDto>>.Failure(e.Message);
            
        }
    }
}