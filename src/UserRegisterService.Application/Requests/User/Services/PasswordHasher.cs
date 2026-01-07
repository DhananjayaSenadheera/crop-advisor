using System.Security.Cryptography;

namespace UserRegisterService.Application.Requests.User.Services;

public class PasswordHasher :IPasswordHasher
{
    private const int SaltSize = 16;     // 128-bit
    private const int KeySize = 32;      // 256-bit
    private const int Iterations = 100_100;
    public string HashPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password cannot be empty.", nameof(password));
        
        var salt = RandomNumberGenerator.GetBytes(SaltSize);

        using var pbkdf2 = new Rfc2898DeriveBytes(
            password,
            salt,
            Iterations,
            HashAlgorithmName.SHA256
        );

        var key = pbkdf2.GetBytes(KeySize);
        return $"{Iterations}:{Convert.ToBase64String(salt)}:{Convert.ToBase64String(key)}";
    }

    public bool VerifyHashedPassword(string storedHash, string password)
    {
        if (string.IsNullOrWhiteSpace(storedHash) || string.IsNullOrWhiteSpace(password))
            return false;
        // Backward compatibility
        var parts = storedHash.Split(':');
        if (parts.Length == 2)
        {
            var salt = Convert.FromBase64String(parts[0]);
            var expectedKey = Convert.FromBase64String(parts[1]);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
            var actualKey = pbkdf2.GetBytes(expectedKey.Length);

            return CryptographicOperations.FixedTimeEquals(actualKey, expectedKey);
        }
        
        // New format
        if (parts.Length != 3) return false;

        if (!int.TryParse(parts[0], out var iterations)) return false;

        var saltNew = Convert.FromBase64String(parts[1]);
        var expectedKeyNew = Convert.FromBase64String(parts[2]);

        using var pbkdf2New = new Rfc2898DeriveBytes(password, saltNew, iterations, HashAlgorithmName.SHA256);
        var actualKeyNew = pbkdf2New.GetBytes(expectedKeyNew.Length);

        return CryptographicOperations.FixedTimeEquals(actualKeyNew, expectedKeyNew);
        
    }
}