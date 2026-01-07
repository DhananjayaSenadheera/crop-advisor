using UserRegisterService.Domain.Entities;

namespace UserRegisterService.Domain.Interfaces;

public interface IUserRepository
{
    Task<User> AddAsync(User user);
    Task<User> UpdateAsync(User user);
    Task<User> DeleteAsync(User user);
    Task <IEnumerable<User>> GetAll();
    Task<User> GetByIdAsync(Guid id);
    Task<User?> GetByUserNameAsync(string userName);
    Task<bool> ExistsByUsernameAsync(string userName);

}