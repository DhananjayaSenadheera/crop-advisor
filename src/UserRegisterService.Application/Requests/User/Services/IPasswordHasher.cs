namespace UserRegisterService.Application.Requests.User.Services;

public interface IPasswordHasher
{
    string HashPassword(string password);
    bool VerifyHashedPassword(string storedHash, string password);
}