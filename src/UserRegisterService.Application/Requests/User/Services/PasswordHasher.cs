using System.Security.Cryptography;

namespace UserRegisterService.Application.Requests.User.Services;

public class PasswordHasher :IPasswordHasher
{
    public string HashPassword(string password)
    {
        using var deriveBytes = new Rfc2898DeriveBytes(
            password,
            16,
            100_100,
            HashAlgorithmName.SHA256
        );

        var salt = deriveBytes.Salt;
        var key = deriveBytes.GetBytes(32);
        return $"{Convert.ToBase64String(salt)}:{Convert.ToBase64String(key)}";
    }
}