using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserRegisterService.Application.Requests.User.Commands.Create;

namespace UserRegisterService.API.Controllers;

[ApiController]
[Route("api/user")]
public class UserController(IMediator mediator) : ControllerBase
{
  [HttpPost("register")]
  public async Task<IActionResult> Post([FromBody] UserCreateCommand usercreateCommand)
  {
      var result = await mediator.Send(usercreateCommand);
      if (result.IsSuccess)
      {
        return StatusCode(statusCode: StatusCodes.Status201Created);
      }

      return BadRequest(new
      {
        errors = new[]
        {
          new { property = "General", message = result.Error }
        }
      });

    }
}
