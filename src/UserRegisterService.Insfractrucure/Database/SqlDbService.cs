using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserRegisterService.Insfractrucure.Database_Configurations;

namespace UserRegisterService.Insfractrucure.Database;

public static class SqlDbService
{
  public static IServiceCollection DabaseService(this IServiceCollection service, IConfiguration configuration)
  {
    var connectionString = "";
    service.AddDbContext<RegistrationServiceDbContext>(options => options.UseSqlServer(connectionString));
    return service;
  }
}