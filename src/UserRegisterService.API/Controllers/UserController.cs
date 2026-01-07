using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserRegisterService.Application.Requests.User.Commands.Create;
using UserRegisterService.Application.Requests.User.Quaries.GetList;

namespace UserRegisterService.API.Controllers;

[ApiController]
[Route("api/users")]
public class UserController(IMediator mediator) : ControllerBase
{
  [HttpPost("register")]
  public async Task<IActionResult> Post([FromBody] UserCreateCommand usercreateCommand)
  {
      var result = await mediator.Send(usercreateCommand);
      if (result.IsSuccess)
        return StatusCode(statusCode: StatusCodes.Status201Created);
      
      return BadRequest(ToErrorResponse(result.Error));
  }

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    var result = await mediator.Send(new UserGetAllQuery());
    if (result.IsSuccess)
      return Ok(result.Data);
    
    return BadRequest(ToErrorResponse(result.Error));
  }

  [HttpPost("Login")]
  public async Task<IActionResult> Login([FromBody] UserLoginCommand command, CancellationToken cancellationToken)
  {
    var result = await mediator.Send(command, cancellationToken);
    if (result.IsSuccess)
      return Ok(result.Data);
    
    return BadRequest(ToErrorResponse(result.Error));
  }
  
  private static object ToErrorResponse(string error) => new
  {
    errors = new[]
    {
      new { property = "User", message = error }
    }
  };
}
