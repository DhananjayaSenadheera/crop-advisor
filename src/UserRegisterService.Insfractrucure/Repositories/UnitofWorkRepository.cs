using UserRegisterService.Domain.Interfaces;
using UserRegisterService.Insfractrucure.Database_Configurations;

namespace UserRegisterService.Insfractrucure.Repositories;

public class UnitofWorkRepository(RegistrationServiceDbContext context) : IUnitOfWork
{
    public void Dispose()
    {
       context.Dispose();
    }

    public async Task CommitAsync()
    {
       await context.SaveChangesAsync();
    }
}