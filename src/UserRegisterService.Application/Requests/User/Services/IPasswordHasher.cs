namespace UserRegisterService.Application.Requests.User.Services;

public interface IPasswordHasher
{
    string HashPassword(string password);
}