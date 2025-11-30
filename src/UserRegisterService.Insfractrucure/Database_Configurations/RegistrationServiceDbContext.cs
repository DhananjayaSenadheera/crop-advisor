using Microsoft.EntityFrameworkCore;
using UserRegisterService.Domain.Entities;

namespace UserRegisterService.Insfractrucure.Database_Configurations;

public class RegistrationServiceDbContext:DbContext
{
    public RegistrationServiceDbContext(DbContextOptions<RegistrationServiceDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    
}