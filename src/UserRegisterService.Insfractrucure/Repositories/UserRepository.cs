using UserRegisterService.Domain.Entities;
using UserRegisterService.Domain.Interfaces;

namespace UserRegisterService.Insfractrucure.Repositories;

public class UserRepository(IGenericRepository<User> userRepository) : IUserRepository
{
    public async Task<User> AddAsync(User user)
    { 
        await userRepository.AddAsync(user);
        return user;
    }

    public async Task<User> UpdateAsync(User user)
    {
         await userRepository.UpdateAsync(user);
         return user;
    }

    public async Task<User> DeleteAsync(User user)
    { 
        await userRepository.DeleteAsync(user);
        return user;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await userRepository.GetAllAsync();
        
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        return await userRepository.GetByIdAsync(id);
    }
    
}